using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tyuiu.ZvyaginaNY.Sprint5.Task1.V24.Lib;

namespace Tyuiu.ZvyaginaNY.Sprint5.Task1.V24.Test
{
    [TestClass]
    public class DataServiceTest
    {
        [TestMethod]
        public void CheckSaveToFileTextData()
        {
            string path = @"C:\Users\user\source\repos\Tyuiu.ZvyaginaNY.Sprint5\Tyuiu.ZvyaginaNY.Sprint5.Task1.V24\bin\Debug\OutPutFileTask1.txt";

            FileInfo fileInfo = new FileInfo(path);
            bool fileExists = fileInfo.Exists;

            bool wait = true;
            Assert.AreEqual(wait, fileExists);
        }

        [TestMethod]
        public void CheckFunctionCalculation()
        {
            DataService ds = new DataService();

            
            
            double result1 = ds.CalculateFunction(0); 
            double result2 = ds.CalculateFunction(1); 

            
            Assert.IsFalse(double.IsNaN(result1));
            Assert.IsFalse(double.IsInfinity(result1));
            Assert.IsFalse(double.IsNaN(result2));
            Assert.IsFalse(double.IsInfinity(result2));
        }

        [TestMethod]
        public void CheckFileCreation()
        {
            DataService ds = new DataService();
            string path = ds.SaveToFileTextData(-5, 5);

            bool fileExists = File.Exists(path);
            Assert.IsTrue(fileExists);

           
            string content = File.ReadAllText(path);
            Assert.IsFalse(string.IsNullOrEmpty(content));

        
            File.Delete(path);
        }
    }
}