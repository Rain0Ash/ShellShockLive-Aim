// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;

namespace ShellShockLive.ViewModels.Vision
{
    [Flags]
    public enum VisionType
    {
        None = 0,
        Player = 1,
        Weapon = 2,
        Wind = 4,
        Fuel = 8,
        Light = Weapon | Wind | Fuel,
        Heavy = Player,
        All = Light | Heavy
    }
}