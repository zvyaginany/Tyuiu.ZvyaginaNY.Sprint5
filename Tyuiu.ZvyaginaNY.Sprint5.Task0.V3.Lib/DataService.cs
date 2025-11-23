using System;
using System.IO;
using tyuiu.cources.programming.interfaces.Sprint5;

namespace Tyuiu.ZvyaginaNY.Sprint5.Task0.V3.Lib
{
    public class DataService : ISprint5Task0V3
    {
        public string SaveToFileTextData(int x)
        {
            
            double y = -0.25 * (Math.Pow(x, 3) - 3 * Math.Pow(x, 2) + 4);

           
            y = Math.Round(y, 3);

            
            string path = Path.GetTempFileName();

            
            using (StreamWriter writer = new StreamWriter(path))
            {
                writer.WriteLine(y);
            }

            return path;
        }
    }
}