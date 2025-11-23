using System;
using System.IO;
using tyuiu.cources.programming.interfaces.Sprint5;

namespace Tyuiu.ZvyaginaNY.Sprint5.Task1.V24.Lib
{
    public class DataService : ISprint5Task1V24
    {
        public string SaveToFileTextData(int startValue, int stopValue)
        {
            string path = Path.Combine(Path.GetTempPath(), "OutPutFileTask1.txt");

            using (StreamWriter writer = new StreamWriter(path))
            {
                writer.WriteLine("╔══════════════════════════╗");
                writer.WriteLine("║     Табулирование f(x)   ║");
                writer.WriteLine("╠══════╦═══════════════════╣");
                writer.WriteLine("║   x  ║        f(x)       ║");
                writer.WriteLine("╠══════╬═══════════════════╣");

                for (int x = startValue; x <= stopValue; x++)
                {
                    double value = CalculateFunction(x);
                    writer.WriteLine($"║ {x,4} ║ {value,17:F2} ║");
                }

                writer.WriteLine("╚══════╩═══════════════════╝");
            }

            return path;
        }

        private double CalculateFunction(int x)
        {
            
            if (Math.Abs(4 * x - 0.5) < 0.0001) 
            {
                return 0;
            }

            try
            {
                double result = (3 * Math.Cos(x)) / (4 * x - 0.5) + Math.Sin(x) - 5 * x - 2;
                return Math.Round(result, 2);
            }
            catch (DivideByZeroException)
            {
                return 0;
            }
        }
    }
}
