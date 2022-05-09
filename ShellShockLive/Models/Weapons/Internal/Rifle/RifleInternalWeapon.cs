// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using ShellShockLive.Models.Weapons.Shells.Interfaces;
using ShellShockLive.Models.Weapons.Stacks.Internal;

namespace ShellShockLive.Models.Weapons.Internal
{
    public abstract class RifleInternalWeapon<T> : InternalWeapon<T> where T : RifleInternalWeapon<T>, new()
    {
        public sealed override Byte Level
        {
            get
            {
                return 65;
            }
        }

        public sealed override IGuidanceShell Shell
        {
            get
            {
                return Shells.Shell.Direct;
            }
        }
        
        public sealed override RifleWeaponStack Stack
        {
            get
            {
                return RifleWeaponStack.Instance;
            }
        }
    }
}