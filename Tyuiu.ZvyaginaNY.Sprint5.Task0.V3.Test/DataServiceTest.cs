using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tyuiu.ZvyaginaNY.Sprint5.Task0.V3.Lib;

namespace Tyuiu.ZvyaginaNY.Sprint5.Task0.V3.Test
{
    [TestClass]
    public class DataServiceTest
    {
        [TestMethod]
        public void CheckSaveToFileTextData()
        {
            string path = @"C:\Users\user\source\repos\Tyuiu.ZvyaginaNY.Sprint5\Tyuiu.ZvyaginaNY.Sprint5.Task0.V3\bin\Debug\OutPutFileTask0.txt";

            FileInfo fileInfo = new FileInfo(path);
            bool fileExists = fileInfo.Exists;

           
            Assert.IsTrue(fileExists);

            
            string fileContent = File.ReadAllText(path).Trim();
            string expected = "-1,000"; 

            Assert.AreEqual(expected, fileContent);
        }
    }
}