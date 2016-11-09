using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modify_a_Bit_at_Given_Position
{
    class Program
    {
        static void Main()
        {
            do
            {
                int n = int.Parse(Console.ReadLine());
                int p = int.Parse(Console.ReadLine());
                int v = int.Parse(Console.ReadLine());

                if (v == 0)
                {
                    int mask = ~(1 << p);     
                    int result = n & mask;     
                    Console.WriteLine(result);
                }
                else if (v == 1)
                {
                    int mask = 1 << p;          
                    int result = n | mask;      
                    Console.WriteLine(result);  
                }  
            } while (true);
        }
    }
}
