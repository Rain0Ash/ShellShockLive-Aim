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
        private Boolean isStarted = false;
        protected RenderForm Form;
        protected RenderTarget Drawer;
        private RenderLoop looper;

        internal Manager(RenderForm form, RenderTarget drawer)
        {
            Form = form;
            Drawer = drawer;
        }

        internal void Start()
        {
            if (isStarted)
                return;

            new KeyboardController().SetupKeyboardHooks();
            
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
            Drawer.EndDraw();
        }
    }
}