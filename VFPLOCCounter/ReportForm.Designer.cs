namespace VFPLOCCounter
{
	partial class ReportForm
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
			Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
			this.rvResults = new Microsoft.Reporting.WinForms.ReportViewer();
			this.ResultData = new VFPLOCCounter.Properties.DataSources.ResultData();
			this.resultsTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
			((System.ComponentModel.ISupportInitialize)(this.ResultData)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.resultsTableBindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// rvResults
			// 
			this.rvResults.Dock = System.Windows.Forms.DockStyle.Fill;
			reportDataSource1.Name = "ResultData_resultsTable";
			reportDataSource1.Value = this.resultsTableBindingSource;
			this.rvResults.LocalReport.DataSources.Add(reportDataSource1);
			this.rvResults.LocalReport.ReportEmbeddedResource = "VFPLOCCounter.ProjectStatus.rdlc";
			this.rvResults.Location = new System.Drawing.Point(0, 0);
			this.rvResults.Name = "rvResults";
			this.rvResults.Size = new System.Drawing.Size(738, 534);
			this.rvResults.TabIndex = 0;
			// 
			// ResultData
			// 
			this.ResultData.DataSetName = "ResultData";
			this.ResultData.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
			// 
			// resultsTableBindingSource
			// 
			this.resultsTableBindingSource.DataMember = "resultsTable";
			this.resultsTableBindingSource.DataSource = this.ResultData;
			// 
			// ReportForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(738, 534);
			this.Controls.Add(this.rvResults);
			this.Name = "ReportForm";
			this.Text = "ReportForm";
			this.Load += new System.EventHandler(this.ReportForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.ResultData)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.resultsTableBindingSource)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private Microsoft.Reporting.WinForms.ReportViewer rvResults;
		private System.Windows.Forms.BindingSource resultsTableBindingSource;
		private VFPLOCCounter.Properties.DataSources.ResultData ResultData;
	}
}