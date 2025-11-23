using System;
using System.IO;
using Tyuiu.ZvyaginaNY.Sprint5.Task6.V14.Lib;

namespace Tyuiu.ZvyaginaNY.Sprint5.Task6.V14
{
    class Program
    {
        static void Main(string[] args)
        {
            DataService ds = new DataService();

            string path = @"C:\DataSprint5\InPutDataFileTask6V14.txt";

            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* ИСХОДНЫЕ ДАННЫЕ:                                                        *");
            Console.WriteLine("***************************************************************************");
            Console.WriteLine($"Путь к файлу: {path}");
            Console.WriteLine("Задача: найти количество знаков препинания в файле");

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

                    
                    string testText = "Привет, мир! Как дела? Это тестовый текст: с разными знаками препинания; и еще несколько... \"Кавычки\" - тире (скобки) [и другие].";
                    File.WriteAllText(path, testText, System.Text.Encoding.UTF8);

                    Console.WriteLine("Создан тестовый файл с текстом:");
                    Console.WriteLine(testText);
                    Console.WriteLine();
                }

                
                Console.WriteLine("Содержимое файла:");
                string fileContent = File.ReadAllText(path);
                Console.WriteLine(fileContent);
                Console.WriteLine();

                int result = ds.LoadFromDataFile(path);
                Console.WriteLine($"Количество знаков препинания = {result}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }

            Console.ReadKey();
        }
    }
}