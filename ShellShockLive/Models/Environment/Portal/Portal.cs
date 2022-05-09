// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using ShellShockLive.Models.Environment.Portal.Interfaces;

namespace ShellShockLive.Models.Environment.Portal
{
    public class Portal : CircleSurface, IPortal
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

        public PortalType PortalType { get; }

        public Portal(PortalType type)
        {
            PortalType = type;
        }

        public override Object Clone()
        {
            return new Portal(PortalType)
            {
                Center = Center,
                Radius = Radius
            };
        }
    }
}