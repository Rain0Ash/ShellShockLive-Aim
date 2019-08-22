// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Drawing;

namespace Ruler.Common
{
    public abstract class Circle : Surface
    {
        public Point Coord;
        public Single Radius;

        protected Circle(Point coord, Single radius)
        {
            Coord = coord;
            Radius = radius;
        }

        public virtual Boolean IsIntersect(Point point)
        {
            return IsIntersect(point, 0.5d);
        }
        
        public virtual Boolean IsIntersect(Point point, Double radiusModifier)
        {
            return Radius > 0.1 && 
                   Math.Sqrt(Math.Pow(Coord.X - point.X, 2) + Math.Pow(Coord.Y - point.Y, 2)) < Radius * radiusModifier;
        }
        
        public override void Draw(ref Graphics graphics)
        {
            
        }
    }
}
