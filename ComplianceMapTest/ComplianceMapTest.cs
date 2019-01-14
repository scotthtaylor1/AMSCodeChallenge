using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Implementations;

namespace ComplianceMapTest
{
    [TestClass]
    public class ComplianceMapTest
    {
        [TestMethod]
        public void TestEnteredData()
        {
            //Arrange
            ComplianceMapping mapTest = new ComplianceMapping();

            var finalArray = new List<char[]>();
            List<string> firstSet = new List<string>() { "*...", "....", ".*...", "...." };
            for (int i = 0; i < 4; i++)
            {
                finalArray.Add(firstSet[i].ToCharArray());
            }

            //Act
            var result = mapTest.CreateComplianceMap(finalArray, 4, 4, 1);

            //Assert
            Assert.AreEqual("Set #1", result[0].ToString());
            Assert.AreEqual("*100", result[1].ToString());
            Assert.AreEqual("2210", result[2].ToString());
            Assert.AreEqual("1*10", result[3].ToString());
        }

        [TestMethod]
        public void TestNegativeData()
        {
            ComplianceMapping mapTest = new ComplianceMapping();

            var finalArray = new List<char[]>();
            List<string> firstSet = new List<string>() { "*...", "....", ".*...", "...." };
            for (int i = 0; i < 4; i++)
            {
                finalArray.Add(firstSet[i].ToCharArray());
            }

            //Act
            var result = mapTest.CreateComplianceMap(finalArray, -1, 1, 1);

            //Assert
            Assert.AreEqual("Set #1", result[0].ToString());
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => result[1].ToString());
        }
    }
}
