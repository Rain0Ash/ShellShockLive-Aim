// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using ShellShockLive.Models.Physics.Guidances.Interfaces;
using ShellShockLive.Models.Weapons.Shells.Interfaces;
using ShellShockLive.Models.Weapons.Stacks;

namespace ShellShockLive.Models.Weapons.Internal
{
    public abstract class InternalWeapon<T> : Weapon where T : InternalWeapon<T>, new()
    {
        private static Lazy<T> Internal { get; } = new Lazy<T>(() => new T(), true);

        public static T Instance
        {
            get
            {
                return Internal.Value;
            }
        }
        
        public abstract override WeaponStack Stack { get; }

        public abstract override IGuidanceShell Shell { get; }

        public sealed override IGuidance Guidance
        {
            get
            {
                return Shell;
            }
        }
    }
}