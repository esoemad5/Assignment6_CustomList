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
            for(int i = 0; i < 512; i++)
            {
                if((i)%16 == 0)
                {
                    Console.WriteLine();
                    Console.Write("{0}: ", i);
                }
                Console.Write("{0} ", (char)i);
            }
            Console.WriteLine();
            string a = true.ToString();
            Console.WriteLine("{0}", a);
        }
    }
}
