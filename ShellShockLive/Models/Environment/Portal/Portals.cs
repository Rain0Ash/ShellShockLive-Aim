// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Drawing;
using ShellShockLive.Models.Environment.Portal.Interfaces;

namespace ShellShockLive.Models.Environment.Portal
{
    public class Portals : Surface, IPortals
    {
        public override SurfaceType Type
        {
            get
            {
                return SurfaceType.Portal;
            }
        }
        
        public override Boolean Interactive
        {
            get
            {
                return true;
            }
        }
        
        public IPortal Input { get; }
        public IPortal Output { get; }

        public Portals()
        {
            Input = new Portal(PortalType.Input);
            Output = new Portal(PortalType.Output);
        }

        public Portals(IPortal input, IPortal output)
        {
            Input = input ?? throw new ArgumentNullException(nameof(input));
            Output = output ?? throw new ArgumentNullException(nameof(output));
        }

        public override Boolean Intersect(Point point)
        {
            return Input.Intersect(point) || Output.Intersect(point);
        }
        
        public override Object Clone()
        {
            return new Portals((IPortal) Input.Clone(), (IPortal) Output.Clone());
        }
    }
}