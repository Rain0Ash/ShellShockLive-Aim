// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using ShellShockLive.Models.Environment.Interfaces;

namespace ShellShockLive.Models.Sight.Interfaces
{
    public interface ITrajectory : ISurface
    {
        public void Set(ITrajectory trajectory);
        public ITrajectory Clone(ISight sight);
    }
}