using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomList
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 1, 2, 3 };
            List<int> list = new List<int>();
            list.Add(1); list.Add(2); list.Add(3);
            Console.WriteLine(list[9]);
        }
    }
}
