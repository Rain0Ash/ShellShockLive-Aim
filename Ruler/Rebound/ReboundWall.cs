// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System.Drawing;
using Ruler.Common;

namespace Ruler
{
    public class ReboundWall : Surface, IRebound
    {
        private Rectangle wallRectangle;
        //private static readonly Pen ReboundWallPaintPen = Pens.Fuchsia;

        public Point FirstCoord, SecondCoord;
        public ReboundWall(Rectangle rectangle)
        {
            wallRectangle = rectangle;
        }
        
        public override void Draw(ref Graphics graphics)
        {
            
        }
    }
}
