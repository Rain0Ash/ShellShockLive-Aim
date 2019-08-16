// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Ruler.Common
{
    internal class GlobalKeyboardHookEventArgs : HandledEventArgs
    {
        public GlobalKeyboardHook.KeyboardState KeyboardState { get; private set; }
        public GlobalKeyboardHook.LowLevelKeyboardInputEvent KeyboardData { get; private set; }

        public GlobalKeyboardHookEventArgs(
            GlobalKeyboardHook.LowLevelKeyboardInputEvent keyboardData,
            GlobalKeyboardHook.KeyboardState keyboardState)
        {
            KeyboardData = keyboardData;
            KeyboardState = keyboardState;
        }
    }

    internal sealed class GlobalKeyboardHook : IDisposable
    {
        private delegate IntPtr HookProc(Int32 nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll")]
        private static extern IntPtr LoadLibrary(String lpFileName);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        private static extern Boolean FreeLibrary(IntPtr hModule);
        
        [DllImport("USER32", SetLastError = true)]
        static extern IntPtr SetWindowsHookEx(Int32 idHook, HookProc lpfn, IntPtr hMod, Int32 dwThreadId);
        
        [DllImport("USER32", SetLastError = true)]
        public static extern Boolean UnhookWindowsHookEx(IntPtr hHook);
        
        [DllImport("USER32", SetLastError = true)]
        static extern IntPtr CallNextHookEx(IntPtr hHook, Int32 code, IntPtr wParam, IntPtr lParam);

        [StructLayout(LayoutKind.Sequential)]
        public struct LowLevelKeyboardInputEvent
        {
            public Int32 VirtualCode;
            
            public Int32 HardwareScanCode;
            
            public Int32 Flags;
            
            public Int32 TimeStamp;
            
            public IntPtr AdditionalInformation;
        }

        public const Int32 WhKeyboardLl = 13;

        public enum KeyboardState
        {
            KeyDown = 0x0100,
            KeyUp = 0x0101,
            SysKeyDown = 0x0104,
            SysKeyUp = 0x0105
        }

        //public const Int32 VkSnapshot = 0x2c;
        //const int VkLwin = 0x5b;
        //const int VkRwin = 0x5c;
        //const int VkTab = 0x09;
        //const int VkEscape = 0x18;
        const Int32 VkControl = 0x11;
        const Int32 KfAltdown = 0x2000;
        public const Int32 LlkhfAltdown = (KfAltdown >> 8);
        public const Int32 LlkhfCtrldown = (VkControl >> 8);
        
        public event EventHandler<GlobalKeyboardHookEventArgs> KeyboardPressed;
        
        private IntPtr windowsHookHandle;
        private IntPtr user32LibraryHandle;
        private static HookProc _hookProc;
        
        public GlobalKeyboardHook()
        {
            windowsHookHandle = IntPtr.Zero;
            user32LibraryHandle = IntPtr.Zero;
            _hookProc = LowLevelKeyboardProc; // we must keep alive hookProc, because GC is not aware about SetWindowsHookEx behaviour.

            user32LibraryHandle = LoadLibrary("User32");
            if (user32LibraryHandle == IntPtr.Zero)
            {
                Int32 errorCode = Marshal.GetLastWin32Error();
                throw new Win32Exception(errorCode, $"Failed to load library 'User32.dll'. Error {errorCode}: {new Win32Exception(Marshal.GetLastWin32Error()).Message}.");
            }
            
            windowsHookHandle = SetWindowsHookEx(WhKeyboardLl, _hookProc, user32LibraryHandle, 0);
            if (windowsHookHandle == IntPtr.Zero)
            {
                Int32 errorCode = Marshal.GetLastWin32Error();
                throw new Win32Exception(errorCode, $"Failed to adjust keyboard hooks for '{Process.GetCurrentProcess().ProcessName}'. Error {errorCode}: {new Win32Exception(Marshal.GetLastWin32Error()).Message}.");
            }
        }

        private void Dispose(Boolean disposing)
        {
            if (disposing)
            {
                // because we can unhook only in the same thread, not in garbage collector thread
                if (windowsHookHandle != IntPtr.Zero)
                {
                    if (!UnhookWindowsHookEx(windowsHookHandle))
                    {
                        Int32 errorCode = Marshal.GetLastWin32Error();
                        throw new Win32Exception(errorCode, $"Failed to remove keyboard hooks for '{Process.GetCurrentProcess().ProcessName}'. Error {errorCode}: {new Win32Exception(Marshal.GetLastWin32Error()).Message}.");
                    }
                    windowsHookHandle = IntPtr.Zero;

                    // ReSharper disable once DelegateSubtraction
                    _hookProc -= LowLevelKeyboardProc;
                }
            }

            if (user32LibraryHandle != IntPtr.Zero)
            {
                if (!FreeLibrary(user32LibraryHandle)) // reduces reference to library by 1.
                {
                    Int32 errorCode = Marshal.GetLastWin32Error();
                    throw new Win32Exception(errorCode, $"Failed to unload library 'User32.dll'. Error {errorCode}: {new Win32Exception(Marshal.GetLastWin32Error()).Message}.");
                }
                user32LibraryHandle = IntPtr.Zero;
            }
        }

        ~GlobalKeyboardHook()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IntPtr LowLevelKeyboardProc(Int32 nCode, IntPtr wParam, IntPtr lParam)
        {
            Boolean fEatKeyStroke = false;
            Int32 wparamTyped = wParam.ToInt32();
            if (Enum.IsDefined(typeof(KeyboardState), wparamTyped))
            {
                
                Object o = Marshal.PtrToStructure(lParam, typeof(LowLevelKeyboardInputEvent));
                LowLevelKeyboardInputEvent p = (LowLevelKeyboardInputEvent) o;

                GlobalKeyboardHookEventArgs eventArguments = new GlobalKeyboardHookEventArgs(p, (KeyboardState)wparamTyped);

                EventHandler<GlobalKeyboardHookEventArgs> handler = KeyboardPressed;
                handler?.Invoke(this, eventArguments);

                fEatKeyStroke = eventArguments.Handled;
            }
            return fEatKeyStroke ? (IntPtr) 1 : CallNextHookEx(IntPtr.Zero, nCode, wParam, lParam);
        }
    }
}