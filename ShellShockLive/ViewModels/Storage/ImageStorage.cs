// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using ShellShockLive.Models.Weapons.Interfaces;
using ShellShockLive.ViewModels.Weapons.Images;

namespace ShellShockLive.ViewModels
{
    public static partial class ImageStorage
    {
        public static WeaponImage? Get(IWeapon weapon)
        {
            if (weapon is null)
            {
                throw new ArgumentNullException(nameof(weapon));
            }

            return WeaponImages.Images.TryGetValue(weapon, out WeaponImage? image) ? image : null;
        }
    }
}