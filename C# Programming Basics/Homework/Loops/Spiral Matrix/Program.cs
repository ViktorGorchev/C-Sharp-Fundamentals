using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Spiral_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());
            int tempNumber = (n - 2) + (n * 3 - 2);
            for (int row = 1; row <= n; row++)
            {
                if (row == 1)
                {
                    Console.Write("{0, -4}",row);
                }
                else if (row != 1 && row != n)
                {
                    Console.Write("{0, -4}", ((n - 2) + (n * 3 - 2)) - (row - 2));                                            
                }
                
                for (int col = 1; col < n; col++)
                {
                    if (row == 1)
                    {
                        Console.Write("{0, -4}", row + col);
                    }
                   
                    else
                    {
                        if (row != 1 && row != n && col < n - 1)
                        {
                            Console.Write("{0, -4}", tempNumber + col);    
                        }
                      
                        if (row == n)
                        {
                            Console.Write("{0, -4}", ((n * 3) - 1) - col);          
                        }                                                            

                        if (col == n - 1)
                        {
                            Console.Write("{0, -4}", n + (row - 1));
                        }
                    }
                }
                Console.WriteLine();
            }
                                   
        }
    }
}
