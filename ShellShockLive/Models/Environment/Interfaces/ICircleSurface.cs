// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Drawing;

namespace ShellShockLive.Models.Environment.Interfaces
{
    public interface ICircleSurface : ISurface
    {
        public Point Center { get; set; }
        public Single Radius { get; set; }

        public Boolean Equals(Point point);
        public Boolean Equals(Point point, Single radius);
    }
}