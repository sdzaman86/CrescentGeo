using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace CrescentFocusDataFormat
{
    // Right align the lines in a file
    public partial class RightAlignLines : Form
    {
        public RightAlignLines()
        {
            InitializeComponent();
        }

        private void BrowseButtonClicked(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.filePathTextBox.Text = openFileDialog.FileName;
            }
        }

        BackgroundWorker worker;
        private string[] lines;
        private void StartClicked(object sender, EventArgs e)
        {
            lines = File.ReadAllLines(this.filePathTextBox.Text);
            this.progressBar.Minimum = 0;
            this.progressBar.Maximum = lines.Length - 1;

            worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.DoWork += new DoWorkEventHandler(DoWork);
            worker.ProgressChanged += new ProgressChangedEventHandler(WorkerProgressChanged);
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(WorkerCompleted);

            worker.RunWorkerAsync();
        }

        void WorkerProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
        }

        private void DoWork(object sender, DoWorkEventArgs e)
        {
            ProcessFile();
        }

        private void WorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Done!");
        }

        private void ProcessFile()
        {
            StringBuilder fileData = new StringBuilder();

            int maxCharCount = GetMaxCharCount();

            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];
                if (line.Length < maxCharCount)
                {
                    StringBuilder spaces = new StringBuilder();
                    for (int spaceIndex = 0; spaceIndex < maxCharCount - line.Length; spaceIndex++)
                        spaces.Append(" ");
                    fileData.AppendLine(spaces.ToString() + line);
                }
                else
                    fileData.AppendLine(line);
                
                worker.ReportProgress(i);
            }

            SaveToFile(fileData);
        }

        private int GetMaxCharCount()
        {
            int maxChar = 0;
            foreach (string line in lines)
            {
                if (line.Length > maxChar)
                    maxChar = line.Length;
            }

            return maxChar;
        }

        private void SaveToFile(StringBuilder data)
        {
            string path = Path.GetDirectoryName(this.openFileDialog.FileName); ;
            string filePath = path + "\\" + "RightAlignedOutput" + ".txt";
            File.WriteAllText(filePath, data.ToString());
        }
    }
}