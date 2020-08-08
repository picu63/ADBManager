using System;

namespace AdbManager.GUI
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.scrcpyMainPanel = new System.Windows.Forms.Panel();
            this.devicesCB = new System.Windows.Forms.ComboBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.fileManagerTabPage = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.refreshDevicesBtn = new System.Windows.Forms.Button();
            this.connectBt = new System.Windows.Forms.Button();
            this.getDirBtn = new System.Windows.Forms.Button();
            this.fileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainFrmMenuStrip = new System.Windows.Forms.MenuStrip();
            this.commandsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutAdbManagerMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl.SuspendLayout();
            this.mainFrmMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // scrcpyMainPanel
            // 
            this.scrcpyMainPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.scrcpyMainPanel.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.scrcpyMainPanel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.scrcpyMainPanel.Location = new System.Drawing.Point(775, 34);
            this.scrcpyMainPanel.Name = "scrcpyMainPanel";
            this.scrcpyMainPanel.Size = new System.Drawing.Size(265, 471);
            this.scrcpyMainPanel.TabIndex = 0;
            this.scrcpyMainPanel.Resize += new System.EventHandler(this.scrcpyMainPanel_Resize);
            // 
            // devicesCB
            // 
            this.devicesCB.FormattingEnabled = true;
            this.devicesCB.Location = new System.Drawing.Point(12, 34);
            this.devicesCB.Name = "devicesCB";
            this.devicesCB.Size = new System.Drawing.Size(129, 23);
            this.devicesCB.TabIndex = 2;
            this.devicesCB.SelectedIndexChanged += new System.EventHandler(this.devicesCB_SelectedIndexChanged);
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tabControl.Controls.Add(this.fileManagerTabPage);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Location = new System.Drawing.Point(12, 78);
            this.tabControl.Name = "tabControl";
            this.tabControl.Padding = new System.Drawing.Point(0, 0);
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(757, 427);
            this.tabControl.TabIndex = 3;
            // 
            // fileManagerTabPage
            // 
            this.fileManagerTabPage.Location = new System.Drawing.Point(4, 24);
            this.fileManagerTabPage.Name = "fileManagerTabPage";
            this.fileManagerTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.fileManagerTabPage.Size = new System.Drawing.Size(749, 399);
            this.fileManagerTabPage.TabIndex = 0;
            this.fileManagerTabPage.Text = "File Manager";
            this.fileManagerTabPage.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(749, 399);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // refreshDevicesBtn
            // 
            this.refreshDevicesBtn.Location = new System.Drawing.Point(202, 29);
            this.refreshDevicesBtn.Name = "refreshDevicesBtn";
            this.refreshDevicesBtn.Size = new System.Drawing.Size(75, 23);
            this.refreshDevicesBtn.TabIndex = 4;
            this.refreshDevicesBtn.Text = "Refresh";
            this.refreshDevicesBtn.UseVisualStyleBackColor = true;
            this.refreshDevicesBtn.Click += new System.EventHandler(this.refreshDevicesBtn_Click);
            // 
            // connectBt
            // 
            this.connectBt.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("connectBt.BackgroundImage")));
            this.connectBt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.connectBt.Location = new System.Drawing.Point(147, 29);
            this.connectBt.Name = "connectBt";
            this.connectBt.Size = new System.Drawing.Size(31, 31);
            this.connectBt.TabIndex = 5;
            this.connectBt.UseVisualStyleBackColor = true;
            this.connectBt.Click += new System.EventHandler(this.connectBt_Click);
            // 
            // getDirBtn
            // 
            this.getDirBtn.Location = new System.Drawing.Point(309, 29);
            this.getDirBtn.Name = "getDirBtn";
            this.getDirBtn.Size = new System.Drawing.Size(75, 23);
            this.getDirBtn.TabIndex = 6;
            this.getDirBtn.Text = "Get";
            this.getDirBtn.UseVisualStyleBackColor = true;
            this.getDirBtn.Click += new System.EventHandler(this.getDirBtn_Click);
            // 
            // fileMenuItem
            // 
            this.fileMenuItem.Name = "fileMenuItem";
            this.fileMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileMenuItem.Text = "File";
            // 
            // mainFrmMenuStrip
            // 
            this.mainFrmMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenuItem,
            this.commandsMenuItem,
            this.helpMenuItem});
            this.mainFrmMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainFrmMenuStrip.Name = "mainFrmMenuStrip";
            this.mainFrmMenuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.mainFrmMenuStrip.Size = new System.Drawing.Size(1052, 24);
            this.mainFrmMenuStrip.TabIndex = 7;
            // 
            // commandsMenuItem
            // 
            this.commandsMenuItem.Name = "commandsMenuItem";
            this.commandsMenuItem.Size = new System.Drawing.Size(81, 20);
            this.commandsMenuItem.Text = "Commands";
            // 
            // helpMenuItem
            // 
            this.helpMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutAdbManagerMenuItem});
            this.helpMenuItem.Name = "helpMenuItem";
            this.helpMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpMenuItem.Text = "Help";
            // 
            // aboutAdbManagerMenuItem
            // 
            this.aboutAdbManagerMenuItem.Name = "aboutAdbManagerMenuItem";
            this.aboutAdbManagerMenuItem.Size = new System.Drawing.Size(179, 22);
            this.aboutAdbManagerMenuItem.Text = "About AdbManager";
            this.aboutAdbManagerMenuItem.Click += new System.EventHandler(this.aboutAdbManagerMenuItem_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1052, 517);
            this.Controls.Add(this.getDirBtn);
            this.Controls.Add(this.connectBt);
            this.Controls.Add(this.scrcpyMainPanel);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.refreshDevicesBtn);
            this.Controls.Add(this.devicesCB);
            this.Controls.Add(this.mainFrmMenuStrip);
            this.MainMenuStrip = this.mainFrmMenuStrip;
            this.MinimumSize = new System.Drawing.Size(650, 450);
            this.Name = "MainWindow";
            this.Text = "AdbManager";
            this.Load += new System.EventHandler(this.SuperAdbMain_Load);
            this.ResizeEnd += new System.EventHandler(this.SuperAdbMain_ResizeEnd);
            this.tabControl.ResumeLayout(false);
            this.mainFrmMenuStrip.ResumeLayout(false);
            this.mainFrmMenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel scrcpyMainPanel;
        private System.Windows.Forms.ComboBox devicesCB;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage fileManagerTabPage;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button refreshDevicesBtn;
        private System.Windows.Forms.Button connectBt;
        private System.Windows.Forms.Button getDirBtn;
        private System.Windows.Forms.ToolStripMenuItem fileMenuItem;
        private System.Windows.Forms.MenuStrip mainFrmMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem commandsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutAdbManagerMenuItem;
    }
}