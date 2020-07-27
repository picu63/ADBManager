using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SuperAdbUI
{
    public partial class SuperAdbMain : Form
    {
        public SuperAdbMain()
        {
            InitializeComponent();
        }

        private void SuperAdbMain_Load(object sender, EventArgs e)
        {
            ScrcpyWin frm = new ScrcpyWin() { TopLevel = false, TopMost = true };
            frm.Size = panel1.Size;
            //frm.FormBorderStyle = (FormBorderStyle)cboFormStyle.SelectedIndex;
            this.panel1.Controls.Add(frm);
            frm.Show();
        }
    }
}
