using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_DistanceCalculator
{
    static class Points3D
    {
        public static void Distance(double x, double y, double z, double x2, double y2, double z2)
        {
            Console.WriteLine(Math.Sqrt(((x2 - x) * (x2 - x) + (y2 - y) * (y2 - y) + (z2 - z) * (z2 - z))));
        }
    }
}
