using System;
using System.IO;
using Tyuiu.ZvyaginaNY.Sprint5.Task3.V11.Lib;

namespace Tyuiu.ZvyaginaNY.Sprint5.Task3.V11
{
    class Program
    {
        static void Main(string[] args)
        {
            DataService ds = new DataService();
            int x = 3;

            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* ИСХОДНЫЕ ДАННЫЕ:                                                        *");
            Console.WriteLine("***************************************************************************");
            Console.WriteLine($"x = {x}");
            Console.WriteLine($"Выражение: y = (4 - x³) / x²");

            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* РЕЗУЛЬТАТ:                                                              *");
            Console.WriteLine("***************************************************************************");

            string path = ds.SaveToFileTextData(x);

            
            double result;
            using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))
            {
                result = reader.ReadDouble();
            }

            Console.WriteLine($"Значение y = {result:F3}");
            Console.WriteLine($"Файл сохранен: {path}");

            Console.ReadKey();
        }
    }
}