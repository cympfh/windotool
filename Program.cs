using ConsoleAppFramework;
using Microsoft.Extensions.Hosting;
using System.Windows.Forms;
using System;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace windotool
{
    class Program : ConsoleAppBase
    {
        [DllImport("kernel32.dll")]
        static extern bool AttachConsole(int dwProcessId);

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

        [DllImport("user32.dll")]
        static extern void mouse_event(long dwFlags, long dx, long dy, uint dwData, UIntPtr dwExtraInfo);

        [Flags]
        public enum MouseEvent : long
        {
            Move = 0x0001,
            LeftDown = 0x0002,
            LeftUp = 0x0004,
            RightDown = 0x0008,
            RightUp = 0x0010,
            MiddleDown = 0x0020,
            MiddleUp = 0x0040,
            Absolute = 0x8000
        }

        [Command("mousemove")]
        public void MouseMove(
            [Option(0)] long x,
            [Option(1)] long y,
            [Option("v")] bool verbose = false
        )
        {
            var scr = Screen.PrimaryScreen.Bounds;
            var normalized_x = (long)Math.Round((float)(x) * 65535 / scr.Width);
            var normalized_y = (long)Math.Round((float)(y) * 65535 / scr.Height);
            mouse_event((long)(MouseEvent.Move | MouseEvent.Absolute), normalized_x, normalized_y, 0, UIntPtr.Zero);
            if (verbose)
            {
                Console.WriteLine($"Moved to {x} {y}");
            }
        }


        [Command("mousedown")]
        public void MouseDown(
            [Option(0)] uint button,
            [Option("v")] bool verbose = false
        )
        {
            var e = MouseEvent.LeftDown;
            if (button == 2) { e = MouseEvent.MiddleDown; }
            else if (button == 3) { e = MouseEvent.RightDown; }
            mouse_event((long)(e), 0, 0, 0, UIntPtr.Zero);
            if (verbose)
            {
                Console.WriteLine($"MouseDown: {button}");
            }
        }


        [Command("mouseup")]
        public void MouseUp(
            [Option(0)] uint button,
            [Option("v")] bool verbose = false
        )
        {
            var e = MouseEvent.LeftUp;
            if (button == 2) { e = MouseEvent.MiddleUp; }
            else if (button == 3) { e = MouseEvent.RightUp; }
            mouse_event((long)(e), 0, 0, 0, UIntPtr.Zero);
            if (verbose)
            {
                Console.WriteLine($"MouseUp: {button}");
            }
        }

        [Command("click")]
        public void Click(
            [Option(0)] uint button,
            [Option("v")] bool verbose = false
        )
        {
            var e = MouseEvent.LeftDown | MouseEvent.LeftUp;
            if (button == 2) { e = MouseEvent.MiddleDown | MouseEvent.MiddleUp; }
            else if (button == 3) { e = MouseEvent.RightDown | MouseEvent.RightUp; }
            mouse_event((long)(e), 0, 0, 0, UIntPtr.Zero);
            if (verbose)
            {
                Console.WriteLine($"Clicked: {button}");
            }
        }
    }
}
