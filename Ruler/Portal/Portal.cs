// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using Ruler.Common;

namespace Ruler
{
    internal sealed class Portals : IElement
    {
        private static Int32 _counter;

        private static readonly List<Color[]> Colors = new List<Color[]>()
        {
            new[] {Color.Blue, Color.Orange}, 
            new[] {Color.LightBlue, Color.Purple}, 
            new[] {Color.Yellow, Color.Red},
        };

    internal Portal FirstPortal, SecondPortal;

    internal Portals(Portal firstPortal, Portal secondPortal)
        {
            if (_counter >= Colors.Count) throw new OverflowException();
            FirstPortal = firstPortal;
            SecondPortal = secondPortal;
            Interlocked.Increment(ref _counter);
            Int32 instanceNumber = _counter - 1;
        }

        ~Portals()
        {
            Interlocked.Decrement(ref _counter);
        }

        internal Boolean IsIntersect(Point point)
        {
            return FirstPortal.IsIntersect(point) || SecondPortal.IsIntersect(point);
        }
        
        internal Point TryTeleport(Point point)
        {
            if (FirstPortal.IsIntersect(point))
            {
                point.X = SecondPortal.Coord.X - FirstPortal.Coord.X - point.X;
                point.Y = SecondPortal.Coord.Y - FirstPortal.Coord.Y - point.Y;
            }
            else if (SecondPortal.IsIntersect(point))
            {
                point.X = FirstPortal.Coord.X - SecondPortal.Coord.X - point.X;
                point.Y = FirstPortal.Coord.Y - SecondPortal.Coord.Y - point.Y;
            }

            return point;
        }

        public void Draw(ref Graphics graphics)
        {
            FirstPortal.Draw(ref graphics);
            SecondPortal.Draw(ref graphics);
        }
    }
    internal class Portal : Circle
    {
        internal Portal(Point coord, Single radius)
            : base(coord, radius)
        {
        }

        public override void Draw(ref Graphics graphics)
        {
        }
    }
}
