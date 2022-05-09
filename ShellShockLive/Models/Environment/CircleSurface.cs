// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Drawing;
using ReactiveUI.Fody.Helpers;
using ShellShockLive.Models.Environment.Interfaces;

namespace ShellShockLive.Models.Environment
{
    public abstract class CircleSurface : Surface, ICircleSurface
    {
        [Reactive]
        public Point Center { get; set; }
        
        [Reactive]
        public Single Radius { get; set; }
        
        public virtual Boolean Equals(Point point)
        {
            return Center == point;
        }

        public virtual Boolean Equals(Point point, Single radius)
        {
            return Center == point && Math.Abs(Radius - radius) < Single.Epsilon;
        }
    }
}