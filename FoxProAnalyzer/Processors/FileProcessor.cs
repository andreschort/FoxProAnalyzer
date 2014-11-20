using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace FoxProAnalyzer.Processors
{
    public abstract class FileProcessor
    {
        public abstract bool CanProcess(string filePath);

        public abstract Result Process(string path, bool trackReports = false);

        public int Occurs(string cString, string cExpression)
        {
            int nPos = 0;
            int nOccured = 0;
            do
            {
                //Look for the search string in the expression
                nPos = cExpression.IndexOf(cString, nPos);
                if (nPos < 0)
                {
                    //This means that we did not find the item			
                    break;
                }
                else
                {
                    //Increment the occured counter based on the current mode we are in			
                    nOccured++;
                    nPos++;
                }
            } while (true);
            //Return the number of occurences	
            return nOccured;
        }

        public List<string> TrackReports(string text)
        {
            var lower = text.ToLower();
            var search1 = from Match match in Regex.Matches(lower, @"'r_(\d{3,4})(\.frx)?'")
                          select match.ToString()
                          into item
                          select item.Substring(1, item.Length - 2);

            var search2 = from Match match in Regex.Matches(lower, @"loimprimir\.id\s*=\s*(\d{3,4})")
                          select match.Groups[1].ToString();

            return search1.Select(x => x.EndsWith(".frx") ? x : x + ".frx")
                          .Union(search2.Select(x => "r_" + (x.Length <= 3 ? "0" + x : x) + ".frx"))
                          .ToList();
        }

        public void InspectLines(string fileContent, Result result)
        {
            var m = fileContent.Replace("\r\n", "\r");
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