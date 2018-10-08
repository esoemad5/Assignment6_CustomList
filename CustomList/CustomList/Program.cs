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
            A.Add(5);
            A.Add(7);
            A.Add(5);
            A.Add(7);
            A.Add(5);
            A.Add(7);
            B.Add(1);
            CustomList<string> S = new CustomList<string>();
            S.Add("1234");
            S.Add(" 234");
            S.Add(" ");
            S.Add("");
            S.Add("!");
            S.Add("123Abc");
            S.Add("Yoooooooooooooo");
            S.Add("yoooooooooooooo");
            S.Add("Yoooooooooooooo");

            CustomList<string> C =S.Sort();
            Console.WriteLine(C.ToString());
        }
    }
}
