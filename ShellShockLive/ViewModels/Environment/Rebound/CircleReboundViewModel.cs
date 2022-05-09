// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Drawing;
using NetExtender.Utilities.Types;
using ShellShockLive.Models.Environment.Rebound;
using ShellShockLive.Models.Environment.Rebound.Interfaces;
using ShellShockLive.Models.Physics.Guidances.Interfaces;

namespace ShellShockLive.ViewModels.Environment.Rebound
{
    public class CircleReboundViewModel : ReboundViewModel<ICircleRebound>
    {
        public ICircleRebound Rebound { get; }
        
        public override ICircleRebound Surface
        {
            get
            {
                return Rebound;
            }
        }

        public CircleReboundViewModel(ICircleRebound? rebound)
        {
            Rebound = rebound ?? new CircleRebound();
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

            using Pen pen = new Pen(Adapt(Color.Fuchsia));
            Single radius = Rebound.Radius;
            graphics.DrawCircle(pen, Rebound.Center.X - radius, Rebound.Center.Y - radius, 2 * radius);
        }
    }
}