using System;
using System.Collections.Generic;

namespace Utilities
{
    public static class Helper
    {
        public static string[] ReadFileIntoArray(string filePath)
        {
            if (System.IO.File.Exists(filePath))
            {
                return System.IO.File.ReadAllLines(filePath);
            }
            else
            {
                throw new System.IO.FileNotFoundException($"File not found: {filePath}");
            }
        }

        public static List<string> ConvertArrayToList(string[] array)
        {
            List<string> list = null;
            try
            {
                list = new List<string>(array);
            }
            catch (NullReferenceException nre)
            {
                Console.WriteLine("Issue with array does it contain data " + nre.Message);
            }

            return list;
        }
    }
}
