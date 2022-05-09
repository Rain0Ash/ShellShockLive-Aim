// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Drawing;
using NetExtender.Utilities.Numerics;
using NetExtender.Utilities.Types;
using ShellShockLive.Models.Physics.Guidances.Interfaces;
using ShellShockLive.Models.Sight.Interfaces;
using ShellShockLive.ViewModels.Environment;
using ShellShockLive.ViewModels.Weapons;

namespace ShellShockLive.ViewModels.Sight
{
    public class SightViewModel : SurfaceViewModel<ISight>
    {
        public ISight Sight { get; }
        public AimViewModel Aim { get; }
        public TrajectoryViewModel Trajectory { get; }
        public SearchPositionViewModel Search { get; }
        public SightInformationViewModel Information { get; }

        public override ISight Surface
        {
            get
            {
                return Sight;
            }
        }

        public override Byte Transparent
        {
            get
            {
                return 60;
            }
        }

        public virtual Single CenterPointRadius
        {
            get
            {
                return 4;
            }
        }
        
        public Boolean IsEmpty
        {
            get
            {
                return Equals(default, default);
            }
        }

        public SightViewModel()
            : this(null)
        {
        }

        public SightViewModel(ISight? sight)
            : this(sight, null, null, null, null)
        {
        }
        
        public SightViewModel(ISight? sight, AimViewModel? aim, TrajectoryViewModel? trajectory, SearchPositionViewModel? search, SightInformationViewModel? information)
        {
            IGuidanceInfo guidance = WeaponsViewModel.Instance.GuidanceInfo;
            Sight = sight ?? new Models.Sight.Sight { Center = guidance.Physics.Center, Radius = guidance.Physics.Binding.Length };

            aim ??= new AimViewModel(this);
            trajectory ??= new TrajectoryViewModel(this);
            search ??= new SearchPositionViewModel(this);
            information ??= new SightInformationViewModel(this);

            if (aim.Sight != Sight)
            {
                throw new ArgumentException(null, nameof(aim));
            }

            if (trajectory.Sight != Sight)
            {
                throw new ArgumentException(null, nameof(trajectory));
            }

            if (search.Sight != Sight)
            {
                throw new ArgumentException(null, nameof(search));
            }

            if (information.Sight != Sight)
            {
                throw new ArgumentException(null, nameof(trajectory));
            }

            Aim = aim;
            Trajectory = trajectory;
            Search = search;
            Information = information;
        }
        
        public virtual Boolean Equals(Point point)
        {
            return Sight.Center == point;
        }
        
        public virtual Boolean Equals(Point point, Single radius)
        {
            return Sight.Center == point && Math.Abs(Sight.Radius - radius) < Single.Epsilon;
        }

        public override void Draw(IGuidanceInfo guidance, Graphics graphics)
        {
            if (guidance is null)
            {
                throw new ArgumentNullException(nameof(guidance));
            }

            if (graphics is null)
            {
                throw new ArgumentNullException(nameof(graphics));
            }

            using Pen pen = new Pen(Color.Transparent);
            using Brush brush = new SolidBrush(Adapt(Color.Lime));
            graphics.FillCircle(brush, Sight.Center.X - CenterPointRadius, Sight.Center.Y - CenterPointRadius, 2 * CenterPointRadius);

            Int32 x = Sight.Center.X;
            Int32 y = Sight.Center.Y;
            Single radius = Sight.Radius;
            
            for (Int32 angle = 0; angle < 360; angle += 45)
            {
                pen.Color = SelectAngleColor(guidance, angle);

                Single degree = MathF.PI * angle / AngleUtilities.SingleDegree.Straight;
                Single sin = radius * MathF.Sin(degree) * 1.05F;
                Single cos = radius * MathF.Cos(degree) * 1.05F;
                
                graphics.DrawLine(pen, x, y, x + cos, y - sin);
            }
            
            for (Int32 circle = 25; circle <= 100; circle += 25)
            {
                pen.Color = SelectRangeColor(guidance, circle);

                Single range = Sight.Radius * circle / 100;
                Single rangeX2 = 2 * range;
                
                graphics.DrawEllipse(pen, x - range, y - range, rangeX2, rangeX2);
            }
            
            Aim.Draw(guidance, graphics);
            Trajectory.Draw(guidance, graphics);
            Search.Draw(guidance, graphics);
            Information.Draw(guidance, graphics);
        }

        protected virtual Color SelectAngleColor(IGuidanceInfo guidance, Int32 angle)
        {
            if (guidance is null)
            {
                throw new ArgumentNullException(nameof(guidance));
            }

            if (angle % 90 == 0)
            {
                return Adapt(Color.DarkRed);
            }

            if (angle % 60 == 0)
            {
                return Adapt(Color.Yellow);
            }
            
            if (angle % 45 == 0)
            {
                return angle < AngleUtilities.SingleDegree.Straight ? Adapt(Color.Aquamarine) : Adapt(Color.Blue);
            }
            
            if (angle % 30 == 0)
            {
                return Adapt(Color.GreenYellow);
            }
            
            if (angle % 15 == 0)
            {
                return angle < AngleUtilities.SingleDegree.Straight ? Adapt(Color.Orange) : Adapt(Color.Brown);
            }
            
            return Adapt(Color.DarkGray);
        }

        protected virtual Color SelectRangeColor(IGuidanceInfo guidance, Int32 range)
        {
            if (guidance is null)
            {
                throw new ArgumentNullException(nameof(guidance));
            }
            
            if (range % 100 == 0)
            {
               return Adapt(Color.LightCoral);
            }

            if (range % 75 == 0)
            {
                return Adapt(Color.LightGoldenrodYellow);
            }
            
            if (range % 50 == 0)
            {
                return Adapt(Color.LightGreen);
            }
            
            if (range % 25 == 0)
            {
                return Adapt(Color.LightSeaGreen);
            }
            
            return range % 10 == 0 ? Adapt(Color.DarkBlue) : Adapt(Color.DarkGray);
        }
    }
}