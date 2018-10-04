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
                if(i >= count) { throw new ArgumentOutOfRangeException(); }
                return data[i];
            }
            set
            {
                if (i >= count) { throw new ArgumentOutOfRangeException(); }
                data[i] = value;
            }
        }
                                                                        //Throw ArgumentOutOfRange
        public CustomList()
        {
            data = new T[0];
            count = 0;
        }

        // Going to do the thing where adding stuff doubles data.Length sometimes, but count remains accurate. How to test for data.Length???
        // data.Length changing is not an externally visible outcome; it need not be tested.
        public void Add(T input)
        {

        }
        public bool Remove(T input) // Removes the 1st occurrence of the object, true if removed, false if not found
        {
            return false;
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
