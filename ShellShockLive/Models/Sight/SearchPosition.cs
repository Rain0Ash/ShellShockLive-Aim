// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using ShellShockLive.Models.Environment;
using ShellShockLive.Models.Sight.Interfaces;

namespace ShellShockLive.Models.Sight
{
    public class SearchPosition : CircleSurface, ISearchPosition
    {
        public override Boolean Interactive
        {
            get
            {
                return false;
            }
        }

        public ISight Sight { get; }

        public SearchPosition(ISight sight)
        {
            Sight = sight ?? throw new ArgumentNullException(nameof(sight));
        }

        public virtual void Set(ISearchPosition search)
        {
            if (search is null)
            {
                throw new ArgumentNullException(nameof(search));
            }

            Center = search.Center;
            Radius = search.Radius;
        }

        public override Object Clone()
        {
            return Clone(Sight);
        }

        public virtual ISearchPosition Clone(ISight sight)
        {
            if (sight is null)
            {
                throw new ArgumentNullException(nameof(sight));
            }

            return new SearchPosition(sight)
            {
                Center = Center,
                Radius = Radius
            };
        }
    }
}