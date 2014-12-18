using System;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace FoxProAnalyzer.Util
{
    public static class FoxUtil
    {
        /// <summary>
        /// Strips the specified foxpro code.
        /// Removes comments and transform multi line statement to single line
        /// </summary>
        /// <param name="content">The content.</param>
        /// <returns></returns>
        public static string Strip(string content)
        {
            // remove inline comments
            var c1 = Regex.Replace(content, @"&&.*", "");

            // remove block comments
            var c2 = Regex.Replace(c1, @"^\s*\*.*", "", RegexOptions.Multiline);

            // transform multiline statements to single line
            var c3 = Regex.Replace(c2, @";\s*\r?\n\s*", " ");

            // remove blank lines
            return Regex.Replace(c3, @"^[ \f\r\v\t\x85\p{Z}]*$", "", RegexOptions.Multiline);
        }

        public static string GetProperty(string file, string baseClass, string propertyName)
        {
            if (string.IsNullOrWhiteSpace(file))
            {
                return string.Empty;
            }

            var cb = new OleDbConnectionStringBuilder { Provider = "VFPOLEDB", DataSource = file };
            OleDbConnection conn = null;
            OleDbDataAdapter da = null;

            try
            {
                conn = new OleDbConnection(cb.ConnectionString);
                da = new OleDbDataAdapter("select properties from '" + Path.GetFileName(file) + "' where baseClass = '" + baseClass + "'", conn);

                var dt = new DataTable();
                da.Fill(dt);

                var props = dt.Rows[0][0].ToString();
                var first =
                    props.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
                        .First(x => x.StartsWith(propertyName));
                return Regex.Match(first, propertyName + @"\s*=\s*""([^""]+)""").Groups[1].ToString().Trim();
            }
            catch (Exception ex)
            {
                // who cares
            }
            finally
            {
                if (da != null)
                {
                    da.Dispose();
                }

                if (conn != null)
                {
                    conn.Dispose();
                }
            }

            return string.Empty;
        }
    }
}
