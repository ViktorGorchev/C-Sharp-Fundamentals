using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numbers_in_Interval
{
    class Program
    {
        static void Main()
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());
            int p = 0;
            for (int i = start; i < end + 1; i++)
            {
                if ((i % 5) == 0)
                {
                    p++;
                }
            }
            Console.WriteLine(p);
        }
    }
}
