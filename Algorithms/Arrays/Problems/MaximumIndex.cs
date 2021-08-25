using System;
using System.Collections.Generic;
using System.Text;

namespace Arrays.Problems
{
    public class MaximumIndex
    {
        public int MaxDiffBetweenIndexes(int [] arr)
        {
            var minLeft = new int[arr.Length];
            var maxRight = new int[arr.Length];

            //populate min from left
            minLeft[0] = arr[0];
            for (var i = 1; i < arr.Length; i++)
            {
                minLeft[i] = Math.Min(arr[i], minLeft[i - 1]);
            }

            //populate max from right
            maxRight[arr.Length - 1] = arr[arr.Length - 1];
            for(var i = arr.Length - 2; i >= 0; i--)
            {
                maxRight[i] = Math.Max(arr[i], maxRight[i + 1]);
            }

            var min = 0; //tracks minleft
            var max = 0; //tracks maxright
            var maxDiff = -1;

            while (min < arr.Length && max < arr.Length)
            {
                if (minLeft[min] <= maxRight[max])
                {
                    maxDiff = Math.Max(maxDiff, max - min);
                    max++;
                }
                else
                {
                    min++;
                }
            }

            return maxDiff;
        }
    }
}
