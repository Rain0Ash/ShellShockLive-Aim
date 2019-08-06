// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Drawing;
using System.Windows.Forms;
using Ruler.Common;

namespace Ruler
{
    internal class ReboundCircle : Circle, IRebound, IElement 
    {
        internal ReboundCircle(Point coord, Single radius, PaintEventArgs e) :
            base(coord, radius, e)
        {
        }
        
        public override void Draw()
        {
            throw new NotImplementedException(
                $"Method '{GetType().FullName}.{System.Reflection.MethodBase.GetCurrentMethod().Name}' is not implemented");
        }
    }
}
