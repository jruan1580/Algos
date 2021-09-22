using System;
using System.Collections.Generic;
using System.Text;

namespace Arrays.Problems
{
    public class Subsequences
    {
        public int LongestIncreasingSubsequence(int [] arr)
        {
            var longestSubTracker = new int[arr.Length];

            //initialize everything to 1 since longest subsequence at each value is itself, at 1.
            for (var i = 0; i < longestSubTracker.Length; i++)
            {
                longestSubTracker[i] = 1;
            }

            for (var i = 1; i < arr.Length; i++)
            {
                for(var j = 0; j < i; j++)
                {
                    //earlier values greater than current, not increasing.
                    if (arr[j] >= arr[i])
                    {
                        continue;
                    }

                    longestSubTracker[i] = Math.Max(longestSubTracker[i], longestSubTracker[j] + 1);
                }
            }

            var longestSubsequence = int.MinValue;
            foreach(var val in longestSubTracker)
            {
                if (val > longestSubsequence)
                {
                    longestSubsequence = val;
                }
            }

            return longestSubsequence;
        }

        public int LongestBitonicSubsequence(int [] arr)
        {
            var incLR = new int[arr.Length]; //inc subsequence from left to right
            var incRL = new int[arr.Length]; //inc subsequence from right to left

            for(var i = 0; i < arr.Length; i++)
            {
                incLR[i] = 1;
                incRL[i] = 1;
            }
            
            //populate inc sub from left to right
            for(var i = 0; i < arr.Length; i++)
            {
                for(var j = 0; j < i; j++)
                {
                    //earlier values greater than current, not increasing.
                    if (arr[j] >= arr[i])
                    {
                        continue;
                    }

                    incLR[i] = Math.Max(incLR[i], incLR[j] + 1);
                }
            }

            //populate inc sub from right to left
            for (var i = arr.Length - 2; i > 0; i--)
            {
                for(var j = arr.Length - 1; j > i; j--)
                {
                    if (arr[j] >= arr[i])
                    {
                        continue;
                    }

                    incRL[i] = Math.Max(incRL[i], incRL[j] + 1);
                }
            }

            var longestBitonic = int.MinValue;
            for(var i = 0; i < arr.Length; i++)
            {
                var currentBitonic = incRL[i] + incLR[i] - 1;
                if (currentBitonic > longestBitonic)
                {
                    longestBitonic = currentBitonic;
                }
            }

            return longestBitonic;
        }
    }
}
