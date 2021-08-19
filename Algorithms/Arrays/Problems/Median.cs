namespace Arrays.Problems
{
    public class Median
    {
        public int MedianOfTwoSortedArrays(int [] arr1, int [] arr2)
        {
            var mergedArray = new int[arr1.Length + arr2.Length];
            var arr1Index = 0;
            var arr2Index = 0;
            var mergeIndex = 0;

            while (arr1Index < arr1.Length && arr2Index < arr2.Length)
            {
                if (arr1[arr1Index] <= arr2[arr2Index])
                {
                    mergedArray[mergeIndex] = arr1[arr1Index];
                    arr1Index++;
                }
                else
                {
                    mergedArray[mergeIndex] = arr2[arr2Index];
                    arr2Index++;
                }

                mergeIndex++;
            }

            //merge remaining arr1 if any
            while(arr1Index < arr1.Length)
            {
                mergedArray[mergeIndex] = arr1[arr1Index];
                arr1Index++;
                mergeIndex++;
            }

            //merge remaining arr2 if any
            while(arr2Index < arr2.Length)
            {
                mergedArray[mergeIndex] = arr2[arr2Index];
                arr2Index++;
                mergeIndex++;
            }

            //now find median of sorted merged array
            //odd numbers in array, median is the middle element
            if (mergedArray.Length % 2 == 1)
            {
                return mergedArray[(mergedArray.Length) / 2];
            }
            else
            {
                //even numbers in array, median is middle element + element before divided by 2
                var mid = mergedArray[(mergedArray.Length) / 2];
                var beforeMid = mergedArray[((mergedArray.Length) / 2) - 1];

                return (beforeMid + mid) / 2;
            }
        }
    }
}
