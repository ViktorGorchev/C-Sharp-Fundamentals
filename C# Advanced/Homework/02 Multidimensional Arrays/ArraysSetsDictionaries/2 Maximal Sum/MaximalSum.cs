namespace _2_Maximal_Sum
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class MaximalSum
    {
        public static void Main(string[] args)
        {
            int[] dementions = Regex.Split(Console.ReadLine(), "\\s+").Select(int.Parse).ToArray();
            var matrix = new List<List<int>>();

            for (int i = 0; i < dementions[0]; i++)
            {
                matrix.Add(Console.ReadLine().Split(' ').Select(int.Parse).ToList());
            }

            int maxSum = int.MinValue;
            int[] pos = new int[2];
            for (int i = 0; i < dementions[0] - 2; i++)
            {
                for (int j = 0; j < dementions[1] - 2; j++)
                {
                    var currSum = matrix[i][j] + matrix[i][j + 1] + matrix[i][j + 2] +
                                  matrix[i + 1][j] + matrix[i + 1][j + 1] + matrix[i + 1][j + 2] +
                                  matrix[i + 2][j] + matrix[i + 2][j + 1] + matrix[i + 2][j + 2];
                    if (currSum > maxSum)
                    {
                        maxSum = currSum;
                        pos[0] = i;
                        pos[1] = j;
                    }
                }
            }

            Console.WriteLine("Sum = {0}", maxSum);
            for (int i = pos[0]; i < pos[0] + 3; i++)
            {
                for (int j = pos[1]; j < pos[1] + 3; j++)
                {
                    Console.Write("{0,3}", matrix[i][j]);
                }

                Console.WriteLine();
            }
        }
    }
}
