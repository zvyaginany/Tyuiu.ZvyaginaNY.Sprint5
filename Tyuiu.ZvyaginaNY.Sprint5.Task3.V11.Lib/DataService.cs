using System;
using System.IO;
using tyuiu.cources.programming.interfaces.Sprint5;

namespace Tyuiu.ZvyaginaNY.Sprint5.Task3.V11.Lib
{
    public class DataService : ISprint5Task3V11
    {
        public string SaveToFileTextData(int x)
        {
            string path = Path.Combine(Path.GetTempPath(), "OutPutFileTask3.bin");

          
            double y = (4 - Math.Pow(x, 3)) / Math.Pow(x, 2);

           
            y = Math.Round(y, 3);

            
            using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.Create)))
            {
                writer.Write(y);
            }

            return path;
        }
    }
}