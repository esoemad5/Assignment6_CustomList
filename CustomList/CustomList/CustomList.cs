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
        public T[] Data { get => data; }
        public int Count { get => GetCount(); }
        private int GetCount()
        {

        }
        public T this[int i] { get => data[i]; set => data[i] = value; }// indexer

        public void Add(T input)
        {

        }
        public bool Remove(T input) // Removes the 1st occurrence of the object, true if removed, false if not found
        {

        }
        public string ToString()
        {

        }
        public static CustomList<T> operator+ (CustomList<T> customListA, CustomList<T> customListB)
        {

        }
        public static CustomList<T> operator- (CustomList<T> customListA, CustomList<T> customListB)
        {

        }
        public static Zip(CustomList<T> customListA, CustomList<T> customListB)
        {

        }
    }
}
