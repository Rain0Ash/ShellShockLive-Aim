using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using Common;
using Ruler.Properties;
using SharpDX.Direct2D1;
using SharpDX.Direct3D;
using SharpDX.Direct3D11;
using SharpDX.DXGI;
using SharpDX.Windows;
using Settings = Common.Settings;

namespace Ruler
{
    internal sealed class Ruler : RenderForm
    {
        internal Licence Licence;
        internal RulerLocalization Localization;
        internal Boolean IsDisguise;

        internal Ruler(Licence licence, Monitor monitor, String languageCode = null, Boolean isDisguise = false)
        {
            Licence = licence;
            Localization = new RulerLocalization(languageCode);
            IsDisguise = isDisguise;

            TopMost = true;
            AutoScaleMode = AutoScaleMode.Font;
            Name = nameof(Ruler);
            Text = $@"Aim Version {Settings.Version}";
            BackColor = Color.Black;
            TransparencyKey = Color.Black;
            FormBorderStyle = FormBorderStyle.Sizable;
            WindowState = FormWindowState.Maximized;
            Icon = Resources.icon;
            Rectangle resolution = monitor.Resolution;
            Location = new Point(resolution.X, resolution.Y);
            Size = new Size(resolution.Width, resolution.Height);
            
            SwapChainDescription desc = new SwapChainDescription()
            {
                BufferCount = 1,
                ModeDescription = 
                    new ModeDescription(ClientSize.Width, ClientSize.Height,
                        new Rational(60, 1), Format.R8G8B8A8_UNorm),
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

            Int32 width = ClientSize.Width;
            Int32 height = ClientSize.Height;
            
            // Ignore all windows events
            SharpDX.DXGI.Factory factory = swapChain.GetParent<SharpDX.DXGI.Factory>();
            factory.MakeWindowAssociation(Handle, WindowAssociationFlags.IgnoreAll);
            
            Texture2D backBuffer = SharpDX.Direct3D11.Resource.FromSwapChain<Texture2D>(swapChain, 0);
            RenderTargetView renderView = new RenderTargetView(device, backBuffer);

            Surface surface = backBuffer.QueryInterface<Surface>();

            RenderTarget d2dRenderTarget = new RenderTarget(d2dFactory, surface,
                new RenderTargetProperties(new PixelFormat(Format.Unknown, SharpDX.Direct2D1.AlphaMode.Premultiplied)));

            RenderForm thisForm = this;
            Manager manager = new Manager(ref thisForm, ref d2dRenderTarget, ref swapChain);
            manager.Start();

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