// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using ShellShockLive.Models.Environment.Interfaces;
using ShellShockLive.Models.Physics;

namespace ShellShockLive.Models.Sight.Interfaces
{
    public interface ISightInformation : ISurface
    {
        public ISight Sight { get; }
        public PhysicsInfo Physics { get; }
        
        public void Set(ISightInformation information);
        public ISightInformation Clone(ISight sight);
    }
}