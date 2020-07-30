using SuperAdbLibrary;
using SuperAdbUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using SuperAdbLibrary;
using SuperAdbLibrary.Android;

namespace SuperAdbUI
{
    public partial class ScrcpyWin : Form
    {
        Process proc;
        private static float ratio;
        public ScrcpyWin()
        {
            InitializeComponent();
        }

        private void ScrcpyWin_Load(object sender, EventArgs e)
        {
            proc = Process.Start(ScrcpyWrapper.GetStartInfo("d5f27533", Screen.AllScreens.Select(s => Math.Min(s.Bounds.Width, s.Bounds.Height)).Max()));
            proc.WaitForInputIdle();

            while (proc.MainWindowHandle == IntPtr.Zero)
            {
                Thread.Sleep(100);
                proc.Refresh();
            }
            WinMethods.SetParent(proc.MainWindowHandle, this.scrcpyPanel.Handle);
            var width = this.scrcpyPanel.Size.Width;
            var height = this.scrcpyPanel.Size.Height;
            WinMethods.SetWindowLongPtr(new HandleRef(null, proc.MainWindowHandle), -16, new IntPtr(0x10000000));
            WinMethods.MoveWindow(proc.MainWindowHandle, 0, 0, (int)width, (int)height, true);
            ratio = (float)height / (float)width;
        }

        private void scrcpyPanel_Resize(object sender, EventArgs e)
        {
            float width = (float)this.scrcpyPanel.Size.Height/ratio;
            float height = (float)this.scrcpyPanel.Size.Height;
            if (proc != null)
            {
                WinMethods.MoveWindow(proc.MainWindowHandle, this.scrcpyPanel.Width - (int)width, 0, (int)width, (int)height, true);
            }
        }

        private void powerBtn_Click(object sender, EventArgs e)
        {
            AdbWrapper.PushPowerButton();
        }
    }
}
