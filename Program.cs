using JumpinFrog.Logging;
using System;
using System.Windows.Forms;

namespace Blueprintz
{
    static class Program
    {
        public static readonly Logger logger = Logger.defaultLogger;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.ThreadException += Application_ThreadException;
            Application.ApplicationExit += Application_ApplicationExit;
            Application.Run(new Blueprintz());
        }

        private static void Application_ApplicationExit(object sender, EventArgs e)
        {
            logger.Info("Closing Main Thread.");
        }

        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            FailHandler.HandleException(e.Exception);
        }
    }
}