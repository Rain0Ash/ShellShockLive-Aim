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

        private Sight sight;

        internal Manager(ref RulerRender form, ref RenderTarget drawer, ref SwapChain swapChain)
        {
            Form = form;
            this.drawer = drawer;
            this.swapChain = swapChain;
            EventsAndGlobalsController.RenderTargetSize = new RawVector2(drawer.Size.Width, drawer.Size.Height);
            EventsAndGlobalsController.Parameters = Parameter.GetParameters($"{Form.Bounds.Width}x{Form.Bounds.Height}");
            
            InitializeComponent();
        }

        internal void Start()
        {
            if (isStarted)
                return;

            new KeyboardController().SetupKeyboardHooks();

            Form.Show();
            Form.MainForm.Show();
            Form.MainForm.BringToFront();
            EventsAndGlobalsController.NeedRedraw += () => ForceNextFrame();
            
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
            sight.Draw();
            drawer.EndDraw();
            swapChain.Present(0, PresentFlags.None);
        }

        public void Dispose()
        {
            looper.Dispose();
        }

        private void InitializeComponent()
        {
            sight = new Sight(new RawVector2(Form.Bounds.Width / 2f, Form.Bounds.Height / 2f), EventsAndGlobalsController.Parameters.Length, ref drawer);
        }
    }
}