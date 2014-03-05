namespace CrescentFocusDataFormat
{
    partial class OldForm
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
            this.btn_Browse = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.txt_fileName = new System.Windows.Forms.TextBox();
            this.lst_fileFormat = new System.Windows.Forms.ListBox();
            this.btn_format = new System.Windows.Forms.Button();
            this.txt_file = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // btn_Browse
            // 
            this.btn_Browse.Location = new System.Drawing.Point(238, 0);
            this.btn_Browse.Name = "btn_Browse";
            this.btn_Browse.Size = new System.Drawing.Size(75, 23);
            this.btn_Browse.TabIndex = 0;
            this.btn_Browse.Text = "Browse";
            this.btn_Browse.UseVisualStyleBackColor = true;
            this.btn_Browse.Click += new System.EventHandler(this.btn_Browse_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.InitialDirectory = "C:";
            // 
            // txt_fileName
            // 
            this.txt_fileName.Location = new System.Drawing.Point(14, 3);
            this.txt_fileName.Name = "txt_fileName";
            this.txt_fileName.Size = new System.Drawing.Size(218, 20);
            this.txt_fileName.TabIndex = 1;
            // 
            // lst_fileFormat
            // 
            this.lst_fileFormat.FormattingEnabled = true;
            this.lst_fileFormat.Items.AddRange(new object[] {
            "Promax"});
            this.lst_fileFormat.Location = new System.Drawing.Point(14, 61);
            this.lst_fileFormat.Name = "lst_fileFormat";
            this.lst_fileFormat.Size = new System.Drawing.Size(120, 95);
            this.lst_fileFormat.TabIndex = 2;
            this.lst_fileFormat.SelectedIndexChanged += new System.EventHandler(this.lst_fileFormat_SelectedIndexChanged);
            // 
            // btn_format
            // 
            this.btn_format.Location = new System.Drawing.Point(157, 104);
            this.btn_format.Name = "btn_format";
            this.btn_format.Size = new System.Drawing.Size(75, 23);
            this.btn_format.TabIndex = 4;
            this.btn_format.Text = "Format";
            this.btn_format.UseVisualStyleBackColor = true;
            this.btn_format.Click += new System.EventHandler(this.btn_format_Click);
            // 
            // txt_file
            // 
            this.txt_file.Location = new System.Drawing.Point(250, 61);
            this.txt_file.Name = "txt_file";
            this.txt_file.Size = new System.Drawing.Size(323, 191);
            this.txt_file.TabIndex = 5;
            this.txt_file.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 264);
            this.Controls.Add(this.txt_file);
            this.Controls.Add(this.btn_format);
            this.Controls.Add(this.lst_fileFormat);
            this.Controls.Add(this.txt_fileName);
            this.Controls.Add(this.btn_Browse);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Browse;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox txt_fileName;
        private System.Windows.Forms.ListBox lst_fileFormat;
        private System.Windows.Forms.Button btn_format;
        private System.Windows.Forms.RichTextBox txt_file;

    }
}

