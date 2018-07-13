using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JLyshoel.FontInstaller.GUI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            FileUploadLabel.AllowDrop = true;
            FileUploadLabel.DragEnter += new DragEventHandler(FileUploadLabel_DragEnter);
            FileUploadLabel.DragDrop += new DragEventHandler(FileUploadLabel_DragDrop); 
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        void FileUploadLabel_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        void FileUploadLabel_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files)
            {
                InstallFont(file);
            }
        }

        private void FileUploadLabel_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                foreach (string file in openFileDialog1.FileNames)
                {
                    InstallFont(file);
                }
            }
        }

        private void clearLogBtn_Click(object sender, EventArgs e)
        {
            InstallLog.Text = "";
        }

        private void InstallFont(string stringFontFile)
        {
            WriteToLog("Found file: " + stringFontFile);

        }

        private void WriteToLog(string line)
        {
            InstallLog.Text += line + "\r\n";
        }
    }
}
