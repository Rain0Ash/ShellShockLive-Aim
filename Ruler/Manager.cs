using System;
using SharpDX;
using SharpDX.Direct2D1;
using SharpDX.DXGI;
using SharpDX.Windows;

namespace Ruler
{
    internal class Manager
    {
        protected RenderForm Form;
        protected RenderTarget Drawer;
        protected SwapChain SwapChain;

        internal Manager(ref RenderForm form, ref RenderTarget drawer, ref SwapChain swapChain)
        {
            Form = form;
            Drawer = drawer;
            SwapChain = swapChain;
        }

        internal void Start()
        {
            Form.Show();
            RenderLoop loop = new RenderLoop(Form);
            while (loop.NextFrame())
            {
                Drawer.BeginDraw();
                Drawer.Clear(Color.Black);
                Drawer.EndDraw();
                SwapChain.Present(0, PresentFlags.None);
            }
        }
    }
}