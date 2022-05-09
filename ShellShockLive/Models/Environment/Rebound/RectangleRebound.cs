// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using ShellShockLive.Models.Environment.Rebound.Interfaces;

namespace ShellShockLive.Models.Environment.Rebound
{
    public class RectangleRebound : RectangleSurface, IRectangleRebound
    {
        public override SurfaceType Type
        {
            get
            {
                return SurfaceType.Rebound;
            }
        }

        public override Boolean Interactive
        {
            get
            {
                return true;
            }
        }

        public override Object Clone()
        {
            return new RectangleRebound
            {
                Rectangle = Rectangle,
                Rotation = Rotation
            };
        }
    }
}