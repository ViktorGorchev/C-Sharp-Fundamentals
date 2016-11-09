using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace triangle
{
    class Program
    {
        static void Main()
        {
            char a = '\u00A9';
            string b = " ";
            Console.WriteLine(new string(' ', 4) + a);
            Console.WriteLine(new string(' ', 3) + a + new string(' ', 1) + a);
            Console.WriteLine(new string(' ', 2) + a + new string(' ', 3) + a);
            Console.WriteLine(b + a + b + a + b + a + b + a);
            
        }
    }
}
