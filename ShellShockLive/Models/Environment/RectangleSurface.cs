// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Drawing;
using ReactiveUI.Fody.Helpers;
using ShellShockLive.Models.Environment.Interfaces;

namespace ShellShockLive.Models.Environment
{
    public abstract class RectangleSurface : Surface, IRectangleSurface
    {
        [Reactive]
        public Rectangle Rectangle { get; set; }

        [Reactive]
        public Double Rotation { get; set; }
    }
}