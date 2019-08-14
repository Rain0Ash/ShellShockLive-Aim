// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using SharpDX;
using SharpDX.Direct2D1;
using SharpDX.Mathematics.Interop;

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
            renderTarget.DrawEllipse(new Ellipse(new RawVector2(Coord.X, Coord.Y), Radius, Radius), new SolidColorBrush(renderTarget, new RawColor4(255, 0, 0, 255)));
        }
    }
}
