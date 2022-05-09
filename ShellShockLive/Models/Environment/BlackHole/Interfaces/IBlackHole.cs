// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using ShellShockLive.Models.Environment.Interfaces;

namespace ShellShockLive.Models.Environment.BlackHole.Interfaces
{
    public interface IBlackHole : ICircleSurface
    {
        public Single Gravity { get; }
        public Single Hole { get; }
    }
}