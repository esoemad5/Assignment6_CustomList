using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CustomList;

namespace CustomListTest
{
    [TestClass]
    public class UnitTest1
    {
        public void Add_ValueToEmptyList_ValueInList()
        {
            //Arrange
            CustomList<int> customList = new CustomList<int>();
            int value = 16;

            int expectedResult = 16;
            //Act
            customList.Add(value);

            int result = customList[0];
            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void Add_Add2ValuesToEmptyList_2ndValueGoesTo2ndIndex()
        {
            //Arrange
            CustomList<int> customList = new CustomList<int>();
            int value0 = 16;
            int value1 = 20;

            int expectedResult = 20;
            //Act
            customList.Add(value0);
            customList.Add(value1);
            int result = customList[1];
            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void Add_Add2ValuesToEmptyList_1stValueGoesTo1stIndex()
        {
            //Arrange
            CustomList<int> customList = new CustomList<int>();
            int value0 = 16;
            int value1 = 20;

            int expectedResult = 16;
            //Act
            customList.Add(value0);
            customList.Add(value1);

            int result = customList[0];
            //Assert
            Assert.AreEqual(expectedResult, result);
        }
        public void Add_Add100ValuesToEmptyList_50thValueGoesTo50thIndex()
        {
            //Arrange
            CustomList<int> customList = new CustomList<int>();

            int expectedResult = 49;
            //Act
            for(int i = 0; i < 100; i++)
            {
                customList.Add(i);
            }

            int result = customList[49];
            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        public void Count_EmptyList_0()
        {
            //Arrange
            CustomList<int> customList = new CustomList<int>();

            int expectedResult = 0;
            //Act
            int result = customList.Count;
            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void Count_Length1List_1()
        {
            //Arrange
            CustomList<int> customList = new CustomList<int>();
            int value = 16;
            customList.Add(value);

            int expectedResult = 1;
            //Act
            int result = customList.Count;
            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void Count_Length100List_100()
        {
            //Arrange
            CustomList<int> customList = new CustomList<int>();
            for(int i = 0; i < 100; i++)
            {
                customList.Add(i);/////////////////////////////////////////////////////////////////////////
            }

            int expectedResult = 100;
            //Act
            int result = customList.Count;
            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        
    }
}
