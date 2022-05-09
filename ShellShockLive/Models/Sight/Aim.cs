// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using ShellShockLive.Models.Environment;
using ShellShockLive.Models.Physics;
using ShellShockLive.Models.Sight.Interfaces;

namespace ShellShockLive.Models.Sight
{
    public class Aim : Surface, IAim
    {
        public override Boolean Interactive
        {
            get
            {
                return false;
            }
        }

        public ISight Sight { get; }

        public Aim(ISight sight)
        {
            Sight = sight ?? throw new ArgumentNullException(nameof(sight));
        }
        
        public Single Range(PhysicsInfo physics)
        {
            return Sight.Radius * physics.Power * 0.01F;
        }

        public virtual void Set(IAim aim)
        {
        }

        public override Object Clone()
        {
            return Clone(Sight);
        }
        
        public virtual IAim Clone(ISight sight)
        {
            if (sight is null)
            {
                throw new ArgumentNullException(nameof(sight));
            }

            return new Aim(sight);
        }
    }
}