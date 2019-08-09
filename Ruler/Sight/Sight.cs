// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Drawing;
using System.Windows.Forms;
using Ruler.Common;
using SharpDX.Direct2D1;

namespace Ruler
{
    internal class Sight : Circle
    {
        private static readonly SolidBrush CenterPaintBrush = new SolidBrush(Color.FromArgb(15, 220, 15));
        internal Sight(Point coord, Single radius, ref RenderTarget renderTarget)
            : base(coord, radius, ref renderTarget)
        {
        }

        public override void Draw(ref RenderTarget renderTarget)
        {
            Int32 power = 50, angle = 50;
            //Pen pen;
            //TODO: Do power and angle;
            //Graphics.FillEllipse(CenterPaintBrush, Coord.X - 4, Coord.Y - 4, 8, 8);
            //for (Int32 circleAngle = 0; circleAngle < 360; circleAngle += 45)
            //{
            //    if (circleAngle % 90 == 0) pen = Pens.Red;
            //    else if (circleAngle % 60 == 0) pen = Pens.Yellow;
            //    else if (circleAngle % 45 == 0) pen = circleAngle < 180 ? Pens.Aquamarine : Pens.Blue;
            //    else if (circleAngle % 30 == 0) pen = Pens.GreenYellow;
            //    else if (circleAngle % 15 == 0) pen = circleAngle < 180 ? Pens.Orange : Pens.Brown;
            //    else pen = Pens.DarkGray;
            //    Single sin = Radius * (Single) Math.Sin(Math.PI * circleAngle / 180d) * 1.05f;
            //    Single cos = Radius * (Single) Math.Cos(Math.PI * circleAngle / 180d) * 1.05f;
            //    Graphics.DrawLine(pen, Coord.X, Coord.Y, Coord.X + cos, Coord.Y - sin);
            //}
            
            //for (Int32 circleRange = 25; circleRange <= 100; circleRange += 25)
            //{
            //    if (circleRange % 100 == 0) pen = Pens.LightCoral;
            //    else if (circleRange % 75 == 0) pen = Pens.LightGoldenrodYellow;
            //    else if (circleRange % 50 == 0) pen = Pens.LightGreen;
            //    else if (circleRange % 25 == 0) pen = Pens.LightSeaGreen;
            //    else if (circleRange % 10 == 0) pen = Pens.DarkBlue;
            //    else pen = Pens.DarkGray;
            //    Single pos = Radius * circleRange / 100f;
            //    Single range = Radius * 2f * circleRange / 100f;
            //    Graphics.DrawEllipse(pen, Coord.X - pos, Coord.Y - pos, 
            //        range, range);
            //}
        }
    }
}
