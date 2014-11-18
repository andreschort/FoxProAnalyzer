using System.Collections.Generic;

namespace ConsoleApplication1.Processors
{
    public abstract class FileProcessor
    {
        public abstract bool CanProcess(string extension);

        public abstract Result Process(string path, List<string> keywords);

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
    }
}