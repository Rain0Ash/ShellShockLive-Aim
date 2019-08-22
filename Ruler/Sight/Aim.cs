// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Drawing;
using Ruler.Common;

namespace Ruler
{
    internal class Aim : Circle, IDisposable
    {
        internal Int32 Power;
        internal Int32 Angle;
        internal Aim(Int32 power, Int32 angle, Point coord, Single radius)
            : base(coord, radius)
        {
            Angle = angle;
            Power = power;
            EventsAndGlobalsController.ChangedSightPosition += SetPosition;
            EventsAndGlobalsController.OffsetSightPosition += OffsetPosition;
            EventsAndGlobalsController.ChangedPower += parameter => Power = parameter;
            EventsAndGlobalsController.ChangedAngle += parameter => Angle = parameter;
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
        
        public override Boolean IsIntersect(Point point)
        {
            return false;
        }

        public override Boolean IsIntersect(Point point, Double radiusModifier)
        {
            return false;
        }

        public override void Draw(ref Graphics graphics)
        {
            graphics.DrawLine(Pens.Red, Coord.X, Coord.Y, Coord.X + Radius * (Single)Math.Cos(Math.PI * Angle / 180f) * Power / 100f, Coord.Y - Radius * (Single)Math.Sin(Math.PI * Angle / 180f) * Power / 100f);
        }

        void IDisposable.Dispose()
        {
        }
    }
}