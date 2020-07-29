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
        ScrcpyWin scrcpyFrm;
        public SuperAdbMain()
        {
            InitializeComponent();
        }

        private void SuperAdbMain_Load(object sender, EventArgs e)
        {
            scrcpyFrm = new ScrcpyWin() { TopLevel = false, TopMost = true };
            scrcpyFrm.Size = scrcpyMainPanel.Size;
            //frm.FormBorderStyle = (FormBorderStyle)cboFormStyle.SelectedIndex;
            this.scrcpyMainPanel.Controls.Add(scrcpyFrm);
            scrcpyFrm.Show();
        }

        private void scrcpyMainPanel_Resize(object sender, EventArgs e)
        {
            scrcpyFrm.Size = this.scrcpyMainPanel.Size;
        }
    }
}
