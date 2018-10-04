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

        public T this[int i] { get => data[i]; set => data[i] = value; }// indexer
        //ArgumentOutOfRange

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
    }
}
