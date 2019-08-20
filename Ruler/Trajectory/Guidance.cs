// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Windows.Forms;
using Ruler.Common;
using Ruler.Weapons;
using SharpDX.Direct3D11;
using SharpDX.Mathematics.Interop;

namespace Ruler
{
    internal enum GuidanceType
    {
        Parabola,
        Direct
    }
    
    internal static class Guidance
    {
        private static readonly Parameters Parameters = Parameter.GetParameters($"{EventsAndGlobalsController.CurrentMonitor.Resolution.Width}x{EventsAndGlobalsController.CurrentMonitor.Resolution.Height}") ;
        internal static RawVector2[] Parabola(RawVector2 coord, WeaponShellOptionBitFlag shellOption)
        {
            const Single maxCount = 60;
            const Single step = 0.05f;
            Double floatAngle = EventsAndGlobalsController.Angle * (Math.PI / 180.0);
            Single floatAngleSin = Convert.ToInt16(Parameters.Radius * Math.Sin(floatAngle));
            Single floatAngleCos = Convert.ToInt16(Parameters.Radius * Math.Cos(floatAngle));
            RawVector2[] points = new RawVector2[(Int32)(maxCount/step)];
            Single x = coord.X;
            Single y = coord.Y;
            RawVector2 point = new RawVector2(0, 0);
            for (Single counter = 0f; counter < maxCount; counter += step)
            {
                point.X = Convert.ToInt32(x +
                                          (EventsAndGlobalsController.Power * Parameters.Velocity * counter * Math.Cos(floatAngle)) +
                                          (0.5 * EventsAndGlobalsController.Wind * Parameters.WindW * counter * counter));
                point.Y = Convert.ToInt32(y -
                                          (EventsAndGlobalsController.Power * Parameters.Velocity * counter * Math.Sin(floatAngle)) +
                                          (0.5 * Parameters.Gravity * counter * counter));
                if (point.Y <= (Double)(EventsAndGlobalsController.CurrentMonitor.Resolution.Height - Parameters.PointHeight))
                {
                    points[(Int32)(counter/step)] = new RawVector2((Int32)(point.X + (Double)floatAngleCos - 1.0), (Int32)(point.Y - (Double)floatAngleSin - 1.0));
                }
            }

            return points;
        }

        internal static RawVector2[] Direct(RawVector2 coord, WeaponShellOptionBitFlag shellOption)
        {
            return new RawVector2[]{};
        }
    }
}
