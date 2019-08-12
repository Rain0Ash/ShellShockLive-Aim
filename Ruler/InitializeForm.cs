using System;
using System.Drawing;
using System.Drawing.Printing;
using SharpDX.Direct2D1;
using SharpDX.Direct3D;
using SharpDX.Direct3D11;
using SharpDX.DXGI;
using SharpDX.Windows;
namespace Ruler
{
    internal sealed partial class Ruler
    {
        internal Manager Manager;
        private void InitializeForm()
        {
            ModeDescription modeDescription = new ModeDescription()
            {
                Width = ClientSize.Width,
                Height = ClientSize.Height,
                RefreshRate = new Rational(60, 1),
                Format = Format.R8G8B8A8_UNorm
            };
            SwapChainDescription desc = new SwapChainDescription()
            {
                BufferCount = 1,
                ModeDescription = modeDescription,
                IsWindowed = true,
                OutputHandle = Handle,
                SampleDescription = new SampleDescription(1, 0),
                SwapEffect = SwapEffect.Discard,
                Usage = Usage.RenderTargetOutput
            };

            // Create Device and SwapChain
            SharpDX.Direct3D11.Device.CreateWithSwapChain(DriverType.Hardware, DeviceCreationFlags.BgraSupport, 
                new[] { SharpDX.Direct3D.FeatureLevel.Level_11_1 }, desc, out SharpDX.Direct3D11.Device device, out SwapChain swapChain);
            
            SharpDX.Direct2D1.Factory d2dFactory = new SharpDX.Direct2D1.Factory();

            // Ignore all windows events
            SharpDX.DXGI.Factory factory = swapChain.GetParent<SharpDX.DXGI.Factory>();
            factory.MakeWindowAssociation(Handle, WindowAssociationFlags.IgnoreAll);
            
            Texture2D backBuffer = SharpDX.Direct3D11.Resource.FromSwapChain<Texture2D>(swapChain, 0);
            RenderTargetView renderView = new RenderTargetView(device, backBuffer);

            Surface surface = backBuffer.QueryInterface<Surface>();

            RenderTarget d2dRenderTarget = new RenderTarget(d2dFactory, surface,
                new RenderTargetProperties(new PixelFormat(Format.Unknown, SharpDX.Direct2D1.AlphaMode.Premultiplied)));

            RenderForm thisForm = this;
            Manager = new Manager(ref thisForm, ref d2dRenderTarget, ref swapChain);
            weaponsPanel.Manager = Manager;
            Manager.Start();

            // Release all resources
            renderView.Dispose();
            backBuffer.Dispose();
            device.ImmediateContext.ClearState();
            device.ImmediateContext.Flush();
            device.Dispose();
            swapChain.Dispose();
            factory.Dispose();
        }
    }
}