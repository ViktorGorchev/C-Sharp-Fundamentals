namespace Exceptions_Homework
{
    using System;
    using System.Collections.Generic;

    public class ArraySubsequencer
    {
        public T[] Subsequence<T>(T[] arr, int startIndex, int count)
        {
            if (startIndex >= arr.Length - 1)
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex), "Start index is out the range of the array!");
            }

            if (startIndex + count > arr.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(count), "Count plus start index is out the range of the array!");
            }

            List<T> result = new List<T>();
            for (int i = startIndex; i < startIndex + count; i++)
            {
                result.Add(arr[i]);
            }

            return result.ToArray();
        }
    }
}
