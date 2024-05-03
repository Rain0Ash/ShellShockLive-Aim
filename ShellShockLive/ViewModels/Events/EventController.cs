// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using NetExtender.Types.HotKeys;
using NetExtender.Types.HotKeys.Comparer;
using NetExtender.Types.HotKeys.Comparer.Interfaces;
using NetExtender.Types.Transactions;
using NetExtender.Types.Transactions.Interfaces;
using NetExtender.Utilities.Types;
using ShellShockLive.Utilities.ViewModels.History;
using ShellShockLive.ViewModels.Commands;
using ShellShockLive.ViewModels.History;
using ShellShockLive.ViewModels.Render;

namespace ShellShockLive.ViewModels.Events
{
    public class EventController
    {
        public CommandController Controller { get; }
        private ImmutableDictionary<HotKeyAction, Command> Actions { get; }

        public HotKeyAction[] HotKeys
        {
            get
            {
                return Actions.Keys.ToArray();
            }
        }

        public EventController()
            : this(null)
        {
        }

        public EventController(CommandController? controller)
        {
            Controller = controller ?? new CommandController();
            IHotKeyActionComparer<HotKeyAction> comparer = new HotKeyActionComparer<HotKeyAction> { Title = false };

            Actions = new Dictionary<HotKeyAction, Command>(comparer)
            {
                { new HotKeyAction(Key.Oem3, ModifierKeys.Control), new Command(ChangeWeaponMenuState, Time.Millisecond.Hundred) },
                { new HotKeyAction(Key.Oem3, ModifierKeys.Control | ModifierKeys.Shift), new Command(ChangeWeaponMenuState, Time.Millisecond.Hundred) },
                
                { new HotKeyAction(Key.E, ModifierKeys.Control), new Command(SetSightToPosition) },
                { new HotKeyAction(Key.E, ModifierKeys.Control | ModifierKeys.Shift), new Command(SetSightToPosition) },
                
                { new HotKeyAction(Key.C, ModifierKeys.Control | ModifierKeys.Shift), new Command(SetInformationOfPlayer, Time.Second.One) },
                { new HotKeyAction(Key.V, ModifierKeys.Control | ModifierKeys.Shift), new Command(SetSightOfPlayer, Time.Second.Three) },

                { new HotKeyAction(Key.W, ModifierKeys.Control), new Command(OffsetSightPositionToUp) },
                { new HotKeyAction(Key.W, ModifierKeys.Control | ModifierKeys.Shift), new Command(LargeOffsetSightPositionToUp) },
                { new HotKeyAction(Key.A, ModifierKeys.Control), new Command(OffsetSightPositionToLeft) },
                { new HotKeyAction(Key.A, ModifierKeys.Control | ModifierKeys.Shift), new Command(LargeOffsetSightPositionToLeft) },
                { new HotKeyAction(Key.S, ModifierKeys.Control), new Command(OffsetSightPositionToDown) },
                { new HotKeyAction(Key.S, ModifierKeys.Control | ModifierKeys.Shift), new Command(LargeOffsetSightPositionToDown) },
                { new HotKeyAction(Key.D, ModifierKeys.Control), new Command(OffsetSightPositionToRight) },
                { new HotKeyAction(Key.D, ModifierKeys.Control | ModifierKeys.Shift), new Command(LargeOffsetSightPositionToRight) },
                
                { new HotKeyAction(Key.Right, ModifierKeys.Control), new Command(IncreaseAngle) },
                { new HotKeyAction(Key.Right, ModifierKeys.Control | ModifierKeys.Shift), new Command(LargeIncreaseAngle) },
                { new HotKeyAction(Key.Left, ModifierKeys.Control), new Command(DecreaseAngle) },
                { new HotKeyAction(Key.Left, ModifierKeys.Control | ModifierKeys.Shift), new Command(LargeDecreaseAngle) },
                
                { new HotKeyAction(Key.Right, ModifierKeys.Control | ModifierKeys.Alt), new Command(IncreaseWind) },
                { new HotKeyAction(Key.Right, ModifierKeys.Control | ModifierKeys.Alt | ModifierKeys.Shift), new Command(LargeIncreaseWind) },
                { new HotKeyAction(Key.Left, ModifierKeys.Control | ModifierKeys.Alt), new Command(DecreaseWind) },
                { new HotKeyAction(Key.Left, ModifierKeys.Control | ModifierKeys.Alt | ModifierKeys.Shift), new Command(LargeDecreaseWind) },
                
                { new HotKeyAction(Key.Up, ModifierKeys.Control), new Command(IncreasePower) },
                { new HotKeyAction(Key.Up, ModifierKeys.Control | ModifierKeys.Shift), new Command(LargeIncreasePower) },
                { new HotKeyAction(Key.Down, ModifierKeys.Control), new Command(DecreasePower) },
                { new HotKeyAction(Key.Down, ModifierKeys.Control | ModifierKeys.Shift), new Command(LargeDecreasePower) },
                
                { new HotKeyAction(Key.F, ModifierKeys.Control), new Command(FindAllSightGuidance, Time.Second.Quarter) },
                { new HotKeyAction(Key.F, ModifierKeys.Control | ModifierKeys.Shift), new Command(FindSightGuidance, Time.Second.Quarter) },
                
                { new HotKeyAction(Key.F, ModifierKeys.Control | ModifierKeys.Shift | ModifierKeys.Alt), new Command(ResetSightGuidance) },
                { new HotKeyAction(Key.X, ModifierKeys.Control | ModifierKeys.Shift), new Command(ResetSightGuidance) },
                
                { new HotKeyAction(Key.Add), new Command(NextTrajectory) },
                { new HotKeyAction(Key.Subtract), new Command(PreviousTrajectory) },
                { new HotKeyAction(Key.Add, ModifierKeys.Control), new Command(NextTrajectory) },
                { new HotKeyAction(Key.Multiply, ModifierKeys.Control), new Command(MiddleTrajectory) },
                { new HotKeyAction(Key.Subtract, ModifierKeys.Control), new Command(PreviousTrajectory) },
                { new HotKeyAction(Key.Add, ModifierKeys.Control | ModifierKeys.Shift), new Command(LowestTrajectory) },
                { new HotKeyAction(Key.Multiply, ModifierKeys.Control | ModifierKeys.Shift), new Command(MiddleTrajectory) },
                { new HotKeyAction(Key.Subtract, ModifierKeys.Control | ModifierKeys.Shift), new Command(HighestTrajectory) },

                { new HotKeyAction(Key.M, ModifierKeys.Control), new Command(ChangeGuidanceType, Time.Millisecond.Fifty) },
                { new HotKeyAction(Key.M, ModifierKeys.Control | ModifierKeys.Shift), new Command(ChangeGuidanceType, Time.Millisecond.Fifty) },
                
                { new HotKeyAction(Key.Z, ModifierKeys.Control | ModifierKeys.Shift), new Command(UndoAction) { IsHistory = false } },
                { new HotKeyAction(Key.Y, ModifierKeys.Control | ModifierKeys.Shift), new Command(RedoAction) { IsHistory = false } },

                { new HotKeyAction(Key.Home, ModifierKeys.Control | ModifierKeys.Shift), new Command(MakeScreenshot) { IsHistory = false, IsRender = false } }
            }.ToImmutableDictionary(comparer);
        }

        public virtual async Task<Boolean> HandleAsync(HotKeyAction<Int32> hotkey)
        {
            if (!Actions.TryGetValue(hotkey, out Command? command))
            {
                throw new InvalidOperationException("Unregistered action: " + command);
            }

            using ITransaction? transaction = command.Transaction();
            if (await command.Invoke(hotkey).ConfigureAwait(false))
            {
                return true;
            }

            transaction?.Rollback();
            return false;
        }

        protected virtual ValueTask<Boolean> ChangeWeaponMenuState(Key key, ModifierKeys modifier)
        {
            return Controller.ChangeWeaponMenuState();
        }

        protected virtual ValueTask<Boolean> SetSightToPosition(Key key, ModifierKeys modifier)
        {
            return Controller.SetSightToPosition();
        }

        protected virtual ValueTask<Boolean> SetSightOfPlayer(Key key, ModifierKeys modifier)
        {
            return Controller.SetSightOfPlayer();
        }

        protected virtual ValueTask<Boolean> SetInformationOfPlayer(Key key, ModifierKeys modifier)
        {
            return Controller.SetInformationOfPlayer();
        }

        protected virtual ValueTask<Boolean> OffsetSightPositionToUp(Key key, ModifierKeys modifier)
        {
            return Controller.OffsetSightPositionToUp();
        }

        protected virtual ValueTask<Boolean> LargeOffsetSightPositionToUp(Key key, ModifierKeys modifier)
        {
            return Controller.LargeOffsetSightPositionToUp();
        }

        protected virtual ValueTask<Boolean> OffsetSightPositionToLeft(Key key, ModifierKeys modifier)
        {
            return Controller.OffsetSightPositionToLeft();
        }

        protected virtual ValueTask<Boolean> LargeOffsetSightPositionToLeft(Key key, ModifierKeys modifier)
        {
            return Controller.LargeOffsetSightPositionToLeft();
        }

        protected virtual ValueTask<Boolean> OffsetSightPositionToDown(Key key, ModifierKeys modifier)
        {
            return Controller.OffsetSightPositionToDown();
        }

        protected virtual ValueTask<Boolean> LargeOffsetSightPositionToDown(Key key, ModifierKeys modifier)
        {
            return Controller.LargeOffsetSightPositionToDown();
        }

        protected virtual ValueTask<Boolean> OffsetSightPositionToRight(Key key, ModifierKeys modifier)
        {
            return Controller.OffsetSightPositionToRight();
        }

        protected virtual ValueTask<Boolean> LargeOffsetSightPositionToRight(Key key, ModifierKeys modifier)
        {
            return Controller.LargeOffsetSightPositionToRight();
        }

        protected virtual ValueTask<Boolean> IncreaseAngle(Key key, ModifierKeys modifier)
        {
            return Controller.IncreaseAngle();
        }
        
        protected virtual ValueTask<Boolean> LargeIncreaseAngle(Key key, ModifierKeys modifier)
        {
            return Controller.LargeIncreaseAngle();
        }
        
        protected virtual ValueTask<Boolean> DecreaseAngle(Key key, ModifierKeys modifier)
        {
            return Controller.DecreaseAngle();
        }
        
        protected virtual ValueTask<Boolean> LargeDecreaseAngle(Key key, ModifierKeys modifier)
        {
            return Controller.LargeDecreaseAngle();
        }
        
        protected virtual ValueTask<Boolean> IncreaseWind(Key key, ModifierKeys modifier)
        {
            return Controller.IncreaseWind();
        }
        
        protected virtual ValueTask<Boolean> LargeIncreaseWind(Key key, ModifierKeys modifier)
        {
            return Controller.LargeIncreaseWind();
        }
        
        protected virtual ValueTask<Boolean> DecreaseWind(Key key, ModifierKeys modifier)
        {
            return Controller.DecreaseWind();
        }
        
        protected virtual ValueTask<Boolean> LargeDecreaseWind(Key key, ModifierKeys modifier)
        {
            return Controller.LargeDecreaseWind();
        }
        
        protected virtual ValueTask<Boolean> IncreasePower(Key key, ModifierKeys modifier)
        {
            return Controller.IncreasePower();
        }
        
        protected virtual ValueTask<Boolean> LargeIncreasePower(Key key, ModifierKeys modifier)
        {
            return Controller.LargeIncreasePower();
        }
        
        protected virtual ValueTask<Boolean> DecreasePower(Key key, ModifierKeys modifier)
        {
            return Controller.DecreasePower();
        }
        
        protected virtual ValueTask<Boolean> LargeDecreasePower(Key key, ModifierKeys modifier)
        {
            return Controller.LargeIncreasePower();
        }

        protected virtual ValueTask<Boolean> FindAllSightGuidance(Key key, ModifierKeys modifier)
        {
            return Controller.FindAllSightGuidance();
        }

        protected virtual ValueTask<Boolean> FindSightGuidance(Key key, ModifierKeys modifier)
        {
            return Controller.FindSightGuidance();
        }

        protected virtual ValueTask<Boolean> ResetSightGuidance(Key key, ModifierKeys modifier)
        {
            return Controller.ResetSightGuidance();
        }

        protected virtual ValueTask<Boolean> NextTrajectory(Key key, ModifierKeys modifier)
        {
            return Controller.NextTrajectory();
        }

        protected virtual ValueTask<Boolean> PreviousTrajectory(Key key, ModifierKeys modifier)
        {
            return Controller.PreviousTrajectory();
        }

        protected virtual ValueTask<Boolean> HighestTrajectory(Key key, ModifierKeys modifier)
        {
            return Controller.HighestTrajectory();
        }

        protected virtual ValueTask<Boolean> MiddleTrajectory(Key key, ModifierKeys modifier)
        {
            return Controller.MiddleTrajectory();
        }

        protected virtual ValueTask<Boolean> LowestTrajectory(Key key, ModifierKeys modifier)
        {
            return Controller.LowestTrajectory();
        }

        protected virtual ValueTask<Boolean> ChangeGuidanceType(Key key, ModifierKeys modifier)
        {
            return Controller.ChangeGuidanceType();
        }

        protected virtual ValueTask<Boolean> UndoAction(Key key, ModifierKeys modifier)
        {
            return Controller.UndoAction();
        }

        protected virtual ValueTask<Boolean> RedoAction(Key key, ModifierKeys modifier)
        {
            return Controller.RedoAction();
        }

        protected virtual ValueTask<Boolean> MakeScreenshot(Key key, ModifierKeys modifier)
        {
            return Controller.MakeScreenshot();
        }

        private record Command
        {
            [return: NotNullIfNotNull("value")]
            public static implicit operator Command?(Func<Key, ModifierKeys, ValueTask<Boolean>>? value)
            {
                return value is not null ? new Command(value) : null;
            }
            
            [return: NotNullIfNotNull("value")]
            public static implicit operator Func<Key, ModifierKeys, ValueTask<Boolean>>?(Command? value)
            {
                return value?.Action;
            }
            
            public static implicit operator TimeSpan(Command? value)
            {
                return value?.Timeout ?? default;
            }
            
            public static implicit operator DateTime(Command? value)
            {
                return value?.At ?? default;
            }

            public Func<Key, ModifierKeys, ValueTask<Boolean>> Action { get; }
            public TimeSpan Timeout { get; }
            public DateTime At { get; private set; }
            public Boolean IsHistory { get; init; } = true;
            public Boolean IsRender { get; init; } = true;

            public Command(Func<Key, ModifierKeys, ValueTask<Boolean>> command)
                : this(command, TimeSpan.Zero)
            {
            }

            public Command(Func<Key, ModifierKeys, ValueTask<Boolean>> command, TimeSpan timeout)
            {
                Action = command ?? throw new ArgumentNullException(nameof(command));
                Timeout = timeout;
            }

            public async ValueTask<Boolean> Invoke(HotKeyAction hotkey)
            {
                if (DateTime.UtcNow - At < Timeout)
                {
                    return false;
                }

                At = DateTime.UtcNow;
                Boolean result = await Action.Invoke(hotkey, hotkey).ConfigureAwait(false);
                At = DateTime.UtcNow;
                return result;
            }

            public ITransaction? Transaction()
            {
                return IsHistory switch
                {
                    true when IsRender => HistoryViewModel.Instance.Manager.Transaction().Render(),
                    true => HistoryViewModel.Instance.Manager.Transaction(),
                    false when IsRender => new RenderTransaction(),
                    false => null
                };
            }

            private sealed class RenderTransaction : ITransaction
            {
                public Boolean? IsCommit { get; private set; } = true;

                public TransactionCommitPolicy Policy
                {
                    get
                    {
                        return TransactionCommitPolicy.Manual;
                    }
                }

                public Boolean Commit()
                {
                    IsCommit = true;
                    return true;
                }

                public Boolean Rollback()
                {
                    IsCommit = false;
                    return true;
                }

                public void Dispose()
                {
                    if (IsCommit == true)
                    {
                        RenderViewModel.Instance.Render();
                    }
                }
            }
        }
    }
}