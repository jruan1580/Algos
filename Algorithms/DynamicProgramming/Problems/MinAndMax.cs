using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicProgramming.Problems
{
    public class MinAndMax
    {
        /// <summary>
        /// starting from 0 to n.
        /// min op to get from 0 to n.
        /// ops allowed - add 1 or multiple by 2
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int MinimumOperation(int n)
        {
            var dp = new int[n + 1];

            dp[0] = 0;
            for(var i = 1; i <= n; i++)
            {
                dp[i] = int.MaxValue;
                if (i % 2 == 0)
                {
                    if (dp[i / 2] + 1 < dp[i])
                    {
                        dp[i] = dp[i / 2] + 1;
                    }
                }

                if (dp[i - 1] + 1 < dp[i])
                {
                    dp[i] = dp[i - 1] + 1;
                }
            }

            return dp[n];
        }

        public int MaxProductByCut(int n)
        {
            var dp = new int[n + 1];
            dp[0] = dp[1] = 0;

            for(var i = 2; i <= n; i++)
            {
                for(var j = 1; j <= i/2; j++)
                {
                    dp[i] = Math.Max(dp[i], Math.Max((j * (i - j)), (j * dp[i - j])));
                }
            }

            return dp[n];
        }

        public int CuttingRod(int len, int [] price)
        {
            var dp = new int[len + 1];
            dp[0] = 0;
            dp[1] = price[0];

            for(var i = 2; i <= len; i++)
            {
                dp[i] = price[i - 1];
                for(var j = 1; j <= i/2; j++)
                {
                    dp[i] = Math.Max(dp[i], Math.Max((price[j - 1] + price[i - j -1]), (price[j - 1] + dp[i - j])));
                }
            }

            return dp[len];
        }

        public int NumberOfStepsToReachNDistance(int n)
        {
            var dp = new int[n + 1];
            dp[0] = 1;            
            
            for(var i = 1; i <= n; i++)
            {
                dp[i] = 0;
                if (i >= 3)
                {
                    dp[i] += dp[i - 3];
                }

                if (i >= 2)
                {
                    dp[i] += dp[i - 2];
                }

                if (i >= 1)
                {
                    dp[i] += dp[i - 1];
                }
            }

            return dp[n];
        }

        public int MinTaskTimeAllowingSkipButNotConsecutive(int [] taskTimes)
        {
            var inc = taskTimes[0]; //include the first one
            var exc = 0; //exclude first one

            for(var i = 1; i < taskTimes.Length; i++)
            {
                var tmp = inc;

                inc = taskTimes[i] + Math.Min(inc, exc); //if we include curr time, we have choice between excluding last number result and including last number result. ofc take the smallest of the two

                exc = tmp; //if we exclude curr time, only one choice, to include last number, there for assign best result from inclduing last number to exc
            }

            return Math.Min(inc, exc);
        }
    }
}
