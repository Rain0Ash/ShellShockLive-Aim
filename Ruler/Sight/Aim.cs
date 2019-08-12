using System;
using SharpDX;
using Ruler.Common;
using SharpDX.Direct2D1;

namespace Ruler
{
    internal class Aim : Circle
    {
        internal Int32 Angle;

        internal Int32 Power;

        internal Aim(Int32 power, Int32 angle, Point coord, Single radius, ref RenderTarget renderTarget)
            : base(coord, radius, ref renderTarget)
        {
            Angle = angle;
            Power = power;
        }

        public override Boolean IsIntersect(Point point)
        {
            return false;
        }

        public override Boolean IsIntersect(Point point, Double radiusModifier)
        {
            return false;
        }

        public override void Draw(ref RenderTarget renderTarget)
        {
            //TODO: renderTarget.DrawLine(LinePaintPen, Coord.X, Coord.Y, Coord.X + Radius * (Single)Math.Cos(Math.PI * Angle / 180f) * Power / 100f, Coord.Y - Radius * (Single)Math.Sin(Math.PI * Angle / 180f) * Power / 100f);
        }
    }
}