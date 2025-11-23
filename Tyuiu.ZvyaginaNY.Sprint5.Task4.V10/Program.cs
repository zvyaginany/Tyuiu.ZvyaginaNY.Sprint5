using System;
using System.IO;
using System.Globalization;
using Tyuiu.ZvyaginaNY.Sprint5.Task4.V10.Lib;

namespace Tyuiu.ZvyaginaNY.Sprint5.Task4.V10
{
    class Program
    {
        static void Main(string[] args)
        {
            DataService ds = new DataService();

            string path = @"C:\DataSprint5\InPutDataFileTask4V0.txt";

            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* ИСХОДНЫЕ ДАННЫЕ:                                                        *");
            Console.WriteLine("***************************************************************************");
            Console.WriteLine($"Путь к файлу: {path}");
            Console.WriteLine($"Формула: y = x³ * 1.2x + 2");

            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* РЕЗУЛЬТАТ:                                                              *");
            Console.WriteLine("***************************************************************************");

            try
            {
                
                if (!File.Exists(path))
                {
                    Console.WriteLine("Файл не найден. Создаем тестовый файл...");

                    
                    string directory = Path.GetDirectoryName(path);
                    if (!Directory.Exists(directory))
                    {
                        Directory.CreateDirectory(directory);
                    }

                   
                    using (StreamWriter writer = new StreamWriter(path, false))
                    {
                        writer.Write("2.5".Replace(',', '.'));
                    }
                    Console.WriteLine($"Создан тестовый файл со значением: 2.5");
                }

                
                string fileContent = File.ReadAllText(path);
                Console.WriteLine($"Содержимое файла: '{fileContent}'");

                double result = ds.LoadFromDataFile(path);
                Console.WriteLine($"Значение y = {result:F3}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
                Console.WriteLine($"Тип ошибки: {ex.GetType()}");
            }

            Console.ReadKey();
        }
    }
}