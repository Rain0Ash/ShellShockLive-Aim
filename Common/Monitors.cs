using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Common
{
    public struct Monitor
    {
        public Int32 ID;
        public String Name;
        public Rectangle Resolution;
        public Int32 Frequency;

        public Monitor(Int32 id, String name, Rectangle resolution, Int32 frequency)
        {
            ID = id;
            Name = name;
            Resolution = resolution;
            Frequency = frequency;
        }
    }
    
    public static class Monitors
    {

        [DllImport("user32.dll")]
        private static extern Boolean EnumDisplaySettings(String lpszDeviceName, Int32 iModeNum, ref DEVMODE lpDevMode);
        
        private const Int32 EnumCurrentSettings = -1;

        public static Monitor GetPrimaryMonitor()
        {
            Screen screen = Screen.PrimaryScreen;
            DEVMODE dm = new DEVMODE(){dmSize = (Int16)Marshal.SizeOf(typeof(DEVMODE))};
            EnumDisplaySettings(screen.DeviceName, EnumCurrentSettings, ref dm);
            return new Monitor(1, screen.DeviceName, screen.Bounds, dm.dmDisplayFrequency);
        }
        
        public static Monitor[] GetMonitors()
        {
            List<Monitor> monitors = new List<Monitor>();
            
            Int32 id = 0;
            Monitor fullScreen = new Monitor(id, @"F", new Rectangle(0, 0, 0, 0), 0);
            foreach (Screen screen in Screen.AllScreens)
            {
                DEVMODE dm = new DEVMODE {dmSize = (Int16)Marshal.SizeOf(typeof(DEVMODE))};
                EnumDisplaySettings(screen.DeviceName, EnumCurrentSettings, ref dm);
                fullScreen.Resolution.Width = Math.Max(fullScreen.Resolution.Width, screen.Bounds.Width);
                fullScreen.Resolution.Height = Math.Max(fullScreen.Resolution.Height, screen.Bounds.Height);
                fullScreen.Frequency = Math.Max(fullScreen.Frequency, dm.dmDisplayFrequency);
                monitors.Add(new Monitor(++id, screen.DeviceName, screen.Bounds, dm.dmDisplayFrequency));
            }

            if (monitors.Count == 1) monitors[0] = fullScreen;
            else monitors.Insert(0, fullScreen);
            return monitors.ToArray();
        }
    }
    
    [StructLayout(LayoutKind.Sequential)]
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    [SuppressMessage("ReSharper", "FieldCanBeMadeReadOnly.Global")]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public struct DEVMODE
    {
        private const Int32 CCHDEVICENAME = 0x20;
        private const Int32 CCHFORMNAME = 0x20;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 0x20)]
        public String dmDeviceName;
        public Int16 dmSpecVersion;
        public Int16 dmDriverVersion;
        public Int16 dmSize;
        public Int16 dmDriverExtra;
        public Int32 dmFields;
        public Int32 dmPositionX;
        public Int32 dmPositionY;
        public ScreenOrientation dmDisplayOrientation;
        public Int32 dmDisplayFixedOutput;
        public Int16 dmColor;
        public Int16 dmDuplex;
        public Int16 dmYResolution;
        public Int16 dmTTOption;
        public Int16 dmCollate;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 0x20)]
        public String dmFormName;
        public Int16 dmLogPixels;
        public Int32 dmBitsPerPel;
        public Int32 dmPelsWidth;
        public Int32 dmPelsHeight;
        public Int32 dmDisplayFlags;
        public Int32 dmDisplayFrequency;
        public Int32 dmICMMethod;
        public Int32 dmICMIntent;
        public Int32 dmMediaType;
        public Int32 dmDitherType;
        public Int32 dmReserved1;
        public Int32 dmReserved2;
        public Int32 dmPanningWidth;
        public Int32 dmPanningHeight;
    }
}