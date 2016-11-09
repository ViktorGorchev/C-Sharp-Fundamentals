namespace _02_SortArrayOfNumbersUsingSelectionSort
{
    using System;
    using System.Linq;

    public class SelectionSortMain
    {
        public static void Main()
        {
            var readLine = Console.ReadLine();
            if (readLine != null)
            {
                int[] numbers = readLine.Split(' ').Select(int.Parse).ToArray();
                int temp = int.MaxValue;
                int tempIndex = 0;

                for (int i = 0; i < numbers.Length; i++)
                {
                    for (int j = i; j < numbers.Length; j++)
                    {
                        if (numbers[j] < temp)
                        {
                            temp = numbers[j];
                            tempIndex = j;
                        }
                    }

                    if (numbers[i] > temp)
                    {
                        int numberAtCheckedPosition = numbers[i];
                        numbers[i] = numbers[tempIndex];
                        numbers[tempIndex] = numberAtCheckedPosition;
                    }

                    temp = int.MaxValue;
                }

                foreach (var number in numbers)
                {
                    Console.Write(number + " ");
                }
            }
        }
    }
}