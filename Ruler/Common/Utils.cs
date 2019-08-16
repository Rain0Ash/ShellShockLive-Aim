using System;
using System.Drawing;
using System.Runtime.InteropServices;
using Common;
using SharpDX;
using SharpDX.Mathematics.Interop;

namespace Ruler.Common
{
    public static class Utils
    {
        public static Double GetUpdateTimeForFPS(Int32 fps)
        {
            return fps * fps / 1000d;
        }

        public static RawColor4 GetColor(Byte r, Byte g, Byte b, Byte a)
        {
            return new RawColor4(r / 255f, g / 255f, b / 255f, a / 255f);
        }
    }
}