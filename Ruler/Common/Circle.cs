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
        public RawVector2 Coord;
        public Single Radius;

        protected Circle(RawVector2 coord, Single radius, ref RenderTarget renderTarget) :
            base(ref renderTarget)
        {
            Coord = coord;
            Radius = radius;
        }

        public virtual Boolean IsIntersect(RawVector2 point)
        {
            return IsIntersect(point, 0.5d);
        }
        
        public virtual Boolean IsIntersect(RawVector2 point, Double radiusModifier)
        {
            return Radius > 0.1 && 
                   Math.Sqrt(Math.Pow(Coord.X - point.X, 2) + Math.Pow(Coord.Y - point.Y, 2)) < Radius * radiusModifier;
        }
        
        public override void Draw(ref RenderTarget renderTarget)
        {
            renderTarget.DrawEllipse(new Ellipse(Coord, Radius, Radius), new SolidColorBrush(renderTarget, Color.Red));
        }
    }
}
