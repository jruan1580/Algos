using System;
using System.Collections.Generic;
using System.Text;

namespace Arrays.Problems
{
    public class Sort
    {
        public int[] BubbleSort(int [] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = 0; j < arr.Length - i - 1; j++)
                {
                    if (arr[j] < arr[j + 1])
                    {
                        var tmp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = tmp;
                    }
                }
            }

            return arr;
        }

        public void QuickSort(int [] arr, int low, int high)
        {
            if (low >= high)
            {
                return;
            }

            var partitionIndex = Partition(arr, low, high);

            //sort left of partition
            QuickSort(arr, low, partitionIndex - 1);
            //sort right of partition
            QuickSort(arr, partitionIndex + 1, high);
        }

        private int Partition(int [] arr, int low, int high)
        {
            var partitionVal = arr[high];
            int indexOfSmallestElement = (low - 1);

            for(int j = low; j <= high - 1; j++)
            {
                if (arr[j] < partitionVal)
                {
                    indexOfSmallestElement++;
                    var tmp = arr[indexOfSmallestElement];
                    arr[indexOfSmallestElement] = arr[j];
                    arr[j] = tmp;
                }
            }

            //swap pivot to right place
            indexOfSmallestElement++;
            var temp = arr[indexOfSmallestElement];
            arr[indexOfSmallestElement] = partitionVal;
            arr[high] = temp;

            return indexOfSmallestElement; //index of pivot right now
        }

        private void Merge(int [] arr, int low, int mid, int high)
        {
            //first sub length is from low to mid
            var lengthOfFirstArr = (mid - low) + 1;
            //second sub length is from mid + 1 to high
            var lengthOfSecondArr = (high - mid);

        }
    }
}
