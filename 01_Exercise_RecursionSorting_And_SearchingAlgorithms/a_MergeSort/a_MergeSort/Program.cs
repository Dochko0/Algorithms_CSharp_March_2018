using System;
using System.Linq;

namespace MergeSort
{
    class Program
    {

        private static void Sort(int[] arr, int startIndex, int endIndex)
        {
            if (startIndex >= endIndex)
            {
                return;
            }

            int middleIndex = (endIndex + startIndex) / 2;

            Sort(arr, startIndex, middleIndex);
            Sort(arr, middleIndex + 1, endIndex);

            Merge(arr, startIndex, middleIndex, endIndex);
        }

        private static void Merge(int[] arr, int startIndex, int middleIndex, int endIndex)
        {
            if (middleIndex < 0
                || middleIndex + 1 > arr.Length
                || arr[middleIndex] <= arr[middleIndex + 1])
            {
                return;
            }

            int[] helpArr = new int[arr.Length];
            for (int i = startIndex; i <= endIndex; i++)
            {
                helpArr[i] = arr[i];
            }

            int left = startIndex;
            int right = middleIndex + 1;
            for (int i = startIndex; i <= endIndex; i++)
            {              
                if (left > middleIndex)
                {
                    arr[i] = helpArr[right++];
                }
                else if (right > endIndex)
                {
                    arr[i] = helpArr[left++];
                }
                else if (helpArr[left] <= helpArr[right])
                {
                    arr[i] = helpArr[left++];
                }
                else
                {
                    arr[i] = helpArr[right++];
                }
            }

        }
        static void Main()
        {
            var numbers = Console.ReadLine().Split(' ').Select(s => int.Parse(s)).ToArray();
            Sort(numbers, 0, numbers.Length - 1);
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}