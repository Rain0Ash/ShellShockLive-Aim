// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Drawing;
using ShellShockLive.Models.Environment.Portal;
using ShellShockLive.Models.Environment.Portal.Interfaces;
using ShellShockLive.Models.Physics.Guidances.Interfaces;

namespace ShellShockLive.ViewModels.Environment.Damage
{
    public class PortalsViewModel : SurfaceViewModel<IPortals>
    {
        public IPortals Portals { get; }
        
        public override IPortals Surface
        {
            get
            {
                return Portals;
            }
        }
        
        public PortalViewModel Input { get; }
        public PortalViewModel Output { get; }

        public PortalsViewModel()
            : this(null)
        {
        }

        public PortalsViewModel(IPortals? portals)
        {
            Portals = portals ?? new Portals();
            Input = new PortalViewModel(Portals.Input);
            Output = new PortalViewModel(Portals.Output);
        }

        public PortalsViewModel(IPortal? input, IPortal? output)
        {
            Portals = new Portals(input ?? new Portal(PortalType.Input), output ?? new Portal(PortalType.Output));
            Input = new PortalViewModel(Portals.Input);
            Output = new PortalViewModel(Portals.Output);
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

            Input.Draw(guidance, graphics);
            Output.Draw(guidance, graphics);
        }
    }
}