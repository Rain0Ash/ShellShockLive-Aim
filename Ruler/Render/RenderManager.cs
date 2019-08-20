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
    internal sealed class RenderManager : IDisposable
    {
        internal static Boolean CanDoRedraw;
        private Boolean isStarted = false;
        private RulerRender Form;
        private RenderTarget drawer;
        private SwapChain swapChain;
        private RenderLoop looper;

        private Manager manager;
        internal RenderManager(ref RulerRender form, ref RenderTarget drawer, ref SwapChain swapChain)
        {
            Form = form;
            this.drawer = drawer;
            this.swapChain = swapChain;
            EventsAndGlobalsController.RenderTargetSize = new RawVector2(drawer.Size.Width, drawer.Size.Height);
            EventsAndGlobalsController.Parameters = Parameter.GetParameters($"{Form.Bounds.Width}x{Form.Bounds.Height}");
            
            manager = new Manager(ref this.drawer);
        }

        internal void Start()
        {
            if (isStarted)
                return;

            new KeyboardController().SetupKeyboardHooks();

            Form.Show();
            Form.MainForm.Show();
            Form.MainForm.BringToFront();
            EventsAndGlobalsController.NeedRedraw += NextFrame;
            
            looper = new RenderLoop(Form);
            NextFrame();
            while (true)
            {
                if (!looper.NextFrame())
                {
                    break;
                }

                Thread.Sleep((Int32) Utils.GetUpdateTimeForFPS(60));
            }
        }

        internal void NextFrame()
        {
            if (!looper.NextFrame())
            {
                return;
            }
            CanDoRedraw = false;
            drawer.BeginDraw();
            drawer.Clear(Color.Black);
            manager.PrepareNextFrame();
            drawer.EndDraw();
            swapChain.Present(0, PresentFlags.None);
            CanDoRedraw = true;
        }

        public void Dispose()
        {
            looper.Dispose();
        }
    }
}