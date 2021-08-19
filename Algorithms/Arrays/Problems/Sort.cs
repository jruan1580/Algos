using System;
using System.Collections.Generic;
using System.Text;

namespace Arrays.Problems
{
    public class Sort
    {
        public void BubbleSort(int [] arr)
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
        }

        public void SelectionSort(int[] arr)
        {
            if (arr.Length == 0 || arr.Length == 1)
            {
                return;
            }

            for(int i = 0; i < arr.Length - 1; i++)
            {
                var smallestElement = arr[i];
                var indexOfSmallestElement = i;
                for(int j = i + 1; j < arr.Length; j++)
                {
                    if (smallestElement < arr[j])
                    {
                        smallestElement = arr[j];
                        indexOfSmallestElement = j;
                    }
                }

                //swap smallest element to front and replace bigger element to original index of smallest element.
                var tmp = arr[i];
                arr[i] = smallestElement;
                arr[indexOfSmallestElement] = tmp;
            }
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

        public void MergeSort(int [] arr, int low, int high)
        {
            if (low >= high)
            {
                return;
            }

            var mid = (low + (high - low)) / 2;
            MergeSort(arr, low, mid); //break apart left side
            MergeSort(arr, mid + 1, high); //break apart right side

            //merge both halfs
            Merge(arr, low, mid, high);
        }

        private void Merge(int [] arr, int low, int mid, int high)
        {
            //first sub length is from low to mid
            var lengthOfFirstArr = (mid - low) + 1;
            //second sub length is from mid + 1 to high
            var lengthOfSecondArr = (high - mid);

            var temp1Arr = new int[lengthOfFirstArr];
            var temp2Arr = new int[lengthOfSecondArr];

            //copy first half sub over (from low to mid)
            for (int i = 0; i < lengthOfFirstArr; i++)
            {
                temp1Arr[i] = arr[low + i];
            }

            //copy second half over (from mid + 1 to high)
            for (int j = 0; j < lengthOfSecondArr; j++)
            {
                temp2Arr[j] = arr[mid + 1 + j];
            }

            var firstArrIndex = 0;
            var secondArrIndex = 0;

            var startIndexToMerge = low; //we start at low of original arr to begin merging
            while (firstArrIndex < lengthOfFirstArr && secondArrIndex < lengthOfSecondArr)
            {
                //first arr is smaller, add it to original arr
                if (temp1Arr[firstArrIndex] <= temp2Arr[secondArrIndex])
                {
                    arr[startIndexToMerge] = temp1Arr[firstArrIndex];
                    firstArrIndex++;
                }
                else
                {
                    //second arr is smaller
                    arr[startIndexToMerge] = temp2Arr[secondArrIndex];
                    secondArrIndex++;
                }

                startIndexToMerge++;
            }

            //copy remaining first arr if any
            while(firstArrIndex < lengthOfFirstArr)
            {
                arr[startIndexToMerge] = temp1Arr[firstArrIndex];
                startIndexToMerge++;
                firstArrIndex++;
            }

            //copy remaining second arr if any
            while(secondArrIndex < lengthOfSecondArr)
            {
                arr[secondArrIndex] = temp2Arr[secondArrIndex];
                secondArrIndex++;
                startIndexToMerge++;
            }
        }
    }
}
