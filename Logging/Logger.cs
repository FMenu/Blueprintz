using JumpinFrog.Vectors;
using System;

namespace JumpinFrog.Logging
{
    public class Logger
    {
        private ConsoleColor infoColor, debugColor, warningColor, errorColor, criticalColor, logPrintColor;
        private bool placeLineBreak;

        public Logger(bool colorPrefix, bool lineEndAfterPrefix, string consoleTitle, bool showCursor, Vector.Vector2I windowSize, Action failCallback = null)
        {
            if (colorPrefix)
            {
                infoColor = ConsoleColor.Blue;
                debugColor = ConsoleColor.Cyan;
                warningColor = ConsoleColor.Yellow;
                errorColor = ConsoleColor.Red;
                criticalColor = ConsoleColor.DarkRed;
                logPrintColor = ConsoleColor.Magenta;
            }
            else
            {
                infoColor = ConsoleColor.White;
                debugColor = ConsoleColor.White;
                warningColor = ConsoleColor.White;
                errorColor = ConsoleColor.White;
                criticalColor = ConsoleColor.White;
                logPrintColor = ConsoleColor.White;
            }
            placeLineBreak = lineEndAfterPrefix;
            try
            {
                CustomConsole.AttachConsole();
                Console.Title = consoleTitle;
                Console.CursorVisible = showCursor;
                Console.SetWindowSize(windowSize.x, windowSize.y);
            }
            catch { if (failCallback != null) failCallback(); }
        }

        public void PrintRaw(string text) => Console.WriteLine("[OUTPUT]: " + text);

        public bool Info(object value)
        {
            try
            {
                Console.ForegroundColor = infoColor;
                Console.Write("[Info:" + DateTime.Now.ToShortTimeString() + "] ");
                Console.ForegroundColor = ConsoleColor.White;
                if (placeLineBreak) Console.WriteLine();
                Console.WriteLine(value.ToString());
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Debug(object value)
        {
            try
            {
                Console.ForegroundColor = debugColor;
                Console.Write("[Debug:" + DateTime.Now.ToShortTimeString() + "] ");
                Console.ForegroundColor = ConsoleColor.White;
                if (placeLineBreak) Console.WriteLine();
                Console.WriteLine(value.ToString());
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Warn(object value)
        {
            try
            {
                Console.ForegroundColor = warningColor;
                Console.Write("[WARNING:" + DateTime.Now.ToShortTimeString() + "] ");
                Console.ForegroundColor = ConsoleColor.White;
                if (placeLineBreak) Console.WriteLine();
                Console.WriteLine(value.ToString());
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Error(object value)
        {
            try
            {
                Console.ForegroundColor = errorColor;
                Console.Write("[ERROR:" + DateTime.Now.ToShortTimeString() + "] ");
                Console.ForegroundColor = ConsoleColor.White;
                if (placeLineBreak) Console.WriteLine();
                Console.WriteLine(value.ToString());
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Critical(object value)
        {
            try
            {
                Console.ForegroundColor = criticalColor;
                Console.Write("[CRITICAL ERROR:" + DateTime.Now.ToShortTimeString() + "] ");
                Console.ForegroundColor = ConsoleColor.White;
                if (placeLineBreak) Console.WriteLine();
                Console.WriteLine(value.ToString());
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Exception(Exception e, bool critical = false, bool printStackTrace = false)
        {
            try
            {
                if (critical) Console.ForegroundColor = criticalColor;
                else Console.ForegroundColor = errorColor;
                Console.WriteLine(e.Message);
                if (printStackTrace)
                {
                    string stackTrace = "Stacktrace:\n" + e.StackTrace;
                    Console.WriteLine(stackTrace);
                }
                Console.ForegroundColor = ConsoleColor.White;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Log(string[] lines)
        {
            try
            {
                Console.ForegroundColor = logPrintColor;
                foreach (string line in lines)
                    Console.WriteLine(line);
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.White;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static Logger defaultLogger { get; } = new Logger(
            true,
            false,
            "Default Logger output",
            false,
            new Vector.Vector2I(800, 600)
            );
    }
}