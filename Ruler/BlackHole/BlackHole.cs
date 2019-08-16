// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using SharpDX;
using Ruler.Common;
using SharpDX.Direct2D1;
using SharpDX.Mathematics.Interop;

namespace Ruler
{
    internal class BlackHole : Circle
    {
        internal BlackHole(RawVector2 point, Single radius, ref RenderTarget renderTarget)
            : base(point, radius, ref renderTarget)
        {
        }

        internal Boolean IsIntersectGravityRadius(RawVector2 point)
        {
            return base.IsIntersect(point, 2);
        }

        public override void Draw(ref RenderTarget renderTarget)
        {
            //Graphics.DrawEllipse(Pens.DarkBlue, Coord.X - Radius / 2, Coord.Y - Radius / 2, Radius, Radius);
            //Graphics.DrawEllipse(Pens.BlueViolet, Coord.X - Radius * 2, Coord.Y - Radius * 2, Radius * 4, Radius * 4);
        }
    }
}
