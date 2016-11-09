using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Print_Long_Sequence
{
    class Program
    {
        static void Main()
        {
            for (int i = 2; i < 1002; i++)
            {
                if ((i % 2) != 0)
                {
                    Console.Write("-" + i + ",");
                }
                else
                {
                    Console.Write(i + ",");
                }
                
            }

        }
    }
}
