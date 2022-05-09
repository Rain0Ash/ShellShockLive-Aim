// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using ShellShockLive.Models.Environment;
using ShellShockLive.Models.Physics;
using ShellShockLive.Models.Sight.Interfaces;
using ShellShockLive.ViewModels.Physics;

namespace ShellShockLive.Models.Sight
{
    public class SightInformation : Surface, ISightInformation
    {
        public override Boolean Interactive
        {
            get
            {
                return false;
            }
        }

        public ISight Sight { get; }

        public PhysicsInfo Physics
        {
            get
            {
                return PhysicsViewModel.Instance.Physics;
            }
        }

        public SightInformation(ISight sight)
        {
            Sight = sight ?? throw new ArgumentNullException(nameof(sight));
        }

        public virtual void Set(ISightInformation information)
        {
        }

        public override Object Clone()
        {
            return Clone(Sight);
        }

        public virtual ISightInformation Clone(ISight sight)
        {
            if (sight is null)
            {
                throw new ArgumentNullException(nameof(sight));
            }

            return new SightInformation(sight);
        }
    }
}