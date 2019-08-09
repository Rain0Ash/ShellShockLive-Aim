// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Drawing;
using System.Windows.Forms;
using Ruler.Common;
using SharpDX.Direct2D1;

namespace Ruler
{
    internal class Trajectory : Surface
    {
        internal Point Coord;
        private Point[] points;
        private static readonly SolidBrush PointPaintBrush = new SolidBrush(Color.Red);
        internal Trajectory(Point coord, ref RenderTarget renderTarget)
            : base(ref renderTarget)
        {
            Coord = coord;
        }

        internal void Draw(ref RenderTarget renderTarget)
        {
            foreach (Point point in points)
            {
                //Graphics.FillEllipse(PointPaintBrush, point.X, point.Y, 2f, 2f);
            }
        }
    }
}
