// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;

namespace ShellShockLive.Models.Weapons.Shells
{
    public class CustomShell : Shell
    {
        public static implicit operator CustomShell(Unsafe value)
        {
            return new CustomShell(value.ShellType, value.Wind, value.Gravitation, value.BlackHole);
        }
        
        public sealed override ShellType ShellType { get; }
        public sealed override Single Wind { get; }
        public sealed override Single Gravitation { get; }
        public sealed override Single BlackHole { get; }
        
        public CustomShell(ShellType type, Single wind, Single gravitation, Single blackhole)
        {
            ShellType = type;
            Wind = wind;
            Gravitation = gravitation;
            BlackHole = blackhole;
        }
    }
}