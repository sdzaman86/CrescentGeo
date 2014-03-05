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
    // Split one file into multiple files based on fault lines
    public partial class SplitFilesByFaultLines : Form
    {
        public SplitFilesByFaultLines()
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

        private void SaveToBrowseClicked(object sender, EventArgs e)
        {
            if (this.folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                this.saveToDir.Text = folderBrowserDialog.SelectedPath;
            }
        }

        BackgroundWorker worker;
        private string[] lines;
        private void StartClicked(object sender, EventArgs e)
        {
            lines = lines = File.ReadAllLines(this.filePathTextBox.Text);
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
            string currentFault = string.Empty;
            StringBuilder fileData = new StringBuilder();
            for(int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];
                string fault = ParseLine(line);
                
                // If this is a different fault, we need to output to a file 
                if (fault != currentFault)
                {
                    if (currentFault != string.Empty)
                    {
                        // Save to file
                        SaveToFile(currentFault, fileData);
                    }

                    // Set the new fault
                    currentFault = fault;
                    // Clear the data
                    fileData = new StringBuilder();
                }
                else
                {
                    // This is the same fault, add it to the data string
                    fileData.AppendLine(line);
                }

                worker.ReportProgress(i);
            }

            if(!string.IsNullOrEmpty(fileData.ToString()))
                SaveToFile(currentFault, fileData);
        }

        private void SaveToFile(string fileName, StringBuilder data)
        {
            string filePath = this.saveToDir.Text + "\\" + fileName + ".txt";
            File.WriteAllText(filePath, data.ToString());
        }

        private string ParseLine(string line)
        {
            StringBuilder fault = new StringBuilder();
            List<String> retLine = new List<String>();
            line = line.Replace('\t', ' ');

            foreach (string parseString in line.Split(' '))
            {
                if (!string.IsNullOrEmpty(parseString))
                {
                    retLine.Add(parseString);
                }
            }

            // Get all the tokens between 5th index and the 4th before last
            int endIndex = retLine.Count - 3; // we're ignoring the last 3
            int startIndex = 6;
            for (int i = startIndex; i < endIndex; i++)
            {
                fault.Append(retLine[i]);
            }

            return fault.ToString();
        }
    }
}