// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Drawing;
using Ruler.Properties;

namespace Ruler.Weapons
{
    internal struct Weapon
    {
        internal readonly String Name;
        internal readonly Byte AvailabilityLevel;
        internal readonly Color Color;
        internal readonly Image Image;
        internal readonly GuidanceType guidance;
        internal Weapon(String name, Byte availabilityLevel, GuidanceType guidanceType = GuidanceType.Parabola, Color? color = null, Image image = null)
        {
            Name = name;
            AvailabilityLevel = availabilityLevel;
            Color = color ?? Color.DarkGray;
            Image = image ?? Resources._null;
            guidance = guidanceType;
        }

        public override String ToString()
        {
            return Name;
        }

        internal Point[] GetTrajectory(Point coord)
        {
            //TODO:
            return Guidance.Parabola(coord);
        }
    }
}