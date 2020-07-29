namespace SuperAdbUI
{
    partial class ScrcpyWin
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
            this.powerBtn = new System.Windows.Forms.Button();
            this.scrcpyPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // powerBtn
            // 
            this.powerBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.powerBtn.Location = new System.Drawing.Point(168, 12);
            this.powerBtn.Name = "powerBtn";
            this.powerBtn.Size = new System.Drawing.Size(90, 23);
            this.powerBtn.TabIndex = 0;
            this.powerBtn.Text = "Power Button";
            this.powerBtn.UseVisualStyleBackColor = true;
            this.powerBtn.Click += new System.EventHandler(this.powerBtn_Click);
            // 
            // scrcpyPanel
            // 
            this.scrcpyPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.scrcpyPanel.Location = new System.Drawing.Point(-1, 43);
            this.scrcpyPanel.Name = "scrcpyPanel";
            this.scrcpyPanel.Size = new System.Drawing.Size(270, 480);
            this.scrcpyPanel.TabIndex = 1;
            this.scrcpyPanel.Resize += new System.EventHandler(this.scrcpyPanel_Resize);
            // 
            // ScrcpyWin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(270, 525);
            this.Controls.Add(this.scrcpyPanel);
            this.Controls.Add(this.powerBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ScrcpyWin";
            this.Text = "ScrcpyWin";
            this.Load += new System.EventHandler(this.ScrcpyWin_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button powerBtn;
        private System.Windows.Forms.Panel scrcpyPanel;
    }
}