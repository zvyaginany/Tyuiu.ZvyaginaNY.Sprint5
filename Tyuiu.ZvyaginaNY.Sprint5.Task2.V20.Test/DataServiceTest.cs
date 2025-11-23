using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tyuiu.ZvyaginaNY.Sprint5.Task2.V20.Lib;

namespace Tyuiu.ZvyaginaNY.Sprint5.Task2.V20.Test
{
    [TestClass]
    public class DataServiceTest
    {
        [TestMethod]
        public void CheckSaveToFileTextData()
        {
            string path = @"C:\Users\user\source\repos\Tyuiu.ZvyaginaNY.Sprint5\Tyuiu.ZvyaginaNY.Sprint5.Task2.V20\bin\Debug\OutPutFileTask2.csv";

            FileInfo fileInfo = new FileInfo(path);
            bool fileExists = fileInfo.Exists;

            bool wait = true;
            Assert.AreEqual(wait, fileExists);
        }

        [TestMethod]
        public void CheckMatrixTransformation()
        {
            DataService ds = new DataService();

            
            int[,] matrix = new int[3, 3]
            {
                { 5, -5, -1 },
                { -4, 2, -4 },
                { -7, 1, 4 }
            };

            string path = ds.SaveToFileTextData(matrix);

           
            Assert.IsTrue(File.Exists(path));

          
            string[] lines = File.ReadAllLines(path);

           
            Assert.AreEqual(3, lines.Length);

          
            string[] firstLine = lines[0].Split(';');
            Assert.AreEqual("1", firstLine[0].Trim());
            Assert.AreEqual("0", firstLine[1].Trim());
            Assert.AreEqual("0", firstLine[2].Trim());

            
            string[] secondLine = lines[1].Split(';');
            Assert.AreEqual("0", secondLine[0].Trim());
            Assert.AreEqual("1", secondLine[1].Trim());
            Assert.AreEqual("0", secondLine[2].Trim());

           
            string[] thirdLine = lines[2].Split(';');
            Assert.AreEqual("0", thirdLine[0].Trim());
            Assert.AreEqual("1", thirdLine[1].Trim());
            Assert.AreEqual("1", thirdLine[2].Trim());

          
            File.Delete(path);
        }

        [TestMethod]
        public void CheckFileFormat()
        {
            DataService ds = new DataService();

            int[,] matrix = new int[2, 2]
            {
                { 1, -2 },
                { -3, 4 }
            };

            string path = ds.SaveToFileTextData(matrix);

            string content = File.ReadAllText(path);

           
            Assert.IsTrue(content.Contains(";"));

            
            string[] lines = content.Split('\n');
            foreach (string line in lines)
            {
                if (!string.IsNullOrEmpty(line.Trim()))
                {
                    string[] values = line.Split(';');
                    foreach (string value in values)
                    {
                        Assert.IsTrue(value.Trim() == "0" || value.Trim() == "1");
                    }
                }
            }

            
            File.Delete(path);
        }
    }
}