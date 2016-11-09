using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Write an expression that checks for given point (x, y) if it is within the circle K({1, 1}, 1.5) 
//and out of the rectangle R(top=1, left=-1, width=6, height=2). 
namespace Point_InsideCircle_OutsideRectangle
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Enter coordinates x and y for circle K({1.1}, 1.5 ):");
            double x = double.Parse(Console.ReadLine());
            double y = double.Parse(Console.ReadLine());
            if ((Math.Pow((x - 1), 2) + Math.Pow((y - 1), 2) <= Math.Pow(1.5, 2)) && (x <= 2.5 && x >= -0.5) && (y <= 2.5 && y > 1))
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }

        }
    }
}
