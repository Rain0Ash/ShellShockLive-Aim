// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using ShellShockLive.Models.Environment;
using ShellShockLive.Models.Sight.Interfaces;

namespace ShellShockLive.Models.Sight
{
    public class Sight : CircleSurface, ISight
    {
        public override Boolean Interactive
        {
            get
            {
                return false;
            }
        }

        public IAim Aim { get; }
        public ITrajectory Trajectory { get; }
        public ISearchPosition Search { get; }
        public ISightInformation Information { get; }

        public Sight()
        {
            Aim = new Aim(this);
            Trajectory = new Trajectory(this);
            Search = new SearchPosition(this);
            Information = new SightInformation(this);
        }

        public Sight(IAim aim, ITrajectory trajectory, ISearchPosition search, ISightInformation information)
            : this(aim, trajectory, search, information, false)
        {
        }

        protected Sight(IAim aim, ITrajectory trajectory, ISearchPosition search, ISightInformation information, Boolean clone)
        {
            if (aim is null)
            {
                throw new ArgumentNullException(nameof(aim));
            }

            if (trajectory is null)
            {
                throw new ArgumentNullException(nameof(trajectory));
            }

            if (clone)
            {
                aim = aim.Clone(this);
                trajectory = trajectory.Clone(this);
                search = search.Clone(this);
                information = information.Clone(this);
            }
            
            Aim = aim;
            Trajectory = trajectory;
            Search = search;
            Information = information;
        }
        
        public virtual void Set(ISight sight)
        {
            if (sight is null)
            {
                throw new ArgumentNullException(nameof(sight));
            }

            Center = sight.Center;
            Radius = sight.Radius;
            
            Aim.Set(sight.Aim);
            Trajectory.Set(sight.Trajectory);
            Search.Set(sight.Search);
            Information.Set(sight.Information);
        }
        
        public override Object Clone()
        {
            return new Sight(Aim, Trajectory, Search, Information, true)
            {
                Center = Center,
                Radius = Radius
            };
        }
    }
}