using System;
using System.Drawing;
using Ruler.Properties;

namespace Ruler.Weapons
{

    public struct WeaponSpecifications
    {
        public readonly Byte AvailabilityLevel;
        public readonly Byte GroupID;
        public readonly Byte LevelInGroup;

        public WeaponSpecifications(Byte availabilityLevel, Byte groupID, Byte levelInGroup)
        {
            AvailabilityLevel = availabilityLevel;
            GroupID = groupID;
            LevelInGroup = levelInGroup;
        }
    }
    public struct Weapon
    {
        public readonly String Name;
        public readonly WeaponSpecifications WeaponSpecifications;
        public readonly Color Color;
        public readonly Image Image;
        private readonly Func<Point, Point[]> guid;
        public Weapon(String name, WeaponSpecifications weaponSpecifications, Func<Point, Point[]> guidance = null, Color? color = null, Image image = null)
        {
            Name = name;
            WeaponSpecifications = weaponSpecifications;
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