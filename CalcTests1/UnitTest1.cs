using Microsoft.VisualStudio.TestTools.UnitTesting;
using AnalaizerClassLibrary;
using CalcClassBr;
using System;
namespace CalcTests.Tests
{
    [TestClass]
    public class CalcTests
    {

        public TestContext TestContext { get; set; }
        [DataSource("System.Data.SqlClient", @"Data Source=DESKTOP-GHMLDHS\SQLEXPRESS;Initial Catalog=newdb;Integrated Security=True;", "Data", DataAccessMethod.Sequential)]
        [TestMethod]
        public void TestAddBD()
        {
            int a = (int)TestContext.DataRow["a"];
            Console.WriteLine(a);
            int b = (int)TestContext.DataRow["b"];
            int expected = (int)TestContext.DataRow["r"];
            int actual;
            actual = CalcClass.Add(a, b);
            Assert.AreEqual(expected, actual);
        }

        [DataSource("System.Data.SqlClient", @"Data Source=DESKTOP-GHMLDHS\SQLEXPRESS;Initial Catalog=newdb;Integrated Security=True;", "UnitTestCases", DataAccessMethod.Sequential)]
        [TestMethod]
        public void TestBrackets()
        {
            string brackets = (string)TestContext.DataRow["InputExpression"];
            AnalaizerClass.expression = brackets;
            string expected = (string)TestContext.DataRow["ExpectedResult"];
            string actual;
            actual = AnalaizerClass.Estimate();
            Assert.AreEqual(expected, actual);
        }
    }
}
