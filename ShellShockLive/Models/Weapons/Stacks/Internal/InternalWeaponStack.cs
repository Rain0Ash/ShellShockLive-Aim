// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using ShellShockLive.Models.Weapons.Interfaces;

namespace ShellShockLive.Models.Weapons.Stacks.Internal
{
    public abstract class InternalWeaponStack<T> : WeaponStack where T : InternalWeaponStack<T>, new()
    {
        private static Lazy<T> Internal { get; } = new Lazy<T>(() => new T(), true);

        public static T Instance
        {
            get
            {
                return Internal.Value;
            }
        }

        protected InternalWeaponStack(params IWeapon[] weapons)
            : base(weapons)
        {
        }
    }
}