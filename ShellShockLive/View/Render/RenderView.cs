// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Forms;
using NetExtender.Windows;
using ShellShockLive.ViewModels.Render;

namespace ShellShockLive.View.Render
{
    public sealed class RenderView : Form
    {
        protected override Boolean ShowWithoutActivation
        {
            get
            {
                return true;
            }
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams parameters = base.CreateParams;
                parameters.ExStyle |= 0x80; //WS_EX_TOOLWINDOW
                return parameters;
            }
        }

        public RenderView(Window window)
        {
            if (window is null)
            {
                throw new ArgumentNullException(nameof(window));
            }

            SuspendLayout();
            Enabled = false;
            TopMost = true;
            ControlBox = false;
            ShowInTaskbar = false;
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            TransparencyKey = Color.Black;
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            Location = new System.Drawing.Point(0, 0);
            Size = new System.Drawing.Size((Int32) window.Width, (Int32) window.Height);
            DoubleBuffered = true;

            const Int32 exstyle = -20;
            HandleRef handle = new HandleRef(null, Handle);
            IntPtr style = GetWindowLong(handle, exstyle);
            SetWindowLongPtr(handle, exstyle, (IntPtr) ((Int32) style | 0x20 | 0x80000));
            /*UserInterfaceUtilities.SetWindowDisplayAffinity(handle.Handle, WindowDisplayAffinity.ExcludeFromCapture);*/
            
            ResumeLayout(false);
            PerformLayout();
        }

        private static IntPtr GetWindowLong(HandleRef handle, Int32 index)
        {
            return IntPtr.Size switch
            {
                8 => GetWindowLongPtr64(handle, index),
                4 => GetWindowLong32(handle, index),
                _ => throw new NotSupportedException()
            };
        }

        [DllImport("user32.dll", EntryPoint = "GetWindowLong", CharSet = CharSet.Auto)]
        private static extern IntPtr GetWindowLong32(HandleRef handle, Int32 index);

        [DllImport("user32.dll", EntryPoint = "GetWindowLongPtr", CharSet = CharSet.Auto)]
        private static extern IntPtr GetWindowLongPtr64(HandleRef handle, Int32 index);

        private static IntPtr SetWindowLongPtr(HandleRef handle, Int32 index, IntPtr value)
        {
            return IntPtr.Size switch
            {
                8 => SetWindowLongPtr64(handle, index, value),
                4 => new IntPtr(SetWindowLong32(handle, index, value.ToInt32())),
                _ => throw new NotSupportedException()
            };
        }

        [DllImport("user32.dll", EntryPoint="SetWindowLong")]
        private static extern Int32 SetWindowLong32(HandleRef handle, Int32 index, Int32 value);

        [DllImport("user32.dll", EntryPoint="SetWindowLongPtr")]
        private static extern IntPtr SetWindowLongPtr64(HandleRef handle, Int32 index, IntPtr value);

        protected override void OnPaint(PaintEventArgs args)
        {
            base.OnPaint(args);
            Graphics graphics = args.Graphics;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.CompositingQuality = CompositingQuality.HighQuality;
            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            RenderManager.Instance.NextFrame(graphics);
        }

        protected override void WndProc(ref Message args)
        {
            WM message = (WM) args.Msg;
            switch (message)
            {
                case WM.MOUSEACTIVATE:
                    args.Result = (IntPtr) 0x3; //MA_NOACTIVATE
                    return;
                default:
                    base.WndProc(ref args);
                    return;
            }
        }
    }
}