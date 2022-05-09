// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using ShellShockLive.Models.Weapons.Shells.Interfaces;
using ShellShockLive.Models.Weapons.Stacks.Internal;

namespace ShellShockLive.Models.Weapons.Internal
{
    public abstract class VolcanoInternalWeapon<T> : InternalWeapon<T> where T : VolcanoInternalWeapon<T>, new()
    {
        public sealed override Byte Level
        {
            get
            {
                return 103;
            }
        }

        public sealed override IGuidanceShell Shell
        {
            get
            {
                return Shells.Shell.Parabola;
            }
        }
        
        public sealed override VolcanoWeaponStack Stack
        {
            get
            {
                return VolcanoWeaponStack.Instance;
            }
        }
    }
}