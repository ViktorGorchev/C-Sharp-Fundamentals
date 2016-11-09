using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_GenericList
{
    class TestList
    {
        static void Main()
        {
            GenericList<int> list = new GenericList<int>();

            for (int i = 0; i < 17; i++)
            {
                list.Add(i);
            }
            Console.WriteLine("Numbers from 0 to 16 are added to the list:");
            Console.WriteLine(list);

            list.Insert(10, 20);
            Console.WriteLine("Number 20 is inserted on index 10:");
            Console.WriteLine(list);

            Console.WriteLine("The index of element 15 is " + list.FindElementIndex(15));

            Console.WriteLine("Is 20 in the list: " + list.Contains(20));

            Console.WriteLine("Min value: {0}, Max value: {1}", list.Min(), list.Max());

            Console.WriteLine("Element on index 4 is {0}", list[4]);

            list.Clear();
            //Console.WriteLine(list);
        }
    }
}
