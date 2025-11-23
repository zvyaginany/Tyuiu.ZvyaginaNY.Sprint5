using System;
using System.IO;
using System.Linq;
using System.Text;
using tyuiu.cources.programming.interfaces.Sprint5;

namespace Tyuiu.ZvyaginaNY.Sprint5.Task6.V14.Lib
{
    public class DataService : ISprint5Task6V14
    {
        public int LoadFromDataFile(string path)
        {
            
            if (!File.Exists(path))
            {
                throw new FileNotFoundException($"Файл не найден: {path}");
            }

            
            string fileContent = File.ReadAllText(path);

            char[] punctuationMarks = {
                '.', ',', '!', '?', ':', ';', '-',
                '(', ')', '[', ']', '{', '}', '"', '\'',
                '…', '—', '«', '»'
            };

            
            int count = fileContent.Count(c => punctuationMarks.Contains(c));

            return count;
        }
    }
}
