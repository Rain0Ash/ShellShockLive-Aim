using System;
using System.Runtime.Remoting.Messaging;
using System.Threading;
using System.Timers;
using System.Windows;
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
        internal Manager(ref RenderForm form, ref RenderTarget drawer, ref SwapChain swapChain)
        {
            Form = form;
            Drawer = drawer;
            SwapChain = swapChain;
            
        }

        internal void Start()
        {
            new KeyboardController().SetupKeyboardHooks();

            Form.Show();
            RenderLoop loop = new RenderLoop(Form);
            while (true)
            {
                if (!loop.NextFrame())
                {
                    break;
                }
                NextFrame();
            }
        }

        private void NextFrame()
        {
            Drawer.BeginDraw();
            Drawer.Clear(Color.Black);
            new Portal(new SharpDX.Point(100, 100), 10, ref Drawer).Draw();
            Drawer.EndDraw();
            SwapChain.Present(0, PresentFlags.None);
        }
    }
}