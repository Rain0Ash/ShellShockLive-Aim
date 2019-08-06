// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Drawing;
using System.Windows.Forms;
using Ruler.Common;

namespace Ruler
{
    internal class BlackHole : Circle
    {
        internal BlackHole(Point point, Single radius, PaintEventArgs e)
            : base(point, radius, e)
        {
        }

        internal Boolean IsIntersectGravityRadius(Point point)
        {
            return base.IsIntersect(point, 2);
        }
    }
}
