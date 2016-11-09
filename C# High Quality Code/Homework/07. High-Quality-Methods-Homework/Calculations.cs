namespace Methods
{
    using System;

    public class Calculations
    {
        public static double CalculateTriangleArea(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                throw new AggregateException("Sides should be positive.");
            }

            double s = (a + b + c) / 2;
            double area = Math.Sqrt(s * (s - a) * (s - b) * (s - c));

            return area;
        }

        public static int FindMax(params int[] elements)
        {
            if (elements.Length == 0)
            {
                throw new ArgumentNullException(nameof(elements), "The array of elements can't be empty!");
            }

            int maxElement = elements[0];
            for (int i = 1; i < elements.Length; i++)
            {
                if (elements[i] > maxElement)
                {
                    maxElement = elements[i];
                }
            }

            return maxElement;
        }

        public static double CalculateDistance(double x1, double y1, double x2, double y2)
        {
            double distance = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));

            return distance;
        }

        public static bool IsHorizontalLine(double x1, double x2)
        {
            bool isHorizontal = x1 == x2;
            return isHorizontal;
        }

        public static bool IsVerticalLine(double y1, double y2)
        {
            bool isVertical = y1 == y2;
            return isVertical;
        }
    }
}
