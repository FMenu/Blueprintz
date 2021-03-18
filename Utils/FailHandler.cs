using System;
using System.IO;
using System.Windows.Forms;

namespace Blueprintz
{
    public static class FailHandler
    {
        public static readonly string defaultPath = Directory.GetCurrentDirectory() + @"\errorlogs\";

        public static void HandleException(Exception exception, bool writeToFile = true, bool showMsgBox = false, bool critical = true)
        {
            Program.logger.Exception(exception, critical, true);
            if (showMsgBox) MessageBox.Show(exception.Message, "An exception occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
            if (writeToFile) WriteToFile(defaultPath, exception.Message + "\n" + exception.StackTrace);
        }

        private static void WriteToFile(string path, string text)
        {
            string newPath = path + "error_" + Guid.NewGuid().ToString();
            File.WriteAllText(newPath, text);
        }
    }
}
