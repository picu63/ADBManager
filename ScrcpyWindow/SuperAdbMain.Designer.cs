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
            this.devicesCB = new System.Windows.Forms.ComboBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.refreshDevicesBtn = new System.Windows.Forms.Button();
            this.connectBtn = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // scrcpyMainPanel
            // 
            this.scrcpyMainPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.scrcpyMainPanel.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.scrcpyMainPanel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.scrcpyMainPanel.Location = new System.Drawing.Point(825, 11);
            this.scrcpyMainPanel.Name = "scrcpyMainPanel";
            this.scrcpyMainPanel.Size = new System.Drawing.Size(323, 589);
            this.scrcpyMainPanel.TabIndex = 0;
            this.scrcpyMainPanel.Resize += new System.EventHandler(this.scrcpyMainPanel_Resize);
            // 
            // devicesCB
            // 
            this.devicesCB.FormattingEnabled = true;
            this.devicesCB.Location = new System.Drawing.Point(12, 12);
            this.devicesCB.Name = "devicesCB";
            this.devicesCB.Size = new System.Drawing.Size(83, 23);
            this.devicesCB.TabIndex = 2;
            this.devicesCB.SelectedIndexChanged += new System.EventHandler(this.devicesCB_SelectedIndexChanged);
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Location = new System.Drawing.Point(12, 47);
            this.tabControl.Name = "tabControl";
            this.tabControl.Padding = new System.Drawing.Point(0, 0);
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(807, 557);
            this.tabControl.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(799, 529);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(799, 529);
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
            this.refreshDevicesBtn.Click += new System.EventHandler(this.refreshDevicesBtn_Click);
            // 
            // connectBtn
            // 
            this.connectBtn.Location = new System.Drawing.Point(101, 11);
            this.connectBtn.Name = "connectBtn";
            this.connectBtn.Size = new System.Drawing.Size(75, 23);
            this.connectBtn.TabIndex = 5;
            this.connectBtn.Text = "Connect";
            this.connectBtn.UseVisualStyleBackColor = true;
            this.connectBtn.Click += new System.EventHandler(this.connectBtn_Click);
            // 
            // SuperAdbMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1160, 616);
            this.Controls.Add(this.scrcpyMainPanel);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.connectBtn);
            this.Controls.Add(this.refreshDevicesBtn);
            this.Controls.Add(this.devicesCB);
            this.Name = "SuperAdbMain";
            this.Text = "SuperAdbMain";
            this.Load += new System.EventHandler(this.SuperAdbMain_Load);
            this.tabControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel scrcpyMainPanel;
        private System.Windows.Forms.ComboBox devicesCB;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button refreshDevicesBtn;
        private System.Windows.Forms.Button connectBtn;
    }
}