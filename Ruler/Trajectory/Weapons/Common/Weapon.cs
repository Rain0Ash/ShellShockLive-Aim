using System;
using System.Drawing;

namespace Ruler.Weapons
{
    public struct Weapon
    {
        public readonly String Name;
        public readonly Int32 Level;
        public readonly Point Group;
        public readonly Color Color;
        public readonly Image Image;
        private readonly Func<Point, Point[]> guid;
        public Weapon(String name, Int32 level = 0, Point? group = null, Func<Point, Point[]> guidance = null, Color? color = null, Image image = null)
        {
            Name = name;
            Level = level;
            Group = group ?? new Point(-1, -1);
            Color = color ?? Color.DarkGray;
            Image = image;
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