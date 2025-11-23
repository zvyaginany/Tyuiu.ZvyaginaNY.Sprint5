using System;
using System.IO;
using Tyuiu.ZvyaginaNY.Sprint5.Task7.V30.Lib;

namespace Tyuiu.ZvyaginaNY.Sprint5.Task7.V30
{
    class Program
    {
        static void Main(string[] args)
        {
            DataService ds = new DataService();

            string inputPath = @"C:\DataSprint5\InPutDataFileTask7V30.txt";

            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* ИСХОДНЫЕ ДАННЫЕ:                                                        *");
            Console.WriteLine("***************************************************************************");
            Console.WriteLine($"Входной файл: {inputPath}");
            Console.WriteLine("Задача: заменить все однозначные числа на число '9'");

            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* РЕЗУЛЬТАТ:                                                              *");
            Console.WriteLine("***************************************************************************");

            try
            {
              
                if (!File.Exists(inputPath))
                {
                    Console.WriteLine("Входной файл не найден. Создаем тестовый файл...");

                    
                    string directory = Path.GetDirectoryName(inputPath);
                    if (!Directory.Exists(directory))
                    {
                        Directory.CreateDirectory(directory);
                    }

                    
                    string testText = "В тексте есть числа: 1, 25, 3, 456, 7, 89, 0. Также 5 и 6.\n" +
                                     "Многозначные 123 и 45 не должны измениться, а однозначные 8 и 9 - да.";
                    File.WriteAllText(inputPath, testText, System.Text.Encoding.UTF8);

                    Console.WriteLine("Создан тестовый входной файл с текстом:");
                    Console.WriteLine(testText);
                    Console.WriteLine();
                }

                
                Console.WriteLine("Исходный текст:");
                string originalContent = File.ReadAllText(inputPath);
                Console.WriteLine(originalContent);
                Console.WriteLine();

               
                string outputPath = ds.LoadDataAndSave(inputPath);

                
                Console.WriteLine("Обработанный текст:");
                string resultContent = File.ReadAllText(outputPath);
                Console.WriteLine(resultContent);
                Console.WriteLine();

                Console.WriteLine($"Результат сохранен в: {outputPath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }

            Console.ReadKey();
        }
    }
}