// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Drawing;
using System.Windows.Forms;

namespace Ruler.Common
{
    public static class Utils
    {
        public static Point GetCursorPosition()
        {
            Point cursorPosition = Cursor.Position;
            return new Point(cursorPosition.X, cursorPosition.Y);
        }        
        
        public static Point GetCursorPosition(Point renderTargetSize)
        {
            Point cursorPosition = Cursor.Position;
            return new Point(cursorPosition.X * renderTargetSize.X / EventsAndGlobalsController.CurrentMonitor.Resolution.Width, 
                cursorPosition.Y * renderTargetSize.Y / EventsAndGlobalsController.CurrentMonitor.Resolution.Height);
        }

        public static Double LimitToRange(Double value, Double inclusiveMinimum, Double inclusiveMaximum, Boolean reverse = false)
        {
            if (value < inclusiveMinimum) { return reverse ? inclusiveMaximum : inclusiveMinimum; }
            if (value > inclusiveMaximum) { return reverse ? inclusiveMinimum : inclusiveMaximum; }
            return value;
        }
    }
}