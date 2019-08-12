using System;
using System.Threading;
using System.Windows.Forms.VisualStyles;
using Ruler.Common;
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
        private RenderLoop looper;

        internal Manager(ref RenderForm form, ref RenderTarget drawer, ref SwapChain swapChain)
        {
            Form = form;
            Drawer = drawer;
            SwapChain = swapChain;
        }

        internal void Start()
        {
            Manager me = this;
            new KeyboardController(ref me).SetupKeyboardHooks();
            
            Form.Show();


            looper = new RenderLoop(Form);
            Boolean firstRender = false;
            while (true)
            {
                if (!looper.NextFrame())
                {
                    break;
                }
                if (!firstRender) NextFrame();
                firstRender = true;
                Thread.Sleep(60*60/1000);
            }
        }

        internal Boolean ForceNextFrame()
        {
            for (Int32 i = 0; i < 3; i++)
            {
                if (!looper.NextFrame())
                {
                    continue;
                }
                NextFrame();
                return true;
            }

            return false;
        }
        internal void NextFrame()
        {
            Drawer.BeginDraw();
            Drawer.Clear(Color.Black);
            new Portal(new Point(100, 100), 10, ref Drawer).Draw();
            Drawer.EndDraw();
            SwapChain.Present(0, PresentFlags.None);
        }
    }
}