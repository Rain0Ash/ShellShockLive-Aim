// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Drawing;
using System.Windows.Forms;
using Ruler.Common;
using SharpDX.Direct2D1;

namespace Ruler
{
    public class ReboundWall : Surface, IRebound
    {
        private Rectangle wallRectangle;
        private static readonly Pen ReboundWallPaintPen = Pens.Fuchsia;

        public Point FirstCoord, SecondCoord;
        public ReboundWall(Rectangle rectangle, ref RenderTarget renderTarget)
            : base(ref renderTarget)
        {
            wallRectangle = rectangle;
            
        }
        
        public override void Draw(ref RenderTarget drawer)
        {
            
        }
    }
}
