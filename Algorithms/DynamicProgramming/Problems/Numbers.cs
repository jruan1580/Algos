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
    }
}
