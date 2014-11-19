using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;

namespace FoxProAnalyzer.Processors
{
    public class MenuProcessor : FileProcessor
    {
        public override bool CanProcess(string filePath)
        {
            return filePath.ToLower().Equals("mnx");
        }

        public override Result Process(string path, bool trackReports = false)
        {
            var result = new Result { Name = Path.GetFileName(path), Path = path };

            if (trackReports)
            {
                result.Reports = new List<string>();
            }

            OleDbConnection conn = null;
            try
            {
                var cb = new OleDbConnectionStringBuilder { Provider = "VFPOLEDB", DataSource = path };
                var dt = new DataTable();
                conn = new OleDbConnection(cb.ConnectionString);

                conn.Open();
                var da = new OleDbDataAdapter("select * from '" + result.Name + "'", conn);

                da.Fill(dt);

                foreach (DataRow r in dt.Rows)
                {
                    var m = r["procedure"].ToString();

                    if (m.Length > 0)
                    {
                        if (trackReports)
                        {
                            this.TrackReports(m);
                        }

                        result.MethodCount += this.Occurs("PROCEDURE", m);
                        m = m.Replace("\r\n", "\r");
                        m = m.Replace("\t", "");

                        foreach (string s in m.Split(new[] { "\r" }, StringSplitOptions.None))
                        {
                            if (string.IsNullOrEmpty(s))
                            {
                                result.BlankLines++;
                            }
                            else if (s.Substring(0, 1) == "*" || (s.Length > 2 && s.Substring(0, 3) == "*!*")
                                     || (s.Length > 1 && s.Substring(0, 2) == "&&"))
                            {
                                result.CommentLines++;
                            }
                            else
                            {
                                result.CodeLines++;
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                result.IsError = true;
                result.ErrorMessage = e.Message;
                result.Exception = e;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Dispose();
                }
            }

            if (trackReports)
            {
                result.Reports = result.Reports.Distinct().ToList();
            }

            return result;
        }
    }
}
