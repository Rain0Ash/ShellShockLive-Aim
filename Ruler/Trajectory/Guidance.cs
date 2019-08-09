// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Data;
using System.Drawing;
using Ruler.Weapons;

namespace Ruler
{
    public enum AvGuidance
    {
        Parabola,
        Direct
    }
    
    internal class Guidance
    {
        internal Point Coord;
        internal Weapon Weapon;
        internal Guidance(Point coord)
        {
            Coord = coord;
        }

        /*
        internal Point[] Evaluate()
        {
            if (Weapon.)
        }

        internal Point[] Parabola()
        {
            point.X = Convert.ToInt32((Double) _x + 
                                      ((Double) power * velocity * (Double) counter * Math.Cos(floatAngle)) +
                                      (0.5 * (Double) wind * windw * (Double) counter * (Double) counter));
            point.Y = Convert.ToInt32((Double) _y -
                                      ((Double) power * velocity * (Double) counter * Math.Sin(floatAngle)) +
                                      (0.5 * gravity * (Double) counter * (Double) counter));
            if ((Double)point.Y <= (Double)(Height - ph))
            {
                Graphics.FillEllipse((Brush)brush, (Single)((Double)point.X + (Double)floatAngleCos - 1.0), (Single)((Double)point.Y - (Double)floatAngleSin - 1.0), 2f, 2f);
            }
            counter += 0.05f;
        }
        

        internal Point[] Direct()
        {
            
        }
        */



    }
}
