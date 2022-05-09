// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using ShellShockLive.Models.Environment;
using ShellShockLive.Models.Physics;
using ShellShockLive.Models.Physics.Guidances;
using ShellShockLive.Models.Sight.Interfaces;
using ShellShockLive.Models.Weapons.Interfaces;

namespace ShellShockLive.ViewModels.History
{
    public readonly struct HistoryEntry
    {
        private static Int32 Identifier { get; set; }
        
        public ISight Sight { get; }
        public IWeapon Weapon { get; }
        public PhysicsInfo Physics { get; }
        public GuidanceSearchInfo? Guidance { get; }
        public EnvironmentInfo? Environment { get; }

        public Boolean IsEmpty
        {
            get
            {
                return Sight is null;
            }
        }

        public HistoryEntry(ISight sight, IWeapon weapon, PhysicsInfo physics, GuidanceSearchInfo? guidance, EnvironmentInfo? environment)
        {
            Sight = sight ?? throw new ArgumentNullException(nameof(sight));
            Weapon = weapon ?? throw new ArgumentNullException(nameof(weapon));
            Physics = physics;
            Guidance = guidance;
            Environment = environment;
        }
    }
}