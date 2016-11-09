using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using _01_Point3D;

namespace _03_Paths
{
    class Loader
    {
        static void Main()
        {
            
            try
            {
                Point3D point1 = new Point3D(8, 90, -1);
                Point3D point2 = new Point3D(-5, 66, 45);
                Path3D path = new Path3D(point1, point2);

                Storage.SavePathToFile("text.txt", path.ToString());
                Console.WriteLine("Load from file:\n" + Storage.LoadPathFromFile("text.txt"));
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }                    
        
        }
    }
}
