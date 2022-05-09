// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using ShellShockLive.Models.Physics.Guidances;

namespace ShellShockLive.Models.Weapons.Shells.Interfaces
{
    public interface IShell
    {
        public ShellType ShellType { get; }
        public GuidanceType? GuidanceType { get; }

        public Single Wind { get; }
        public Boolean IsWind { get; }

        public Single Gravitation { get; }
        public Boolean IsGravitation { get; }

        public Single BlackHole { get; }
        public Boolean IsBlackHole { get; }

        public Boolean IsPortal { get; }
        public Boolean IsRebound { get; }

        public Shell.Unsafe Unsafe();
    }
}