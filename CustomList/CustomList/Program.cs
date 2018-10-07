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
            int[] a = new int[2];
            try
            {
                while(a[5] != 3)
                {
                    //If the line below is commented out, the program takes a long time to start, but still writes "Hello" as normal.
                    Console.WriteLine("feelsbadman"); Console.ReadLine();
                }
                // a[5] = 8;
                try
                {
                    a[5] = 8;
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("World!");
                }
            }
            catch(IndexOutOfRangeException)
            {
                Console.WriteLine("Hello");
            }
            




        }
        class Test
        {
            public List<decimal> list;
            public Test()
            {
                list = new List<decimal>();
            }
            public void Add(string thing)
            {
                Console.WriteLine("---------------------------------------------");
                try
                {
                    list.Add(decimal.Parse(thing));
                    if (thing.Length != list[list.Count - 1].ToString().Length)
                    {
                        list.RemoveAt(list.Count - 1);
                        Console.WriteLine("woooooooooo");
                        throw new FormatException();
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("{0}|bad format", thing);
                    return;
                }
                Console.WriteLine("{0}|good format", thing);
                Console.WriteLine("{0}|the last element of the list of decimals", list[list.Count - 1]);
            }
        }
        //Needs Test class
        private void TestingConvertingStringToDecimal()
        {
            Test test = new Test();
            test.Add("Hello");
            test.Add("14");
            test.Add(19.1354.ToString());
            test.Add('c'.ToString());
            test.Add("");
            test.Add(" ");
            test.Add(" 0"); // this is a problem
            Console.WriteLine("---------------------------------------------");
        }
        private void TestingToString()
        {
            CustomList<int> testList = new CustomList<int>();
            testList.Add(1);
            testList.Add(2);
            testList.Add(3);

            Console.Write(testList.ToString());
            Console.WriteLine('|');

            string a = "1, 2, 3";
            Console.WriteLine(testList.ToString() == a);
        }
        private void TestConvertToNumber()
        {
        decimal[] decimalRepresentationOfList;
        CustomList<string> listOfStrings = new CustomList<string>();
        Console.WriteLine((int)'1');
            listOfStrings.Add("1234");
            listOfStrings.Add("hello");
            listOfStrings.Add("!@#$#$%~");
            listOfStrings.Add("90182364");
            listOfStrings.Add(" -0828374098");
            listOfStrings.Add(" ");
            listOfStrings.Add("");
            listOfStrings.Add("333ncv023u");
            /*
            decimalRepresentationOfList = listOfStrings.ConvertToNumber(); // need to make the function public to test this
            foreach(decimal thing in decimalRepresentationOfList)
            {
                Console.WriteLine(thing);
            }
            */
        }




        class Node<T>
        {
            T data;
            Node<T> next;
            public Node (T data)
            {
                this.data = data;
            }
            public Node(T data, Node<T> next)
            {
                this.data = data;
                this.next = next;
            }

        }
    }
}
