using System;
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

        // This variable is only used for sorting and will not be instantiated until CustomList<T>.Sort is called.
        private CustomList<CustomList<SortHelper>> sortHelperList2D;

        public T this[int i]
        {
            get
            {
                if(i >= count || i < 0)
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

        // Going to do the thing where adding stuff doubles data.Length sometimes, but count remains accurate. How to test for data.Length???
        // data.Length changing is not an externally visible outcome; it need not be tested.
        public void Add(T input)
        {
            try
            {
                data[count] = input;
            }
            catch (IndexOutOfRangeException)
            {
                data = MakeNewArray();
                data[count] = input;
            }
            finally
            {
                count++;
            }
        }
        private T[] MakeNewArray()
        {
            T[] output = new T[data.Length*2];
            for(int i = 0; i < data.Length; i++)
            {
                output[i] = data[i];
            }
            return output;
        }
        public bool Remove(T input) // Removes the 1st occurrence of the object, true if removed, false if not found
        {
            T[] newData = new T[data.Length];
            bool foundTarget = false;

            for(int i = 0; i < count; i++)
            {
                if(data[i].Equals(input) && !foundTarget)
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
            for(int i = 0; i < count; i++)
            {
                output += data[i].ToString();
                if(i != count - 1)
                {
                    output += ", ";
                }
            }
            return output;
        }
        public static CustomList<T> operator+ (CustomList<T> customListA, CustomList<T> customListB)
        {
            CustomList<T> output = new CustomList<T>();
            foreach(T item in customListA)
            {
                output.Add(item);
            }
            foreach (T item in customListB)
            {
                output.Add(item);
            }
            return output;
        }
        public static CustomList<T> operator- (CustomList<T> customListA, CustomList<T> customListB) // hold off on this until after Sort.
        {
            CustomList<T> output = new CustomList<T>();

            foreach(T item in customListA)
            {
                //compare to everything in B and remove if matches
                //sorting B makes this much faster
            }

            return output;
        }
        public static CustomList<T> Zip(CustomList<T> customListA, CustomList<T> customListB) 
        {
            CustomList<T> output = new CustomList<T>();
            int stop = customListA.Count;
            if(customListA.Count < customListB.Count) { stop = customListB.Count; }

            for (int i = 0; i < stop; i++)
            {
                try
                {
                    output.Add(customListA[i]);
                }
                catch (ArgumentOutOfRangeException e)
                {
                    Console.WriteLine(e.Message);
                }
                try
                {
                    output.Add(customListB[i]);
                }
                catch (ArgumentOutOfRangeException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

           return output;
        }
        public CustomList<T> Sort()
        {
            
            MakeSortHelperList2D(ConvertToSortHelper());
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
        }

        private CustomList<T> ReOrderData()
        {
            CustomList<T> sortedList = new CustomList<T>();

            // These 2 lines scare me
            sortedList.data = new T[count];
            sortedList.count = count;

            for(int i = 0; i < count; i++)
            {
                sortedList[i] = data[sortHelperList2D[0][i].OriginalLocation];
            }

            return sortedList;
        }
        private void MergeSort()
        {

            CustomList<CustomList<SortHelper>> next2DList = new CustomList<CustomList<SortHelper>>();

            for(int i = 0; i < sortHelperList2D.Count-1; i = i + 2)
            {
                CustomList<SortHelper>  nextElement = new CustomList<SortHelper>();

                while(sortHelperList2D[i].Count != 0 && sortHelperList2D[i+1].Count != 0)
                {
                    try
                    {
                        if(sortHelperList2D[i][0].DecimalRepresentation <= sortHelperList2D[i + 1][0].DecimalRepresentation)
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
                    catch (ArgumentOutOfRangeException ex)
                    {
                        Console.WriteLine("---------------------------------------------------");
                        Console.WriteLine("Out of range inside while loop of MergeSort. This should be impossible.");
                        // Get stack trace for the exception with source file information
                        var st = new StackTrace(ex, true);
                        // Get the top stack frame
                        var frame = st.GetFrame(0);
                        // Get the line number from the stack frame
                        var line = frame.GetFileLineNumber();
                        Console.WriteLine(st);
                        Console.WriteLine("---------------------------------------------------");
                    }
                }
                while(sortHelperList2D[i].Count > 0)
                {
                    nextElement.Add(sortHelperList2D[i][0]);
                    sortHelperList2D[i].Remove(sortHelperList2D[i][0]);
                }
                while (sortHelperList2D[i + 1].Count > 0)
                {
                    nextElement.Add(sortHelperList2D[i + 1][0]);
                    sortHelperList2D[i + 1].Remove(sortHelperList2D[i + 1][0]);
                }

                next2DList.Add(nextElement);
            }
            if(sortHelperList2D.Count % 2 == 1)
            {
                CustomList<SortHelper> nextElement = new CustomList<SortHelper>();
                while (sortHelperList2D[sortHelperList2D.Count - 1].Count > 0)
                {
                    nextElement.Add(sortHelperList2D[sortHelperList2D.Count - 1][0]);
                    sortHelperList2D[sortHelperList2D.Count - 1].Remove(sortHelperList2D[sortHelperList2D.Count - 1][0]);
                }
                next2DList.Add(nextElement);
            }

            sortHelperList2D = next2DList;
            if(sortHelperList2D.Count > 1)
            {
                MergeSort();
            }
        }

        private void MakeSortHelperList2D(CustomList<SortHelper> sortHelperList)
        {
            sortHelperList2D = new CustomList<CustomList<SortHelper>>();
            for(int i = 0; i < count; i++)
            {
                sortHelperList2D.Add(new CustomList<SortHelper>());
                sortHelperList2D[i].Add(null);
                sortHelperList2D[i][0] = sortHelperList[i];
            }
        }

        private CustomList<SortHelper> ConvertToSortHelper()
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

            return sortHelperList;
        }
        
        
    }
}
