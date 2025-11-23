using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tyuiu.ZvyaginaNY.Sprint5.Task3.V11.Lib;

namespace Tyuiu.ZvyaginaNY.Sprint5.Task3.V11.Test
{
    [TestClass]
    public class DataServiceTest
    {
        [TestMethod]
        public void CheckSaveToFileTextData()
        {
            string path = @"C:\Users\user\source\repos\Tyuiu.ZvyaginaNY.Sprint5\Tyuiu.ZvyaginaNY.Sprint5.Task3.V11\bin\Debug\OutPutFileTask3.bin";

            FileInfo fileInfo = new FileInfo(path);
            bool fileExists = fileInfo.Exists;

            bool wait = true;
            Assert.AreEqual(wait, fileExists);
        }

        [TestMethod]
        public void CheckBinaryFileContent()
        {
            DataService ds = new DataService();
            int x = 3;

            string path = ds.SaveToFileTextData(x);

            // Проверяем существование файла
            Assert.IsTrue(File.Exists(path));

            // Проверяем, что файл не пустой
            FileInfo fileInfo = new FileInfo(path);
            Assert.IsTrue(fileInfo.Length > 0);

            // Читаем данные из бинарного файла
            double result;
            using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))
            {
                result = reader.ReadDouble();
            }

            // Ожидаемое значение: (4 - 3³) / 3² = (4 - 27) / 9 = -23 / 9 ≈ -2.5556
            // После округления до 3 знаков: -2.556
            double expected = -2.556;

            Assert.AreEqual(expected, result, 0.001);

            // Очистка
            File.Delete(path);
        }

        [TestMethod]
        public void CheckCalculation()
        {
            DataService ds = new DataService();
            int x = 3;

            string path = ds.SaveToFileTextData(x);

            
            double result;
            using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))
            {
                result = reader.ReadDouble();
            }

           
            double manualCalculation = (4 - Math.Pow(3, 3)) / Math.Pow(3, 2); 
            manualCalculation = Math.Round(manualCalculation, 3);

            Assert.AreEqual(manualCalculation, result);

            
            File.Delete(path);
        }

        [TestMethod]
        public void CheckFileExtension()
        {
            DataService ds = new DataService();
            int x = 3;

            string path = ds.SaveToFileTextData(x);

            
            string extension = Path.GetExtension(path);
            Assert.AreEqual(".bin", extension);

           
            File.Delete(path);
        }
    }
}