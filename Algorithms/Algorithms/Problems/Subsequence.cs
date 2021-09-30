using System;
using System.Collections.Generic;
using System.Text;

namespace Strings.Problems
{
    public class Subsequence
    {
        public int NumberOfUniqueSubsequence(string str)
        {
            var dp = new int[str.Length + 1];
            dp[0] = 1; //1 subsequence at empty string

            var last = new int[26]; //tracks the last occurence of the character
            Array.Fill(last, -1);

            for (var i = 1; i <= str.Length; i++)
            {
                //check if we've seen this char
                if (last[str[i - 1] - 'a'] != -1)
                {
                    var lastIndex = last[str[i - 1] - 'a'];
                    dp[i] = (2 * dp[i - 1]) - dp[lastIndex];
                }
                else
                {
                    dp[i] = 2 * dp[i - 1];
                }

                last[str[i - 1] - 'a'] = i - 1;
            }

            return dp[str.Length];
        }        
    }
}
