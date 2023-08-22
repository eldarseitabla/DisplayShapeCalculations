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
                IShape shape = null;

                switch (fields[0])
                {
                    case "Rec":
                        shape = new Rectangle { Length = Convert.ToDouble(fields[2]), Width = Convert.ToDouble(fields[3]) };
                        break;
                    case "Sq":
                        shape = new Square { SideLength = Convert.ToDouble(fields[2]) };
                        break;
                    case "Cir":
                        shape = new Circle { Radius = Convert.ToDouble(fields[2]) };
                        break;
                    case "Cyl":
                        shape = new Cylinder { Radius = Convert.ToDouble(fields[2]), Height = Convert.ToDouble(fields[3]) };
                        break;
                    default:
                        Console.WriteLine($"Unknown shape type: {fields[0]}");
                        continue;
                }

                switch (fields[1])
                {
                    case "A":
                        Console.WriteLine($"Area of {fields[0]}: {shape.CalculateArea()}");
                        break;
                    case "SA":
                        Console.WriteLine($"Surface Area of Cylinder: {shape.CalculateArea()}");
                        break;
                    case "V":
                        if (shape is IShapeWithVolume shapeWithVolume)
                        {
                            Console.WriteLine($"Volume of {fields[0]}: {shapeWithVolume.CalculateVolume()}");
                        }
                        else
                        {
                            Console.WriteLine($"{fields[0]} doesn't support volume calculations.");
                        }
                        break;
                    default:
                        Console.WriteLine($"Unknown calculation type: {fields[1]}");
                        break;
                }
            }
            Console.ReadKey();
        }
    }
}
