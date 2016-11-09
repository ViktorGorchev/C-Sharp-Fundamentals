using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fibonacci_Numbers
{
    class Program
    {
        static void Main()
        {
           
            int n = int.Parse(Console.ReadLine());
            int result1 = 0;
            int result2 = 1;
            int result3 = 0;


            for (int i = 0; i < n; i++)
            {


                if (i == 0)
                {
                    Console.Write(i);
                }
                else if(i == 1)
                {
                    Console.Write(", " + i);
                    
                }
                else
                {
                    result3 = result1 + result2;

                    Console.Write(", " + result3);

                    result1 = result2;
                    result2 = result3;
                }



            }
        }
    }
}
