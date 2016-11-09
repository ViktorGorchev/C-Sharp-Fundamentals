using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Point3D
{
    class Space3D
    {
        static void Main()
        {
            Point3D p1 = new Point3D(3.5, 8, 20.9);
            Point3D zeroPoint = Point3D.StartingPoint;

            Console.WriteLine(p1);
            Console.WriteLine(zeroPoint);
        }
    }
}
