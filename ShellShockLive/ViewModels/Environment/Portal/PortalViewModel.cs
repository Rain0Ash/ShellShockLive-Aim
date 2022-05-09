// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Drawing;
using NetExtender.Types.Exceptions;
using NetExtender.Utilities.Types;
using ShellShockLive.Models.Environment.Portal;
using ShellShockLive.Models.Environment.Portal.Interfaces;
using ShellShockLive.Models.Physics.Guidances.Interfaces;

namespace ShellShockLive.ViewModels.Environment.Damage
{
    public class PortalViewModel : SurfaceViewModel<IPortal>
    {
        public IPortal Portal { get; }
        
        public override IPortal Surface
        {
            get
            {
                return Portal;
            }
        }

        public PortalViewModel(PortalType type)
        {
            Portal = new Portal(type);
        }

        public PortalViewModel(IPortal portal)
        {
            Portal = portal ?? throw new ArgumentNullException(nameof(portal));
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
            using Brush brush = new SolidBrush(Adapt(Color.Black));
            using Pen pen = Portal.PortalType switch
            {
                PortalType.None => new Pen(Adapt(Color.LimeGreen)),
                PortalType.Input => new Pen(Adapt(Color.Blue)),
                PortalType.Output => new Pen(Adapt(Color.OrangeRed)),
                _ => throw new EnumUndefinedOrNotSupportedException<PortalType>(Portal.PortalType, nameof(Portal.PortalType), null)
            };

            Single radius = Portal.Radius;
            graphics.FillCircle(brush, Portal.Center.X - radius, Portal.Center.Y - radius, 2 * radius);
            graphics.DrawCircle(pen, Portal.Center.X - radius, Portal.Center.Y - radius, 2 * radius);
        }
    }
}