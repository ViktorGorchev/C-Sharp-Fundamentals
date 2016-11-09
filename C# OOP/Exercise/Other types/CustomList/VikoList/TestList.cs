using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VikoList
{
    class TestList
    {
        static void Main()
        {
            VicoList<int> list = new VicoList<int>();
            for (int i = 0; i < 16; i++)
            {
                list.Add(i);
            }
            Console.WriteLine(list);

            list.Remove(10);
            Console.WriteLine(list);
            list.Add(40);
            list.Add(50);
            Console.WriteLine(list);

            list[2] = 50;
            Console.WriteLine(list);

            Console.WriteLine(list.IndexOf(4));


            //List<int> a = new List<int>();
            //a.Add(13);
            //a.Remove(14);
        }
    }
}
