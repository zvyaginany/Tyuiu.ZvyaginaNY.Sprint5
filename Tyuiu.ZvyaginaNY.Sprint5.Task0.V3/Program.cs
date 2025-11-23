using System;
using Tyuiu.ZvyaginaNY.Sprint5.Task0.V3.Lib;

namespace Tyuiu.ZvyaginaNY.Sprint5.Task0.V3
{
    class Program
    {
        static void Main(string[] args)
        {
            DataService ds = new DataService();
            int x = 3;

            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* ИСХОДНЫЕ ДАННЫЕ:                                                        *");
            Console.WriteLine("***************************************************************************");
            Console.WriteLine("x = " + x);

            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* РЕЗУЛЬТАТ:                                                              *");
            Console.WriteLine("***************************************************************************");

            string res = ds.SaveToFileTextData(x);

            
            string result = File.ReadAllText(res);
            Console.WriteLine("Файл: " + res);
            Console.WriteLine("Успешно создан!");
            Console.WriteLine("Значение y = " + result);

            Console.ReadKey();
        }
    }
}