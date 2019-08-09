using System;
using System.Drawing;
using System.Windows.Forms;
using SharpDX.Direct2D1;

namespace Ruler.Common
{
    public abstract class Circle : Surface
    {
        public Point Coord;
        public Single Radius;
        public Color Color = Color.Gray;

        protected Circle(Point coord, Single radius, ref RenderTarget renderTarget) :
            base(ref renderTarget)
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
                   (Math.Sqrt(Math.Pow(Coord.X - point.X, 2) + Math.Pow(Coord.Y - point.Y, 2)) < Radius * radiusModifier);
        }
        
        public override void Draw(ref RenderTarget renderTarget)
        {
            
        }
    }
}
