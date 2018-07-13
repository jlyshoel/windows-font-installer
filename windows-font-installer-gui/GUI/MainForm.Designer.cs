namespace JLyshoel.FontInstaller.GUI
{
    partial class MainForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.InstallLogLabel = new System.Windows.Forms.Label();
            this.FileUploadLabel = new System.Windows.Forms.Label();
            this.InstallLog = new System.Windows.Forms.TextBox();
            this.clearLogBtn = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(914, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem1});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.aboutToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem1
            // 
            this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            this.aboutToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.aboutToolStripMenuItem1.Text = "About";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Multiselect = true;
            // 
            // InstallLogLabel
            // 
            this.InstallLogLabel.AutoSize = true;
            this.InstallLogLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InstallLogLabel.Location = new System.Drawing.Point(396, 48);
            this.InstallLogLabel.Name = "InstallLogLabel";
            this.InstallLogLabel.Size = new System.Drawing.Size(62, 13);
            this.InstallLogLabel.TabIndex = 3;
            this.InstallLogLabel.Text = "Install log";
            // 
            // FileUploadLabel
            // 
            this.FileUploadLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.FileUploadLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FileUploadLabel.Location = new System.Drawing.Point(22, 64);
            this.FileUploadLabel.Name = "FileUploadLabel";
            this.FileUploadLabel.Size = new System.Drawing.Size(328, 410);
            this.FileUploadLabel.TabIndex = 4;
            this.FileUploadLabel.Text = "Drop files here or click to select";
            this.FileUploadLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.FileUploadLabel.Click += new System.EventHandler(this.FileUploadLabel_Click);
            // 
            // InstallLog
            // 
            this.InstallLog.BackColor = System.Drawing.SystemColors.Info;
            this.InstallLog.Location = new System.Drawing.Point(399, 64);
            this.InstallLog.Multiline = true;
            this.InstallLog.Name = "InstallLog";
            this.InstallLog.ReadOnly = true;
            this.InstallLog.Size = new System.Drawing.Size(503, 410);
            this.InstallLog.TabIndex = 5;
            // 
            // clearLogBtn
            // 
            this.clearLogBtn.Location = new System.Drawing.Point(827, 38);
            this.clearLogBtn.Name = "clearLogBtn";
            this.clearLogBtn.Size = new System.Drawing.Size(75, 23);
            this.clearLogBtn.TabIndex = 6;
            this.clearLogBtn.Text = "Clear log";
            this.clearLogBtn.UseVisualStyleBackColor = true;
            this.clearLogBtn.Click += new System.EventHandler(this.clearLogBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(914, 499);
            this.Controls.Add(this.clearLogBtn);
            this.Controls.Add(this.InstallLog);
            this.Controls.Add(this.FileUploadLabel);
            this.Controls.Add(this.InstallLogLabel);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximumSize = new System.Drawing.Size(930, 538);
            this.MinimumSize = new System.Drawing.Size(930, 538);
            this.Name = "Form1";
            this.Text = "Windows Font Installer";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label InstallLogLabel;
        private System.Windows.Forms.Label FileUploadLabel;
        private System.Windows.Forms.TextBox InstallLog;
        private System.Windows.Forms.Button clearLogBtn;
    }
}

