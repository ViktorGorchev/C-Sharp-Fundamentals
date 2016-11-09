namespace CohesionAndCoupling
{
    using System;

    public static class Calculations
    {
        public static double CalculateDistanceIn2D(double x1, double y1, double x2, double y2)
        {
            double distance = Math.Sqrt(((x2 - x1) * (x2 - x1)) + ((y2 - y1) * (y2 - y1)));

            return distance;
        }

        public static double CalculateDiagonaIn2D(double x, double y)
        {
            double distance = Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));

            return distance;
        }
        
        public static double CalculateDistanceIn3D(double x1, double y1, double z1, double x2, double y2, double z2)
        {
            double distance = Math.Sqrt(((x2 - x1) * (x2 - x1)) + ((y2 - y1) * (y2 - y1)) + ((z2 - z1) * (z2 - z1)));

            return distance;
        }

        public static double CalculateDiagonalIn3D(double width, double height, double depth)
        {
            double distance = Math.Sqrt(Math.Pow(width, 2) + Math.Pow(height, 2) + Math.Pow(depth, 2));
            
            return distance;
        }

        public static double CalculateVolume(double width, double height, double depth)
        {
            double volume = width * height * depth;

            return volume;
        }
    }
}
