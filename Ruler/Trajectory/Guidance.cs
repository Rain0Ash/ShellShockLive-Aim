// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Collections.Generic;
using System.Drawing;
using Ruler.Common;
using Ruler.Weapons;

namespace Ruler
{
    internal enum GuidanceType
    {
        Parabola,
        Direct
    }
    
    internal static class Guidance
    {
        private const Single MaxCount = 60;
        internal static List<Point> Parabola(Point coord, WeaponShellOptionBitFlag shellOption)
        {
            const Single step = 0.05f;
            Double floatAngle = EventsAndGlobalsController.Angle * (Math.PI / 180);
            Single floatAngleSin = Convert.ToInt16(EventsAndGlobalsController.Parameters.Radius * Math.Sin(floatAngle));
            Single floatAngleCos = Convert.ToInt16(EventsAndGlobalsController.Parameters.Radius * Math.Cos(floatAngle));
            List<Point> points = new List<Point>();
            PointF point = new PointF(0, 0);
            for (Single counter = 0; counter < MaxCount; counter += step)
            {
                point.X = (Single)(coord.X +
                                          EventsAndGlobalsController.Power * EventsAndGlobalsController.Parameters.Velocity * counter * Math.Cos(floatAngle) +
                                          0.50 * EventsAndGlobalsController.Wind * EventsAndGlobalsController.Parameters.WindW * counter * counter);
                point.Y = (Single)(coord.Y -
                                          EventsAndGlobalsController.Power * EventsAndGlobalsController.Parameters.Velocity * counter * Math.Sin(floatAngle) +
                                          0.50 * EventsAndGlobalsController.Parameters.Gravity * counter * counter);
                if (point.Y <= EventsAndGlobalsController.CurrentMonitor.Resolution.Height - EventsAndGlobalsController.Parameters.PointHeight)
                {
                    points.Add(new Point((Int32)(point.X + floatAngleCos - 1.0), (Int32)(point.Y - floatAngleSin - 1.0)));
                }
            }

            return points;
        }

        internal static List<Point> Direct(Point coord, WeaponShellOptionBitFlag shellOption)
        {
            const Single step = 0.03f;
            List<Point> points = new List<Point>();
            for (Single counter = 0; counter < MaxCount; counter += step)
            {
                points.Add(new Point(
                    (Int32)(coord.X + EventsAndGlobalsController.Parameters.Length * Math.Cos(Math.PI * EventsAndGlobalsController.Angle / 180f) * counter),
                    (Int32)(coord.Y - EventsAndGlobalsController.Parameters.Length * Math.Sin(Math.PI * EventsAndGlobalsController.Angle / 180f) * counter)));
            }

            return points;
        }
    }
}
