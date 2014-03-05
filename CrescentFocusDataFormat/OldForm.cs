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
    public partial class OldForm : Form
    {
        public OldForm()
        {
            InitializeComponent();
        }

        private void btn_Browse_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();

            txt_fileName.Text = openFileDialog1.FileName;
        }

        private void lst_fileFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            //label1.Text = lst_fileFormat.SelectedItem.ToString();
            //label2.Text = openFileDialog1.SafeFileName;
        }

        private void btn_format_Click(object sender, EventArgs e)
        {
            string inFilename, outFilename, directory, outLine; //line
            StreamReader srFile;
            StreamWriter swFile;
            long count;
            long CDP, X, Y, time, vel, currentCDP, lineNum;
            string[] file;

            outLine = "";
            count = 0;
            lineNum=0;
            currentCDP = 0;

            txt_file.Text = "";

            directory = txt_fileName.Text.Substring(0, txt_fileName.Text.IndexOf(openFileDialog1.SafeFileName));
            inFilename = directory + openFileDialog1.SafeFileName;
            outFilename = directory + "reformat_" + openFileDialog1.SafeFileName;

            file = File.ReadAllLines(inFilename);
            //srFile = new StreamReader(File.Open(inFilename, FileMode.Open, FileAccess.Read));
            swFile = new StreamWriter(File.Open(outFilename, FileMode.Create, FileAccess.Write));
            
CDP = time = vel = 0;
            //line = srFile.ReadLine();
            foreach(string line in File.ReadAllLines(inFilename))
            //while (!srFile.EndOfStream)
            {
                long[] nums = parseLine(line.Split(' '));
                CDP = nums[0];
                X = nums[1];
                Y = nums[2];
                time = nums[3];
                vel = nums[4];
                count++;
                lineNum++;

                if (CDP != currentCDP)
                {
                    if (lineNum > 1)
                        writeLine(ref swFile, outLine);                        
                    writeLine(ref swFile, "HANDVEL " + CDP);
                    if (lineNum > 1)
                        outLine = "";
                    currentCDP = CDP;
                    count = 1;
                }

                outLine = createOutLine(outLine, time, vel);

                if (count == 4)
                {
                    writeLine(ref swFile, outLine);
                    outLine = "";
                    count = 0;
                }
            }

            swFile.Close();
        }

        private long[] parseLine(string[] inLine)
        {
            List<long> retLine = new List<long>();

            foreach (string parseString in inLine)
            {
                if (!string.IsNullOrEmpty(parseString))
                    retLine.Add((long) Math.Truncate(decimal.Parse(parseString)));
            }

            return retLine.ToArray();
        }
       
        private void writeLine(ref StreamWriter swFile, string outLine)
        {
            swFile.WriteLine(outLine);
            txt_file.Text = txt_file.Text + outLine + "\n";
        }

        private string createOutLine(string outLine, long time, long vel)
        {
            return outLine + string.Format("{0,-8}", time) + string.Format("{0,-8}", vel);
        }

    
    }
}