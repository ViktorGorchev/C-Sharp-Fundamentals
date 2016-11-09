using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace formatting_numbers
{
    class Program
    {
        static void Main()
        {
            try
            {
                int a = int.Parse(Console.ReadLine());
                double b = double.Parse(Console.ReadLine());
                double c = double.Parse(Console.ReadLine());

                Console.WriteLine("|{0,-10:X}|{1}|{2,10:F2}|{3,-10:F3}|",a , Convert.ToString(a, 2).PadLeft(10, '0'), b, c);
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid input!");
                throw;
            }
        }
    }
}
