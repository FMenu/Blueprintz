using System.Runtime.InteropServices;

namespace JumpinFrog.Logging
{
    public static class CustomConsole
    {
        /// <summary>
        /// Attaches a Console to a Windows Forms Application.
        /// (It only works if the SubSystem is Windows)
        /// It can be controlled with the Default Console Class, which is already included in the .Net Framework.
        /// </summary>
        public static void AttachConsole()
        {
            AllocConsole();
        }

        // DLLImport
        [DllImport("kernel32.dll", SetLastError = true)]

        // Marshaling
        [return: MarshalAs(UnmanagedType.Bool)]

        // Defining the Function Which Shows the Console
        private static extern bool AllocConsole();
    }
}
