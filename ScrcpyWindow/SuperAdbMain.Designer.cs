namespace SuperAdbUI
{
    partial class SuperAdbMain
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
            this.scrcpyMainPanel = new System.Windows.Forms.Panel();
            this.connectedDevicesCbox = new System.Windows.Forms.ComboBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.refreshDevicesBtn = new System.Windows.Forms.Button();
            this.connectDeviceBtn = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // scrcpyMainPanel
            // 
            this.scrcpyMainPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.scrcpyMainPanel.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.scrcpyMainPanel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.scrcpyMainPanel.Location = new System.Drawing.Point(815, 12);
            this.scrcpyMainPanel.Name = "scrcpyMainPanel";
            this.scrcpyMainPanel.Size = new System.Drawing.Size(333, 592);
            this.scrcpyMainPanel.TabIndex = 0;
            this.scrcpyMainPanel.Resize += new System.EventHandler(this.scrcpyMainPanel_Resize);
            // 
            // connectedDevicesCbox
            // 
            this.connectedDevicesCbox.FormattingEnabled = true;
            this.connectedDevicesCbox.Location = new System.Drawing.Point(12, 12);
            this.connectedDevicesCbox.Name = "connectedDevicesCbox";
            this.connectedDevicesCbox.Size = new System.Drawing.Size(83, 23);
            this.connectedDevicesCbox.TabIndex = 2;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 41);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Padding = new System.Drawing.Point(0, 0);
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(797, 563);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(789, 535);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(789, 535);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // refreshDevicesBtn
            // 
            this.refreshDevicesBtn.Location = new System.Drawing.Point(182, 12);
            this.refreshDevicesBtn.Name = "refreshDevicesBtn";
            this.refreshDevicesBtn.Size = new System.Drawing.Size(75, 23);
            this.refreshDevicesBtn.TabIndex = 4;
            this.refreshDevicesBtn.Text = "Refresh";
            this.refreshDevicesBtn.UseVisualStyleBackColor = true;
            // 
            // connectDeviceBtn
            // 
            this.connectDeviceBtn.Location = new System.Drawing.Point(101, 11);
            this.connectDeviceBtn.Name = "connectDeviceBtn";
            this.connectDeviceBtn.Size = new System.Drawing.Size(75, 23);
            this.connectDeviceBtn.TabIndex = 5;
            this.connectDeviceBtn.Text = "Connect";
            this.connectDeviceBtn.UseVisualStyleBackColor = true;
            // 
            // SuperAdbMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1160, 616);
            this.Controls.Add(this.connectDeviceBtn);
            this.Controls.Add(this.refreshDevicesBtn);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.connectedDevicesCbox);
            this.Controls.Add(this.scrcpyMainPanel);
            this.Name = "SuperAdbMain";
            this.Text = "SuperAdbMain";
            this.Load += new System.EventHandler(this.SuperAdbMain_Load);
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel scrcpyMainPanel;
        private System.Windows.Forms.ComboBox connectedDevicesCbox;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button refreshDevicesBtn;
        private System.Windows.Forms.Button connectDeviceBtn;
    }
}