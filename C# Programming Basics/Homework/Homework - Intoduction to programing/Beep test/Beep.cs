using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00___beep_test
{
    class Beep
    {
        static void Main()
        {
            int a = 1;
            for (int i = 0; i < 10; i++)
            {
                Console.Beep(500, 700);
                Console.Beep(600, 700);
                Console.Beep(700, 700);
                Console.Beep(800, 700);
                Console.Beep(900, 700);
                Console.Beep(1000, 700);
                Console.Beep(1100, 700);
                Console.Beep(1200, 700);
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("end of part " + a);
                a++;
            }
        }
    }
}
