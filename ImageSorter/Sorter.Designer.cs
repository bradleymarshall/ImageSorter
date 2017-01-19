namespace ImageSorter
{
    partial class FormImageSorter
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
            this.buttonTest = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.textSourcePath = new System.Windows.Forms.TextBox();
            this.labelSource = new System.Windows.Forms.Label();
            this.labelDest = new System.Windows.Forms.Label();
            this.textDestPath = new System.Windows.Forms.TextBox();
            this.buttonSource = new System.Windows.Forms.Button();
            this.buttonDest = new System.Windows.Forms.Button();
            this.buttonSort = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.browserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.labelStatus = new System.Windows.Forms.Label();
            this.buttonSortVids = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonTest
            // 
            this.buttonTest.Location = new System.Drawing.Point(17, 85);
            this.buttonTest.Name = "buttonTest";
            this.buttonTest.Size = new System.Drawing.Size(75, 23);
            this.buttonTest.TabIndex = 0;
            this.buttonTest.Text = "Test Images";
            this.buttonTest.UseVisualStyleBackColor = true;
            this.buttonTest.Click += new System.EventHandler(this.buttonTest_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(572, 85);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Close";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // textSourcePath
            // 
            this.textSourcePath.Location = new System.Drawing.Point(83, 12);
            this.textSourcePath.Name = "textSourcePath";
            this.textSourcePath.Size = new System.Drawing.Size(483, 20);
            this.textSourcePath.TabIndex = 2;
            // 
            // labelSource
            // 
            this.labelSource.AutoSize = true;
            this.labelSource.Location = new System.Drawing.Point(33, 15);
            this.labelSource.Name = "labelSource";
            this.labelSource.Size = new System.Drawing.Size(44, 13);
            this.labelSource.TabIndex = 3;
            this.labelSource.Text = "Source:";
            this.labelSource.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelDest
            // 
            this.labelDest.AutoSize = true;
            this.labelDest.Location = new System.Drawing.Point(14, 41);
            this.labelDest.Name = "labelDest";
            this.labelDest.Size = new System.Drawing.Size(63, 13);
            this.labelDest.TabIndex = 5;
            this.labelDest.Text = "Destination:";
            this.labelDest.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // textDestPath
            // 
            this.textDestPath.Location = new System.Drawing.Point(83, 38);
            this.textDestPath.Name = "textDestPath";
            this.textDestPath.Size = new System.Drawing.Size(483, 20);
            this.textDestPath.TabIndex = 4;
            // 
            // buttonSource
            // 
            this.buttonSource.Location = new System.Drawing.Point(572, 10);
            this.buttonSource.Name = "buttonSource";
            this.buttonSource.Size = new System.Drawing.Size(75, 23);
            this.buttonSource.TabIndex = 6;
            this.buttonSource.Text = "Browse...";
            this.buttonSource.UseVisualStyleBackColor = true;
            this.buttonSource.Click += new System.EventHandler(this.buttonSource_Click);
            // 
            // buttonDest
            // 
            this.buttonDest.Location = new System.Drawing.Point(572, 37);
            this.buttonDest.Name = "buttonDest";
            this.buttonDest.Size = new System.Drawing.Size(75, 23);
            this.buttonDest.TabIndex = 7;
            this.buttonDest.Text = "Browse...";
            this.buttonDest.UseVisualStyleBackColor = true;
            this.buttonDest.Click += new System.EventHandler(this.buttonDest_Click);
            // 
            // buttonSort
            // 
            this.buttonSort.Location = new System.Drawing.Point(410, 85);
            this.buttonSort.Name = "buttonSort";
            this.buttonSort.Size = new System.Drawing.Size(75, 23);
            this.buttonSort.TabIndex = 8;
            this.buttonSort.Text = "Sort Images";
            this.buttonSort.UseVisualStyleBackColor = true;
            this.buttonSort.Click += new System.EventHandler(this.buttonSort_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(98, 85);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(306, 23);
            this.progressBar.TabIndex = 9;
            this.progressBar.Visible = false;
            // 
            // browserDialog
            // 
            this.browserDialog.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(215, 69);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(47, 13);
            this.labelStatus.TabIndex = 10;
            this.labelStatus.Text = "<status>";
            this.labelStatus.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // buttonSortVids
            // 
            this.buttonSortVids.Location = new System.Drawing.Point(491, 85);
            this.buttonSortVids.Name = "buttonSortVids";
            this.buttonSortVids.Size = new System.Drawing.Size(75, 23);
            this.buttonSortVids.TabIndex = 11;
            this.buttonSortVids.Text = "Sort Videos";
            this.buttonSortVids.UseVisualStyleBackColor = true;
            this.buttonSortVids.Click += new System.EventHandler(this.buttonSortVids_Click);
            // 
            // FormImageSorter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 126);
            this.Controls.Add(this.buttonSortVids);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.buttonSort);
            this.Controls.Add(this.buttonDest);
            this.Controls.Add(this.buttonSource);
            this.Controls.Add(this.labelDest);
            this.Controls.Add(this.textDestPath);
            this.Controls.Add(this.labelSource);
            this.Controls.Add(this.textSourcePath);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonTest);
            this.Name = "FormImageSorter";
            this.Text = "ImageSorter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonTest;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.TextBox textSourcePath;
        private System.Windows.Forms.Label labelSource;
        private System.Windows.Forms.Label labelDest;
        private System.Windows.Forms.TextBox textDestPath;
        private System.Windows.Forms.Button buttonSource;
        private System.Windows.Forms.Button buttonDest;
        private System.Windows.Forms.Button buttonSort;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.FolderBrowserDialog browserDialog;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Button buttonSortVids;
    }
}

