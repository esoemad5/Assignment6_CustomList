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
        public static CustomList<T> operator- (CustomList<T> customListA, CustomList<T> customListB) // hold off on this until after Sort. May want to overload <, >, and =
        {
            CustomList<T> output = new CustomList<T>();

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

            }
            return output;
        }

        public decimal[] ConvertToNumber() 
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


        public IEnumerator GetEnumerator()
        {
            for(int i = 0; i < count; i++)
            {
                yield return data[i];
            }
        }
    }
}
