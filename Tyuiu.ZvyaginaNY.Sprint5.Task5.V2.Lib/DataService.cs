using System;
using System.IO;
using System.Globalization;
using System.Linq;
using tyuiu.cources.programming.interfaces.Sprint5;

namespace Tyuiu.ZvyaginaNY.Sprint5.Task5.V2.Lib
{
    public class DataService : ISprint5Task5V2
    {
        public double LoadFromDataFile(string path)
        {
           
            if (!File.Exists(path))
            {
                throw new FileNotFoundException($"Файл не найден: {path}");
            }

            string fileContent = File.ReadAllText(path);

            
            string[] numberStrings = fileContent.Split(new char[] { ' ', '\n', '\r', '\t' },
                StringSplitOptions.RemoveEmptyEntries);

            Console.WriteLine($"DEBUG: Найдено {numberStrings.Length} строк в файле");

            var positiveNumbers = numberStrings
                .Select(str => str.Trim())
                .Where(str => !string.IsNullOrEmpty(str))
                .Select(str =>
                {
                   
                    string normalizedStr = str.Replace(',', '.');

                    
                    normalizedStr = new string(normalizedStr.Where(c =>
                        char.IsDigit(c) || c == '.' || c == '-').ToArray());

                    if (double.TryParse(normalizedStr, NumberStyles.Any, CultureInfo.InvariantCulture, out double number))
                    {
                        Console.WriteLine($"DEBUG: Успешно распаршено: '{str}' -> {number}");
                        return number;
                    }
                    else
                    {
                        Console.WriteLine($"DEBUG: Не удалось распарсить: '{str}'");
                        return double.NaN;
                    }
                })
                .Where(number => !double.IsNaN(number) && number > 0)
                .ToList();

            Console.WriteLine($"DEBUG: Найдено {positiveNumbers.Count} положительных чисел");

            
            if (positiveNumbers.Count == 0)
            {
                Console.WriteLine("DEBUG: Положительные числа не найдены");
                return 0;
            }

           
            double sum = positiveNumbers.Sum();
            double average = sum / positiveNumbers.Count;

            Console.WriteLine($"DEBUG: Сумма = {sum}, Количество = {positiveNumbers.Count}, Среднее = {average}");

            
            average = Math.Round(average, 3);

            Console.WriteLine($"DEBUG: Округленное среднее = {average}");

            return average;
        }
    }
}