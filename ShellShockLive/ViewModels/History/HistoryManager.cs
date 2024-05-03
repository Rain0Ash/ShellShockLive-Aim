// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using NetExtender.Types.Transactions;
using ShellShockLive.Models.Physics;
using ShellShockLive.Models.Physics.Guidances;
using ShellShockLive.Models.Sight.Interfaces;
using ShellShockLive.Models.Weapons.Interfaces;
using ShellShockLive.ViewModels.Guidance;
using ShellShockLive.ViewModels.History.Interfaces;
using ShellShockLive.ViewModels.Physics;
using ShellShockLive.ViewModels.Render;
using ShellShockLive.ViewModels.Weapons;

namespace ShellShockLive.ViewModels.History
{
    public sealed class HistoryManager
    {
        public HistoryCollection Past { get; } = new HistoryCollection();
        public HistoryCollection Future { get; } = new HistoryCollection();

        private static void Restore(HistoryEntry entry)
        {
            RenderManager.Instance.Sight.Sight.Set(entry.Sight);
            WeaponsViewModel.Instance.Weapon = entry.Weapon;
            PhysicsViewModel.Instance.Physics = entry.Physics;
            GuidanceViewModel.Instance.Set(entry.Guidance);
        }

        public IHistoryTransaction Transaction()
        {
            return new HistoryTransaction(this);
        }

        public Boolean Undo()
        {
            if (!Past.TryPop(out HistoryEntry entry))
            {
                return false;
            }

            Future.Save();
            Restore(entry);
            return true;
        }

        public Boolean Redo()
        {
            if (!Future.TryPop(out HistoryEntry entry))
            {
                return false;
            }
            
            Past.Save();
            Restore(entry);
            return true;
        }

        public void Clear()
        {
            Past.Clear();
            Future.Clear();
        }

        public sealed class HistoryCollection : IReadOnlyCollection<HistoryEntry>
        {
            private ConcurrentStack<HistoryEntry> History { get; } = new ConcurrentStack<HistoryEntry>();
            
            public HistoryEntry Snapshot
            {
                get
                {
                    ISight sight = (ISight) RenderManager.Instance.Sight.Sight.Clone();
                    IWeapon weapon = WeaponsViewModel.Instance.Weapon;
                    PhysicsInfo physics = PhysicsViewModel.Instance.Physics;
                    GuidanceSearchInfo? guidance = GuidanceViewModel.Instance.Guidance;
                    return new HistoryEntry(sight, weapon, physics, guidance, default);
                }
            }

            public Int32 Count
            {
                get
                {
                    return History.Count;
                }
            }

            public Boolean TryPeek(out HistoryEntry entry)
            {
                return History.TryPeek(out entry);
            }

            public Boolean TryPop(out HistoryEntry entry)
            {
                return History.TryPop(out entry);
            }
            
            public void Push(HistoryEntry entry)
            {
                History.Push(entry);
            }

            public HistoryEntry Save()
            {
                HistoryEntry entry = Snapshot;
                Push(entry);
                return entry;
            }

            public void Clear()
            {
                History.Clear();
            }

            public IEnumerator<HistoryEntry> GetEnumerator()
            {
                return History.GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }

        private sealed class HistoryTransaction : IHistoryTransaction
        {
            private HistoryManager Manager { get; }
            private HistoryEntry Entry { get; }
            public Boolean? IsCommit { get; private set; } = true;

            public TransactionCommitPolicy Policy
            {
                get
                {
                    return TransactionCommitPolicy.Required;
                }
            }

            public HistoryTransaction(HistoryManager manager)
            {
                Manager = manager ?? throw new ArgumentNullException(nameof(manager));
                Entry = manager.Past.Snapshot;
            }

            public Boolean Commit()
            {
                return true;
            }

            public Boolean Rollback()
            {
                IsCommit = false;
                return true;
            }

            public void Dispose()
            {
                if (IsCommit != true)
                {
                    return;
                }
                
                Manager.Past.Push(Entry);
                Manager.Future.Clear();
            }
        }
    }
}