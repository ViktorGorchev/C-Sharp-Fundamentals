namespace Assertions_Homework
{
    using System;

    public class AssertinsMain
    {
        public static void Main()
        {
            Assertions assertions = new Assertions();

            int[] arr = { 3, -1, 15, 4, 17, 2, 33, 0 };
            Console.WriteLine("arr = [{0}]", string.Join(", ", arr));
            assertions.SelectionSort(arr);
            Console.WriteLine("sorted = [{0}]", string.Join(", ", arr));

            ////assertions.SelectionSort(new int[0]); // Test sorting empty array
            assertions.SelectionSort(new int[1]); // Test sorting single element array

            Console.WriteLine(assertions.BinarySearch(arr, -1000));
            Console.WriteLine(assertions.BinarySearch(arr, 0));
            Console.WriteLine(assertions.BinarySearch(arr, 17));
            Console.WriteLine(assertions.BinarySearch(arr, 10));
            Console.WriteLine(assertions.BinarySearch(arr, 1000));
        }
    }
}