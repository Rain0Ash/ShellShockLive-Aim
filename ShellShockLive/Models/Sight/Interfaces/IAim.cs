// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using ShellShockLive.Models.Environment.Interfaces;
using ShellShockLive.Models.Physics;

namespace ShellShockLive.Models.Sight.Interfaces
{
    public interface IAim : ISurface
    {
        public ISight Sight { get; }
        
        public Single Range(PhysicsInfo physics);
        public void Set(IAim aim);
        public IAim Clone(ISight sight);
    }
}