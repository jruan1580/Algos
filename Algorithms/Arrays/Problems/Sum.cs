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

        public int MaximumSumOfAllRotations(int [] arr)
        {
            var sumOfArr = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                sumOfArr += arr[i];
            }

            var currSum = 0;
            for(int i = 0; i < arr.Length; i++)
            {
                currSum += (i * arr[i]);
            }

            var currMax = currSum;

            //formula -> currSum - (SumOfArr - arr[i -1]) + (arr[i-1]*arr.Length-1)
            for (int i = 1; i < arr.Length; i++)
            {
                var nextSum = currSum - (sumOfArr - arr[i - 1]) + (arr[i - 1] * (arr.Length - 1));

                if (nextSum > currMax)
                {
                    currMax = nextSum;
                }

                currSum = nextSum;
            }

            return currMax;
        }

        public int MaximumSumPath(int [] arr1, int [] arr2)
        {
            var sum1 = 0;
            var sum2 = 0;
            var result = 0;

            var i = 0; //tracks arr1
            var j = 0; //tracks arr2

            while(i < arr1.Length && j < arr2.Length)
            {
                if (arr2[i] < arr2[j])
                {
                    sum1 += arr1[i];
                    i++;
                }
                else if(arr2[i] > arr2[j])
                {
                    sum2 += arr2[j];
                    j++;
                }
                else
                {
                    result += (Math.Max(sum1, sum2)) + arr2[i];
                    sum1 = 0;
                    sum2 = 0;
                    i++;
                    j++;
                }
            }

            while (i < arr1.Length)
            {
                sum1 += arr1[i];
                i++;
            }

            while (j < arr2.Length)
            {
                sum2 += arr2[j];
                j++;
            }

            return result + Math.Max(sum1, sum2);
        }

        public void PrintPairClosestToSum(int [] arr, int target)
        {
            var start = 0;
            var end = arr.Length - 1;

            var minDiffSoFar = int.MaxValue;
            var firstMinPair = int.MaxValue;
            var secMinPair = int.MaxValue;

            while(start < end)
            {
                //sum is less than target
                if (arr[end] + arr[start] <= target)
                {
                    //check to see if smaller than curr min, if so, new pair of closest to x
                    if ((target - (arr[end] + arr[start])) < minDiffSoFar)
                    {
                        firstMinPair = arr[start];
                        secMinPair = arr[end];
                        minDiffSoFar = target - (arr[end] + arr[start]);
                    }                
                    
                    if (arr[start] + arr[end] > target)
                    {
                        end--;
                    }
                    else
                    {
                        start++;
                    }
                }               
            }

            if (firstMinPair == int.MaxValue && secMinPair == int.MaxValue)
            {
                Console.WriteLine("None");
            }
            else
            {
                Console.WriteLine($"{firstMinPair},{secMinPair}");
            }
        }
    }
}
