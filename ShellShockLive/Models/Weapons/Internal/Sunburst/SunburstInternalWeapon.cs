// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using ShellShockLive.Models.Weapons.Shells.Interfaces;
using ShellShockLive.Models.Weapons.Stacks.Internal;

namespace ShellShockLive.Models.Weapons.Internal
{
    public abstract class SunburstInternalWeapon<T> : InternalWeapon<T> where T : SunburstInternalWeapon<T>, new()
    {
        public sealed override Byte Level
        {
            get
            {
                return 48;
            }
        }

        public sealed override IGuidanceShell Shell
        {
            get
            {
                return Shells.Shell.Parabola;
            }
        }
        
        public sealed override SunburstWeaponStack Stack
        {
            get
            {
                return SunburstWeaponStack.Instance;
            }
        }
    }
}