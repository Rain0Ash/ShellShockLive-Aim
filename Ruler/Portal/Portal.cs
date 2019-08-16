// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Collections.Generic;
using System.Threading;
using Ruler.Common;
using SharpDX;
using SharpDX.Direct2D1;
using SharpDX.Mathematics.Interop;

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

        internal Boolean IsIntersect(RawVector2 point)
        {
            return FirstPortal.IsIntersect(point) || SecondPortal.IsIntersect(point);
        }
        
        internal RawVector2 TryTeleport(RawVector2 point)
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
        internal Portal(RawVector2 coord, Single radius, ref RenderTarget renderTarget)
            : base(coord, radius, ref renderTarget)
        {
        }

        public override void Draw(ref RenderTarget renderTarget)
        {
            Random random = new Random();
            renderTarget.FillEllipse(new Ellipse(Coord, Radius, Radius), new SolidColorBrush(renderTarget, new RawColor4(
                (Single)random.NextDouble(), (Single)random.NextDouble(), (Single)random.NextDouble(), (Single)random.NextDouble())));
        }
    }
}
