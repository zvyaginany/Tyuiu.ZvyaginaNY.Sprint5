using System;
using System.IO;
using Tyuiu.ZvyaginaNY.Sprint5.Task2.V20.Lib;

namespace Tyuiu.ZvyaginaNY.Sprint5.Task2.V20
{
    class Program
    {
        static void Main(string[] args)
        {
            DataService ds = new DataService();

            // Создаем массив 3x3
            int[,] matrix = new int[3, 3];

            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* ИСХОДНЫЕ ДАННЫЕ:                                                        *");
            Console.WriteLine("***************************************************************************");
            Console.WriteLine("Введите 9 элементов массива 3x3:");

            
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write($"Элемент [{i},{j}]: ");
                    matrix[i, j] = int.Parse(Console.ReadLine());
                }
            }

            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* РЕЗУЛЬТАТ:                                                              *");
            Console.WriteLine("***************************************************************************");

           
            Console.WriteLine("Исходный массив:");
            PrintMatrix(matrix);

          
            string path = ds.SaveToFileTextData(matrix);

            
            Console.WriteLine("Преобразованный массив:");
            string[] resultLines = File.ReadAllLines(path);
            foreach (string line in resultLines)
            {
                Console.WriteLine(line.Replace(";", " "));
            }

            Console.WriteLine($"Файл сохранен: {path}");
            Console.ReadKey();
        }

        static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write($"{matrix[i, j],4} ");
                }
                Console.WriteLine();
            }
        }
    }
}