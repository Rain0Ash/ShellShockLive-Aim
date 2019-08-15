// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Threading;
using Ruler.Common;
using SharpDX;
using SharpDX.Direct2D1;
using SharpDX.DXGI;
using SharpDX.Mathematics.Interop;
using SharpDX.Windows;

namespace Ruler
{
    internal sealed class Manager : IDisposable
    {
        private Boolean isStarted = false;
        private RulerRender Form;
        private RenderTarget drawer;
        private SwapChain swapChain;
        private RenderLoop looper;

        internal Manager(ref RulerRender form, ref RenderTarget drawer, ref SwapChain swapChain)
        {
            Form = form;
            this.drawer = drawer;
            this.swapChain = swapChain;
        }

        internal void Start()
        {
            if (isStarted)
                return;

            new KeyboardController().SetupKeyboardHooks();

            Form.Show();
            Form.MainForm.Show();
            Form.MainForm.BringToFront();
            EventController.NeedRedraw += (sender, args) => ForceNextFrame();
            
            looper = new RenderLoop(Form);
            Boolean firstRender = false;
            while (true)
            {
                if (!looper.NextFrame())
                {
                    break;
                }

                if (!firstRender)
                {
                    NextFrame();
                    firstRender = true;
                }
                Thread.Sleep((Int32) Utils.GetUpdateTimeForFPS(60));
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
            drawer.BeginDraw();
            drawer.Clear(Color.Black);
            new Portal(new Point(450, 500), 100, ref drawer).Draw();
            drawer.EndDraw();
            swapChain.Present(0, PresentFlags.None);
        }

        public void Dispose()
        {
            looper.Dispose();
        }
    }
}