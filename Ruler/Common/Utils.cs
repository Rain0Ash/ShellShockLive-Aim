using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Common;
using SharpDX;
using SharpDX.Direct2D1;
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

        public static RawVector2 GetCursorPosition()
        {
            System.Drawing.Point cursorPosition = Cursor.Position;
            return new RawVector2(cursorPosition.X, cursorPosition.Y);
        }        
        
        public static RawVector2 GetCursorPosition(ref RenderTarget renderTarget)
        {
            System.Drawing.Point cursorPosition = Cursor.Position;
            return new RawVector2(cursorPosition.X * renderTarget.Size.Width / Globals.Monitor.Resolution.Width, 
                cursorPosition.Y * renderTarget.Size.Height / Globals.Monitor.Resolution.Height);
        }
        
    }
}