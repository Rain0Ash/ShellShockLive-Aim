// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;

namespace ShellShockLive.Models.Weapons.Shells
{
    [Flags]
    public enum ShellType
    {
        None = 0,
        Wind = 1,
        Gravitation = 2,
        BlackHole = 4,
        Portal = 8,
        Rebound = 16,
        Nature = Wind | Gravitation,
        Environment = BlackHole | Portal | Rebound,
        All = Nature | Environment
    }
}