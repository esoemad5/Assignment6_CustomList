using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomList
{
    public class CustomList<T> : System.Collections.IEnumerable
    {
        private T[] data;
        private int count;
        public int Count { get => count; }

        private CustomList<CustomList<SortHelper>> sortingArrayBob;

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
            if (foundTarget) { count--; data = newData; }
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
            CustomList<T> output = new CustomList<T>();
            if(data is int[])
            {
                MakeSortingArrayBob(MakeMiniBob());
                MergeSortBob();
                //ReOrderData();
            }
            return output;
        }

        private class SortHelper
        {
            private decimal decimalRepresentation;
            private int originalLocation;

            public SortHelper(decimal decimalRepresentation, int originalLocation)
            {
                this.decimalRepresentation = decimalRepresentation;
                this.originalLocation = originalLocation;
            }
        }

        private void MergeSortBob()
        {
            CustomList<CustomList<SortHelper>> nextBob = new CustomList<CustomList<SortHelper>>();

            for(int i = 0; i< sortingArrayBob.Count; i = i + 2)
            {
                try
                {
                    foreach(SortHelper item in sortingArrayBob[i])
                    {

                    }
                    //sortingArrayBob[i][???] sortingArrayBob[i + 1][???];
                }
                catch (IndexOutOfRangeException)
                {
                    nextBob[i] = sortingArrayBob[i];
                    if(i != sortingArrayBob.Count - 1)
                    {
                        throw new Exception("There are still array(s) left in Bob that have not been sorted.");
                    }
                }
            }

            sortingArrayBob = nextBob;
            if(sortingArrayBob.Count > 1)
            {
                MergeSortBob();
            }
        }

        private void MakeSortingArrayBob(CustomList<SortHelper> miniBob)
        {
            sortingArrayBob = new CustomList<CustomList<SortHelper>>();
            for(int i = 0; i < count; i++)
            {
                sortingArrayBob[i][0] = miniBob[i];
            }
        }

        private CustomList<SortHelper> MakeMiniBob()
        {
            CustomList<SortHelper> miniBob = new CustomList<SortHelper>();

            try
            {
                // make sure sorting function just returns for length zero lists or this will throw an exception
                if (data[0] is string) // so strings like " 0823" dont get converted here
                {
                    throw new FormatException();
                }
                else
                {
                    for (int i = 0; i < count; i++)
                    {
                        miniBob.Add(new SortHelper(decimal.Parse(data[i].ToString()), i)); // Converts any number type to decimal, throws exception for a non-string/number
                    }
                }
            }
            catch (FormatException) // convert anything thats not a number
            {
                for (int i = 0; i < count; i++)
                {
                    try
                    {
                        miniBob.Add(new SortHelper((decimal)data[i].ToString()[0], i));// Converts strings (or Object.ToString();)
                    }
                    catch (IndexOutOfRangeException)
                    {
                        miniBob.Add(new SortHelper((decimal)' ', i)); // If the string/char is: ""
                    }
                }
            }

            return miniBob;
        }
        
        
        
        //Obsolete. Remove before submitting
        private decimal[] ConvertToNumber() 
        {
            decimal[] output = new decimal[count];

            try
            {
                // make sure sorting function just returns for length zero lists or this will throw an exception
                if (data[0] is string) // so strings like " 0823" dont get converted here
                {
                    throw new FormatException();
                }
                else
                {
                    for(int i = 0; i < count; i++)
                    {
                        output[i] = decimal.Parse(data[i].ToString()); // Converts numbers, throws exception for a non-string/number
                    }
                }
            }
            catch (FormatException) // convert anything thats not a number
            {
                for(int i = 0; i < count; i++)
                {
                    try
                    {
                        output[i] = (decimal)data[i].ToString()[0];// Converts strings (or Object.ToString();)
                    }
                    catch (IndexOutOfRangeException)
                    {
                        output[i] = (decimal)' '; // If the string/char is: ""
                    }
                }
            }
            return output;
        }

        private int[] MergeSortButReturnArrayOfIndicesOfOriginalPositions(decimal[] array) // TODO
        {
            int[] indices = new int[array.Length];
            CustomList<CustomList<decimal>> list2D = ChangeArrayTo2DCustomList(array);

            while (list2D.Count != 1)
            {
                CustomList<CustomList<decimal>> nextList = new CustomList<CustomList<decimal>>();
                for (int i = 0; i < list2D.Count; i = i + 2)
                {
                    try
                    {
                        // merge lists 2 by 2
                        // store lists in nextList
                        CustomList<decimal> element = new CustomList<decimal>();

                        CustomList<decimal> section1 = list2D[i];
                        CustomList<decimal> section2 = list2D[i+1];

                        for (int j = 0; j < section1.Count; j++) // this might be totally bad
                        {
                            for(int k = 0; k < section2.Count; k++)
                            {
                                //if(section1[j])
                            }
                        }
                        nextList.Add(element);
                        // note the indices in indices when swapping
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        // if there are an odd number of lists, just add the last one to the end of nextList
                        nextList[i] = list2D[i];
                        if(i != list2D.Count)
                        {
                            throw new Exception("There are still lists left in list2D that have not been sorted.");
                        }
                    }
                }
                list2D = nextList;
            }
            return indices;
        }

        private CustomList<CustomList<decimal>> ChangeArrayTo2DCustomList(decimal[] array)
        {
            CustomList<CustomList<decimal>> list2D = new CustomList<CustomList<decimal>>();
            foreach(decimal number in array)
            {
                CustomList<decimal> element = new CustomList<decimal>();
                element.Add(number);
                list2D.Add(element);
            }
            return list2D;
        }

        private void ReOrderList(int[] indices)
        {
            T[] newData = new T[count];
            for(int i = 0; i < count; i++)
            {
                newData[i] = data[indices[i]];
            }
            data = newData;
        }

        
    }
}
