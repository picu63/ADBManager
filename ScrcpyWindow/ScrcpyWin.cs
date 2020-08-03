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
using SuperAdbLibrary.Android;
using System.Threading.Tasks;
using SuperAdbLibrary.Models;
using System.Collections.ObjectModel;

namespace SuperAdbUI
{
    public partial class ScrcpyWin : Form
    {
        /// <summary>
        /// Process of scrcpy.
        /// </summary>
        Process proc;
        private float ratio;
        private List<Device> devices;
        public ScrcpyWin()
        {
            InitializeComponent();
        }


        private void scrcpyPanel_Resize(object sender, EventArgs e)
        {
            float width = (float)this.scrcpyPanel.Size.Height/ratio;
            float height = (float)this.scrcpyPanel.Size.Height;
            if (proc != null)
            {
                WinMethods.MoveWindow(proc.MainWindowHandle, 0, 0, (int)width, (int)height, true);
            }
        }

        private void powerBtn_Click(object sender, EventArgs e)
        {
            AdbWrapper.SendKeycode(AdbWrapper.KeyEvent.POWER_BUTTON);
        }



        private void ScrcpyWin_Load(object sender, EventArgs e)
        {

        }

        internal void RunScrcpy(Device currentDevice)
        {
            proc = Process.Start(ScrcpyWrapper.GetStartInfo(currentDevice.ID, Screen.AllScreens.Select(s => Math.Min(s.Bounds.Width, s.Bounds.Height)).Max()));
            proc.WaitForInputIdle();

            while (proc.MainWindowHandle == IntPtr.Zero)
            {
                Thread.Sleep(100);
                proc.Refresh();
            }
            WinMethods.SetParent(proc.MainWindowHandle, this.scrcpyPanel.Handle);
            WinMethods.SetWindowLongPtr(new HandleRef(null, proc.MainWindowHandle), -16, new IntPtr(0x10000000));
            var width = (float)this.scrcpyPanel.Size.Height / ratio;
            var height = (float)this.scrcpyPanel.Size.Height;
            WinMethods.MoveWindow(proc.MainWindowHandle, 0, 0, (int)width, (int)height, true);
        }




    }
}