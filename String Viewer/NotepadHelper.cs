using System;
using System.Runtime.InteropServices;
using System.Diagnostics;


namespace Notepad
{
    public static class NotepadHelper
    {
        [DllImport("user32.dll", EntryPoint = "SetWindowText")]
        private static extern int SetWindowText(IntPtr hWnd, string text);

        [DllImport("user32.dll", EntryPoint = "FindWindowEx")]
        private static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        private static extern int SendMessage(IntPtr hWnd, int uMsg, int wParam, string lParam);


        /// <summary>
        /// Starts Notepad with the given <paramref name="text"/> and <paramref name="title"/>.
        /// </summary>
        /// <param name="text">The text to show in Notepad.</param>
        /// <param name="title">The title to show on Notepad.</param>
        /// <remarks>
        /// Uses code found <see href="https://stackoverflow.com/questions/7613576/how-to-open-text-in-notepad-from-net/7613901#14295249">here</see>.
        /// </remarks>
        public static void ShowText(string text = null, string title = null)
        {
            Process notepad = Process.Start(new ProcessStartInfo("notepad.exe"));
            if (notepad != null)
            {
                notepad.WaitForInputIdle();

                if (!string.IsNullOrEmpty(title))
                    SetWindowText(notepad.MainWindowHandle, title);

                if (!string.IsNullOrEmpty(text))
                {
                    IntPtr child = FindWindowEx(notepad.MainWindowHandle, new IntPtr(0), "Edit", null);
                    SendMessage(child, 0x000C, 0, text);
                }
            }
        }
    }
}