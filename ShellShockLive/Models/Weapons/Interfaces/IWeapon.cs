// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using ShellShockLive.Models.Weapons.Shells.Interfaces;
using ShellShockLive.Models.Weapons.Stacks;

namespace ShellShockLive.Models.Weapons.Interfaces
{
    public interface IWeapon : IGuidanceShell
    {
        public String Title { get; }
        public Byte Level { get; }
        public IShell Shell { get; }
        public WeaponStack? Stack { get; } 
    }
}