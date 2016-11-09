namespace _01_Sort_Array_of_Numbers
{
    using System;
    using System.Linq;

    public class SortNumbersMain
    {
        public static void Main()
        {
            var readLine = Console.ReadLine();
            if (readLine != null)
            {
                int[] numbers = readLine.Split(' ').Select(int.Parse).ToArray();
                Array.Sort(numbers);
                foreach (var number in numbers)
                {
                    Console.Write(number + " ");
                }
            }
        }
    }
}