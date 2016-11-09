namespace _05_LongestIncreasingSequence
{
    using System;
    using System.Linq;

    public class LongestIncreasingSequenceMain
    {
        public static void Main()
        {
            int numberLongest = 0;
            int bestCount = 0;
            int longestCount = 0;

            int[] inputNumbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            for (int i = 0; i < inputNumbers.Length - 1; i++)
            {
                var count = CountSequence(i, inputNumbers);

                if (count >= bestCount)
                {
                    bestCount = count;
                    int number = i;
                    i += count - 1;

                    PrintSequence(number, bestCount, inputNumbers);

                    if (bestCount > longestCount)
                    {
                        longestCount = bestCount;
                        numberLongest = number;
                    }

                    bestCount = 0;
                }
            }

            Console.Write("Longest: ");
            PrintSequence(numberLongest, longestCount, inputNumbers);
        }

        private static void PrintSequence(int number, int bestCount, int[] inputNumbers)
        {
            for (int l = number; l <= number + bestCount - 1; l++)
            {
                Console.Write("{0} ", inputNumbers[l]);
            }

            Console.WriteLine();
        }

        private static int CountSequence(int i, int[] inputNumbers)
        {
            int count = 1;
            int j = i + 1;
            int k = i;
            while (inputNumbers[k] < inputNumbers[j])
            {
                count++;
                j++;
                k++;
                if (j >= inputNumbers.Length)
                {
                    break;
                }
            }

            return count;
        }
    }
}