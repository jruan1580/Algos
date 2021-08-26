using System;

namespace Arrays.Problems
{
    public class ChocolateDistribution
    {
        public int FindMinDiffBetweenMinAndMaxDistribution(int [] arr, int m)
        {
            Array.Sort(arr);

            var minDiff = int.MaxValue;
            for(var i = 0; i < arr.Length; i++)
            {
                if (i + m >= arr.Length)
                {
                    break;
                }

                minDiff = Math.Min(minDiff, (arr[i + m - 1] - arr[i]));
            }

            return minDiff;
        }
    }
}
