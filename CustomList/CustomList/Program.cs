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

            CustomList<int> list1 = new CustomList<int>();
            CustomList<int> list2 = new CustomList<int>();
            list1.Add(1);
            list1.Add(2);
            list1.Add(3);
            list2.Add(3);
            list2.Add(4);
            list2.Add(5);

            CustomList<int> expectedResult = new CustomList<int>();
            expectedResult.Add(1);
            expectedResult.Add(2);
            //Act
            CustomList<int> result = (list1 - list2);

            Console.WriteLine(expectedResult.ToString());
            Console.WriteLine(result.ToString());
            ListsAreEqual(expectedResult, result);
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
        private void TestSortWithListOf26RandomInts()
        {
            CustomList<CustomList<int>> test = new CustomList<CustomList<int>>();
            Random rand = new Random();

            while (test.Count < 26)
            {
                CustomList<int> qwer = new CustomList<int>();
                qwer.Add(rand.Next(0, 100));
                test.Add(qwer);
            }
            Console.WriteLine(test.Count);
            Console.WriteLine(test.ToString());
            Console.WriteLine(test.Sort().ToString());
        }
        /*
        private void MergeSortBob()
        {
            CustomList<CustomList<SortHelper>> nextBob = new CustomList<CustomList<SortHelper>>();
            int mergeSortCounter = 0;//debuggingLine
            for (int i = 0; i < sortingArrayBob.Count; i = i + 2)
            {
                int whileLoopCounter = 0;//debuggingLine
                nextBob.Add(new CustomList<SortHelper>());
                try
                {
                    Console.WriteLine("MSC: {0}, i: {1}, WLC: {2}", mergeSortCounter, i, whileLoopCounter);//debuggingLine
                    Console.WriteLine("Bob: {0}, InnerBob: {1}", sortingArrayBob.Count, sortingArrayBob[i].Count);//db
                    while (sortingArrayBob[i].Count != 0 && sortingArrayBob[i + 1].Count != 0)
                    {

                        whileLoopCounter++;//db
                        try
                        {
                            if (sortingArrayBob[i][0].DecimalRepresentation > sortingArrayBob[i + 1][0].DecimalRepresentation)
                            {
                                nextBob[i].Add(sortingArrayBob[i][0]);
                                sortingArrayBob.Remove(sortingArrayBob[i]);
                            }
                            else
                            {
                                nextBob[i].Add(sortingArrayBob[i + 1][0]);
                                sortingArrayBob.Remove(sortingArrayBob[i + 1]);
                            }

                        }
                        catch (ArgumentOutOfRangeException ex)
                        {
                            Console.WriteLine("---------------------------------------------------");
                            Console.WriteLine("Out of range inside while loop of MergeSort. This should be impossible.");
                            // Get stack trace for the exception with source file information
                            var st = new StackTrace(ex, true);
                            // Get the top stack frame
                            var frame = st.GetFrame(0);
                            // Get the line number from the stack frame
                            var line = frame.GetFileLineNumber();
                            Console.WriteLine(st);

                            Console.WriteLine("---------------------------------------------------");
                            break;
                        }
                    }
                    if (sortingArrayBob[i].Count > 0)
                    {
                        foreach (SortHelper extraThing in sortingArrayBob[i])
                        {
                            nextBob[i].Add(extraThing);
                        }
                        sortingArrayBob.Remove(sortingArrayBob[i]);
                    }
                    else
                    {
                        foreach (SortHelper extraThing in sortingArrayBob[i + 1])
                        {
                            nextBob[i].Add(extraThing);
                            sortingArrayBob[i + 1].Remove(extraThing);
                        }
                    }
                }
                catch (ArgumentOutOfRangeException)
                {
                    nextBob[i] = sortingArrayBob[i];
                    sortingArrayBob.Remove(sortingArrayBob[i]);
                    if (i != sortingArrayBob.Count - 1)
                    {
                        throw new Exception("There are still array(s) left in Bob that have not been sorted.");
                    }
                }
            }

            sortingArrayBob = nextBob;
            if (sortingArrayBob.Count > 1)
            {
                MergeSortBob();
            }
        }
        */

        private static bool ListsAreEqual<T>(CustomList<T> list1, CustomList<T> list2)
        {
            if (list1.Count != list2.Count)
            {
                return false;
            }
            for (int i = 0; i < list1.Count; i++)
            {
                if (!list1[i].Equals(list2[i]))
                {
                    return false;
                }
            }
            return true;
        }






















    }
}
