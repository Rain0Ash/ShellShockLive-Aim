// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using NetExtender.Types.Drawing.Colors;

namespace ShellShockLive.Models.Environment.Containers
{
    public class PointContainer : IReadOnlyCollection<Point>
    {
        public Point Center { get; }
        public RectangleF Rectangle { get; }
        public ConcurrentHashSet<Point> Container { get; }

        public Int32 Count
        {
            get
            {
                return Container.Count;
            }
        }

        public PointContainer(Point center, Size size, Int32 capacity)
        {
            Center = center;
            Rectangle = new RectangleF(center.X + size.Width / 2F, center.Y + size.Height / 2F, size.Width, size.Height);
            Container = new ConcurrentHashSet<Point>(System.Environment.ProcessorCount, capacity) { center };
        }

        public Boolean Contains(Single x, Single y)
        {
            return Rectangle.Contains(x, y);
        }

        public Boolean Contains(Point point)
        {
            return Rectangle.Contains(point);
        }

        public Boolean Contains(PointF point)
        {
            return Rectangle.Contains(point);
        }

        public Boolean Contains(ColorPoint point)
        {
            return Rectangle.Contains(point.Point);
        }

        public Boolean Add(Point point)
        {
            return Contains(point) && Container.Add(point);
        }

        public Boolean Add(ColorPoint point)
        {
            return Contains(point) && Container.Add(point);
        }

        public ConcurrentHashSet<Point>.Enumerator GetEnumerator()
        {
            return Container.GetEnumerator();
        }

        IEnumerator<Point> IEnumerable<Point>.GetEnumerator()
        {
            return GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}