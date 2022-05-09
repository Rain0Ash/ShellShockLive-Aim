// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using NetExtender.Types.Native.Windows;
using NetExtender.Utilities.Threading;
using NetExtender.Utilities.Types;
using ShellShockLive.ViewModels.Vision.Bindings;

namespace ShellShockLive.ViewModels.Game
{
    public class GameController
    {
        public String Name { get; init; } = "ShellShockLive";
        private Process Process { get; } = Process.GetCurrentProcess();
        private Process? Game { get; set; }

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern Boolean GetClientRect(IntPtr handle, out WinRectangle rectangle);

        public IntPtr Handle()
        {
            if (Game is null || !Game.IsAlive())
            {
                Game = Process.GetProcessesByName(Name).WhereNotSameBy(Process, process => process.Id).SingleOrDefault();
            }

            return Game?.MainWindowHandle ?? IntPtr.Zero;
        }

        public IntPtr Window(out Rectangle screen)
        {
            IntPtr handle = Handle();
            if (!GetClientRect(handle, out WinRectangle rect))
            {
                screen = default;
                return IntPtr.Zero;
            }

            screen = rect;
            return handle;
        }

        public IntPtr Window(VisionBinding? binding)
        {
            return Window(binding, out _, out _);
        }

        public IntPtr Window(VisionBinding? binding, out Boolean outbound)
        {
            return Window(binding, out _, out outbound);
        }

        public IntPtr Window(VisionBinding? binding, out Rectangle screen)
        {
            return Window(binding, out screen, out _);
        }

        public IntPtr Window(VisionBinding? binding, out Rectangle screen, out Boolean outbound)
        {
            if (binding is null)
            {
                outbound = false;
                return Window(out screen);
            }

            IntPtr handle = Window(out screen);
            outbound = screen.Size != binding.Size;
            return handle;
        }
    }
}