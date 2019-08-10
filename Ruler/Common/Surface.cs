using System;
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

        public void Draw()
        {
            if (RenderTarget == null)
            {
                throw new ArgumentNullException();
            }
            Draw(ref RenderTarget);
        }
        
        public virtual void Draw(ref RenderTarget renderTarget)
        {
        }
    }
}