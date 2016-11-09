using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Point_in_a_Circle
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Enter points x and y for circle K({0, 0}, 2):");
            double x = double.Parse(Console.ReadLine());
            double y = double.Parse(Console.ReadLine());
            bool check = Math.Pow((x - 0), 2) + Math.Pow((y - 0), 2) <= Math.Pow(2, 2);
            Console.WriteLine("Point inside? {0}", check);

        }
    }
}
