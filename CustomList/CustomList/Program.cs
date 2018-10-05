using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomList
{
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

    class Program
    {

        static void Main(string[] args)
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
