﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;

namespace CustomList
{
    public class CustomList<T> : System.Collections.IEnumerable
    {
        private T[] data;
        private int count;
        public int Count { get => count; }

        /* This variable is not be instantiated in the constructor.
         * It is primarily used for sorting.
         * Use MakeSortHelperList2D(MakeSortHelperList()); to instantiate it.
         * This list is NEVER updated. MakeSortHelperList2D(MakeSortHelperList()); must be used to do so.
         */
        private CustomList<CustomList<SortHelper>> sortHelperList2D;

        public T this[int i]
        {
            get
            {
                if (i >= count || i < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                return data[i];
            }
            set
            {
                if (i >= count || i < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                data[i] = value;
            }
        }
        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < count; i++)
            {
                yield return data[i];
            }
        }

        public CustomList()
        {
            data = new T[1];
            count = 0;
        }

        public void Add(T input)
        {
            try
            {
                data[count] = input;
            }
            catch (IndexOutOfRangeException)
            {
                data = EnlargeArray();
                data[count] = input;
            }
            finally
            {
                count++;
            }
        }

        private T[] EnlargeArray()
        {
            T[] output = new T[data.Length * 2];
            for (int i = 0; i < data.Length; i++)
            {
                output[i] = data[i];
            }
            return output;
        }

        public bool Remove(T target) // Removes the 1st occurrence of target. Returns true if removed or false if not found.
        {
            T[] newData = new T[data.Length];
            bool foundTarget = false;

            for (int i = 0; i < count; i++)
            {
                if (data[i].Equals(target) && !foundTarget)
                {
                    foundTarget = true;
                }
                else
                {
                    if (foundTarget)
                    {
                        newData[i - 1] = data[i];
                    }
                    else
                    {
                        newData[i] = data[i];
                    }
                }
            }
            if (foundTarget)
            {
                count--;
                data = newData;
            }
            return foundTarget;
        }

        public override string ToString()
        {
            string output = "";
            for (int i = 0; i < count; i++)
            {
                output += data[i].ToString();
                if (i != count - 1)
                {
                    output += ", ";
                }
            }
            return output;
        }

        public static CustomList<T> operator +(CustomList<T> customListA, CustomList<T> customListB)
        {
            CustomList<T> output = new CustomList<T>();
            foreach (T item in customListA)
            {
                output.Add(item);
            }
            foreach (T item in customListB)
            {
                output.Add(item);
            }
            return output;
        }

        public static CustomList<T> operator -(CustomList<T> customListA, CustomList<T> customListB)
        {
            if (customListA.Count == 0 || customListB.Count == 0)
            {
                return customListA;
            }
            CustomList<T> output = new CustomList<T>();
            customListB = customListB.Sort();
            CustomList<SortHelper> sortHelperA = customListA.MakeSortHelperList();
            CustomList<SortHelper> sortHelperB = customListB.MakeSortHelperList();
            for (int i = 0; i < customListA.Count; i++)
            {
                if (customListA[i].Equals(customListB[0]) || customListA[i].Equals(customListB[customListB.count - 1]))
                {
                    continue;
                }
                if (SearchSortedListFor(sortHelperA[i].DecimalRepresentation, 0, sortHelperB.Count - 1, sortHelperB))
                {
                    continue;
                }

                output.Add(customListA[i]);

            }

            return output;
        }

        private static bool SearchSortedListFor(decimal target, int start, int end, CustomList<SortHelper> sortedList)
        {

            int middleIndex = (end - start) / 2;
            if (target.Equals(sortedList[middleIndex]))
            {
                return true;
            }
            else
            {
                if (start == end)
                {
                    return false;
                }
                if (sortedList[middleIndex].IsGreaterThan(target))
                {
                    return SearchSortedListFor(target, start, middleIndex, sortedList);
                }
                if (sortedList[middleIndex].IsLessThan(target))
                {
                    return SearchSortedListFor(target, middleIndex, end, sortedList);
                }

                throw new Exception("Element is not greater-than, less-than, or equal-to the target. Someone call Euler!!!");
            }
        }

        public static CustomList<T> Zip(CustomList<T> customListA, CustomList<T> customListB)
        {
            CustomList<T> output = new CustomList<T>();
            int stop = customListA.Count;
            if (customListA.Count < customListB.Count)
            {
                stop = customListB.Count;
            }

            for (int i = 0; i < stop; i++)
            {
                try
                {
                    output.Add(customListA[i]);
                }
                catch (ArgumentOutOfRangeException)
                {
                }
                try
                {
                    output.Add(customListB[i]);
                }
                catch (ArgumentOutOfRangeException)
                {
                }
            }

            return output;
        }

        public CustomList<T> Sort()
        {

            MakeSortHelperList2D(MakeSortHelperList());
            MergeSort();
            CustomList<T> sortedList = ReOrderData();

            return sortedList;
        }

        private class SortHelper
        {
            private decimal decimalRepresentation;
            public decimal DecimalRepresentation { get => decimalRepresentation; }
            private int originalLocation;
            public int OriginalLocation { get => originalLocation; }

            public SortHelper(decimal decimalRepresentation, int originalLocation)
            {
                this.decimalRepresentation = decimalRepresentation;
                this.originalLocation = originalLocation;
            }
            public override string ToString()
            {
                string output = "";
                output += "(Decimal: ";
                output += DecimalRepresentation;
                output += ") (OriginalIndex: ";
                output += originalLocation;
                output += ")";
                return output;
            }
            public bool IsGreaterThan(decimal number)
            {
                return decimalRepresentation > number;
            }
            public bool IsLessThan(decimal number)
            {
                return decimalRepresentation < number;
            }
        }

        private CustomList<T> ReOrderData()
        {
            CustomList<T> sortedList = new CustomList<T>();

            sortedList.data = new T[count];
            sortedList.count = count;

            for (int i = 0; i < count; i++)
            {
                sortedList[i] = this.data[sortHelperList2D[0][i].OriginalLocation];
            }

            return sortedList;
        }

        private void MergeSort()
        {

            CustomList<CustomList<SortHelper>> next2DList = new CustomList<CustomList<SortHelper>>();

            for (int i = 0; i < sortHelperList2D.Count - 1; i = i + 2) // Merge lists 2 by 2
            {
                CustomList<SortHelper> nextElement = new CustomList<SortHelper>();

                while (sortHelperList2D[i].Count != 0 && sortHelperList2D[i + 1].Count != 0) // Merge 2 lists
                {
                    if (sortHelperList2D[i][0].DecimalRepresentation <= sortHelperList2D[i + 1][0].DecimalRepresentation)
                    {
                        nextElement.Add(sortHelperList2D[i][0]);
                        sortHelperList2D[i].Remove(sortHelperList2D[i][0]);
                    }
                    else
                    {
                        nextElement.Add(sortHelperList2D[i + 1][0]);
                        sortHelperList2D[i + 1].Remove(sortHelperList2D[i + 1][0]);
                    }
                }

                while (sortHelperList2D[i].Count > 0) // Add the leftovers
                {
                    nextElement.Add(sortHelperList2D[i][0]);
                    sortHelperList2D[i].Remove(sortHelperList2D[i][0]);
                }
                while (sortHelperList2D[i + 1].Count > 0) // ibid
                {
                    nextElement.Add(sortHelperList2D[i + 1][0]);
                    sortHelperList2D[i + 1].Remove(sortHelperList2D[i + 1][0]);
                }

                next2DList.Add(nextElement);
            }

            if (sortHelperList2D.Count % 2 == 1) // If there are an odd number of lists, just add the last one to the end of next2DList since it didn't get to merge this time.
            {
                next2DList.Add(sortHelperList2D[sortHelperList2D.Count - 1]);
            }

            sortHelperList2D = next2DList;
            if (sortHelperList2D.Count > 1)
            {
                MergeSort();
            }
        }

        private void MakeSortHelperList2D(CustomList<SortHelper> sortHelperList)
        {
            sortHelperList2D = new CustomList<CustomList<SortHelper>>();
            for (int i = 0; i < count; i++)
            {
                sortHelperList2D.Add(new CustomList<SortHelper>());
                sortHelperList2D[i].Add(sortHelperList[i]);
            }
        }

        private CustomList<SortHelper> MakeSortHelperList()
        {
            CustomList<SortHelper> sortHelperList = new CustomList<SortHelper>();

            try
            {
                if (data[0] is string) // so strings like " 0823" dont get converted here
                {
                    throw new FormatException();
                }
                else
                {
                    for (int i = 0; i < count; i++)
                    {
                        sortHelperList.Add(new SortHelper(decimal.Parse(data[i].ToString()), i)); // Converts any number type to decimal, throws FormatException for a non-string/number
                    }
                }
            }
            catch (FormatException) // convert anything that is not a number
            {
                for (int i = 0; i < count; i++)
                {
                    try
                    {
                        sortHelperList.Add(new SortHelper((decimal)data[i].ToString()[0], i));// Converts strings (or Object.ToString();)
                    }
                    catch (IndexOutOfRangeException)
                    {
                        sortHelperList.Add(new SortHelper((decimal)' ', i)); // If the string/char is: "", treat it as " "
                    }
                }
            }
            catch (IndexOutOfRangeException)
            {
                return new CustomList<SortHelper>();
            }

            return sortHelperList;
        }
    }
}