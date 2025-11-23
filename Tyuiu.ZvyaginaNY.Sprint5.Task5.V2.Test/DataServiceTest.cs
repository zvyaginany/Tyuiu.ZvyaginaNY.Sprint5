using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tyuiu.ZvyaginaNY.Sprint5.Task5.V2.Lib;

namespace Tyuiu.ZvyaginaNY.Sprint5.Task5.V2.Test
{
    [TestClass]
    public class DataServiceTest
    {
        [TestMethod]
        public void CheckLoadFromDataFile()
        {
            
            string path = Path.GetTempFileName();

            string[] testData = {
                "3.5", "-2.1", "8.9", "0", "-4.3",
                "12.6", "-7.2", "5.1", "-1.8", "9.4"
            };

            File.WriteAllLines(path, testData);

            DataService ds = new DataService();
            double result = ds.LoadFromDataFile(path);

            
            double expected = 7.900;

            Assert.AreEqual(expected, result);

           
            File.Delete(path);
        }

        [TestMethod]
        public void CheckLoadFromDataFileWithCommas()
        {
           
            string path = Path.GetTempFileName();

            string[] testData = {
                "3,5", "-2,1", "8,9", "0", "5,1"
            };

            File.WriteAllLines(path, testData);

            DataService ds = new DataService();
            double result = ds.LoadFromDataFile(path);

          
            double expected = 5.833;

            Assert.AreEqual(expected, result);

           
            File.Delete(path);
        }

        [TestMethod]
        public void CheckLoadFromDataFileNoPositiveNumbers()
        {
            
            string path = Path.GetTempFileName();

            string[] testData = {
                "-3.5", "-2.1", "-8.9", "-5.1"
            };

            File.WriteAllLines(path, testData);

            DataService ds = new DataService();
            double result = ds.LoadFromDataFile(path);

            
            double expected = 0;

            Assert.AreEqual(expected, result);

            
            File.Delete(path);
        }

        [TestMethod]
        public void CheckLoadFromDataFileEmptyFile()
        {
            
            string path = Path.GetTempFileName();

            DataService ds = new DataService();
            double result = ds.LoadFromDataFile(path);

            
            double expected = 0;

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

            string[] testData = {
                "1.2345", "2.3456", "3.4567"
            };

            File.WriteAllLines(path, testData);

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