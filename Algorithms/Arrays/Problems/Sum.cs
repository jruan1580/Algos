using System;
using System.Collections.Generic;

namespace Arrays.Problems
{
    public class Sum
    {
        public void PrintAllPairsEqualToSum(int sum, int[] nums)
        {
            var tracker = new Dictionary<int, bool>();

            foreach (var num in nums)
            {
                //found a pair.
                if (tracker.ContainsKey(sum - num))
                {
                    Console.WriteLine($"{sum - num},{num}");
                }
                else
                {
                    tracker.Add(num, true);
                }
            }
        }

        /// <summary>
        /// same as above but use some data structure to keep track of all distinct 
        /// </summary>
        /// <param name="sum"></param>
        /// <param name="nums"></param>
        public void PrintAllDistinctPairEqualToSum(int sum, int [] nums)
        {
            var tracker = new Dictionary<int, bool>();
            var distinctSum = new Dictionary<string, bool>();

            foreach (var num in nums)
            {
                //found a pair.
                if (tracker.ContainsKey(sum - num))
                {
                    //aready found the pair, continue
                    if (distinctSum.ContainsKey($"{sum - num},{num}") || distinctSum.ContainsKey($"{sum},{sum - num}"))
                    {
                        continue;
                    }

                    //did not find pair, print it and store it in dicitonary of distinct sums
                    Console.WriteLine($"{sum - num},{num}");

                    distinctSum.Add($"{sum - num},{num}", true);
                    distinctSum.Add($"{sum - num},{sum}", true);
                }
                else
                {
                    tracker.Add(num, true);
                }
            }
        }

        public bool HasSubArrySumEqualToZeroBruteForce(int [] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                //found subarray of 0
                if (arr[i] == 0)
                {
                    return true;
                }

                var zeroSum = arr[i];
                for (int j = i + 1; j < arr.Length; j++)
                {
                    //found sub array of 0
                    if (arr[j] == 0)
                    {
                        return true;
                    }

                    zeroSum += arr[j];
                    if (zeroSum == 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool HasSubArrySumEqualToZeroNotBruteForce(int[] arr)
        {
            var tracker = new Dictionary<int, bool>();
            var res = 0;

            foreach(var num in arr)
            {
                res += num;
                if (num == 0 || res == 0 || tracker.ContainsKey(res))
                {
                    return true;
                }

                tracker.Add(res, true);
            }

            return false;
        }
    }
}
