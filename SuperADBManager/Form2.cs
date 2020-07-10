using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace SuperADBManager
{
    public partial class Form2 : Form
    {
        //Import window changing function
        [DllImport("USER32.DLL")]
        public static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        //Import find window function
        [DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
        static extern IntPtr FindWindowByCaption(IntPtr ZeroOnly, string lpWindowName);

        //Import force window draw function
        [DllImport("user32.dll")]
        static extern bool DrawMenuBar(IntPtr hWnd);
        [DllImport("user32.dll")]
        static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
        public static extern IntPtr SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int Y, int cx, int cy, int wFlags);



        private readonly string WINDOW_NAME = "TC52";  //name of the window
        private const int GWL_STYLE = -16;              //hex constant for style changing
        private const int WS_BORDER = 0x00800000;       //window with border
        private const int WS_CAPTION = 0x00C00000;      //window with a title bar
        private const int WS_SYSMENU = 0x00080000;      //window with no borders etc.
        private const int WS_MINIMIZEBOX = 0x00020000;  //window with minimizebox

        public Form2()
        {
            InitializeComponent();
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            IntPtr window = FindWindowByCaption(IntPtr.Zero, WINDOW_NAME);
            SetWindowLong(window, GWL_STYLE, WS_SYSMENU);
            SetWindowPos(window, -2, 0, 0, 800, 600, 0x0040);
            //this.WindowState = FormWindowState.Maximized;
            DrawMenuBar(window);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            IntPtr window = FindWindowByCaption(IntPtr.Zero, WINDOW_NAME);
            SetParent(window, this.Handle);
            //SetWindowLong(window, GWL_STYLE, WS_CAPTION | WS_BORDER | WS_SYSMENU | WS_MINIMIZEBOX);
            //this.WindowState = FormWindowState.Normal;
            //DrawMenuBar(window);
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
