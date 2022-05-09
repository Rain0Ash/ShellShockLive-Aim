// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Drawing;
using ShellShockLive.Models.Environment.Interfaces;
using ShellShockLive.Models.Physics.Guidances.Interfaces;

namespace ShellShockLive.ViewModels.Environment.Interfaces
{
    public interface ISurfaceViewModel<out T> : ISurfaceViewModel where T : ISurface
    {
        public new T Surface { get; }
    }
    
    public interface ISurfaceViewModel
    {
        public ISurface Surface { get; }
        public Byte Transparent { get; }
        public void Draw(IGuidanceInfo guidance, Graphics graphics);
    }
}