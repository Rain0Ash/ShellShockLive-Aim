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
        public Rectangle WorkingArea;
        public Rectangle Bounds;
        public Int32 Frequency;

        public Monitor(Int32 id, String name, Rectangle resolution, Rectangle workingArea, Rectangle bounds, Int32 frequency)
        {
            ID = id;
            Name = name;
            Resolution = resolution;
            WorkingArea = workingArea;
            Bounds = bounds;
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
            return new Monitor(1, screen.DeviceName, screen.Bounds, screen.WorkingArea, screen.Bounds, dm.dmDisplayFrequency);
        }
        
        public static Monitor[] GetMonitors()
        {
            List<Monitor> monitors = new List<Monitor>();
            
            Int32 id = 0;
            foreach (Screen screen in Screen.AllScreens)
            {
                DEVMODE dm = new DEVMODE {dmSize = (Int16)Marshal.SizeOf(typeof(DEVMODE))};
                EnumDisplaySettings(screen.DeviceName, EnumCurrentSettings, ref dm);
                monitors.Add(new Monitor(id++, screen.DeviceName, screen.Bounds, screen.WorkingArea, screen.Bounds, dm.dmDisplayFrequency));
            }
            
            return monitors.ToArray();
        }
    }
    

}