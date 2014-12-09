using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;

namespace FoxProAnalyzer.Util
{
    public class FileIterator : IDisposable
    {
        private readonly string path;
        private readonly OleDbConnection connection;

        public FileIterator(string path)
        {
            this.path = path;
            var cb = new OleDbConnectionStringBuilder { Provider = "VFPOLEDB", DataSource = path };
            this.connection = new OleDbConnection(cb.ConnectionString);
        }

        public IEnumerable<string> Iterate(params string[] fields)
        {
            this.connection.Open();
            var dt = new DataTable();
            var da = new OleDbDataAdapter("select " + fields.Aggregate((x, next) => x + "," + next) +" from '" + Path.GetFileName(this.path) + "'", this.connection);

            da.Fill(dt);

            return from DataRow r in dt.Rows
                   from m in fields.Select(f => r[f].ToString()).Where(x => x.Length > 0)
                   select m;
        }

        public void Dispose()
        {
            if (this.connection != null)
            {
                this.connection.Close();
            }
        }
    }
}
