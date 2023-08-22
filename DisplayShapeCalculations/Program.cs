using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using Utilities;
using Shape;
using System.IO;

namespace DisplayShapeCalculations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string projectRoot = Directory.GetParent(baseDirectory).Parent.Parent.Parent.FullName;
            string directory = projectRoot;
            ///string directory = @"C:\Users\User\source\repos\DisplayShapeCalculations";
            string fileName = @"\DimensionsRecs.txt";
            string filePath = directory + fileName;

            string[] records = Helper.ReadFileIntoArray(filePath);
            List<string> listOfRecords = Helper.ConvertArrayToList(records);

            foreach (var record in listOfRecords)
            {
                string[] fields = record.Split(';');
                string shapeType = fields[0];
                string calcType = fields[1];

                if (shapeType == "Rec" && calcType == "A")
                {
                    var rectangle = new Rectangle { Length = double.Parse(fields[2]), Width = double.Parse(fields[3]) };
                    Console.WriteLine($"Area of Rectangle: {rectangle.CalculateArea()}");
                }
                else if (shapeType == "Cir" && calcType == "A")
                {
                    var circle = new Circle { Radius = double.Parse(fields[2]) };
                    Console.WriteLine($"Area of Circle: {circle.CalculateArea()}");
                }
                else if (shapeType == "")
                // You can expand this with more shapes and calculations
            }
        }
    }
}
