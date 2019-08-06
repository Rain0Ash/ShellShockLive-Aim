using System;
using System.Drawing;
using System.Windows.Forms;
using Ruler.Common;

namespace Ruler
{
    internal class Aim : Circle
    {
        internal Aim(Point coord, Single radius, PaintEventArgs e)
            : base(coord, radius, e)
        {
            
        }
    }
}