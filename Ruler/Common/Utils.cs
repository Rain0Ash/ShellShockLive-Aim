// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Windows.Forms;
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
        
        public static RawVector2 GetCursorPosition(RawVector2 renderTargetSize)
        {
            System.Drawing.Point cursorPosition = Cursor.Position;
            return new RawVector2(cursorPosition.X * renderTargetSize.X / EventsAndGlobalsController.CurrentMonitor.Resolution.Width, 
                cursorPosition.Y * renderTargetSize.Y / EventsAndGlobalsController.CurrentMonitor.Resolution.Height);
        }        
        
        public static RawVector2 GetCursorPosition(ref RenderTarget renderTarget)
        {
            return GetCursorPosition(new RawVector2(renderTarget.Size.Width, renderTarget.Size.Height));
        }

        public static Double LimitToRange(Double value, Double inclusiveMinimum, Double inclusiveMaximum, Boolean reverse = false)
        {
            if (value < inclusiveMinimum) { return reverse ? inclusiveMaximum : inclusiveMinimum; }
            if (value > inclusiveMaximum) { return reverse ? inclusiveMinimum : inclusiveMaximum; }
            return value;
        }
    }
}