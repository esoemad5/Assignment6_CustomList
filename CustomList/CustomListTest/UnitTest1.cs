﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CustomList;

namespace CustomListTest
{
    [TestClass]
    public class UnitTest1
    {
        // Add
        [TestMethod]
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

        [TestMethod]
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


        // Count
        [TestMethod]
        public void Count_NewObject_0()
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
        public void Count_EmptyList_0()
        {
            //Arrange
            CustomList<int> customList = new CustomList<int>();
            customList.Add(1);
            customList.Remove(1);

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
                customList.Add(i);
            }

            int expectedResult = 100;
            //Act
            int result = customList.Count;
            //Assert
            Assert.AreEqual(expectedResult, result);
        }


        // Remove

        [TestMethod]
        public void Remove_ListOnlyContainsObject_EmptyList()
        {
            //Arrange
            CustomList<int> customList = new CustomList<int>();
            int[] expectedResult = customList.Data;
            customList.Add(1);
            //Act
            customList.Remove(1);
            int[] result = customList.Data;
            //Assert
            Assert.IsTrue(ArraysAreEqual(expectedResult, result));
        }

        [TestMethod]
        public void Remove_ListOnlyContainsObject_True() // only check for true in this one case.  This tests ensures the method returns true if an object is removed. Other cases test if object is removed in specific conditions. If the object is removed under specific conditions and this test passed, there should be no reason the true/false test would fail for the specific conditions.
        {
            //Arrange
            CustomList<int> customList = new CustomList<int>();
            customList.Add(1);
            //Act
            bool result = customList.Remove(1);
            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Remove_ListContains1OfTheTargetAtTheBegining_ListSansTarget()
        {
            //Arrange
            CustomList<int> customList = new CustomList<int>();
            customList.Add(1);
            customList.Add(2);

            int[] expectedResult = new int[] { 2 };
            //Act
            customList.Remove(1);
            int[] result = customList.Data;
            //Assert
            Assert.IsTrue(ArraysAreEqual(expectedResult, result));
        }

        [TestMethod]
        public void Remove_ListContainsMultipleOfTheTarget_ListSans1stOccurrence()
        {
            //Arrange
            CustomList<int> customList = new CustomList<int>();
            customList.Add(1);
            customList.Add(2);
            customList.Add(1);

            int[] expectedResult = new int[] { 2, 1 };
            //Act
            customList.Remove(1);
            int[] result = customList.Data;
            //Assert
            Assert.IsTrue(ArraysAreEqual(expectedResult, result));
        }

        [TestMethod]
        public void Remove_RemoveFromNewList_False()
        {
            //Arrange
            CustomList<int> customList = new CustomList<int>();
            //Act
            bool result = customList.Remove(6);
            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Remove_RemoveFromNewList_0()
        {
            //Arrange
            CustomList<int> customList = new CustomList<int>();

            int expectedResult = 0;
            //Act
            customList.Remove(6);

            int result = customList.Count;
            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void Remove_RemoveFromEmptyList_False()
        {
            //Arrange
            CustomList<int> customList = new CustomList<int>();
            customList.Add(99);
            customList.Remove(99);
            //Act
            bool result = customList.Remove(6);
            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Remove_RemoveFromEmptyList_0()
        {
            //Arrange
            CustomList<int> customList = new CustomList<int>();
            customList.Add(99);
            customList.Remove(99);

            int expectedResult = 0;
            //Act
            customList.Remove(99);

            int result = customList.Count;
            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        // ToString
        // +
        // -
        // Zip
        // Indexer
        [TestMethod]
        public void IndexerGet_1ElementList_ValueAtIndex()
        {
            //Arrange
            CustomList<int> customList = new CustomList<int>();
            customList.Add(5);

            int expectedResult = 5;
            //Act
            int result = customList[0];
            //Assert
            Assert.AreEqual(expectedResult, result);
        }
        [TestMethod][ExpectedException(typeof(IndexOutOfRangeException))]
        public void IndexerGet_0ElementList_IndexOutOfRangeException()
        {
            //Arrange
            CustomList<int> customList = new CustomList<int>();
            //Act
            int test = customList[0];
        }

        [TestMethod]
        public void IndexerSet_1ElementList_ValueSpecified()
        {
            //Arrange
            CustomList<int> customList = new CustomList<int>();
            customList.Add(5);

            int expectedResult = 6;
            //Act
            customList[0] = 6;

            int result = customList[0];
            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void IndexerSet_0ElementList_IndexOutOfRangeException()
        {
            //Arrange
            CustomList<int> customList = new CustomList<int>();
            //Act
            customList[0] = 5;
        }

        // Iterable


        // Template
        [TestMethod]
        public void __()
        {
            //Arrange
            CustomList<int> customList = new CustomList<int>();
            //Act
            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        private bool ArraysAreEqual(T[] arr1, int[] arr2) // pls
        {
            if(arr1.Length != arr2.Length)
            {
                return false;
            }
            for(int i = 0; i < arr1.Length; i++)
            {
                if(arr1[i] != arr2[i])
                {
                    return false;
                }
            }
            return true;
        }
       
    }
}
