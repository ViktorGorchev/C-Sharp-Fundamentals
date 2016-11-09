namespace CohesionAndCoupling
{
    using System;

    public class UtilsExamples
    {
        public static void Main()
        {
            Console.WriteLine(FileNameExtraction.GetFileExtension("example.exe"));
            Console.WriteLine(FileNameExtraction.GetFileExtension("example.pdf"));
            Console.WriteLine(FileNameExtraction.GetFileExtension("example.new.pdf"));

            Console.WriteLine(FileNameExtraction.GetFileNameWithoutExtension("example"));
            Console.WriteLine(FileNameExtraction.GetFileNameWithoutExtension("example.pdf"));
            Console.WriteLine(FileNameExtraction.GetFileNameWithoutExtension("example.new.pdf"));

            double point1X = 1;
            double point1Y = -2;
            double point2X = 3;
            double point2Y = 4;
            Console.WriteLine(
                "Distance in the 2D space = {0:f2}", 
                Calculations.CalculateDistanceIn2D(point1X, point1Y, point2X, point2Y));

            double x1 = 5;
            double y1 = 2;
            double z1 = -1;
            double x2 = 3;
            double y2 = -6;
            double z2 = 4;
            Console.WriteLine("Distance in the 3D space = {0:f2}", Calculations.CalculateDistanceIn3D(x1, y1, z1, x2, y2, z2));

            double width = 3;
            double height = 4;
            double depth = 5;
            Console.WriteLine("Volume = {0:f2}", Calculations.CalculateVolume(width, height, depth));
            Console.WriteLine("Diagonal XYZ = {0:f2}", Calculations.CalculateDiagonalIn3D(width, height, depth));
            Console.WriteLine("Diagonal XY = {0:f2}", Calculations.CalculateDiagonaIn2D(height, width));
            Console.WriteLine("Diagonal XZ = {0:f2}", Calculations.CalculateDiagonaIn2D(width, depth));
            Console.WriteLine("Diagonal YZ = {0:f2}", Calculations.CalculateDiagonaIn2D(height, depth));
        }
    }
}
