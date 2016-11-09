namespace Assertions_Homework
{
    using System;
    using System.Diagnostics;

    public class Assertions
    {
        public int BinarySearch<T>(T[] arr, T value, int startIndex = 0)
            where T : IComparable<T>
        {
            int endIndex = arr.Length - 1;
            Debug.Assert(arr.Length > 0, "Array is empty!");
            while (startIndex <= endIndex)
            {
                int midIndex = (startIndex + endIndex) / 2;
                if (arr[midIndex].Equals(value))
                {
                    return midIndex;
                }

                if (arr[midIndex].CompareTo(value) < 0)
                {
                    // Search on the right half
                    startIndex = midIndex + 1;
                }
                else
                {
                    // Search on the right half
                    endIndex = midIndex - 1;
                }
            }

            // Searched value not found
            return -1;
        }

        public void SelectionSort<T>(T[] arr) where T : IComparable<T>
        {
            int arryLehgth = arr.Length;
            Debug.Assert(arr.Length > 0, "Can't sort an empty array!");
            for (int index = 0; index < arr.Length - 1; index++)
            {
                int minElementIndex = this.FindMinElementIndex(arr, index, arr.Length - 1);
                this.Swap(ref arr[index], ref arr[minElementIndex]);
            }

            Debug.Assert(arryLehgth == arr.Length, "Array length different after sorting!");
            for (int i = 0; i < arr.Length - 1; i++)
            {
                Debug.Assert(arr[i].CompareTo(arr[i + 1]) <= 0, "Array is not sorted!");
            }
        }

        private int FindMinElementIndex<T>(T[] arr, int startIndex, int endIndex)
            where T : IComparable<T>
        {
            int minElementIndex = startIndex;
            for (int i = startIndex + 1; i <= endIndex; i++)
            {
                if (arr[i].CompareTo(arr[minElementIndex]) < 0)
                {
                    minElementIndex = i;
                }
            }

            return minElementIndex;
        }

        private void Swap<T>(ref T x, ref T y)
        {
            Debug.Assert(x.GetType() == y.GetType(), "Elements of different type can’t be swapped!");
            T oldX = x;
            T oldY = y;
            x = oldY;
            y = oldX;
            bool swapComplete = x.Equals(oldY) && y.Equals(oldX);
            Debug.Assert(swapComplete, "Swap could not be performed!");
        }
    }
}
