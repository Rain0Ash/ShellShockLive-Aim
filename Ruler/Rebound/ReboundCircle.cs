// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using SharpDX;
using Ruler.Common;
using SharpDX.Direct2D1;
using SharpDX.Mathematics.Interop;

namespace Ruler
{
    internal class ReboundCircle : Circle, IRebound
    {
        internal ReboundCircle(RawVector2 coord, Single radius, ref RenderTarget renderTarget) :
            base(coord, radius, ref renderTarget)
        {
        }
        
        public override void Draw(ref RenderTarget renderTarget)
        {
        }
    }
}
