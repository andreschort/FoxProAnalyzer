namespace VFPLOCCounter
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
			this.components = new System.ComponentModel.Container();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
			this.ofdProject = new System.Windows.Forms.OpenFileDialog();
			this.label1 = new System.Windows.Forms.Label();
			this.txtFolder = new System.Windows.Forms.TextBox();
			this.btnSelectFolder = new System.Windows.Forms.Button();
			this.btnProcess = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.txtTotalLines = new System.Windows.Forms.TextBox();
			this.txtNumMethods = new System.Windows.Forms.TextBox();
			this.pbProcess = new System.Windows.Forms.ProgressBar();
			this.txtNumberOfFiles = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txtBlankLines = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.txtCommentLines = new System.Windows.Forms.TextBox();
			this.txtCodeLines = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.txtBlankPercent = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.txtCommentPercent = new System.Windows.Forms.TextBox();
			this.txtCodePercent = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.dgvResults = new System.Windows.Forms.DataGridView();
			this.lblCurrentFile = new System.Windows.Forms.Label();
			this.btnPrintPreview = new System.Windows.Forms.Button();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			((System.ComponentModel.ISupportInitialize)(this.dgvResults)).BeginInit();
			this.SuspendLayout();
			// 
			// ofdProject
			// 
			this.ofdProject.DefaultExt = "\"pjx\"";
			this.ofdProject.Filter = "VFP Project files (*.pjx)|*.pjx";
			this.ofdProject.Title = "Select Project to open.";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(13, 12);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(65, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Select Path:";
			// 
			// txtFolder
			// 
			this.txtFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtFolder.Location = new System.Drawing.Point(84, 9);
			this.txtFolder.Name = "txtFolder";
			this.txtFolder.ReadOnly = true;
			this.txtFolder.Size = new System.Drawing.Size(393, 20);
			this.txtFolder.TabIndex = 1;
			this.toolTip1.SetToolTip(this.txtFolder, "File and Path name of VFP Project being analyzed.");
			// 
			// btnSelectFolder
			// 
			this.btnSelectFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSelectFolder.Location = new System.Drawing.Point(483, 7);
			this.btnSelectFolder.Name = "btnSelectFolder";
			this.btnSelectFolder.Size = new System.Drawing.Size(27, 23);
			this.btnSelectFolder.TabIndex = 2;
			this.btnSelectFolder.Text = "...";
			this.toolTip1.SetToolTip(this.btnSelectFolder, "Select VFP Project to Analyze");
			this.btnSelectFolder.UseVisualStyleBackColor = true;
			this.btnSelectFolder.Click += new System.EventHandler(this.btnSelectFolder_Click);
			// 
			// btnProcess
			// 
			this.btnProcess.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.btnProcess.Enabled = false;
			this.btnProcess.Location = new System.Drawing.Point(84, 36);
			this.btnProcess.Name = "btnProcess";
			this.btnProcess.Size = new System.Drawing.Size(393, 23);
			this.btnProcess.TabIndex = 3;
			this.btnProcess.Text = "Process";
			this.toolTip1.SetToolTip(this.btnProcess, "Click to Start Analyzing!");
			this.btnProcess.UseVisualStyleBackColor = true;
			this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(16, 114);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(62, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "Total Lines:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(17, 138);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(61, 13);
			this.label3.TabIndex = 5;
			this.label3.Text = "# Methods:";
			// 
			// txtTotalLines
			// 
			this.txtTotalLines.Location = new System.Drawing.Point(84, 111);
			this.txtTotalLines.Name = "txtTotalLines";
			this.txtTotalLines.ReadOnly = true;
			this.txtTotalLines.Size = new System.Drawing.Size(64, 20);
			this.txtTotalLines.TabIndex = 6;
			this.toolTip1.SetToolTip(this.txtTotalLines, "Total Lines found in Project files");
			// 
			// txtNumMethods
			// 
			this.txtNumMethods.Location = new System.Drawing.Point(84, 135);
			this.txtNumMethods.Name = "txtNumMethods";
			this.txtNumMethods.ReadOnly = true;
			this.txtNumMethods.Size = new System.Drawing.Size(64, 20);
			this.txtNumMethods.TabIndex = 7;
			this.toolTip1.SetToolTip(this.txtNumMethods, "Total Number of Methods found in Project");
			// 
			// pbProcess
			// 
			this.pbProcess.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.pbProcess.Location = new System.Drawing.Point(84, 65);
			this.pbProcess.Name = "pbProcess";
			this.pbProcess.Size = new System.Drawing.Size(393, 23);
			this.pbProcess.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
			this.pbProcess.TabIndex = 8;
			// 
			// txtNumberOfFiles
			// 
			this.txtNumberOfFiles.Location = new System.Drawing.Point(84, 161);
			this.txtNumberOfFiles.Name = "txtNumberOfFiles";
			this.txtNumberOfFiles.ReadOnly = true;
			this.txtNumberOfFiles.Size = new System.Drawing.Size(64, 20);
			this.txtNumberOfFiles.TabIndex = 10;
			this.toolTip1.SetToolTip(this.txtNumberOfFiles, "# of Project files analyzed.");
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(37, 164);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(41, 13);
			this.label4.TabIndex = 9;
			this.label4.Text = "# Files:";
			// 
			// txtBlankLines
			// 
			this.txtBlankLines.Location = new System.Drawing.Point(260, 161);
			this.txtBlankLines.Name = "txtBlankLines";
			this.txtBlankLines.ReadOnly = true;
			this.txtBlankLines.Size = new System.Drawing.Size(64, 20);
			this.txtBlankLines.TabIndex = 16;
			this.toolTip1.SetToolTip(this.txtBlankLines, "Total Number of Blank Lines found in Project.");
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(190, 164);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(65, 13);
			this.label5.TabIndex = 15;
			this.label5.Text = "Blank Lines:";
			// 
			// txtCommentLines
			// 
			this.txtCommentLines.Location = new System.Drawing.Point(260, 135);
			this.txtCommentLines.Name = "txtCommentLines";
			this.txtCommentLines.ReadOnly = true;
			this.txtCommentLines.Size = new System.Drawing.Size(64, 20);
			this.txtCommentLines.TabIndex = 14;
			this.toolTip1.SetToolTip(this.txtCommentLines, "Total Number of Comment Lines (\"*\" lines only) found in Project.");
			// 
			// txtCodeLines
			// 
			this.txtCodeLines.Location = new System.Drawing.Point(260, 111);
			this.txtCodeLines.Name = "txtCodeLines";
			this.txtCodeLines.ReadOnly = true;
			this.txtCodeLines.Size = new System.Drawing.Size(64, 20);
			this.txtCodeLines.TabIndex = 13;
			this.toolTip1.SetToolTip(this.txtCodeLines, "Total Number of Lines of Code found in Project.");
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(173, 138);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(82, 13);
			this.label6.TabIndex = 12;
			this.label6.Text = "Comment Lines:";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(192, 114);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(63, 13);
			this.label7.TabIndex = 11;
			this.label7.Text = "Code Lines:";
			// 
			// txtBlankPercent
			// 
			this.txtBlankPercent.Location = new System.Drawing.Point(455, 161);
			this.txtBlankPercent.Name = "txtBlankPercent";
			this.txtBlankPercent.ReadOnly = true;
			this.txtBlankPercent.Size = new System.Drawing.Size(64, 20);
			this.txtBlankPercent.TabIndex = 22;
			this.toolTip1.SetToolTip(this.txtBlankPercent, "Percentage of Blank lines in entire project.");
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(373, 164);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(76, 13);
			this.label8.TabIndex = 21;
			this.label8.Text = "% Blank Lines:";
			// 
			// txtCommentPercent
			// 
			this.txtCommentPercent.Location = new System.Drawing.Point(455, 135);
			this.txtCommentPercent.Name = "txtCommentPercent";
			this.txtCommentPercent.ReadOnly = true;
			this.txtCommentPercent.Size = new System.Drawing.Size(64, 20);
			this.txtCommentPercent.TabIndex = 20;
			this.toolTip1.SetToolTip(this.txtCommentPercent, "Percentage of Comments in entire project.");
			// 
			// txtCodePercent
			// 
			this.txtCodePercent.Location = new System.Drawing.Point(455, 111);
			this.txtCodePercent.Name = "txtCodePercent";
			this.txtCodePercent.ReadOnly = true;
			this.txtCodePercent.Size = new System.Drawing.Size(64, 20);
			this.txtCodePercent.TabIndex = 19;
			this.toolTip1.SetToolTip(this.txtCodePercent, "Percentage of Code in entire project.");
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(356, 138);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(93, 13);
			this.label9.TabIndex = 18;
			this.label9.Text = "% Comment Lines:";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(375, 114);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(74, 13);
			this.label10.TabIndex = 17;
			this.label10.Text = "% Code Lines:";
			// 
			// dgvResults
			// 
			this.dgvResults.AllowUserToAddRows = false;
			this.dgvResults.AllowUserToDeleteRows = false;
			this.dgvResults.AllowUserToOrderColumns = true;
			this.dgvResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.dgvResults.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
			dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle19.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle19.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dgvResults.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle19;
			this.dgvResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle20.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle20.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle20.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dgvResults.DefaultCellStyle = dataGridViewCellStyle20;
			this.dgvResults.Location = new System.Drawing.Point(12, 187);
			this.dgvResults.Name = "dgvResults";
			this.dgvResults.ReadOnly = true;
			dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle21.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle21.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle21.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle21.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dgvResults.RowHeadersDefaultCellStyle = dataGridViewCellStyle21;
			this.dgvResults.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvResults.Size = new System.Drawing.Size(507, 113);
			this.dgvResults.TabIndex = 23;
			// 
			// lblCurrentFile
			// 
			this.lblCurrentFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.lblCurrentFile.Location = new System.Drawing.Point(84, 92);
			this.lblCurrentFile.Name = "lblCurrentFile";
			this.lblCurrentFile.Size = new System.Drawing.Size(393, 16);
			this.lblCurrentFile.TabIndex = 24;
			this.lblCurrentFile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// btnPrintPreview
			// 
			this.btnPrintPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnPrintPreview.Enabled = false;
			this.btnPrintPreview.Image = global::VFPLOCCounter.Properties.Resources.PrintPreviewHS;
			this.btnPrintPreview.Location = new System.Drawing.Point(483, 35);
			this.btnPrintPreview.Name = "btnPrintPreview";
			this.btnPrintPreview.Size = new System.Drawing.Size(27, 24);
			this.btnPrintPreview.TabIndex = 25;
			this.toolTip1.SetToolTip(this.btnPrintPreview, "Report Print Preview");
			this.btnPrintPreview.UseVisualStyleBackColor = true;
			this.btnPrintPreview.Click += new System.EventHandler(this.btnPrintPreview_Click);
			// 
			// toolTip1
			// 
			this.toolTip1.IsBalloon = true;
			this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(531, 312);
			this.Controls.Add(this.btnPrintPreview);
			this.Controls.Add(this.lblCurrentFile);
			this.Controls.Add(this.dgvResults);
			this.Controls.Add(this.txtBlankPercent);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.txtCommentPercent);
			this.Controls.Add(this.txtCodePercent);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.txtBlankLines);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.txtCommentLines);
			this.Controls.Add(this.txtCodeLines);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.txtNumberOfFiles);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.pbProcess);
			this.Controls.Add(this.txtNumMethods);
			this.Controls.Add(this.txtTotalLines);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.btnProcess);
			this.Controls.Add(this.btnSelectFolder);
			this.Controls.Add(this.txtFolder);
			this.Controls.Add(this.label1);
			this.MinimumSize = new System.Drawing.Size(539, 346);
			this.Name = "MainForm";
			this.Text = "VFP Project Lines Of Code Analyzer";
			((System.ComponentModel.ISupportInitialize)(this.dgvResults)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.OpenFileDialog ofdProject;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtFolder;
		private System.Windows.Forms.Button btnSelectFolder;
		private System.Windows.Forms.Button btnProcess;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtTotalLines;
		private System.Windows.Forms.TextBox txtNumMethods;
		private System.Windows.Forms.ProgressBar pbProcess;
		private System.Windows.Forms.TextBox txtNumberOfFiles;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtBlankLines;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtCommentLines;
		private System.Windows.Forms.TextBox txtCodeLines;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox txtBlankPercent;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox txtCommentPercent;
		private System.Windows.Forms.TextBox txtCodePercent;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.DataGridView dgvResults;
		private System.Windows.Forms.Label lblCurrentFile;
		private System.Windows.Forms.Button btnPrintPreview;
		private System.Windows.Forms.ToolTip toolTip1;
	}
}

