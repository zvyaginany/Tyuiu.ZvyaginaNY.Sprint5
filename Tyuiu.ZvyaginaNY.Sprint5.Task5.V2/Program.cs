using System;
using System.IO;
using Tyuiu.ZvyaginaNY.Sprint5.Task5.V2.Lib;

namespace Tyuiu.ZvyaginaNY.Sprint5.Task5.V2
{
    class Program
    {
        static void Main(string[] args)
        {
            DataService ds = new DataService();

            string path = @"C:\DataSprint5\InPutDataFileTask5V2.txt";

            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* ИСХОДНЫЕ ДАННЫЕ:                                                        *");
            Console.WriteLine("***************************************************************************");
            Console.WriteLine($"Путь к файлу: {path}");
            Console.WriteLine("Задача: найти среднее всех положительных значений из файла");

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

                    
                    string[] testData = {
                        "3.5", "-2.1", "8.9", "0", "-4.3",
                        "12.6", "-7.2", "5.1", "-1.8", "9.4"
                    };

                    File.WriteAllLines(path, testData);
                    Console.WriteLine("Создан тестовый файл со значениями:");
                    Console.WriteLine(string.Join(", ", testData));
                }

               
                Console.WriteLine("Содержимое файла:");
                string[] fileContent = File.ReadAllLines(path);
                foreach (string line in fileContent)
                {
                    Console.WriteLine(line);
                }
                Console.WriteLine();

                double result = ds.LoadFromDataFile(path);
                Console.WriteLine($"Среднее всех положительных значений = {result:F3}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }

            Console.ReadKey();
        }
    }
}