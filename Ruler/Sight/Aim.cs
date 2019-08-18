// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using Ruler.Common;
using SharpDX;
using SharpDX.Direct2D1;
using SharpDX.Mathematics.Interop;

namespace Ruler
{
    internal class Aim : Circle
    {
        internal Int32 Power;
        internal Int32 Angle;
        private readonly SolidColorBrush paintBrush;
        internal Aim(Int32 power, Int32 angle, RawVector2 coord, Single radius, ref RenderTarget renderTarget)
            : base(coord, radius, ref renderTarget)
        {
            paintBrush = new SolidColorBrush(renderTarget, Color.Red);
            Angle = angle;
            Power = power;
            EventsAndGlobalsController.ChangedSightPosition += SetPosition;
            EventsAndGlobalsController.ChangedPower += parameter => Power = parameter;
            EventsAndGlobalsController.ChangedAngle += parameter => Angle = parameter;
        }

        private void SetPosition(RawVector2 newCoord)
        {
            Coord = newCoord;
        }
        
        public override Boolean IsIntersect(RawVector2 point)
        {
            return false;
        }

        public override Boolean IsIntersect(RawVector2 point, Double radiusModifier)
        {
            return false;
        }

        public override void Draw(ref RenderTarget renderTarget)
        {
            renderTarget.DrawLine(Coord, 
                new RawVector2(Coord.X + Radius * (Single)Math.Cos(Math.PI * Angle / 180f) * Power / 100f, 
                Coord.Y - Radius * (Single)Math.Sin(Math.PI * Angle / 180f) * Power / 100f), paintBrush);
        }
    }
}