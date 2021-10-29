using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicProgramming.Problems
{
    public class StringDp
    {
        public int LongestCommonSubstring(string str1, string str2)
        {
            var dp = new int[str1.Length + 1, str2.Length + 1];      
            var result = int.MinValue;
            for(var i = 0; i <= str1.Length; i++)
            {
                for(var j = 0; j < str2.Length; j++)
                {
                    if (i == 0 || j == 0)
                    {
                        dp[i, j] = 0;
                    }
                    else if (str1[i - 1] == str2[j - 1])
                    {
                        dp[i, j] = 1 + dp[i - 1, j - 1];
                        result = Math.Max(result, dp[i, j]);
                    }
                    else
                    {
                        dp[i, j] = 0;
                    }
                }
            }

            return result;
        }

        public int NumberOfSubFormFittingFormatABC(string pattern)
        {
            var aCount = 0;
            var bCount = 0;
            var cCount = 0;

            for(var i = 0; i < pattern.Length; i++)
            {
                if (pattern[i] == 'a')
                {
                    aCount = 1 + (2 * aCount);
                }

                if (pattern[i] == 'b')
                {
                    bCount = aCount + (2 * bCount);
                }

                if (pattern[i] == 'c')
                {
                    cCount = bCount + (2 * cCount);
                }
            }

            return cCount;
        }

        public int PossibleDecoding(string str)
        {
            if (str.Length == 0 || str.Length == 1)
            {
                return 1;
            }

            var dp = new int[str.Length + 1];
            dp[0] = 1;
            dp[1] = 1;

            for(var i = 2; i <= str.Length; i++)
            {
                dp[i] = dp[i - 1]; //take char by itself

                if ((str[i - 2] == '1') || (str[i-2] == '2' && str[i-1] < '7'))
                {
                    dp[i] += dp[i - 2];
                }
            }

            return dp[str.Length];
        }
    }
}
