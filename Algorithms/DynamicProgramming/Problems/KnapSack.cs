using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicProgramming.Problems
{
    public class KnapSack
    {
        public int MaxValFillingSackToLimitW(int [] val, int [] weights, int w)
        {
            var dp = new int[weights.Length + 1, w + 1];

            //given no val, cannot fill any weight, so max val is 0
            for(var i = 0; i < dp.GetLength(1); i++)
            {
                dp[0, i] = 0;
            }

            //given a weight limit of 0, cannot fill any weight, so max val is 0
            for (var i = 0; i < dp.GetLength(0); i++)
            {
                dp[i, 0] = 0;
            }

            for(var i = 1; i < dp.GetLength(0); i++)
            {
                for(var j = 1; j < dp.GetLength(1); j++)
                {
                    //weight is greater than weight, we cannot take it
                    if (weights[i - 1] > j)
                    {
                        dp[i, j] = dp[i - 1, j]; //val is equal to val of prior subsets forming weight without current val
                    }
                    else
                    {
                        //val is less than j, we can take it or not take it.
                        //val is max between the two vals
                        var takeItVal = val[i - 1] + dp[i - 1, j - weights[i - 1]]; //take the val of the current weight and add it to val of whatever weight is remaining with remaining subset
                        var leaveItVal = dp[i - 1, j];

                        dp[i, j] = Math.Max(takeItVal, leaveItVal);
                    }
                }
            }

            return dp[weights.Length, w];
        }
    }
}
