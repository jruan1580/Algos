using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicProgramming.Problems
{
    public class Numbers
    {
        public int Catalan(int n)
        {
            var dp = new int[n + 2];
            dp[0] = dp[1] = 1;

            for(var i = 2; i <= n; i++)
            {
                dp[i] = 0;
                for(var j = 0; j < i; j++)
                {
                    dp[i] += (dp[j] * dp[i - j - 1]);
                }
            }

            return dp[n];
        }

        public int Fib(int n)
        {
            var dp = new int[n + 2];
            dp[0] = 0;
            dp[1] = 1;

            for(var i = 2; i <= n; i++)
            {
                dp[i] = dp[i - 1] + dp[i - 2];
            }

            return dp[n];
        }

        public bool HasSubsetSum(int[] arr, int sum)
        {
            var dp = new bool[arr.Length + 1, sum + 1];

            for (var i = 0; i < dp.GetLength(0); i++)
            {
                //first column is sum 0. if you have sum 0, no matter what array of int ur given, can always find subset of sum 0 = empty subset
                dp[i, 0] = true; 
            }

            for (var i = 1; i < dp.GetLength(1); i++)
            {
                //first row represent the diff sums up to our input sum. Given only 0 (empty subset) as our array, we can NOT form any sum, so it is false
                dp[0, i] = false;
            }

            for(var i = 1; i < dp.GetLength(0); i++)
            {
                for(var j = 1; j < dp.GetLength(1); j++)
                {
                    //current number is greater than the sum we want, can not use it, need to exclude
                    if (arr[i - 1] > j)
                    {
                        //if we exclude, we need for form sum with number presented prior to curr number, look at value above
                        dp[i, j] = dp[i - 1, j];
                    }
                    else
                    {
                        //we can use the number. Can we form subset is equal to can we form subset including number OR excluding
                        dp[i, j] = (dp[i - 1, j] || dp[i - 1, j - arr[i - 1]]);
                    }
                }
            }

            return dp[arr.Length, sum];
        }

        public bool CanBePartitionToEqualSumSets(int [] arr)
        {
            var sum = 0;
            foreach(var n in arr)
            {
                sum += n;
            }

            //if total sum is odd, cannot be evenly divided between two sets
            if (sum % 2 == 1)
            {
                return false;
            }

            return HasSubsetSum(arr, sum / 2);
        }

        public int MaxSumIncSubsequence(int [] arr)
        {
            var dp = new int[arr.Length];

            for(var i = 0; i < arr.Length; i++)
            {
                dp[i] = arr[i];
            }

            for(var i = 1; i < arr.Length; i++)
            {
                for (var j = 0; j < i; j++)
                {
                    //number before is greater than number after, not inc.
                    if (arr[j] > arr[i])
                    {
                        continue;
                    }

                    dp[i] = Math.Max(dp[i], arr[i] + dp[j]);
                }
            }

            var maxSum = int.MinValue;
            foreach(var sum in dp)
            {
                if(maxSum < sum)
                {
                    maxSum = sum;
                }
            }

            return maxSum;
        }

        public int MinimumSquareWhereSumIsN(int n)
        {
            if (n <= 3)
            {
                return n;
            }

            var dp = new int[n + 1];
            dp[0] = 0;
            dp[1] = 1;
            dp[2] = 2;
            dp[3] = 3;

            for(var i = 4; i <= n; i++)
            {
                dp[i] = i; //curr max val is i using 1 as squares
                for(var x = 1; x <= Math.Ceiling(Math.Sqrt(i)); x++)
                {
                    var tmp = x * x;
                    if (tmp > i) 
                    { 
                        break;
                    }

                    dp[i] = Math.Min(dp[i], 1 + dp[i - tmp]);   
                }
            }

            return dp[n];
        }
    }
}
