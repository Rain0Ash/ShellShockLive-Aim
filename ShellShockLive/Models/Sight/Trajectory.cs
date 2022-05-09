// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using ShellShockLive.Models.Environment;
using ShellShockLive.Models.Sight.Interfaces;

namespace ShellShockLive.Models.Sight
{
    public class Trajectory : Surface, ITrajectory
    {
        public override Boolean Interactive
        {
            get
            {
                return false;
            }
        }

        public ISight Sight { get; }

        public Trajectory(ISight sight)
        {
            Sight = sight ?? throw new ArgumentNullException(nameof(sight));
        }

        public virtual void Set(ITrajectory trajectory)
        {
        }

        public override Object Clone()
        {
            return Clone(Sight);
        }

        public virtual ITrajectory Clone(ISight sight)
        {
            if (sight is null)
            {
                throw new ArgumentNullException(nameof(sight));
            }

            return new Trajectory(sight);
        }
    }
}