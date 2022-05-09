// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using ShellShockLive.Models.Environment.Interfaces;

namespace ShellShockLive.Models.Sight.Interfaces
{
    public interface ISight : ICircleSurface
    {
        public IAim Aim { get; }
        public ITrajectory Trajectory { get; }
        public ISearchPosition Search { get; }
        public ISightInformation Information { get; }

        public void Set(ISight sight);
    }
}