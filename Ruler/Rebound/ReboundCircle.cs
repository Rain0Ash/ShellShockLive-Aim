// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Drawing;
using Ruler.Common;

namespace Ruler
{
    internal class ReboundCircle : Circle, IRebound
    {
        internal ReboundCircle(Point coord, Single radius) :
            base(coord, radius)
        {
        }
        
        public override void Draw(ref Graphics graphics)
        {
        }
    }
}
