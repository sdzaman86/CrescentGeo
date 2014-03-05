namespace CrescentFocusDataFormat
{
    partial class InputWizard
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabHeader = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.sortCheckBox = new System.Windows.Forms.CheckBox();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.simpleRadioButton = new System.Windows.Forms.RadioButton();
            this.customRadioButton = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.headerText = new System.Windows.Forms.TextBox();
            this.customPanel = new System.Windows.Forms.Panel();
            this.customControlPanel = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.nextButton = new System.Windows.Forms.Button();
            this.tabColumns = new System.Windows.Forms.TabPage();
            this.cancelButton = new System.Windows.Forms.Button();
            this.finishButton = new System.Windows.Forms.Button();
            this.columnGridView = new System.Windows.Forms.DataGridView();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.handvel = new System.Windows.Forms.RadioButton();
            this.horizon = new System.Windows.Forms.RadioButton();
            this.panel5 = new System.Windows.Forms.Panel();
            this.tabControl.SuspendLayout();
            this.tabHeader.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.customPanel.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tabColumns.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.columnGridView)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabHeader);
            this.tabControl.Controls.Add(this.tabColumns);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(630, 437);
            this.tabControl.TabIndex = 0;
            // 
            // tabHeader
            // 
            this.tabHeader.Controls.Add(this.panel1);
            this.tabHeader.Controls.Add(this.customPanel);
            this.tabHeader.Controls.Add(this.panel3);
            this.tabHeader.Location = new System.Drawing.Point(4, 22);
            this.tabHeader.Name = "tabHeader";
            this.tabHeader.Padding = new System.Windows.Forms.Padding(3);
            this.tabHeader.Size = new System.Drawing.Size(622, 411);
            this.tabHeader.TabIndex = 0;
            this.tabHeader.Text = "Header";
            this.tabHeader.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.sortCheckBox);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dataGridView);
            this.panel1.Controls.Add(this.simpleRadioButton);
            this.panel1.Controls.Add(this.customRadioButton);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.headerText);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(616, 290);
            this.panel1.TabIndex = 10;
            // 
            // sortCheckBox
            // 
            this.sortCheckBox.AutoSize = true;
            this.sortCheckBox.Location = new System.Drawing.Point(333, 9);
            this.sortCheckBox.Name = "sortCheckBox";
            this.sortCheckBox.Size = new System.Drawing.Size(45, 17);
            this.sortCheckBox.TabIndex = 8;
            this.sortCheckBox.Text = "Sort";
            this.sortCheckBox.UseVisualStyleBackColor = true;
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(11, 74);
            this.dataGridView.MultiSelect = false;
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.Size = new System.Drawing.Size(600, 200);
            this.dataGridView.TabIndex = 3;
            this.dataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.CellClicked);
            // 
            // simpleRadioButton
            // 
            this.simpleRadioButton.AutoSize = true;
            this.simpleRadioButton.Checked = true;
            this.simpleRadioButton.Location = new System.Drawing.Point(11, 51);
            this.simpleRadioButton.Name = "simpleRadioButton";
            this.simpleRadioButton.Size = new System.Drawing.Size(56, 17);
            this.simpleRadioButton.TabIndex = 6;
            this.simpleRadioButton.TabStop = true;
            this.simpleRadioButton.Text = "Simple";
            this.simpleRadioButton.UseVisualStyleBackColor = true;
            this.simpleRadioButton.CheckedChanged += new System.EventHandler(this.SimpleRadioButtonCheckedChanged);
            // 
            // customRadioButton
            // 
            this.customRadioButton.AutoSize = true;
            this.customRadioButton.Location = new System.Drawing.Point(73, 51);
            this.customRadioButton.Name = "customRadioButton";
            this.customRadioButton.Size = new System.Drawing.Size(60, 17);
            this.customRadioButton.TabIndex = 7;
            this.customRadioButton.Text = "Custom";
            this.customRadioButton.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(255, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Highlight the column or row or cell for header number";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(176, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Header Text:";
            // 
            // headerText
            // 
            this.headerText.Location = new System.Drawing.Point(251, 7);
            this.headerText.Name = "headerText";
            this.headerText.Size = new System.Drawing.Size(65, 20);
            this.headerText.TabIndex = 2;
            this.headerText.Text = "HANDVEL";
            // 
            // customPanel
            // 
            this.customPanel.Controls.Add(this.customControlPanel);
            this.customPanel.Controls.Add(this.label3);
            this.customPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.customPanel.Location = new System.Drawing.Point(3, 293);
            this.customPanel.Name = "customPanel";
            this.customPanel.Size = new System.Drawing.Size(616, 84);
            this.customPanel.TabIndex = 11;
            this.customPanel.Visible = false;
            // 
            // customControlPanel
            // 
            this.customControlPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.customControlPanel.Location = new System.Drawing.Point(11, 19);
            this.customControlPanel.Name = "customControlPanel";
            this.customControlPanel.Size = new System.Drawing.Size(600, 62);
            this.customControlPanel.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Design Custom:";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.nextButton);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(3, 377);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(616, 31);
            this.panel3.TabIndex = 12;
            // 
            // nextButton
            // 
            this.nextButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.nextButton.Location = new System.Drawing.Point(536, 5);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(75, 23);
            this.nextButton.TabIndex = 4;
            this.nextButton.Text = "Next...";
            this.nextButton.UseVisualStyleBackColor = true;
            this.nextButton.Click += new System.EventHandler(this.NextButtonClicked);
            // 
            // tabColumns
            // 
            this.tabColumns.Controls.Add(this.cancelButton);
            this.tabColumns.Controls.Add(this.finishButton);
            this.tabColumns.Controls.Add(this.columnGridView);
            this.tabColumns.Location = new System.Drawing.Point(4, 22);
            this.tabColumns.Name = "tabColumns";
            this.tabColumns.Padding = new System.Windows.Forms.Padding(3);
            this.tabColumns.Size = new System.Drawing.Size(622, 411);
            this.tabColumns.TabIndex = 1;
            this.tabColumns.Text = "Desired Columns";
            this.tabColumns.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.Location = new System.Drawing.Point(460, 398);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 6;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButtonClicked);
            // 
            // finishButton
            // 
            this.finishButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.finishButton.Location = new System.Drawing.Point(541, 398);
            this.finishButton.Name = "finishButton";
            this.finishButton.Size = new System.Drawing.Size(75, 23);
            this.finishButton.TabIndex = 5;
            this.finishButton.Text = "Finish";
            this.finishButton.UseVisualStyleBackColor = true;
            this.finishButton.Click += new System.EventHandler(this.FinishButtonClicked);
            // 
            // columnGridView
            // 
            this.columnGridView.AllowUserToAddRows = false;
            this.columnGridView.AllowUserToDeleteRows = false;
            this.columnGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.columnGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.columnGridView.Location = new System.Drawing.Point(6, 37);
            this.columnGridView.Name = "columnGridView";
            this.columnGridView.ReadOnly = true;
            this.columnGridView.Size = new System.Drawing.Size(610, 355);
            this.columnGridView.TabIndex = 4;
            this.columnGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.CellClicked);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tabControl);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(630, 437);
            this.panel2.TabIndex = 7;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.progressBar);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 437);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(630, 16);
            this.panel4.TabIndex = 13;
            // 
            // progressBar
            // 
            this.progressBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progressBar.Location = new System.Drawing.Point(0, 0);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(630, 16);
            this.progressBar.TabIndex = 0;
            // 
            // handvel
            // 
            this.handvel.AutoSize = true;
            this.handvel.Checked = true;
            this.handvel.Location = new System.Drawing.Point(3, 4);
            this.handvel.Name = "handvel";
            this.handvel.Size = new System.Drawing.Size(76, 17);
            this.handvel.TabIndex = 9;
            this.handvel.TabStop = true;
            this.handvel.Text = "HANDVEL";
            this.handvel.UseVisualStyleBackColor = true;
            this.handvel.CheckedChanged += new System.EventHandler(this.OutputTypeCheckedChanged);
            // 
            // horizon
            // 
            this.horizon.AutoSize = true;
            this.horizon.Location = new System.Drawing.Point(85, 5);
            this.horizon.Name = "horizon";
            this.horizon.Size = new System.Drawing.Size(75, 17);
            this.horizon.TabIndex = 10;
            this.horizon.Text = "HORIZON";
            this.horizon.UseVisualStyleBackColor = true;
            this.horizon.CheckedChanged += new System.EventHandler(this.OutputTypeCheckedChanged);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.handvel);
            this.panel5.Controls.Add(this.horizon);
            this.panel5.Location = new System.Drawing.Point(9, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(161, 27);
            this.panel5.TabIndex = 11;
            // 
            // InputWizard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 453);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel4);
            this.Name = "InputWizard";
            this.Text = "InputWizard";
            this.tabControl.ResumeLayout(false);
            this.tabHeader.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.customPanel.ResumeLayout(false);
            this.customPanel.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.tabColumns.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.columnGridView)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabHeader;
        private System.Windows.Forms.TabPage tabColumns;
        private System.Windows.Forms.TextBox headerText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button nextButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView columnGridView;
        private System.Windows.Forms.Button finishButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.RadioButton simpleRadioButton;
        private System.Windows.Forms.RadioButton customRadioButton;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Panel customPanel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel customControlPanel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.CheckBox sortCheckBox;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.RadioButton handvel;
        private System.Windows.Forms.RadioButton horizon;
    }
}