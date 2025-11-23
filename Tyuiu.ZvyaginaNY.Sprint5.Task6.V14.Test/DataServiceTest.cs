using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tyuiu.ZvyaginaNY.Sprint5.Task6.V14.Lib;

namespace Tyuiu.ZvyaginaNY.Sprint5.Task6.V14.Test
{
    [TestClass]
    public class DataServiceTest
    {
        [TestMethod]
        public void CheckLoadFromDataFile()
        {
            
            string path = Path.GetTempFileName();

            string testText = "Привет, мир! Как дела? Это тестовый текст.";
            File.WriteAllText(path, testText, System.Text.Encoding.UTF8);

            DataService ds = new DataService();
            int result = ds.LoadFromDataFile(path);

            
            int expected = 4;

            Assert.AreEqual(expected, result);

            
            File.Delete(path);
        }

        [TestMethod]
        public void CheckLoadFromDataFileWithMultiplePunctuation()
        {
            
            string path = Path.GetTempFileName();

            string testText = "Hello, world! How are you? I'm fine; thanks. \"Quotes\" - dash (parentheses) [brackets]...";
            File.WriteAllText(path, testText, System.Text.Encoding.UTF8);

            DataService ds = new DataService();
            int result = ds.LoadFromDataFile(path);

            
            int expected = 15;

            Assert.AreEqual(expected, result);

            File.Delete(path);
        }

        [TestMethod]
        public void CheckLoadFromDataFileNoPunctuation()
        {
            
            string path = Path.GetTempFileName();

            string testText = "Это текст без знаков препинания";
            File.WriteAllText(path, testText, System.Text.Encoding.UTF8);

            DataService ds = new DataService();
            int result = ds.LoadFromDataFile(path);

            int expected = 0;

            Assert.AreEqual(expected, result);

            
            File.Delete(path);
        }

        [TestMethod]
        public void CheckLoadFromDataFileEmptyFile()
        {
            
            string path = Path.GetTempFileName();

            DataService ds = new DataService();
            int result = ds.LoadFromDataFile(path);

            
            int expected = 0;

            Assert.AreEqual(expected, result);

            
            File.Delete(path);
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void CheckLoadFromDataFileFileNotFound()
        {
            DataService ds = new DataService();
            int result = ds.LoadFromDataFile(@"C:\Nonexistent\File.txt");
        }

        [TestMethod]
        public void CheckLoadFromDataFileWithRussianText()
        {
            
            string path = Path.GetTempFileName();

            string testText = "— Здравствуйте! — сказал он. — Как ваши дела? Всё хорошо?";
            File.WriteAllText(path, testText, System.Text.Encoding.UTF8);

            DataService ds = new DataService();
            int result = ds.LoadFromDataFile(path);

           
            int expected = 7;

            Assert.AreEqual(expected, result);

            
            File.Delete(path);
        }
    }
}