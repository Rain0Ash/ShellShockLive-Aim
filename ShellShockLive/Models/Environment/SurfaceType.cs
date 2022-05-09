// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;

namespace ShellShockLive.Models.Environment
{
    public enum SurfaceType : Byte
    {
        None,
        DamageX3,
        DamageX2,
        WeaponBox,
        Portal,
        BlackHole,
        Rebound,
        LifeBox
    }
}