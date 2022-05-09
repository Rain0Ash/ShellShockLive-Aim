// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using ShellShockLive.Models.Environment.BlackHole.Interfaces;

namespace ShellShockLive.Models.Environment.BlackHole
{
    public class BlackHole : CircleSurface, IBlackHole
    {
        public override SurfaceType Type
        {
            get
            {
                return SurfaceType.BlackHole;
            }
        }

        public override Boolean Interactive
        {
            get
            {
                return true;
            }
        }

        public Single Gravity { get; }
        public Single Hole { get; }
        
        public BlackHole(Single gravity, Single hole)
        {
            Gravity = gravity;
            Hole = hole;
        }
        
        public override Object Clone()
        {
            return new BlackHole(Gravity, Hole)
            {
                Center = Center,
                Radius = Radius
            };
        }
    }
}