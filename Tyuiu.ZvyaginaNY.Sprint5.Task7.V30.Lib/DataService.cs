using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using tyuiu.cources.programming.interfaces.Sprint5;

namespace Tyuiu.ZvyaginaNY.Sprint5.Task7.V30.Lib
{
    public class DataService : ISprint5Task7V30
    {
        public string LoadDataAndSave(string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException($"Файл не найден: {path}");
            }

            string fileContent = File.ReadAllText(path);

            
            string pattern = @"\b\d\b";
            string result = Regex.Replace(fileContent, pattern, "9");

            string outputPath = Path.Combine(Path.GetTempPath(), "OutPutDataFileTask7V30.txt");
            File.WriteAllText(outputPath, result, Encoding.UTF8);

            return outputPath;
        }
    }
}