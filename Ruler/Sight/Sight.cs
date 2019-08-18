// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using Ruler.Common;
using SharpDX;
using SharpDX.Direct2D1;
using SharpDX.Mathematics.Interop;
namespace Ruler
{
    internal class Sight : Circle
    {
        private const Single CenterPointRadius = 4;
        private static Aim _aim;
        private readonly SolidColorBrush paintBrush;
        internal Sight(RawVector2 coord, Single radius, ref RenderTarget renderTarget)
            : base(coord, radius, ref renderTarget)
        {
            paintBrush = new SolidColorBrush(renderTarget, Color.Gray);
            _aim = new Aim(EventsAndGlobalsController.Power, EventsAndGlobalsController.Angle, coord, radius, ref renderTarget);
            EventsAndGlobalsController.ChangedSightPosition += SetPosition;
        }

        private void SetPosition()
        {
            Coord = Utils.GetCursorPosition(ref RenderTarget);
        }        
        
        private void SetPosition(RawVector2 newCoord)
        {
            Coord = newCoord;
        }
        
        public override void Draw(ref RenderTarget renderTarget)
        {
            paintBrush.Color = Color.Lime;
            renderTarget.FillEllipse(new Ellipse(Coord, 
                CenterPointRadius,CenterPointRadius), paintBrush);
            
            for (Int32 circleAngle = 0; circleAngle < 360; circleAngle += 45)
            {
                if (circleAngle % 90 == 0) paintBrush.Color = Color.DarkRed;
                else if (circleAngle % 60 == 0) paintBrush.Color = Color.Yellow;
                else if (circleAngle % 45 == 0) paintBrush.Color = circleAngle < 180 ? Color.Aquamarine : Color.Blue;
                else if (circleAngle % 30 == 0) paintBrush.Color = Color.GreenYellow;
                else if (circleAngle % 15 == 0) paintBrush.Color = circleAngle < 180 ? Color.Orange : Color.Brown;
                else paintBrush.Color = Color.DarkGray;
                Single sin = Radius * (Single) Math.Sin(Math.PI * circleAngle / 180d) * 1.05f;
                Single cos = Radius * (Single) Math.Cos(Math.PI * circleAngle / 180d) * 1.05f;
                renderTarget.DrawLine(Coord, new RawVector2(Coord.X + cos, Coord.Y - sin), paintBrush);
            }
            
            for (Int32 circleRange = 25; circleRange <= 100; circleRange += 25)
            {
                if (circleRange % 100 == 0) paintBrush.Color = Color.LightCoral;
                else if (circleRange % 75 == 0) paintBrush.Color = Color.LightGoldenrodYellow;
                else if (circleRange % 50 == 0) paintBrush.Color = Color.LightGreen;
                else if (circleRange % 25 == 0) paintBrush.Color = Color.LightSeaGreen;
                else if (circleRange % 10 == 0) paintBrush.Color = Color.DarkBlue;
                else paintBrush.Color = Color.DarkGray;
                Single range = Radius * circleRange / 100f;
                renderTarget.DrawEllipse(new Ellipse(new RawVector2(Coord.X, Coord.Y), range, range), paintBrush);
            }
            _aim.Draw();
        }
    }
}
