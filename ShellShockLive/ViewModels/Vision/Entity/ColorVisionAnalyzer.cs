// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using ShellShockLive.Models.Environment.Containers;

namespace ShellShockLive.ViewModels.Vision
{
    public abstract class ColorVisionAnalyzer<T> : EntityVisionAnalyzer<T>
    {
        protected abstract ColorVisionTemplate Template { get; }

        protected sealed class ConcurrentPointsContainer : ConcurrentDictionary<Point, PointContainer>
        {
            public ConcurrentPointsContainer()
            {
            }

            public ConcurrentPointsContainer(IEnumerable<KeyValuePair<Point, PointContainer>> collection)
                : base(collection)
            {
            }

            public ConcurrentPointsContainer(IEnumerable<KeyValuePair<Point, PointContainer>> collection, IEqualityComparer<Point>? comparer)
                : base(collection, comparer)
            {
            }

            public ConcurrentPointsContainer(IEqualityComparer<Point>? comparer)
                : base(comparer)
            {
            }

            public ConcurrentPointsContainer(Int32 capacity)
                : base(System.Environment.ProcessorCount, capacity)
            {
            }

            public ConcurrentPointsContainer(Int32 capacity, IEqualityComparer<Point>? comparer)
                : base(System.Environment.ProcessorCount, capacity, comparer)
            {
            }
        }
    }
}