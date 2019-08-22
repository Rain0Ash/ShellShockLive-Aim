// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Drawing;
using Ruler.Common;
namespace Ruler
{
    internal class Sight : Circle, IDisposable
    {
        private const Single CenterPointRadius = 4;
        private static Aim _aim;
        private readonly Pen paintPen;
        internal Sight(Point coord, Single radius)
            : base(coord, radius)
        {
            paintPen = new Pen(Color.Gray);
            _aim = new Aim(EventsAndGlobalsController.Power, EventsAndGlobalsController.Angle, coord, radius);
            EventsAndGlobalsController.ChangedSightPosition += SetPosition;
            EventsAndGlobalsController.OffsetSightPosition += OffsetPosition;
        }

        private void OffsetPosition(Point offsetCoord)
        {
            Coord.X += offsetCoord.X;
            Coord.Y += offsetCoord.Y;
        }
        private void SetPosition(Point newCoord)
        {
            Coord = newCoord;
        }
        
        public override void Draw(ref Graphics graphics)
        {
            paintPen.Color = Color.Lime;
            graphics.FillEllipse(Brushes.Lime, Coord.X - CenterPointRadius, Coord.Y - CenterPointRadius, 2*CenterPointRadius, 2*CenterPointRadius);
            for (Int32 circleAngle = 0; circleAngle < 360; circleAngle += 45)
            {
                if (circleAngle % 90 == 0) paintPen.Color = Color.DarkRed;
                else if (circleAngle % 60 == 0) paintPen.Color = Color.Yellow;
                else if (circleAngle % 45 == 0) paintPen.Color = circleAngle < 180 ? Color.Aquamarine : Color.Blue;
                else if (circleAngle % 30 == 0) paintPen.Color = Color.GreenYellow;
                else if (circleAngle % 15 == 0) paintPen.Color = circleAngle < 180 ? Color.Orange : Color.Brown;
                else paintPen.Color = Color.DarkGray;
                Single sin = Radius * (Single) Math.Sin(Math.PI * circleAngle / 180d) * 1.05f;
                Single cos = Radius * (Single) Math.Cos(Math.PI * circleAngle / 180d) * 1.05f;
                graphics.DrawLine(paintPen, Coord.X, Coord.Y, Coord.X + cos, Coord.Y - sin);
            }
            
            for (Int32 circleRange = 25; circleRange <= 100; circleRange += 25)
            {
                if (circleRange % 100 == 0) paintPen.Color = Color.LightCoral;
                else if (circleRange % 75 == 0) paintPen.Color = Color.LightGoldenrodYellow;
                else if (circleRange % 50 == 0) paintPen.Color = Color.LightGreen;
                else if (circleRange % 25 == 0) paintPen.Color = Color.LightSeaGreen;
                else if (circleRange % 10 == 0) paintPen.Color = Color.DarkBlue;
                else paintPen.Color = Color.DarkGray;
                Single range = Radius * circleRange / 100f;
                graphics.DrawEllipse(paintPen, Coord.X - range, Coord.Y - range, 2 * range, 2 * range);
            }
            _aim.Draw(ref graphics);
        }

        void IDisposable.Dispose()
        {
            paintPen.Dispose();
        }
    }
}
