// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using Ruler.Common;
using SharpDX;
using SharpDX.Direct2D1;

namespace Ruler
{
    internal sealed class Portals : IElement
    {
        private static Int32 _counter = 0;
        private Int32 instanceNumber = 0;

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
            instanceNumber = _counter - 1;
            FirstPortal.Color = Colors[instanceNumber][0];
            FirstPortal.Color = Colors[instanceNumber][1];
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

        public void Draw(ref RenderTarget renderTarget)
        {
            FirstPortal.Draw(ref renderTarget);
            SecondPortal.Draw(ref renderTarget);
        }
    }
    internal class Portal : Circle
    {
        internal Portal(Point coord, Single radius, ref RenderTarget renderTarget)
            : base(coord, radius, ref renderTarget)
        {
        }
        
        
    }
}
