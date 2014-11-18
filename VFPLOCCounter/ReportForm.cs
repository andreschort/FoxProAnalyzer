using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace VFPLOCCounter
{
	public partial class ReportForm : Form
	{
		private DataTable rptTable;

		public ReportForm()
		{
			InitializeComponent();
		}

		private void ReportForm_Load(object sender, EventArgs e)
		{
			foreach (DataRow r in rptTable.Rows)
			{
				DataRow newRow = ResultData.resultsTable.NewRow();
				newRow ["fileName"] = r ["fileName"].ToString();
				newRow ["fileType"] = r ["fileType"].ToString();
				newRow ["totalLines"] = Convert.ToInt64(r ["totalLines"].ToString());
				newRow["numberMethods"] = Convert.ToInt64(r["numberMethods"].ToString());
				
				newRow["codeLines"] = Convert.ToInt64(r["codeLines"].ToString());
				newRow["commentLines"] = Convert.ToInt64(r["commentLines"].ToString());
				newRow["blankLines"] = Convert.ToInt64(r["blankLines"].ToString());

				newRow["codePercent"] = Convert.ToDecimal(r["codePercent"].ToString());
				newRow["commentPercent"] = Convert.ToDecimal(r["commentPercent"].ToString());
				newRow["blankPercent"] = Convert.ToDecimal(r["blankPercent"].ToString());

				newRow["projectName"] = r["projectName"].ToString();
				newRow["projectPath"] = r["projectPath"].ToString();
				

				ResultData.resultsTable.Rows.Add(newRow);
			}
			rvResults.RefreshReport();
		}
		/// <summary>
		/// ReportTable is the dataTable to view in the report body
		/// </summary>
		public DataTable ReportTable
		{
			set { rptTable = value;}
		}
	}
}