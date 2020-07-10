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
                
                //SetParent(proc.MainWindowHandle, this.panel1.Handle);
                //SetParent(proc.Handle, this.Handle);
                SetParent(proc.MainWindowHandle, this.panel1.Handle);
            
            }
        }
    }
}
