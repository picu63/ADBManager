using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using System.Diagnostics;
using System.IO;

namespace SuperADBManager
{
    public partial class Form2 : Form
    {   
        private System.Windows.Forms.Control host;
        private Process proc;
        //https://www.codeproject.com/Questions/413778/Removing-a-Window-Border-No-Winform




        private readonly string WINDOW_NAME = "TC52";  //name of the window
        private const int GWL_STYLE = -16;              //hex constant for style changing
        private const int WS_BORDER = 0x00800000;       //window with border
        private const int WS_CAPTION = 0x00C00000;      //window with a title bar
        private const int WS_SYSMENU = 0x00080000;      //window with no borders etc.
        private const int WS_MINIMIZEBOX = 0x00020000;  //window with minimizebox
        private const int WS_CHILD = 0x40000000;  
        private const uint WS_POPUP = 0x80000000;  

        public Form2()
        {
            InitializeComponent();
        }
        static string notepad = "notepad.exe";
        private void button1_Click(object sender, EventArgs e)
        {
            proc = Process.Start(notepad);
            proc.WaitForInputIdle();

            while (proc.MainWindowHandle == IntPtr.Zero)
            {
                Thread.Sleep(100);
                proc.Refresh();
            }
            StealWindow();
            
        }

        /// <summary>
        /// Steals the window from the desktop and embeds it.
        /// </summary>
        private void StealWindow()
        {
            // Create host surface
            host = new System.Windows.Forms.Control();
            host.Focus();

            WinMethods.SetParent(proc.MainWindowHandle, this.panel1.Handle);
            WinMethods.SetWindowLongPtr(new HandleRef(null, proc.MainWindowHandle), -16, new IntPtr(0x10000000));

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
