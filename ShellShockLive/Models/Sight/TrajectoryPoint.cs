// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Drawing;

namespace ShellShockLive.Models.Sight
{
    public readonly struct TrajectoryPoint
    {
        public static implicit operator Point(TrajectoryPoint point)
        {
            return point.Point;
        }

        public static implicit operator TrajectoryPoint(Point point)
        {
            return new TrajectoryPoint(point);
        }

        public static Boolean operator ==(TrajectoryPoint first, TrajectoryPoint second)
        {
            return first.Point == second.Point;
        }

        public static Boolean operator !=(TrajectoryPoint first, TrajectoryPoint second)
        {
            return first.Point != second.Point;
        }

        public Point Point { get; }

        public Int32 X
        {
            get
            {
                return Point.X;
            }
        }

        public Int32 Y
        {
            get
            {
                return Point.Y;
            }
        }

        public Boolean IsEmpty
        {
            get
            {
                return Point.IsEmpty;
            }
        }

        public TrajectoryPoint(Int32 x, Int32 y)
            : this(new Point(x, y))
        {
        }
        
        public TrajectoryPoint(Point point)
        {
            Point = point;
        }

        public override Int32 GetHashCode()
        {
            return Point.GetHashCode();
        }

        public override Boolean Equals(Object? obj)
        {
            return Point.Equals(obj);
        }

        public override String ToString()
        {
            return Point.ToString();
        }
    }
}