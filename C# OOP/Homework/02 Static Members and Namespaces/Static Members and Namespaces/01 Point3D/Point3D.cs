using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Point3D
{
    public class Point3D
    {
        private static readonly Point3D startingPoint = new Point3D(0, 0, 0);

        private double x;
        private double y;
        private double z;

        public static Point3D StartingPoint
        {
            get { return startingPoint; }
        }

        public Point3D(double x, double y, double z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public double X
        {
            get { return this.x; }
            set { this.x = value; }
        }

        public double Y
        {
            get { return this.y; }
            set { this.y = value; }
        }

        public double Z
        {
            get { return this.z; }
            set { this.z = value; }
        }

        public override string ToString()
        {
            return string.Format("Point with coordinates: X = {0}, Y = {1}, Z = {2}", this.x, this.y, this.z);
        }
    }
}
