using System;
using System.IO;
using System.Globalization;
using tyuiu.cources.programming.interfaces.Sprint5;

namespace Tyuiu.ZvyaginaNY.Sprint5.Task4.V10.Lib
{
    public class DataService : ISprint5Task4V10
    {
        public double LoadFromDataFile(string path)
        {
           
            string strX = File.ReadAllText(path).Trim();

            
            strX = strX.Replace(',', '.');

            
            double x = double.Parse(strX, CultureInfo.InvariantCulture);

            double y = 1.2 * Math.Pow(x, 4) + 2;

           
            y = Math.Round(y, 3);

            return y;
        }
    }
}