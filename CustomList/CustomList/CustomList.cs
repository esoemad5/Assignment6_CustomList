using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomList
{
    public class CustomList<T>
    {
        private T[] data;
        private int count;
        public int Count { get => count; }

        public T this[int i]
        {
            get
            {
                if(i >= count || i < 0) { throw new ArgumentOutOfRangeException(); }
                return data[i];
            }
            set
            {
                if (i >= count || i < 0) { throw new ArgumentOutOfRangeException(); }
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
            bool returnBool = false;

            for(int i = 0; i < count; i++)
            {
                if(data[i].Equals(input) && !returnBool)
                {
                    count--;
                    returnBool = true;
                }
                else
                {
                    if (returnBool)
                    {
                        newData[i - 1] = data[i];
                    }
                    else
                    {
                        newData[i] = data[i];
                    }
                }
            }
            return returnBool;
        }
        public override string ToString()
        {
            string output = "";

            return output;
        }
        public static CustomList<T> operator+ (CustomList<T> customListA, CustomList<T> customListB)
        {
            CustomList<T> output = new CustomList<T>();

            return output;
        }
        public static CustomList<T> operator- (CustomList<T> customListA, CustomList<T> customListB)
        {
            CustomList<T> output = new CustomList<T>();

            return output;
        }
        public static CustomList<T> Zip(CustomList<T> customListA, CustomList<T> customListB) 
        {
            CustomList<T> output = new CustomList<T>();

            return output;
        }
        public CustomList<T> Sort()
        {
            CustomList<T> output = new CustomList<T>();

            return output;
        }
    }
}
