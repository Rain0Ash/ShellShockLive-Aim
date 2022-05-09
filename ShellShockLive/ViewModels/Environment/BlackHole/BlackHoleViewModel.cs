// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Drawing;
using NetExtender.Utilities.Types;
using ShellShockLive.Models.Environment.BlackHole.Interfaces;
using ShellShockLive.Models.Physics.Guidances.Interfaces;

namespace ShellShockLive.ViewModels.Environment.BlackHole
{
    public class BlackHoleViewModel : SurfaceViewModel<IBlackHole>
    {
        public IBlackHole BlackHole { get; }

        public override IBlackHole Surface
        {
            get
            {
                return BlackHole;
            }
        }

        public BlackHoleViewModel(IBlackHole? hole)
        {
            BlackHole = hole ?? throw new ArgumentNullException(nameof(hole));
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

            using Pen pen = new Pen(Adapt(Color.Black));
            
            Single radius = BlackHole.Radius;
            Single hole = BlackHole.Hole;
            graphics.DrawCircle(pen, BlackHole.Center.X - radius, BlackHole.Center.Y - radius, 2 * radius);
            pen.Color = Adapt(Color.Blue);
            graphics.DrawCircle(pen, BlackHole.Center.X - hole, BlackHole.Center.Y - hole, 2 * hole);
        }
    }
}