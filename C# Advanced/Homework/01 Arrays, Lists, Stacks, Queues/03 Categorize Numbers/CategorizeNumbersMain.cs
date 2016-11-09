namespace _03_Categorize_Numbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CategorizeNumbersMain
    {
        public static void Main()
        {
            string[] inputNumbers = Console.ReadLine().Split(' ');
            List<int> roundNumbers = new List<int>();
            List<double> floatingPointNumbers = new List<double>();

            for (int i = 0; i < inputNumbers.Length; i++)
            {
                var checkForInt = 0;
                if (int.TryParse(inputNumbers[i], out checkForInt))
                {
                    roundNumbers.Add(int.Parse(inputNumbers[i]));
                }
                else if (double.Parse(inputNumbers[i]) == Math.Floor(double.Parse(inputNumbers[i])))
                {
                    roundNumbers.Add((int)Math.Floor(double.Parse(inputNumbers[i])));
                }
                else
                {
                    floatingPointNumbers.Add(double.Parse(inputNumbers[i]));
                }
            }

            Console.WriteLine(
                "[{0}] -> min: {1}, max: {2}, sum: {3}, avg: {4}", 
                string.Join(", ", floatingPointNumbers), 
                Math.Round(floatingPointNumbers.Min(), 2), 
                Math.Round(floatingPointNumbers.Max(), 2), 
                Math.Round(floatingPointNumbers.Sum(), 2), 
                Math.Round(floatingPointNumbers.Average(), 2));

            Console.WriteLine(
                "[{0}] -> min: {1}, max: {2}, sum: {3}, avg: {4}", 
                string.Join(", ", roundNumbers), 
                roundNumbers.Min(), 
                roundNumbers.Max(), 
                roundNumbers.Sum(), 
                roundNumbers.Average());
        }
    }
}