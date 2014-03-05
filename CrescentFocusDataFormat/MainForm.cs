using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Linq;

namespace CrescentFocusDataFormat
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        #region Buttons

        private void BrowseButtonClicked(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.filePathTextBox.Text = openFileDialog.FileName;
                ShowWizard();
            }
        }

        private void ShowWizard()
        {
            InputWizard wizard = new InputWizard(openFileDialog.FileName, ignoreAllText.Checked);
            if (wizard.ShowDialog() == DialogResult.OK)
            {
                String outputString = ProcessWizardData(wizard);
                output.Text = outputString;
            }
        }

        private void StartOverButtonClicked(object sender, EventArgs e)
        {
            ShowWizard();
        }

        #endregion Buttons

        #region Process Data

        private String ProcessWizardData(InputWizard wizard)
        {
            if (wizard.IsSimple)
            {
                if (wizard.OutputType == OutputType.HANDVEL)
                    return ProcessSimpleHandvel(wizard.FormattedTable, wizard.HeaderName, wizard.HeaderColumn, wizard.DesiredColumns);
                else if (wizard.OutputType == OutputType.HORIZON)
                    return ProcessSimpleHorizon(wizard.FormattedTable, wizard.DesiredColumns);
            }
            else
            {
                if (wizard.OutputType == OutputType.HANDVEL)
                    return ProcessCustomHandvel(wizard.FormattedTable, wizard.HeaderName, wizard.HeaderColumn, wizard.DesiredColumns);
            }

            return string.Empty;
        }

        private string CreateFormattedOutput(String output)
        {
            // If we can make this into an integer, do it, if not return the string that was passed in
            // in the 8 space format
            try
            {
                long outputLong = (long)Math.Truncate(decimal.Parse(output));
                return String.Format("{0,-8}", outputLong);
            }
            catch
            {
                return String.Format("{0,-8}", output);
            }
        }

        #region HANDVEL

        private String ProcessSimpleHandvel(DataTable table, String headerName, int headerNumberIndex, List<int> desiredColumns)
        {
            StringBuilder retString = new StringBuilder();

            String currentHeaderNumber = String.Empty;
            StringBuilder data = new StringBuilder();
            int dataValueCount = 0;
            foreach (DataRow row in table.Rows)
            {
                String headerNumber = (String)row[headerNumberIndex];

                // Compare the header number, if it's different, we need to start a new "section"
                if (!headerNumber.Trim().Equals(currentHeaderNumber.Trim()))
                {
                    // If there are data from previous "section" write it out to return string
                    if (!String.IsNullOrEmpty(data.ToString()))
                    {
                        retString.AppendLine(data.ToString());
                        data = new StringBuilder();
                        dataValueCount = 0;
                    }

                    // Start new section
                    retString.AppendLine(CreateFormattedOutput(headerName) + CreateFormattedOutput(headerNumber));
                    currentHeaderNumber = headerNumber;
                }

                HandleDesiredData(row, desiredColumns, retString, ref data, ref dataValueCount);
            }

            if (!String.IsNullOrEmpty(data.ToString()))
                retString.AppendLine(data.ToString());

            return retString.ToString();
        }

        private String ProcessCustomHandvel(DataTable table, String headerName, int headerNumberIndex, List<int> desiredColumns)
        {
            StringBuilder retString = new StringBuilder();

            StringBuilder data = new StringBuilder();
            int dataValueCount = 0;
            foreach (DataRow row in table.Rows)
            {
                if (IsHeaderRow(row))
                {
                    String headerNumber = (String)row[headerNumberIndex];

                    // If there are data from previous "section" write it out to return string
                    if (!String.IsNullOrEmpty(data.ToString()))
                    {
                        retString.AppendLine(data.ToString());
                        data = new StringBuilder();
                        dataValueCount = 0;
                    }

                    // Start new section
                    retString.AppendLine(CreateFormattedOutput(headerName) + CreateFormattedOutput(headerNumber));
                }
                else
                    HandleDesiredData(row, desiredColumns, retString, ref data, ref dataValueCount);
            }

            if (!String.IsNullOrEmpty(data.ToString()))
                retString.AppendLine(data.ToString());

            return retString.ToString();
        }

        private void HandleDesiredData(DataRow row, List<int> desiredColumns, StringBuilder retString, ref StringBuilder data, ref int dataValueCount)
        {
            foreach (int desiredColumn in desiredColumns)
            {
                String dataValue = (String)row[desiredColumn];

                // If there's no data, we don't want to add it
                if (dataValue == String.Empty) continue;

                // If we hit the limit for one line, we need to write it out to return string
                // and reset our string builder
                if (dataValueCount >= 8)
                {
                    retString.AppendLine(data.ToString());
                    data = new StringBuilder();
                    dataValueCount = 0;
                }

                data.Append(CreateFormattedOutput(dataValue));
                dataValueCount++;
            }
        }

        private bool IsHeaderRow(DataRow row)
        {
            foreach (object obj in row.ItemArray)
            {
                // If this value is string empty, we won't try to test it for header row.
                // For it to be a header row, it needs to have "real" text.
                String value = (String)obj;
                if (value == String.Empty) continue;

                // We will try to convert this object into a number, if we cannot convert it we will assume
                // that it's a string. If it's a string then this is a header row
                try
                {
                    decimal.Parse(value);
                }
                catch
                {
                    return true;
                }
            }

            return false;
        }

        #endregion HANDVEL

        #region HORIZON

        private String ProcessSimpleHorizon(DataTable table, List<int> desiredColumns)
        {
            Dictionary<int, HorizonFormat> desiredColumnLengthMappings = GetDesiredColumnLengthMapping(table, desiredColumns);
            StringBuilder data = new StringBuilder();
            foreach (DataRow row in table.Rows)
            {
                if (IsDesiredData(row))
                {
                    String line = HandleDesiredDataForHorizon(row, desiredColumnLengthMappings);
                    data.AppendLine(line);
                }
            }

            return data.ToString();
        }

        private Dictionary<int, HorizonFormat> GetDesiredColumnLengthMapping(DataTable table, List<int> desiredColumns)
        {
            Dictionary<int, HorizonFormat> retVal = new Dictionary<int, HorizonFormat>();

            foreach (int desiredCol in desiredColumns)
            {
                HorizonFormat format = GetColumnFormat(table, desiredCol);
                retVal.Add(desiredCol, format);
            }

            return retVal;
        }

        private HorizonFormat GetColumnFormat(DataTable table, int columnIndex)
        {
            HorizonFormat format = new HorizonFormat();

            foreach (DataRow row in table.Rows)
            {
                string data = Convert.ToString(row[columnIndex]);
                string[] dataTokens = data.Split('.');

                if (dataTokens.Length == 1)
                {
                    if (format.WholeNumberCount < data.Length)
                        format.WholeNumberCount = data.Length;
                }
                else
                {
                    if (format.WholeNumberCount < dataTokens[0].Length)
                        format.WholeNumberCount = dataTokens[0].Length;
                    if (format.DecimalPlaceCount < dataTokens[1].Length)
                        format.DecimalPlaceCount = dataTokens[1].Length;
                }
            }

            return format;
        }

        /// <summary>
        /// For HORIZON, it has to have 5 columns or more.
        /// If the 5th column has negative number, we don't want it
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        private bool IsDesiredData(DataRow row)
        {
            if (row.Table == null || row.Table.Columns.Count < 5 || row[4] == null)
                return false;

            double negativeIndicator;
            if (Double.TryParse(row[4].ToString(), out negativeIndicator))
            {
                if (negativeIndicator > 0)
                    return true;
            }

            return false;
        }

        /// <summary>
        /// For HORIZON, we will output the data right-aligned
        /// </summary>
        /// <param name="row"></param>
        /// <param name="desiredColumns"></param>
        /// <returns></returns>
        private String HandleDesiredDataForHorizon(DataRow row, Dictionary<int, HorizonFormat> desiredColumnLengthMappings)
        {
            StringBuilder retVal = new StringBuilder();

            foreach (int desiredCol in desiredColumnLengthMappings.Keys)
            {
                HorizonFormat format = desiredColumnLengthMappings[desiredCol];

                var data = Convert.ToString(row[desiredCol]);
                string[] dataTokens = data.Split('.');

                string wholeNumber;
                string decimalNumber;

                if (dataTokens.Length == 1)
                {
                    wholeNumber = data.PadLeft(format.WholeNumberCount, ' ');
                    decimalNumber = string.Empty.PadRight(format.DecimalPlaceCount, '0');
                }
                else
                {
                    wholeNumber = dataTokens[0].PadLeft(format.WholeNumberCount, ' ');
                    decimalNumber = dataTokens[1].PadRight(format.DecimalPlaceCount, '0');
                }

                if (!string.IsNullOrEmpty(retVal.ToString()))
                    retVal.Append(" ");
                retVal.Append(string.Format("{0}.{1}", wholeNumber, decimalNumber));
            }

            return retVal.ToString();
        }

        #endregion HORIZON

        #endregion Process Data

        #region Save to file

        private void SaveToFileClicked(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (String.IsNullOrEmpty(saveFileDialog.FileName))
                {
                    MessageBox.Show("Please pick a file to save to");
                    return;
                }

                Stream myStream = saveFileDialog.OpenFile();
                if (myStream != null)
                {
                    WriteToFile(myStream);
                    myStream.Close();
                }

                MessageBox.Show("File Saved Successfully");
            }
        }

        private void WriteToFile(Stream myStream)
        {
            StreamWriter streamWriter = new StreamWriter(myStream);

            String[] lines = this.output.Text.Split('\n');

            foreach (String line in lines)
                streamWriter.WriteLine(line);

            streamWriter.Close();
        }

        #endregion Save to file
    }

    public class HorizonFormat
    {
        public int WholeNumberCount { get; set; }
        public int DecimalPlaceCount { get; set; }
    }
}