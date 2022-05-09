// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using NetExtender.Utilities.Types;
using ShellShockLive.Models.Weapons.Interfaces;

namespace ShellShockLive.Models.Weapons.Stacks
{
    public class WeaponStack : IReadOnlyList<IWeapon>
    {
        protected ImmutableArray<IWeapon> Weapons { get; }
        public Byte? Level { get; }

        public Int32 Count
        {
            get
            {
                return Weapons.Length;
            }
        }

        public WeaponStack(params IWeapon[] weapons)
        {
            if (weapons is null)
            {
                throw new ArgumentNullException(nameof(weapons));
            }

            Weapons = weapons.ToImmutableArray();
            Level = Weapons.AllSame(weapon => weapon.Level) ? Weapons.FirstOrDefault()?.Level : default;
        }

        public ImmutableArray<IWeapon>.Enumerator GetEnumerator()
        {
            return Weapons.GetEnumerator();
        }

        IEnumerator<IWeapon> IEnumerable<IWeapon>.GetEnumerator()
        {
            // ReSharper disable once ForeachCanBeConvertedToQueryUsingAnotherGetEnumerator
            foreach (IWeapon weapon in Weapons)
            {
                yield return weapon;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<IWeapon>) this).GetEnumerator();
        }

        public IWeapon this[Int32 index]
        {
            get
            {
                return Weapons[index];
            }
        }
    }
}