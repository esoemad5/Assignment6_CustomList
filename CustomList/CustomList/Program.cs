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
            CustomList<int> customList = new CustomList<int>();
            customList.Add(1);
            customList.Add(2);
            customList.Add(1);
            customList.Add(2);
            customList.Add(1);
            customList.Add(2);
            customList.Add(1);
            customList.Add(2);

            foreach (int number in customList)
            {
                Console.WriteLine(number);
            }


            /*
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
            */
        }
    }
}
