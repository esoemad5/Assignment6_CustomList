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
        public int Count { get => GetCount(); }
        private int GetCount()
        {

        }
        public T Data { get; set; }

        public void Add(T input)
        {

        }
        public void Remove(T input)
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
