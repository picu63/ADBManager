using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ScrcpyWindow
{
    public partial class ScrcpyWin : Form
    {
        Process proc;
        public ScrcpyWin()
        {
            InitializeComponent();
        }

        private void ScrcpyWin_Load(object sender, EventArgs e)
        {
            proc = Process.Start("notepad.exe");
            proc.WaitForInputIdle();

            while (proc.MainWindowHandle == IntPtr.Zero)
            {
                Thread.Sleep(100);
                proc.Refresh();
            }
            WinMethods.SetParent(proc.MainWindowHandle, this.Handle);
            var width = this.Size.Width;
            var height = this.Size.Height;
            WinMethods.SetWindowLongPtr(new HandleRef(null, proc.MainWindowHandle), -16, new IntPtr(0x10000000));
            WinMethods.MoveWindow(proc.MainWindowHandle, 0, 0, (int)width-10, (int)height-10, true);
        }

        private void ScrcpyWin_Resize(object sender, EventArgs e)
        {
            var width = this.Size.Width;
            var height = this.Size.Height;
            WinMethods.MoveWindow(proc.MainWindowHandle, 0, 0, (int)width-10, (int)height-10, true);

        }
    }
}
