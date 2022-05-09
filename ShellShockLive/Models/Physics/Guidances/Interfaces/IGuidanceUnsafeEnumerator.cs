// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Collections.Generic;
using ShellShockLive.Models.Sight;

namespace ShellShockLive.Models.Physics.Guidances.Interfaces
{
    public interface IGuidanceUnsafeEnumerator : IEnumerator<TrajectoryPoint>, IEnumerable<TrajectoryPoint>
    {
        public Int32 Size { get; }
    }
}