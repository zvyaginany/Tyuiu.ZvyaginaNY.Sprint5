using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tyuiu.ZvyaginaNY.Sprint5.Task7.V30.Lib;

namespace Tyuiu.ZvyaginaNY.Sprint5.Task7.V30.Test
{
    [TestClass]
    public class DataServiceTest
    {
        [TestMethod]
        public void CheckLoadDataAndSave()
        {
           
            string inputPath = Path.GetTempFileName();

            string testText = "Числа: 1, 25, 3, 456, 7, 89, 0. Также 5 и 6.";
            File.WriteAllText(inputPath, testText);

            DataService ds = new DataService();
            string outputPath = ds.LoadDataAndSave(inputPath);

            
            Assert.IsTrue(File.Exists(outputPath));

            
            string result = File.ReadAllText(outputPath);

            
            string expected = "Числа: 9, 25, 9, 456, 9, 89, 9. Также 9 и 9.";

            Assert.AreEqual(expected, result);

            
            File.Delete(inputPath);
            File.Delete(outputPath);
        }

        [TestMethod]
        public void CheckSingleDigitReplacement()
        {
            string inputPath = Path.GetTempFileName();

            string testText = "1 2 3 4 5 6 7 8 9 0";
            File.WriteAllText(inputPath, testText);

            DataService ds = new DataService();
            string outputPath = ds.LoadDataAndSave(inputPath);

            string result = File.ReadAllText(outputPath);
            string expected = "9 9 9 9 9 9 9 9 9 9";

            Assert.AreEqual(expected, result);

            File.Delete(inputPath);
            File.Delete(outputPath);
        }

        [TestMethod]
        public void CheckMultiDigitPreservation()
        {
            string inputPath = Path.GetTempFileName();

            string testText = "10 25 100 999 12345";
            File.WriteAllText(inputPath, testText);

            DataService ds = new DataService();
            string outputPath = ds.LoadDataAndSave(inputPath);

            string result = File.ReadAllText(outputPath);
            string expected = "10 25 100 999 12345"; 

            Assert.AreEqual(expected, result);

            File.Delete(inputPath);
            File.Delete(outputPath);
        }

        [TestMethod]
        public void CheckMixedContent()
        {
            string inputPath = Path.GetTempFileName();

            string testText = "У меня 2 яблока и 25 груш. Температура 5 градусов, а завтра будет 15.";
            File.WriteAllText(inputPath, testText);

            DataService ds = new DataService();
            string outputPath = ds.LoadDataAndSave(inputPath);

            string result = File.ReadAllText(outputPath);
            string expected = "У меня 9 яблока и 25 груш. Температура 9 градусов, а завтра будет 15.";

            Assert.AreEqual(expected, result);

            File.Delete(inputPath);
            File.Delete(outputPath);
        }

        [TestMethod]
        public void CheckNoDigits()
        {
            string inputPath = Path.GetTempFileName();

            string testText = "Это текст без чисел.";
            File.WriteAllText(inputPath, testText);

            DataService ds = new DataService();
            string outputPath = ds.LoadDataAndSave(inputPath);

            string result = File.ReadAllText(outputPath);
            string expected = "Это текст без чисел.";

            Assert.AreEqual(expected, result);

            File.Delete(inputPath);
            File.Delete(outputPath);
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void CheckFileNotFound()
        {
            DataService ds = new DataService();
            string result = ds.LoadDataAndSave(@"C:\Nonexistent\File.txt");
        }

        [TestMethod]
        public void CheckOutputFileCreation()
        {
            string inputPath = Path.GetTempFileName();
            File.WriteAllText(inputPath, "Test 1 2 3");

            DataService ds = new DataService();
            string outputPath = ds.LoadDataAndSave(inputPath);

            string expectedDirectory = Path.GetTempPath();
            string actualDirectory = Path.GetDirectoryName(outputPath);

            Assert.AreEqual(expectedDirectory, actualDirectory);

            
            string fileName = Path.GetFileName(outputPath);
            Assert.AreEqual("OutPutDataFileTask7V30.txt", fileName);

            File.Delete(inputPath);
            File.Delete(outputPath);
        }
    }
}