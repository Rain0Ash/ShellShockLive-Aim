// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using ShellShockLive.Models.Weapons.Stacks.Internal;

namespace ShellShockLive.Models.Weapons.Internal
{
    public abstract class GuidanceInternalWeapon<T> : InternalWeapon<T> where T : GuidanceInternalWeapon<T>, new()
    {
        public sealed override Byte Level
        {
            get
            {
                return 0;
            }
        }
        
        public sealed override GuidanceWeaponStack Stack
        {
            get
            {
                return GuidanceWeaponStack.Instance;
            }
        }
    }
}