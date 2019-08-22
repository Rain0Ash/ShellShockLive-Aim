// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Drawing;
using Ruler.Properties;

namespace Ruler.Weapons
{
    internal enum WeaponShellOptionBitFlag
    {
        Common = 0,
        IgnoreWind = 1,
        IgnorePortal = 2,
        IgnoreBlackHoleGravitation = 4,
        IgnoreRebound = 8
    }
    internal struct Weapon
    {
        internal readonly String Name;
        internal readonly Int32 AvailabilityLevel;
        internal readonly Color Color;
        internal readonly Image Image;
        internal readonly GuidanceType Guidance;
        internal readonly WeaponShellOptionBitFlag ShellOption;
        internal Weapon(String name, Int32 availabilityLevel, GuidanceType guidanceType = GuidanceType.Parabola, Color? color = null, Image image = null, WeaponShellOptionBitFlag shellOption = WeaponShellOptionBitFlag.Common)
        {
            Name = name;
            AvailabilityLevel = availabilityLevel;
            Color = color ?? Color.DarkGray;
            Image = image ?? Resources._null;
            Guidance = guidanceType;
            ShellOption = shellOption;
        }

        public override String ToString()
        {
            return Name;
        }

        public override Boolean Equals(Object obj)
        {
            return obj is Weapon secondWeapon && Name == secondWeapon.Name && AvailabilityLevel == secondWeapon.AvailabilityLevel && Guidance == secondWeapon.Guidance;
        }
    }
}