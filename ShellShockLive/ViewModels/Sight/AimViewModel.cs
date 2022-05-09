// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Drawing;
using NetExtender.Types.Exceptions;
using NetExtender.Utilities.Numerics;
using ShellShockLive.Models.Physics.Guidances.Interfaces;
using ShellShockLive.Models.Sight.Interfaces;
using ShellShockLive.ViewModels.Environment;

namespace ShellShockLive.ViewModels.Sight
{
    public class AimViewModel : SurfaceViewModel<IAim>
    {
        protected SightViewModel? Model { get; }

        public virtual ISight Sight
        {
            get
            {
                return Model?.Sight ?? throw new NotInitializedException(null, nameof(Model));
            }
        }

        public IAim Aim
        {
            get
            {
                return Sight.Aim;
            }
        }

        public override IAim Surface
        {
            get
            {
                return Aim;
            }
        }
        
        public override Byte Transparent
        {
            get
            {
                return Model?.Transparent ?? base.Transparent;
            }
        }
        
        protected AimViewModel()
        {
        }

        public AimViewModel(SightViewModel model)
        {
            Model = model ?? throw new ArgumentNullException(nameof(model));
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

            Point center = Sight.Center;
            Single range = Aim.Range(guidance.Physics);
            Single rangeX2 = 2 * range;
            Single angle = guidance.Physics.Angle;
            Single degree = angle.ToRadians();

            using Pen pen = new Pen(Color.Transparent);

            pen.Color = Adapt(Color.Red);
            graphics.DrawLine(pen, center.X, center.Y, center.X + range * MathF.Cos(degree), center.Y - range * MathF.Sin(degree));

            pen.Color = Adapt(Color.Black);
            graphics.DrawEllipse(pen, center.X - range, center.Y - range, rangeX2, rangeX2);
        }
    }
}