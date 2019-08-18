// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using Ruler.Common;
using SharpDX.Direct2D1;
using SharpDX.Mathematics.Interop;

namespace Ruler
{
    internal class Trajectory : Surface
    {
        internal RawVector2 Coord;
        private RawVector2[] points = new RawVector2[0];
        //private static readonly SolidBrush PointPaintBrush = new SolidBrush(Color.Red);
        internal Trajectory(RawVector2 coord, ref RenderTarget renderTarget)
            : base(ref renderTarget)
        {
            Coord = coord;
        }

        public override void Draw(ref RenderTarget renderTarget)
        {
            for (Int32 i = 0; i < points.Length; i++)
            {
                //Graphics.FillEllipse(PointPaintBrush, point.X, point.Y, 2f, 2f);
            }
        }
    }
}
