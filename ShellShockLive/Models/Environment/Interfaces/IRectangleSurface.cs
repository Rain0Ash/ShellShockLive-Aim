// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Drawing;

namespace ShellShockLive.Models.Environment.Interfaces
{
    public interface IRectangleSurface : ISurface
    {
        public Rectangle Rectangle { get; set; }
        public Double Rotation { get; set; }
    }
}