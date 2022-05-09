// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Drawing;
using System.Linq;
using NetExtender.Types.Comparers;

namespace ShellShockLive.Models.Physics.Guidances
{
    public sealed class GuidanceSearchInfo : IReadOnlySet<GuidanceSearchResult>
    {
        public static implicit operator PhysicsInfo(GuidanceSearchInfo value)
        {
            return value.Highest;
        }
        
        public ImmutableSortedSet<GuidanceSearchResult> Search { get; }
        public Point Position { get; }
        public GuidanceStep Step { get; }
        
        public Int32 Count
        {
            get
            {
                return Search.Count;
            }
        }
        
        public PhysicsInfo Highest
        {
            get
            {
                return Search[0];
            }
            
        }

        public PhysicsInfo Middle
        {
            get
            {
                return Search.Last(search => search.Physics.Power > 40 && search.Physics.Degree >= 60);
            }
        }

        public PhysicsInfo Lowest
        {
            get
            {
                return Search[^1];
            }
        }

        public GuidanceSearchInfo(GuidanceSearchResult search, Point position, GuidanceStep step)
        {
            Search = ImmutableSortedSet<GuidanceSearchResult>.Empty.Add(search);
            Position = position;
            Step = step;
        }

        public GuidanceSearchInfo(IEnumerable<GuidanceSearchResult> search, Point position, GuidanceStep step)
        {
            if (search is null)
            {
                throw new ArgumentNullException(nameof(search));
            }

            Search = search.ToImmutableSortedSet(ReverseComparer<GuidanceSearchResult>.Default);

            if (Search.Count <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(search), Search.Count, null);
            }
            
            Position = position;
            Step = step;
        }

        public Boolean Contains(GuidanceSearchResult item)
        {
            return Search.Contains(item);
        }

        public Boolean IsSubsetOf(IEnumerable<GuidanceSearchResult> other)
        {
            return Search.IsSubsetOf(other);
        }

        public Boolean IsProperSubsetOf(IEnumerable<GuidanceSearchResult> other)
        {
            return Search.IsProperSubsetOf(other);
        }

        public Boolean IsSupersetOf(IEnumerable<GuidanceSearchResult> other)
        {
            return Search.IsSupersetOf(other);
        }

        public Boolean IsProperSupersetOf(IEnumerable<GuidanceSearchResult> other)
        {
            return Search.IsProperSupersetOf(other);
        }

        public Boolean Overlaps(IEnumerable<GuidanceSearchResult> other)
        {
            return Search.Overlaps(other);
        }

        public Boolean SetEquals(IEnumerable<GuidanceSearchResult> other)
        {
            return Search.SetEquals(other);
        }

        public ImmutableSortedSet<GuidanceSearchResult>.Enumerator GetEnumerator()
        {
            return Search.GetEnumerator();
        }
        
        IEnumerator<GuidanceSearchResult> IEnumerable<GuidanceSearchResult>.GetEnumerator()
        {
            // ReSharper disable once ForeachCanBeConvertedToQueryUsingAnotherGetEnumerator
            foreach (GuidanceSearchResult physics in this)
            {
                yield return physics;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<GuidanceSearchResult>) this).GetEnumerator();
        }

        public GuidanceSearchResult this[Int32 index]
        {
            get
            {
                return Search[index];
            }
        }
    }
}