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
            CustomList<int> A = new CustomList<int>();
            CustomList<int> B = new CustomList<int>();
            CustomList<int> C = A - B;
        }
    }
}
