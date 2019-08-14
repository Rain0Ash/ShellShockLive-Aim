// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Drawing;
using Ruler.Properties;

namespace Ruler.Weapons
{
    public struct Weapon
    {
        public readonly String Name;
        public readonly Byte AvailabilityLevel;
        public readonly Byte GroupID;
        public readonly Byte LevelInGroup;
        public readonly Color Color;
        public readonly Image Image;
        private readonly Func<Point, Point[]> guid;
        public Weapon(String name, Byte availabilityLevel, Byte groupID, Byte levelInGroup, Func<Point, Point[]> guidance = null, Color? color = null, Image image = null)
        {
            Name = name;
            AvailabilityLevel = availabilityLevel;
            GroupID = groupID;
            LevelInGroup = levelInGroup;
            Color = color ?? Color.DarkGray;
            Image = image ?? Resources._null;
            guid = guidance;
        }

        public override String ToString()
        {
            return Name;
        }

        public Point[] GetTrajectory(Point coord)
        {
            return guid?.Invoke(coord) ?? Guidance.Parabola(coord);
        }
    }
}