using System;
using System.Windows.Forms;

namespace windotool
{
    static class Program
    {

        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
                static extern bool AttachConsole( int dwProcessId );

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            AttachConsole(-1);
            SendKeys.SendWait("a");
            Console.WriteLine("Sent: a");
            // Application.SetHighDpiMode(HighDpiMode.SystemAware);
            // Application.EnableVisualStyles();
            // Application.SetCompatibleTextRenderingDefault(false);
            // Application.Run(new Form1());
        }
    }
}
