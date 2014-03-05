using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace CrescentFocusDataFormat
{
    public partial class InputWizard : Form
    {
        private DataTable table;
        private List<int> desiredColumns = new List<int>();
        private int headerColumn;
        public const String HeaderNumber = "Header Number";
        public const String Data = "Data";
        private String filePath;
        private bool ignoreAllText;
        private BackgroundWorker worker;
        private String[] lines;

        #region Properties

        public bool IsSimple
        {
            get { return simpleRadioButton.Checked; }
        }

        public OutputType OutputType
        {
            get { return this.horizon.Checked ? OutputType.HORIZON : OutputType.HANDVEL; }
        }

        public List<int> DesiredColumns
        {
            get
            {
                if (IsSimple)
                {
                    this.desiredColumns.Sort();
                    return this.desiredColumns;
                }
                else
                    return GetCustomDesiredColumns();
            }
        }

        public DataTable FormattedTable
        {
            get
            {
                if (this.sortCheckBox.Checked)
                {
                    DataView view = new DataView(this.table);
                    view.Sort = String.Format("{0} ASC", this.table.Columns[this.HeaderColumn].ColumnName);
                    return view.ToTable();
                }
                
                if (this.customRadioButton.Checked)
                    this.CleanUpTable();

                return this.table;
            }
        }

        public int HeaderColumn
        {
            get { return this.headerColumn; }
        }

        public String HeaderName
        {
            get { return headerText.Text; }
        }

        #endregion Properties

        public InputWizard(String pFilePath, bool pIgnoreAllText)
        {
            InitializeComponent();

            filePath = pFilePath;
            ignoreAllText = pIgnoreAllText;

            worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.DoWork += new DoWorkEventHandler(DoWork);
            worker.ProgressChanged += new ProgressChangedEventHandler(WorkerProgressChanged);
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(WorkerCompleted);

            lines = File.ReadAllLines(filePath);
            progressBar.Minimum = 0;
            progressBar.Maximum = lines.Length;

            worker.RunWorkerAsync();
        }

        void WorkerProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
        }

        private void DoWork(object sender, DoWorkEventArgs e)
        {
            CreateInput();
        }

        private void WorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            SetDataSource();
        }

        #region Data

        private void CreateInput()
        {
            table = new DataTable();

            for(int index = 0; index < lines.Length; index++)
            {
                String line = lines[index];
                String[] parseTokens = ParseLine(line);

                if (ignoreAllText && IsAllText(parseTokens))
                    continue;

                // Create the input table with the columns we need 
                if (table.Columns.Count == 0)
                    InitializeInputTable();

                SetData(parseTokens);

                worker.ReportProgress(index);
            }
        }

        private bool IsAllText(String[] tokens)
        {
            foreach (String token in tokens)
            {
                try
                {
                    Decimal.Parse(token);
                    return false;
                }
                catch
                {
                }
            }

            return true;
        }

        private void SetDataSource()
        {
            if (table.Rows.Count > 100)
            {
                DataTable displayTable = table.Clone();

                for (int i = 0; i < 100; i++)
                {
                    DataRow newRow = displayTable.NewRow();

                    foreach (DataColumn column in table.Columns)
                        newRow[column.ColumnName] = table.Rows[i][column];

                    displayTable.Rows.Add(newRow);
                }

                dataGridView.DataSource = new DataView(displayTable);
                columnGridView.DataSource = new DataView(displayTable);
            }
            else
            {
                dataGridView.DataSource = new DataView(table);
                columnGridView.DataSource = new DataView(table);
            }

            InitializeView(dataGridView, DataGridViewSelectionMode.ColumnHeaderSelect);
            InitializeView(columnGridView, DataGridViewSelectionMode.ColumnHeaderSelect);
            InitializeCustomData(table.Columns.Count);
        }

        private void InitializeView(DataGridView view, DataGridViewSelectionMode selectionMode)
        {
            foreach (DataGridViewColumn col in view.Columns)
                col.SortMode = DataGridViewColumnSortMode.NotSortable;

            view.SelectionMode = selectionMode;
        }

        private void InitializeInputTable()
        {
            int columnCount = GetMaxColumnCount();

            for (int i = 0; i < columnCount; i++)
            {
                DataColumn col = new DataColumn("Column" + i, typeof(String));
                table.Columns.Add(col);
            }
        }

        private int GetMaxColumnCount()
        {
            int maxCount = 0;

            for (int i = 0; i < 10; i++)
            {
                String line = lines[i];
                String[] parseTokens = ParseLine(line);
                if (parseTokens.Length > maxCount)
                    maxCount = parseTokens.Length;
            }

            return maxCount;
        }

        private void SetData(String[] tokens)
        {
            DataRow newRow = table.NewRow();
            foreach (DataColumn col in table.Columns)
            {
                int columnIndex = table.Columns.IndexOf(col.ColumnName);

                if (columnIndex < tokens.Length)
                    newRow[col] = tokens[columnIndex];
                else
                    newRow[col] = "EMPTY";
            }
            table.Rows.Add(newRow);
        }

        protected virtual String[] ParseLine(string line)
        {
            List<String> retLine = new List<String>();
            line = line.Replace('\t', ' ');
            line = line.Replace(',', ' ');

            foreach (string parseString in line.Split(' '))
            {
                if (!string.IsNullOrEmpty(parseString))
                {
                    // If the string is longer than 8 characters AND it's an int, we'll try to make it into 2 strings
                    // because the limit is 8 normally...
                    if (parseString.Length > 8)
                    {
                        try
                        {
                            long.Parse(parseString);
                            retLine.Add(parseString.Substring(0, 8));
                            retLine.Add(parseString.Substring(8, parseString.Length - 8));
                        }
                        catch
                        {
                            retLine.Add(parseString);
                        }
                    }
                    else
                        retLine.Add(parseString);
                }
            }

            return retLine.ToArray();
        }

        #endregion Data

        #region Custom Data

        private void InitializeCustomData(int columnCount)
        {
            int x = 42;
            int y = 5;
            InitializeOneRow(columnCount, HeaderNumber, 42, 5);
            InitializeOneRow(columnCount, Data, 42, 35);
        }

        private void InitializeOneRow(int columnCount, String text, int x, int y)
        {
            for (int i = 0; i < columnCount; i++)
            {
                ComboBox box = CreateComboBox(i, text);
                if (customControlPanel.Controls.Count > 0 && customControlPanel.Controls.Count != columnCount)
                {
                    Control lastControl = customControlPanel.Controls[customControlPanel.Controls.Count - 1];
                    x = lastControl.Location.X + lastControl.Size.Width;
                }
                box.Location = new Point(x, y);
                customControlPanel.Controls.Add(box);
            }
        }

        private ComboBox CreateComboBox(int columnIndex, String text)
        {
            ComboBox box = new ComboBox();
            box.Items.Add(text);
            box.Items.Add("Ignore");
            box.Tag = String.Format("{0}_{1}", text, columnIndex);
            box.Size = new Size(100, 26);

            if(text == HeaderNumber)
                box.SelectedIndexChanged += new EventHandler(HeaderNumberBoxSelectedIndexChanged);

            return box;
        }

        private void HeaderNumberBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox senderComboBox = sender as ComboBox;
            foreach (Control customControl in customControlPanel.Controls)
            {
                if (customControl is ComboBox)
                {
                    String tag = (String)customControl.Tag;

                    if (tag.Contains(HeaderNumber) && customControl != (Control)sender && senderComboBox.Text == HeaderNumber)
                        customControl.Enabled = false;
                    else
                        customControl.Enabled = true;
                }
            }

            if (senderComboBox.Text == HeaderNumber)
                this.headerColumn = Convert.ToInt32(((String)senderComboBox.Tag).Split('_')[1]);
        }

        private List<int> GetCustomDesiredColumns()
        {
            List<int> retVal = new List<int>();

            foreach (Control customControl in customControlPanel.Controls)
            {
                if (customControl is ComboBox)
                {
                    String tag = (String)customControl.Tag;

                    if (tag.Contains(Data) && ((ComboBox)customControl).Text == Data)
                        retVal.Add(Convert.ToInt32(tag.Split('_')[1]));
                }
            }

            return retVal;
        }

        private void CleanUpTable()
        {
            foreach (DataRow row in this.table.Rows)
            {
                bool allInts = true;

                foreach (DataColumn col in this.table.Columns)
                {
                    try
                    {
                        // If this cell says it's EMPTY, we will see if the previous cells were all integers
                        // If they were, we want to clear the empty text because this is not a "header" row
                        if (Convert.ToString(row[col]) == "EMPTY")
                        {
                            if (allInts == true)
                                row[col] = String.Empty;
                            else
                                break;
                        }
                        else if(allInts == true)    // If allInts is already false, we don't really need to test it anymore
                            Int32.Parse((String)row[col]);
                    }
                    catch
                    {
                        allInts = false;
                    }
                }
            }
        }

        #endregion Custom Data

        #region Events

        private void NextButtonClicked(object sender, EventArgs e)
        {
            tabControl.SelectedTab = tabColumns;
        }

        private void FinishButtonClicked(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void CancelButtonClicked(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void AddDesiredColumn(int index)
        {
            if (!this.desiredColumns.Contains(index))
                this.desiredColumns.Add(index);
        }

        private void SimpleRadioButtonCheckedChanged(object sender, EventArgs e)
        {
            if (this.simpleRadioButton.Checked)
            {
                this.dataGridView.Enabled = true;
                this.customPanel.Visible = false;
                this.columnGridView.Enabled = true;
            }
            else
            {
                this.dataGridView.Enabled = false;
                this.customPanel.Visible = true;
                this.columnGridView.Enabled = false;
                this.columnGridView.ClearSelection();
            }
        }

        private void CellClicked(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0)
                return;

            DataGridView gridView = sender as DataGridView;

            gridView.Columns[e.ColumnIndex].Selected = true;

            if (gridView.Name == "columnGridView")
                AddDesiredColumn(e.ColumnIndex);
            else
                this.headerColumn = e.ColumnIndex;
        }

        #endregion Events

        private void OutputTypeCheckedChanged(object sender, EventArgs e)
        {
            this.headerText.Enabled = this.handvel.Checked;
            this.customRadioButton.Enabled = this.handvel.Checked;
            if (!this.customRadioButton.Enabled)
                this.simpleRadioButton.Checked = true;
        }
    }

    public enum OutputType
    {
        HANDVEL,
        HORIZON
    }
}