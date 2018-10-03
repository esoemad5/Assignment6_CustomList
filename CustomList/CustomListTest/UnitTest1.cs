using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CustomList;

namespace CustomListTest
{
    [TestClass]
    public class UnitTest1
    {
        public void TestMethod1()
        {
            //Arrange
            CustomList<int> customList = new CustomList<int>();
            int value = 16;
            //Act
            customList.Add(value);
            //Assert
            Assert.AreEqual(value, customList[0]);
        }

        [TestMethod]
        public void TestMethod2()
        {
            //Arrange
            CustomList<int> customList = new CustomList<int>();
            int value = 16;
            int countValue = 1;
            //Act
            customList.Add(value);
            //Assert
            Assert.AreEqual(countValue, customList.Count);
        }

        [TestMethod]
        public void TestMethod3()
        {
            //Arrange
            CustomList<int> customList = new CustomList<int>();
            int value0 = 16;
            int value1 = 20;
            //Act
            customList.Add(value0);
            customeList.Add(value1);
            //Assert
            Assert.AreEqual(value1, customList[1]);
        }
    }
}
