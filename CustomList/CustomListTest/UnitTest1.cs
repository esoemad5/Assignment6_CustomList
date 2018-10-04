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
            customList.Add(1);

            int expectedResult = 0;
            //Act
            customList.Remove(1);
            int result = customList.Count;
            //Assert
            Assert.AreEqual(expectedResult, result);
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

            CustomList<int> expectedResult = new CustomList<int>();
            expectedResult.Add(2);
            //Act
            customList.Remove(1);
            CustomList<int> result = customList;
            //Assert
            Assert.IsTrue(ListsAreEqual(expectedResult, result));
        }

        [TestMethod]
        public void Remove_ListContains1OfTheTargetAtTheEnd_ListSansTarget()
        {
            //Arrange
            CustomList<int> customList = new CustomList<int>();
            customList.Add(1);
            customList.Add(2);
            customList.Add(3);

            CustomList<int> expectedResult = new CustomList<int>();
            expectedResult.Add(1);
            expectedResult.Add(2);
            //Act
            customList.Remove(3);
            CustomList<int> result = customList;
            //Assert
            Assert.IsTrue(ListsAreEqual(expectedResult, result));
        }

        [TestMethod]
        public void Remove_ListContainsMultipleOfTheTarget_ListSans1stOccurrence()
        {
            //Arrange
            CustomList<int> customList = new CustomList<int>();
            customList.Add(1);
            customList.Add(2);
            customList.Add(1);

            CustomList<int> expectedResult = new CustomList<int>();
            expectedResult.Add(2);
            expectedResult.Add(1);
            //Act
            customList.Remove(1);
            CustomList<int> result = customList;
            //Assert
            Assert.IsTrue(ListsAreEqual(expectedResult, result));
        }

        [TestMethod]
        public void Remove_ListDoesNotContainTheTarget_OriginalList()
        {
            //Arrange
            CustomList<int> customList1 = new CustomList<int>();
            customList1.Add(1);
            customList1.Add(2);
            customList1.Add(3);

            CustomList<int> expectedResult = customList1;
            //Act
            customList1.Remove(7);
            CustomList<int> result = customList1;
            //Assert
            Assert.IsTrue(ListsAreEqual(expectedResult, result));
        }

        [TestMethod]
        public void Remove_ListDoesNotContainTheTarget_False()
        {
            //Arrange
            CustomList<int> customList1 = new CustomList<int>();
            customList1.Add(1);
            customList1.Add(2);
            customList1.Add(3);
            //Act
            bool result = customList1.Remove(7);
            //Assert
            Assert.IsFalse(result);
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
        [TestMethod]
        public void ToString_3Elements_StringComprisedOfTheElements()
        {
            //Arrange
            CustomList<int> customList = new CustomList<int>();
            customList.Add(1);
            customList.Add(2);
            customList.Add(3);

            string expectedResult = "123";
            //Act
            string result = customList.ToString();
            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void ToString_NewObject_EmptyString()
        {
            //Arrange
            CustomList<int> customList = new CustomList<int>();

            string expectedResult = "";
            //Act
            string result = customList.ToString();
            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void ToString_Length0Array_EmptyString()
        {
            //Arrange
            CustomList<int> customList = new CustomList<int>();
            customList.Add(1);
            customList.Remove(1);

            string expectedResult = "";
            //Act
            string result = customList.ToString();
            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        // +
        [TestMethod]
        public void AdditionOperatorOverload_TwoNonEmptyLists_ConcatenatedList()
        {
            //Arrange
            CustomList<int> list1 = new CustomList<int>();
            CustomList<int> list2 = new CustomList<int>();
            list1.Add(1);
            list1.Add(2);
            list1.Add(3);
            list2.Add(4);
            list2.Add(5);
            list2.Add(6);

            CustomList<int> expectedResult = new CustomList<int>();
            expectedResult.Add(1);
            expectedResult.Add(2);
            expectedResult.Add(3);
            expectedResult.Add(4);
            expectedResult.Add(5);
            expectedResult.Add(6);
            //Act
            CustomList<int> result = (list1 + list2);
            //Assert
            Assert.IsTrue(ListsAreEqual(expectedResult, result));
        }

        [TestMethod]
        public void AdditionOperatorOverload_OneListIsEmpty_TheNonEmptyList()
        {
            //Arrange
            CustomList<int> list1 = new CustomList<int>();
            CustomList<int> list2 = new CustomList<int>();
            list1.Add(1);
            list1.Add(2);
            list1.Add(3);

            CustomList<int> expectedResult = new CustomList<int>();
            expectedResult.Add(1);
            expectedResult.Add(2);
            expectedResult.Add(3);
            //Act
            CustomList<int> result = (list1 + list2);
            //Assert
            Assert.IsTrue(ListsAreEqual(expectedResult, result));
        }

        [TestMethod]
        public void AdditionOperatorOverload_OtherListIsEmpty_TheNonEmptyList()
        {
            //Arrange
            CustomList<int> list1 = new CustomList<int>();
            CustomList<int> list2 = new CustomList<int>();
            list2.Add(1);
            list2.Add(2);
            list2.Add(3);

            CustomList<int> expectedResult = new CustomList<int>();
            expectedResult.Add(1);
            expectedResult.Add(2);
            expectedResult.Add(3);
            //Act
            CustomList<int> result = (list1 + list2);
            //Assert
            Assert.IsTrue(ListsAreEqual(expectedResult, result));
        }

        [TestMethod]
        public void AdditionOperatorOverload_BothListsAreEmpty_EmptyList()
        {
            //Arrange
            CustomList<int> list1 = new CustomList<int>();
            CustomList<int> list2 = new CustomList<int>();

            CustomList<int> expectedResult = new CustomList<int>();
            //Act
            CustomList<int> result = (list1 + list2);
            //Assert
            Assert.IsTrue(ListsAreEqual(expectedResult, result));
        }

        // -
        [TestMethod]
        public void SubtractionOperatorOverload_MinuendContainsPartOrAllOfTheSubtrahend_ShortenedList()
        {
            //Arrange
            CustomList<int> list1 = new CustomList<int>();
            CustomList<int> list2 = new CustomList<int>();
            list1.Add(1);
            list1.Add(2);
            list1.Add(3);
            list2.Add(3);
            list2.Add(4);
            list2.Add(5);

            CustomList<int> expectedResult = new CustomList<int>();
            expectedResult.Add(1);
            expectedResult.Add(2);
            //Act
            CustomList<int> result = (list1 - list2);
            //Assert
            Assert.IsTrue(ListsAreEqual(expectedResult, result));
        }

        [TestMethod]
        public void SubtractionOperatorOverload_MinuendContainsNoneOfTheSubtrahend_OriginalList()
        {
            //Arrange
            CustomList<int> list1 = new CustomList<int>();
            CustomList<int> list2 = new CustomList<int>();
            list1.Add(1);
            list1.Add(2);
            list1.Add(3);
            list2.Add(4);
            list2.Add(5);
            list2.Add(6);

            CustomList<int> expectedResult = new CustomList<int>();
            expectedResult.Add(1);
            expectedResult.Add(2);
            expectedResult.Add(3);
            //Act
            CustomList<int> result = (list1 - list2);
            //Assert
            Assert.IsTrue(ListsAreEqual(expectedResult, result));
        }

        [TestMethod]
        public void SubtractionOperatorOverload_MinuendIsEmptySubtrahendIsNot_EmptyList()
        {
            //Arrange
            CustomList<int> list1 = new CustomList<int>();
            CustomList<int> list2 = new CustomList<int>();
            list2.Add(3);
            list2.Add(4);
            list2.Add(5);

            CustomList<int> expectedResult = new CustomList<int>();
            //Act
            CustomList<int> result = (list1 - list2);
            //Assert
            Assert.IsTrue(ListsAreEqual(expectedResult, result));
        }

        [TestMethod]
        public void SubtractionOperatorOverload_SubtrahendIsEmptyMinuendIsNot_OriginalList()
        {
            //Arrange
            CustomList<int> list1 = new CustomList<int>();
            CustomList<int> list2 = new CustomList<int>();
            list1.Add(3);
            list1.Add(4);
            list1.Add(5);

            CustomList<int> expectedResult = new CustomList<int>();
            expectedResult.Add(3);
            expectedResult.Add(4);
            expectedResult.Add(5);
            //Act
            CustomList<int> result = (list1 - list2);
            //Assert
            Assert.IsTrue(ListsAreEqual(expectedResult, result));
        }

        [TestMethod]
        public void SubtractionOperatorOverload_BothMinuendAndSubtrahendAreEmpty_EmptyList()
        {
            //Arrange
            CustomList<int> list1 = new CustomList<int>();
            CustomList<int> list2 = new CustomList<int>();

            CustomList<int> expectedResult = new CustomList<int>();
            //Act
            CustomList<int> result = (list1 - list2);
            //Assert
            Assert.IsTrue(ListsAreEqual(expectedResult, result));
        }


        // Zip
        [TestMethod]
        public void Zip_ListsOfEqualLengths_ZippedList()
        {
            //Arrange
            CustomList<int> customList1 = new CustomList<int>();
            CustomList<int> customList2 = new CustomList<int>();
            customList1.Add(1);
            customList1.Add(3);
            customList1.Add(5);

            customList2.Add(2);
            customList2.Add(4);
            customList2.Add(6);

            CustomList<int> expectedResult = new CustomList<int>();
            expectedResult.Add(1);
            expectedResult.Add(2);
            expectedResult.Add(3);
            expectedResult.Add(4);
            expectedResult.Add(5);
            expectedResult.Add(6);
            //Act
            CustomList<int> result = CustomList<int>.Zip(customList1, customList2);
            //Assert
            Assert.IsTrue(ListsAreEqual(expectedResult, result));
        }

        [TestMethod]
        public void Zip_List1LongerThanList2_ZippedList()
        {
            //Arrange
            CustomList<int> customList1 = new CustomList<int>();
            CustomList<int> customList2 = new CustomList<int>();
            customList1.Add(1);
            customList1.Add(3);
            customList1.Add(5);

            customList2.Add(2);

            CustomList<int> expectedResult = new CustomList<int>();
            expectedResult.Add(1);
            expectedResult.Add(2);
            expectedResult.Add(3);
            expectedResult.Add(5);
            //Act
            CustomList<int> result = CustomList<int>.Zip(customList1, customList2);
            //Assert
            Assert.IsTrue(ListsAreEqual(expectedResult, result));
        }

        [TestMethod]
        public void Zip_List1ShorterThanList2_ZippedList()
        {
            //Arrange
            CustomList<int> customList1 = new CustomList<int>();
            CustomList<int> customList2 = new CustomList<int>();
            customList1.Add(1);

            customList2.Add(2);
            customList2.Add(4);
            customList2.Add(6);

            CustomList<int> expectedResult = new CustomList<int>();
            expectedResult.Add(1);
            expectedResult.Add(2);
            expectedResult.Add(4);
            expectedResult.Add(6);
            //Act
            CustomList<int> result = CustomList<int>.Zip(customList1, customList2);
            //Assert
            Assert.IsTrue(ListsAreEqual(expectedResult, result));
        }

        [TestMethod]
        public void Zip_OneListIsEmpty_OriginalList()
        {
            //Arrange
            CustomList<int> customList1 = new CustomList<int>();
            CustomList<int> customList2 = new CustomList<int>();
            customList1.Add(1);
            customList1.Add(3);
            customList1.Add(5);
            customList2.Add(1);
            customList2.Remove(1);

            CustomList<int> expectedResult = customList1;
            //Act
            CustomList<int> result = CustomList<int>.Zip(customList1, customList2);
            //Assert
            Assert.IsTrue(ListsAreEqual(expectedResult, result));
        }

        [TestMethod]
        public void Zip_OneListIsOnlyInstantiated_OriginalList()
        {
            //Arrange
            CustomList<int> customList1 = new CustomList<int>();
            CustomList<int> customList2 = new CustomList<int>();
            customList1.Add(1);
            customList1.Add(3);
            customList1.Add(5);

            CustomList<int> expectedResult = customList1;
            //Act
            CustomList<int> result = CustomList<int>.Zip(customList1, customList2);
            //Assert
            Assert.IsTrue(ListsAreEqual(expectedResult, result));
        }

        [TestMethod]
        public void Zip_OtherListIsEmpty_OriginalList()
        {
            //Arrange
            CustomList<int> customList1 = new CustomList<int>();
            CustomList<int> customList2 = new CustomList<int>();
            customList2.Add(1);
            customList2.Add(3);
            customList2.Add(5);
            customList1.Add(1);
            customList1.Remove(1);


            CustomList<int> expectedResult = customList2;
            //Act
            CustomList<int> result = CustomList<int>.Zip(customList1, customList2);
            //Assert
            Assert.IsTrue(ListsAreEqual(expectedResult, result));
        }

        [TestMethod]
        public void Zip_OtherListIsOnlyInstantiated_OriginalList()
        {
            //Arrange
            CustomList<int> customList1 = new CustomList<int>();
            CustomList<int> customList2 = new CustomList<int>();
            customList2.Add(1);
            customList2.Add(3);
            customList2.Add(5);

            CustomList<int> expectedResult = customList2;
            //Act
            CustomList<int> result = CustomList<int>.Zip(customList1, customList2);
            //Assert
            Assert.IsTrue(ListsAreEqual(expectedResult, result));
        }

        [TestMethod]
        public void Zip_BothListsareEmpty_EmptyList()
        {
            //Arrange
            CustomList<int> customList1 = new CustomList<int>();
            CustomList<int> customList2 = new CustomList<int>();

            CustomList<int> expectedResult = new CustomList<int>();
            //Act
            CustomList<int> result = CustomList<int>.Zip(customList1, customList2);
            //Assert
            Assert.IsTrue(ListsAreEqual(expectedResult, result));
        }

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

        [TestMethod][ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void IndexerGet_0ElementList_ArgumentOutOfRangeException()
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

        [TestMethod][ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void IndexerSet_0ElementList_ArgumentOutOfRangeException()
        {
            //Arrange
            CustomList<int> customList = new CustomList<int>();
            //Act
            customList[0] = 5;
        }

        // Iterable


        /* Template for all tests
        [TestMethod]
        public void __()
        {
            //Arrange
            CustomList<int> customList = new CustomList<int>();
            //Act
            //Assert
            Assert.AreEqual(expectedResult, result);
        }
        */

        // Assert.IsTrue(ListsAreEqual(expectedResult, result));
        private bool ListsAreEqual<T>(CustomList<T> list1, CustomList<T> list2)
        {
            if(list1.Count != list2.Count)
            {
                return false;
            }
            for(int i = 0; i < list1.Count; i++)
            {
                if (!list1[i].Equals(list2[i]))
                {
                    return false;
                }
            }
            return true;
        }
        /* used this method when Data was a property
         * Assert.IsTrue(ArraysAreEqual(expectedResult, result));
        private bool ArraysAreEqual<T>(T[] arr1, T[] arr2)
        {
            if(arr1.Length != arr2.Length)
            {
                return false;
            }
            for(int i = 0; i < arr1.Length; i++)
            {
                if(!arr1[i].Equals(arr2[i]))
                {
                    return false;
                }
            }
            return true;
        }
        */

        /*
         * Review remove tests
         * */

    }
}
