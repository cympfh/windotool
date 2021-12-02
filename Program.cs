using ConsoleAppFramework;
using Microsoft.Extensions.Hosting;
using System.Windows.Forms;
using System;
using System.Threading.Tasks;

namespace windotool
{
    class Program : ConsoleAppBase
    {
        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        static extern bool AttachConsole( int dwProcessId );

        /// <summary>
        /// windotool Entrypoint
        /// </summary>
        [STAThread]
        static async Task Main(string[] args)
        {
            AttachConsole(-1);
            await Host.CreateDefaultBuilder().RunConsoleAppFrameworkAsync<Program>(args);
        }

        [Command("key")]
        public void Key(
            [Option(0)] string key,
            [Option("v")] bool verbose = false)
        {
            SendKeys.SendWait(key);
            if (verbose)
            {
                Console.WriteLine($"Sent Key: {key}");
            }
        }
    }
}
