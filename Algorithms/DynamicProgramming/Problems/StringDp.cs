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
    }
}
