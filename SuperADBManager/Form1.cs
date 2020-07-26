using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection.Emit;
using System.Runtime.InteropServices;

namespace SuperADBManager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog od = new OpenFileDialog();     
            if (od.ShowDialog() == DialogResult.OK)       
            {                                             
                                                          
                Process proc = Process.Start(od.FileName);
                proc.WaitForInputIdle();

                while (proc.MainWindowHandle == IntPtr.Zero)
                {
                    Thread.Sleep(100);
                    proc.Refresh();
                }
                var host = new System.Windows.Forms.Control();
                host.Focus();

                WinMethods.SetParent(proc.MainWindowHandle, this.panel1.Handle);
                WinMethods.SetWindowLongPtr(new HandleRef(null, proc.MainWindowHandle), -16, new IntPtr(0x10000000));
            
            }
        }
    }
}
