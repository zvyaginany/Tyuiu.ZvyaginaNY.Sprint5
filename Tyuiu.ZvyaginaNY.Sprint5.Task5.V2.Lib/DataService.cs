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

            string[] lines = File.ReadAllLines(path);

            
            var positiveNumbers = lines
                .Select(line => line.Trim())
                .Where(line => !string.IsNullOrEmpty(line))
                .Select(line =>
                {
                   
                    string normalizedLine = line.Replace(',', '.');
                    if (double.TryParse(normalizedLine, NumberStyles.Any, CultureInfo.InvariantCulture, out double number))
                    {
                        return number;
                    }
                    return double.NaN;
                })
                .Where(number => !double.IsNaN(number) && number > 0) 
                .ToList();

            
            if (positiveNumbers.Count == 0)
            {
                return 0;
            }

            double average = positiveNumbers.Average();

            
            average = Math.Round(average, 3);

            return average;
        }
    }
}
