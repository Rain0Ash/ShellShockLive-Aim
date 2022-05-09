// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Drawing;
using NetExtender.Types.Exceptions;
using NetExtender.Utilities.Types;
using ShellShockLive.Models.Physics.Guidances.Interfaces;
using ShellShockLive.Models.Sight;
using ShellShockLive.Models.Sight.Interfaces;
using ShellShockLive.ViewModels.Environment;

namespace ShellShockLive.ViewModels.Sight
{
    public class TrajectoryViewModel : SurfaceViewModel<ITrajectory>
    {
        protected SightViewModel? Model { get; }

        public virtual ISight Sight
        {
            get
            {
                return Model?.Sight ?? throw new NotInitializedException(null, nameof(Model));
            }
        }

        public ITrajectory Trajectory
        {
            get
            {
                return Sight.Trajectory;
            }
        }
        
        public override ITrajectory Surface
        {
            get
            {
                return Trajectory;
            }
        }

        public override Byte Transparent
        {
            get
            {
                return Model?.Transparent ?? base.Transparent;
            }
        }

        protected TrajectoryViewModel()
        {
        }
        
        public TrajectoryViewModel(SightViewModel model)
        {
            Model = model ?? throw new ArgumentNullException(nameof(model));
        }

        public override void Draw(IGuidanceInfo guidance, Graphics graphics)
        {
            if (graphics is null)
            {
                throw new ArgumentNullException(nameof(graphics));
            }

            foreach (TrajectoryPoint point in guidance.Evaluate(Sight.Center, default))
            {
                graphics.FillCircle(Brushes.DarkGray, point.X - 1, point.Y - 1, 2);
            }
        }
    }
}