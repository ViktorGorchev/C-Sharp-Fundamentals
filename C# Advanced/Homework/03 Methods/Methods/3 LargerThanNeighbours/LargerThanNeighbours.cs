namespace _3_LargerThanNeighbours
{
    using System;

    public class LargerThanNeighbours
    {
        public static void Main()
        {
            int[] numbers = { 1, 3, 4, 5, 1, 0, 5 };
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine(IsLargerThanNeighbours(numbers, i));
            }
        }

        private static bool IsLargerThanNeighbours(int[] arr, int index)
        {
            if (index != 0 && index != arr.Length - 1)
            {
                if (arr[index] > arr[index + 1] &&
                    arr[index] > arr[index - 1])
                {
                    return true;
                }
            }

            if (index == 0 && arr[index] > arr[index + 1])
            {
                return true;
            }

            if (index == arr.Length - 1 && arr[index] > arr[index - 1])
            {
                return true;
            }

            return false;
        }
    }
}
