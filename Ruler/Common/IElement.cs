using SharpDX.Direct2D1;

namespace Ruler.Common
{
    internal interface IElement
    {
        void Draw(ref RenderTarget renderTarget);
    }
}