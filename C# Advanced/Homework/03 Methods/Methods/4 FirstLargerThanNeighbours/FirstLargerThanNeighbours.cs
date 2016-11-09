namespace _4_FirstLargerThanNeighbours
{
    using System;

    public class FirstLargerThanNeighbours
    {
        public static void Main()
        {
            int[] seqOne = { 1, 3, 4, 5, 1, 0, 5 };
            int[] seqTwo = { 1, 2, 3, 4, 5, 6, 6 };
            int[] seqThree = { 1, 1, 1 };
            Console.WriteLine(GetIndexOfFirstLarger(seqOne));
            Console.WriteLine(GetIndexOfFirstLarger(seqTwo));
            Console.WriteLine(GetIndexOfFirstLarger(seqThree));
        }

        private static int GetIndexOfFirstLarger(int[] arr)
        {
            for (int index = 0; index < arr.Length; index++)
            {
                if (index != 0 && index != arr.Length - 1)
                {
                    if (arr[index] > arr[index + 1] &&
                        arr[index] > arr[index - 1])
                    {
                        return index;
                    }
                }

                if (index == 0 && arr[index] > arr[index + 1])
                {
                    return index;
                }

                if (index == arr.Length - 1 && arr[index] > arr[index - 1])
                {
                    return index;
                }
            }

            return -1;
        }
    }
}
