using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CustomList;

namespace CustomListTest
{
    [TestClass]
    public class CustomListTest
    {
        // Add | 4 tests
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
            for (int i = 0; i < 100; i++)
            {
                customList.Add(i);
            }

            int result = customList[49];
            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        // Count | 8 tests
        [TestMethod]
        public void Count_NewObject_0()
        {
            //Arrange
            CustomList<int> customList = new CustomList<int>();
            int[] a;

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
        public void Count_ItemAddedToNewList_1()
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
        public void Count_ItemAddedToEmptyList_1()
        {
            //Arrange
            CustomList<int> customList = new CustomList<int>();
            int value = 16;
            customList.Add(value);
            customList.Remove(value);
            customList.Add(value);

            int expectedResult = 1;
            //Act
            int result = customList.Count;
            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void Count_ItemAddedToList_3()
        {
            //Arrange
            CustomList<int> customList = new CustomList<int>();
            int value = 16;
            customList.Add(value);
            customList.Add(value);
            customList.Add(value);

            int expectedResult = 3;
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
            for (int i = 0; i < 100; i++)
            {
                customList.Add(i);
            }

            int expectedResult = 100;
            //Act
            int result = customList.Count;
            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void Count_RemoveAnItem_2()
        {
            //Arrange
            CustomList<int> customList = new CustomList<int>();
            customList.Add(1);
            customList.Add(2);
            customList.Add(3);

            int expectedResult = 2;
            //Act
            customList.Remove(1);
            int result = customList.Count;
            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void Count_RemoveTheLastItem_0()
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

        // Remove | 11 tests
        [TestMethod]
        public void Remove_ListOnlyContainsObject_EmptyList()
        {
            //Arrange
            CustomList<int> customList = new CustomList<int>();
            customList.Add(1);

            CustomList<int> expectedResult = new CustomList<int>();
            //Act
            customList.Remove(1);
            CustomList<int> result = customList;
            //Assert
            Assert.IsTrue(ListsAreEqual(expectedResult, result));
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
        public void Remove_RemoveFromNewList_EmptyList()
        {
            //Arrange
            CustomList<int> customList = new CustomList<int>();

            CustomList<int> expectedResult = new CustomList<int>();
            //Act
            customList.Remove(6);

            CustomList<int> result = customList;
            //Assert
            Assert.IsTrue(ListsAreEqual(expectedResult, result));
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
        public void Remove_RemoveFromEmptyList_EmptyList()
        {
            //Arrange
            CustomList<int> customList = new CustomList<int>();
            customList.Add(99);
            customList.Remove(99);

            CustomList<int> expectedResult = new CustomList<int>();
            //Act
            customList.Remove(99);

            CustomList<int> result = customList;
            //Assert
            Assert.IsTrue(ListsAreEqual(expectedResult, result));
        }

        // ToString | 3 tests
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

        // + | 8 Tests
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
        public void AdditionOperatorOverload_BothListsAreEmpty_CountIsCorrect()
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

        [TestMethod]
        public void AdditionOperatorOverload_TwoNonEmptyLists_CountIsCorrect()
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

            int expectedResult = 6;
            //Act
            CustomList<int> sum = list1 + list2;
            int result = sum.count;
            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void AdditionOperatorOverload_OneListIsEmpty_CountIsCorrect()
        {
            //Arrange
            CustomList<int> list1 = new CustomList<int>();
            CustomList<int> list2 = new CustomList<int>();
            list1.Add(1);
            list1.Add(2);
            list1.Add(3);

            int expectedResult = 3;
            //Act
            CustomList<int> sum = list1 + list2;
            int result = sum.count;
            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void AdditionOperatorOverload_OtherListIsEmpty_CountIsCorrect()
        {
            //Arrange
            CustomList<int> list1 = new CustomList<int>();
            CustomList<int> list2 = new CustomList<int>();
            list2.Add(1);
            list2.Add(2);
            list2.Add(3);

            int expectedResult = 3;
            //Act
            CustomList<int> sum = list1 + list2;
            int result = sum.count;
            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void AdditionOperatorOverload_BothListsAreEmpty_CountIsCorrect()
        {
            //Arrange
            CustomList<int> list1 = new CustomList<int>();
            CustomList<int> list2 = new CustomList<int>();

            int expectedResult = 0;
            //Act
            CustomList<int> sum = list1 + list2;
            int result = sum.count;
            //Assert
            Assert.AreEqual(expectedResult, result);
        }


        // - | 14 Tests
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
        public void SubtractionOperatorOverload_MinuendIsOnlyInstantiatedSubtrahendHasElements_EmptyList()
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
        public void SubtractionOperatorOverload_MinuendIsEmptySubtrahendIsNot_EmptyList()
        {
            //Arrange
            CustomList<int> list1 = new CustomList<int>();
            CustomList<int> list2 = new CustomList<int>();
            list2.Add(3);
            list2.Add(4);
            list2.Add(5);
            list1.Add(1);
            list1.Remove(1);

            CustomList<int> expectedResult = new CustomList<int>();
            //Act
            CustomList<int> result = (list1 - list2);
            //Assert
            Assert.IsTrue(ListsAreEqual(expectedResult, result));
        }

        [TestMethod]
        public void SubtractionOperatorOverload_SubtrahendIsOnlyInstantiatedMinuendHasElements_OriginalList()
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
        public void SubtractionOperatorOverload_SubtrahendIsEmptyMinuendIsNot_OriginalList()
        {
            //Arrange
            CustomList<int> list1 = new CustomList<int>();
            CustomList<int> list2 = new CustomList<int>();
            list1.Add(3);
            list1.Add(4);
            list1.Add(5);
            list2.Add(1);
            list2.Remove(1);

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

        [TestMethod]
        public void SubtractionOperatorOverload_MinuendContainsPartOrAllOfTheSubtrahend_CountIsCorrect()
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

            int expectedResult = 2;
            //Act
            CustomList<int> sum = list1 - list2;
            int result = sum.count;
            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void SubtractionOperatorOverload_MinuendContainsNoneOfTheSubtrahend_CountIsCorrect()
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

            int expectedResult = 3;
            //Act
            CustomList<int> sum = list1 - list2;
            int result = sum.count;
            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void SubtractionOperatorOverload_MinuendIsOnlyInstantiatedSubtrahendHasElements_CountIsCorrect()
        {
            //Arrange
            CustomList<int> list1 = new CustomList<int>();
            CustomList<int> list2 = new CustomList<int>();
            list2.Add(3);
            list2.Add(4);
            list2.Add(5);

            int expectedResult = 0;
            //Act
            CustomList<int> sum = list1 - list2;
            int result = sum.count;
            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void SubtractionOperatorOverload_MinuendIsEmptySubtrahendIsNot_CountIsCorrect()
        {
            //Arrange
            CustomList<int> list1 = new CustomList<int>();
            CustomList<int> list2 = new CustomList<int>();
            list2.Add(3);
            list2.Add(4);
            list2.Add(5);
            list1.Add(1);
            list1.Remove(1);

            int expectedResult = 0;
            //Act
            CustomList<int> sum = list1 - list2;
            int result = sum.count;
            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void SubtractionOperatorOverload_SubtrahendIsOnlyInstantiatedMinuendHasElements_CountIsCorrect()
        {
            //Arrange
            CustomList<int> list1 = new CustomList<int>();
            CustomList<int> list2 = new CustomList<int>();
            list1.Add(3);
            list1.Add(4);
            list1.Add(5);

            int expectedResult = 3;
            //Act
            CustomList<int> sum = list1 - list2;
            int result = sum.count;
            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void SubtractionOperatorOverload_SubtrahendIsEmptyMinuendIsNot_CountIsCorrect()
        {
            //Arrange
            CustomList<int> list1 = new CustomList<int>();
            CustomList<int> list2 = new CustomList<int>();
            list1.Add(3);
            list1.Add(4);
            list1.Add(5);
            list2.Add(1);
            list2.Remove(1);

            int expectedResult = 3;
            //Act
            CustomList<int> sum = list1 - list2;
            int result = sum.count;
            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void SubtractionOperatorOverload_BothMinuendAndSubtrahendAreEmpty_CountIsCorrect()
        {
            //Arrange
            CustomList<int> list1 = new CustomList<int>();
            CustomList<int> list2 = new CustomList<int>();

            int expectedResult = 0;
            //Act
            CustomList<int> sum = list1 - list2;
            int result = sum.count;
            //Assert
            Assert.AreEqual(expectedResult, result);
        }


        // Zip | 8 Tests
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

        [TestMethod]
        public void Zip_ListsOfEqualLengths_CountIsCorrect()
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

            int expectedResult = 6;
            //Act
            CustomList<int> zip = CustomList<int>.Zip(customList1, customList2);
            int result = zip.count;
            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void Zip_List1LongerThanList2_CountIsCorrect()
        {
            //Arrange
            CustomList<int> customList1 = new CustomList<int>();
            CustomList<int> customList2 = new CustomList<int>();
            customList1.Add(1);
            customList1.Add(3);
            customList1.Add(5);

            customList2.Add(2);

            int expectedResult = 4;
            //Act
            CustomList<int> zip = CustomList<int>.Zip(customList1, customList2);
            int result = zip.count;
            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void Zip_List1ShorterThanList2_CountIsCorrect()
        {
            //Arrange
            CustomList<int> customList1 = new CustomList<int>();
            CustomList<int> customList2 = new CustomList<int>();
            customList1.Add(1);

            customList2.Add(2);
            customList2.Add(4);
            customList2.Add(6);

            int expectedResult = 4;
            //Act
            CustomList<int> zip = CustomList<int>.Zip(customList1, customList2);
            int result = zip.count;
            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void Zip_OneListIsEmpty_CountIsCorrect()
        {
            //Arrange
            CustomList<int> customList1 = new CustomList<int>();
            CustomList<int> customList2 = new CustomList<int>();
            customList1.Add(1);
            customList1.Add(3);
            customList1.Add(5);
            customList2.Add(1);
            customList2.Remove(1);

            int expectedResult = 3;
            //Act
            CustomList<int> zip = CustomList<int>.Zip(customList1, customList2);
            int result = zip.count;
            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void Zip_OneListIsOnlyInstantiated_CountIsCorrect()
        {
            //Arrange
            CustomList<int> customList1 = new CustomList<int>();
            CustomList<int> customList2 = new CustomList<int>();
            customList1.Add(1);
            customList1.Add(3);
            customList1.Add(5);

            int expectedResult = 3;
            //Act
            CustomList<int> zip = CustomList<int>.Zip(customList1, customList2);
            int result = zip.count;
            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void Zip_OtherListIsEmpty_CountIsCorrect()
        {
            //Arrange
            CustomList<int> customList1 = new CustomList<int>();
            CustomList<int> customList2 = new CustomList<int>();
            customList2.Add(1);
            customList2.Add(3);
            customList2.Add(5);
            customList1.Add(1);
            customList1.Remove(1);


            int expectedResult = 3;
            //Act
            CustomList<int> zip = CustomList<int>.Zip(customList1, customList2);
            int result = zip.count;
            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void Zip_OtherListIsOnlyInstantiated_CountIsCorrect()
        {
            //Arrange
            CustomList<int> customList1 = new CustomList<int>();
            CustomList<int> customList2 = new CustomList<int>();
            customList2.Add(1);
            customList2.Add(3);
            customList2.Add(5);

            int expectedResult = 3;
            //Act
            CustomList<int> zip = CustomList<int>.Zip(customList1, customList2);
            int result = zip.count;
            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void Zip_BothListsareEmpty_CountIsCorrect()
        {
            //Arrange
            CustomList<int> customList1 = new CustomList<int>();
            CustomList<int> customList2 = new CustomList<int>();

            int expectedResult = 0;
            //Act
            CustomList<int> zip = CustomList<int>.Zip(customList1, customList2);
            int result = zip.count;
            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        // Indexer | 8 Tests
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

        [TestMethod] [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void IndexerGet_0ElementList_ArgumentOutOfRangeException()
        {
            //Arrange
            CustomList<int> customList = new CustomList<int>();
            //Act
            int test = customList[0];
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void IndexerGet_NegativeIndex_ArgumentOutOfRangeException()
        {
            //Arrange
            CustomList<int> customList = new CustomList<int>();
            //Act
            int test = customList[-1];
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void IndexerGet_RegularList_ArgumentOutOfRangeException()
        {
            //Arrange
            CustomList<int> customList = new CustomList<int>();
            customList.Add(1);
            customList.Add(1);
            customList.Add(1);
            //Act
            int test = customList[9];
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

        [TestMethod] [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void IndexerSet_0ElementList_ArgumentOutOfRangeException()
        {
            //Arrange
            CustomList<int> customList = new CustomList<int>();
            //Act
            customList[0] = 5;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void IndexerSet_NegativeIndex_ArgumentOutOfRangeException()
        {
            //Arrange
            CustomList<int> customList = new CustomList<int>();
            //Act
            customList[-1] = 5;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void IndexerSet_RegularList_ArgumentOutOfRangeException()
        {
            //Arrange
            CustomList<int> customList = new CustomList<int>();
            customList.Add(1);
            customList.Add(1);
            customList.Add(1);
            //Act
            customList[9] = 5;
        }

        // Sort
        [TestMethod]
        public void Sort_IntegersAllUnique_SortedLlist()
        {
            //Arrange
            CustomList<int> customList = new CustomList<int>();
            customList.Add(4);
            customList.Add(2);
            customList.Add(9);
            customList.Add(11);
            customList.Add(8);

            CustomList<int> expectedResult = new CustomList<int>();
            expectedResult.Add(2);
            expectedResult.Add(4);
            expectedResult.Add(8);
            expectedResult.Add(9);
            expectedResult.Add(11);
            //Act
            CustomList<int> result = customList.Sort();
            //Assert
            Assert.IsTrue(ListsAreEqual(expectedResult, result));
        }

        [TestMethod]
        public void Sort_IntegersSomeAreRepeated_SortedLlist()
        {
            //Arrange
            CustomList<int> customList = new CustomList<int>();
            customList.Add(4);
            customList.Add(2);
            customList.Add(9);
            customList.Add(4);
            customList.Add(8);

            CustomList<int> expectedResult = new CustomList<int>();
            expectedResult.Add(2);
            expectedResult.Add(4);
            expectedResult.Add(4);
            expectedResult.Add(8);
            expectedResult.Add(9);
            //Act
            CustomList<int> result = customList.Sort();
            //Assert
            Assert.IsTrue(ListsAreEqual(expectedResult, result));
        }

        [TestMethod]
        public void Sort_StringAllUnique_SortedLlist()
        {
            //Arrange
            CustomList<string> customList = new CustomList<string>();
            customList.Add("Hello");
            customList.Add("world");
            customList.Add("!");
            customList.Add(" ");
            customList.Add("kappa");

            CustomList<string> expectedResult = new CustomList<string>();
            expectedResult.Add(" ");
            expectedResult.Add("!");
            expectedResult.Add("Hello");
            expectedResult.Add("kappa");
            expectedResult.Add("world");
            //Acts
            CustomList<string> result = customList.Sort();
            //Assert
            Assert.IsTrue(ListsAreEqual(expectedResult, result));
        }

        [TestMethod]
        public void Sort_StringsSomeAreRepeated_SortedLlist()
        {
            //Arrange
            CustomList<string> customList = new CustomList<string>();
            customList.Add("Hello");
            customList.Add("world");
            customList.Add("!");
            customList.Add(" ");
            customList.Add("kappa");
            customList.Add("kappa");

            CustomList<string> expectedResult = new CustomList<string>();
            expectedResult.Add(" ");
            expectedResult.Add("!");
            expectedResult.Add("Hello");
            expectedResult.Add("kappa");
            expectedResult.Add("kappa");
            expectedResult.Add("world");
            //Act
            CustomList<string> result = customList.Sort();
            //Assert
            Assert.IsTrue(ListsAreEqual(expectedResult, result));
        }

        /* Do I need tests for custom objects?
         * The plan is to ToString everything, look at the 1st character, ToUpper, typecast to (int), and finally, sort.
         * It is the other developer's problem to make sure ToString works well for their object.
         * Do I need to test to make sure CustomList.Sort uses ToString???
         */

        // Iterable
        [TestMethod]
        public void GetEnumerator_NonEmptyList_OriginalList()
        {
            //Arrange
            CustomList<int> customList = new CustomList<int>();
            customList.Add(5);
            customList.Add(5);
            customList.Add(5);
            customList.Add(5);

            int expectedResult = 20;
            //Act
            int result = 0;
            foreach(int item in customList)
            {
                result += item;
            }
            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        
        [TestMethod]
        public void GetEnumerator_EmptyList_EmptyList()
        {
            //Arrange
            CustomList<int> customList = new CustomList<int>();

            int expectedResult = 0;
            //Act
            int result = 0;
            foreach (int item in customList)
            {
                result += item;
            }

            //Assert
            Assert.AreEqual(expectedResult, result);
        }
        

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

        // Probably didnt need to add those count tests. This function returns false if the counts arent the same.
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
         */
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
        
    }
}
