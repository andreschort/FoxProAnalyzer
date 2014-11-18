﻿using System.Collections.Generic;
using System.IO;

namespace ConsoleApplication1.Processors
{
    public class ProgramProcessor : FileProcessor
    {
        public override bool CanProcess(string extension)
        {
            return extension.ToLower().Equals("prg") || extension.ToLower().Equals("h");
        }

        public override Result Process(string path, List<string> keywords)
        {
            var result = new Result { Name = Path.GetFileName(path), Path = path };

            foreach (string line in File.ReadAllLines(path))
            {
                var vLine = line.Replace("\r\n", "\r").Replace("\t", "");
                if (vLine.Length == 0)
                {
                    result.BlankLines++;
                }
                else
                {
                    result.MethodCount += this.Occurs("PROCEDURE ", vLine.ToUpper());
                    result.MethodCount += this.Occurs("FUNCTION ", vLine.ToUpper());

                    // Check for lines beginning with && as comments (bad form but VFP accepts it)
                    // Correctly account for short lines
                    if (vLine.Substring(0, 1) == "*" || (vLine.Length > 2 && vLine.Substring(0, 3) == "*!*") || (vLine.Length > 1 && vLine.Substring(0, 2) == "&&"))
                    {
                        result.CommentLines++;
                    }
                    else
                    {
                        result.CodeLines++;
                    }
                }
            }

            return result;
        }
    }
}
