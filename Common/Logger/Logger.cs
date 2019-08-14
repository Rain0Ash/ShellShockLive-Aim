using System;
using System.Globalization;
using System.IO;

namespace Common.Logger
{
    public class Logger
    {
        private const ConsoleColor WhiteColor = ConsoleColor.White;
        private const ConsoleColor BlackColor = ConsoleColor.Black;
        private const ConsoleColor ActionColor = ConsoleColor.Blue;
        private const ConsoleColor GoodColor = ConsoleColor.Green;
        private const ConsoleColor WarningColor = ConsoleColor.Yellow;
        private const ConsoleColor CriticalWarningColor = ConsoleColor.DarkYellow;
        private const ConsoleColor ErrorColor = ConsoleColor.Red;
        private const ConsoleColor CriticalErrorColor = ConsoleColor.DarkRed;

        private Boolean writeToFile;

        public Logger(Boolean writeToFile = false)
        {
            this.writeToFile = writeToFile;
        }
        
        public void ColorWrite(Object objectForLog, ConsoleColor foregroundColor = ConsoleColor.White, ConsoleColor backgroundColor = ConsoleColor.Black, Boolean isNew = true)
        {
            String text = objectForLog.ToString();
            Console.ForegroundColor = foregroundColor;
            Console.BackgroundColor = backgroundColor;
            if (isNew) { Console.WriteLine(text); }
            else { Console.Write(text); }
            Console.ResetColor();
            if (!writeToFile)
            {
                return;
            }
            
            StreamWriter logFile = new StreamWriter(new FileStream(
                Path.Combine(Directory.GetCurrentDirectory(), "log.txt"), FileMode.Create, FileAccess.Write));
            
            if (isNew)
            {
                logFile.WriteLine($"{DateTime.Now.ToString(CultureInfo.InvariantCulture)}: {text}");
            }
            else
            {
                logFile.Write($"{text}");
            }
            logFile.Close();
        }

        public void Action(Object objectForLog, Boolean isNew = true) { ColorWrite(objectForLog, ActionColor, BlackColor, isNew); }

        public void Good(Object objectForLog, Boolean isNew = true) { ColorWrite(objectForLog, GoodColor, BlackColor, isNew); }

        public void Warning(Object objectForLog, Boolean isNew = true) { ColorWrite(objectForLog, WarningColor, BlackColor, isNew); }

        public void CriticalWarning(Object objectForLog, Boolean isNew = true) { ColorWrite(objectForLog, CriticalWarningColor, BlackColor, isNew); }

        public void Error(Object objectForLog, Boolean isNew = true) { ColorWrite(objectForLog, ErrorColor, BlackColor, isNew); }

        public void CriticalError(Object objectForLog, Boolean isNew = true) { ColorWrite(objectForLog, CriticalErrorColor, BlackColor, isNew); }

        public void FatalError(Object objectForLog, Boolean isNew = true) { ColorWrite(objectForLog, WhiteColor, CriticalErrorColor, isNew); }
    }
}