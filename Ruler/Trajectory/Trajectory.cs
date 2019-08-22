// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Collections.Generic;
using System.Drawing;
using Ruler.Common;
using Ruler.Weapons;

namespace Ruler
{
    internal class Trajectory : Surface, IDisposable
    {
        internal Point Coord;
        private List<Point> points = new List<Point>();
        private Weapon weapon;
        internal Trajectory(Point coord)
        {
            Coord = coord;
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
        
        private void OffsetPosition(Point offsetCoord)
        {
            Coord.X += offsetCoord.X;
            Coord.Y += offsetCoord.Y;
        }

        private void SetPosition(Point newCoord)
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

        public override void Draw(ref Graphics graphics)
        {
            if (points.Count == 0)
            {
                CalculateTrajectory();
            }
            foreach (Point point in points)
            {
                graphics.FillEllipse(Brushes.Azure, point.X - 1, point.Y - 1, 2, 2);
                //renderTarget.FillEllipse(new Ellipse(point, 1f, 1f), paintBrush);
            }
        }

        void IDisposable.Dispose()
        {
        }
    }
}
