// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using Ruler.Common;
using Ruler.Weapons;
using SharpDX;
using SharpDX.Direct2D1;
using SharpDX.Mathematics.Interop;

namespace Ruler
{
    internal class Trajectory : Surface, IDisposable
    {
        internal RawVector2 Coord;
        private RawVector2[] points = new RawVector2[0];
        private readonly SolidColorBrush paintBrush;
        private Weapon weapon;
        internal Trajectory(RawVector2 coord, ref RenderTarget renderTarget)
            : base(ref renderTarget)
        {
            Coord = coord;
            paintBrush = new SolidColorBrush(renderTarget, Color.Azure);
            EventsAndGlobalsController.ChangedSightPosition += newCoord =>
            {
                SetPosition(newCoord);
                CalculateTrajectory();
            };
            EventsAndGlobalsController.OffsetSightPosition += offsetCoord =>
            {
                OffsetPosition(offsetCoord);
                CalculateTrajectory();
            };
            EventsAndGlobalsController.ChangedAngle += _ => CalculateTrajectory();
            EventsAndGlobalsController.ChangedWind += _ => CalculateTrajectory();
            EventsAndGlobalsController.ChangedPower += _ => CalculateTrajectory();
            EventsAndGlobalsController.ChangedWeapon += ChangeWeapon;
            
        }
        
        private void OffsetPosition(RawVector2 offsetCoord)
        {
            Coord.X += offsetCoord.X;
            Coord.Y += offsetCoord.Y;
        }

        private void SetPosition(RawVector2 newCoord)
        {
            Coord = newCoord;
        }

        private void ChangeWeapon(Weapon newWeapon)
        {
            if (newWeapon.Guidance == weapon.Guidance && newWeapon.ShellOption == weapon.ShellOption)
            {
                return;
            }

            weapon = newWeapon;
            CalculateTrajectory();
        }

        private void CalculateTrajectory()
        {
            switch (weapon.Guidance)
            {
                case GuidanceType.Direct:
                    points = Guidance.Direct(Coord, weapon.ShellOption);
                    break;
                default:
                    points = Guidance.Parabola(Coord, weapon.ShellOption);
                    break;
            }
        }

        public override void Draw(ref RenderTarget renderTarget)
        {
            if (points.Length == 0)
            {
                CalculateTrajectory();
            }
            foreach (RawVector2 point in points)
            {
                renderTarget.FillEllipse(new Ellipse(point, 1f, 1f), paintBrush);
            }
        }

        void IDisposable.Dispose()
        {
            paintBrush.Dispose();
        }
    }
}
