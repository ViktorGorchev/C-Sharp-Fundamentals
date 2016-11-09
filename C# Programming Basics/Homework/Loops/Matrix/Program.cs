using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int row = 1; row <= n; row++)
            {
                Console.Write(row);
                for (int col = 1; col < n; col++)
                {
                    Console.Write(row + col);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
