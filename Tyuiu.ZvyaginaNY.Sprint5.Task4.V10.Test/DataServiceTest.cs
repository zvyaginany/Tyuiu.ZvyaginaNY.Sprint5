using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tyuiu.ZvyaginaNY.Sprint5.Task4.V10.Lib;

namespace Tyuiu.ZvyaginaNY.Sprint5.Task4.V10.Test
{
    [TestClass]
    public class DataServiceTest
    {
        [TestMethod]
        public void CheckLoadFromDataFile()
        {
           
            string path = Path.GetTempFileName();

            File.WriteAllText(path, "2.5");

            DataService ds = new DataService();
            double result = ds.LoadFromDataFile(path);

           
            double expected = 48.875;

            Assert.AreEqual(expected, result);

           
            File.Delete(path);
        }

        [TestMethod]
        public void CheckLoadFromDataFileWithNegativeValue()
        {
            
            string path = Path.GetTempFileName();
            File.WriteAllText(path, "-1.5");

            DataService ds = new DataService();
            double result = ds.LoadFromDataFile(path);

           
            double expected = 8.075;

            Assert.AreEqual(expected, result);

            File.Delete(path);
        }

        [TestMethod]
        public void CheckLoadFromDataFileWithZero()
        {
           
            string path = Path.GetTempFileName();
            File.WriteAllText(path, "0");

            DataService ds = new DataService();
            double result = ds.LoadFromDataFile(path);

           
            double expected = 2.0;

            Assert.AreEqual(expected, result);

            File.Delete(path);
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void CheckLoadFromDataFileFileNotFound()
        {
            DataService ds = new DataService();
            double result = ds.LoadFromDataFile(@"C:\Nonexistent\File.txt");
        }

        [TestMethod]
        public void CheckRounding()
        {
            string path = Path.GetTempFileName();
            File.WriteAllText(path, "1.234");

            DataService ds = new DataService();
            double result = ds.LoadFromDataFile(path);

          
            string resultStr = result.ToString("F6");
            string[] parts = resultStr.Split('.');

            if (parts.Length > 1)
            {
                Assert.IsTrue(parts[1].Length <= 3);
            }

           
            File.Delete(path);
        }
    }
}