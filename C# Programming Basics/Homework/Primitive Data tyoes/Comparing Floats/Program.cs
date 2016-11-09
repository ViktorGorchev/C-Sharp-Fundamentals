using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comparing_Floats
{
    class Program
    {
        static void Main()
        {
            string a = Console.ReadLine();
            double a1 = double.Parse(a);
            string b = Console.ReadLine();
            double b1 = double.Parse(b);
            float a2 = (float)a1;
            float b2 = (float)b1;
            bool compare = (a2 == b2);
            Console.WriteLine(compare);
            
            //string text1 = "5";
            //int num1;
            //int.TryParse(text1, out num1);
            //Console.WriteLine(num1);
          


        }
    }
}
