// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Drawing;
using NetExtender.Utilities.Types;
using ShellShockLive.Models.Environment.Damage;
using ShellShockLive.Models.Environment.Interfaces;
using ShellShockLive.Models.Physics.Guidances.Interfaces;

namespace ShellShockLive.ViewModels.Environment.Damage
{
    public class DamageX2ViewModel : SurfaceViewModel<ICircleSurface>
    {
        public ICircleSurface Damage { get; }
        
        public override ICircleSurface Surface
        {
            get
            {
                return Damage;
            }
        }

        public DamageX2ViewModel(ICircleSurface? damage)
        {
            Damage = damage ?? new DamageX2();
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

            using Font font = new Font(FontFamily.GenericSansSerif, 20f, FontStyle.Regular, GraphicsUnit.Pixel, 204);
            using Brush brush = new SolidBrush(Adapt(Color.Red));
            
            Single radius = Damage.Radius;
            graphics.FillCircle(brush, Damage.Center.X - radius, Damage.Center.Y - radius, 2 * radius);
            graphics.DrawString("X2", font, Brushes.Azure, Damage.Center, ContentAlignment.MiddleCenter);
        }
    }
}