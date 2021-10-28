using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DynamicProgramming.Problems
{
    public class Chaining
    {
        public int LongestChain(Pair [] pairs)
        {
            var sortedPairs = pairs.OrderBy(p => p.A).ToArray();
            var dp = new int[pairs.Length];

            Array.Fill(dp, 1);

            for(var i = 1; i < pairs.Length; i++)
            {
                for(var j = 0; j < i; j++)
                {
                    if (sortedPairs[i].A > sortedPairs[j].B)
                    {
                        dp[i] = Math.Max(dp[i], 1 + dp[j]);
                    }
                }
            }

            var maxLen = int.MinValue;
            foreach(var len in dp)
            {
                if (len > maxLen)
                {
                    maxLen = len;
                }
            }

            return maxLen;
        }
    }

    public class Pair
    {
        public Pair(int a, int b)
        {
            A = a;
            B = b;
        }
        public int A { get; set; }

        public int B { get; set; }
    }
}
