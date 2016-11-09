using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Third_Digit_is_7
{
    class Program
    {
        static void Main()
        {
            int number = int.Parse(Console.ReadLine());

            if (number < 700)
            {
                Console.WriteLine("false");
            }
            else if (number >= 700)
            {
                number /= 100;
                int tirdNumber = number % 10;
                if (tirdNumber == 7)
                {
                        Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine("false");
                }

            }
        }
    }
}
