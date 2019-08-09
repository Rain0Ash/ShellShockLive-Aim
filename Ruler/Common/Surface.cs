using System;
using System.Drawing;
using System.Windows.Forms;
using SharpDX.Direct2D1;

namespace Ruler.Common
{
    public class Surface : IElement
    {
        protected static Parametrs Settings = Params.GetParametrs();
        protected RenderTarget RenderTarget;

        protected Surface(ref RenderTarget renderTarget)
        {
            RenderTarget = renderTarget;
        }

        public virtual void Draw()
        {
            if (RenderTarget == null)
            {
                throw new ArgumentNullException("Drawer is Null");
            }
            Draw(ref RenderTarget);
        }
        
        public virtual void Draw(ref RenderTarget renderTarget)
        {
        }
    }
}