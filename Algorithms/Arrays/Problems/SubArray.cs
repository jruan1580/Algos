using System;
using System.Collections.Generic;
using System.Text;

namespace Arrays.Problems
{
    public class SubArray
    {
        public bool IsSubArrayWithDictionary(int [] arr1, int[] arr2)
        {
            var tracker = new Dictionary<int, bool>();

            foreach (var num in arr1)
            {
                if (tracker.ContainsKey(num))
                {
                    continue;
                }

                tracker.Add(num, true);
            }

            foreach (var num in arr2)
            {
                if (!tracker.ContainsKey(num))
                {
                    return false;
                }
            }

            return true;
        }

        public bool IsSubArrayWithBST(int [] arr1, int [] arr2)
        {
            Array.Sort(arr1);

            foreach(var num in arr2)
            {
                if (!BinarySearch(arr1, num))
                {
                    return false;
                }
            }

            return true;
        }

        private bool BinarySearch(int [] arr, int target)
        {
            var low = 0;
            var high = arr.Length - 1;

            while(low <= high)
            {
                var mid = (low + high) / 2;

                if (arr[mid] == target)
                {
                    return true;
                }
                else if (target > arr[mid])
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }

            return false;
        }
    }
}
