// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Drawing;

namespace ShellShockLive.Models.Environment.Interfaces
{
    public interface ISurface : ICloneable
    {
        public SurfaceType Type { get; }
        public Boolean Interactive { get; }

        public Boolean Intersect(Point point);
        public Surface.Unsafe Unsafe();
    }
}