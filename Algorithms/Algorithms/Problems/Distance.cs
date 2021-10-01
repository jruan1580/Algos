using System;
using System.Collections.Generic;
using System.Text;

namespace Strings.Problems
{
    public class Distance
    {
        public int MinEditDistance(string str1, string str2)
        {
            var dp = new int[str1.Length + 1, str2.Length + 1];

            dp[0, 0] = 0; //empty string to empty string requires 0 operations
            //fill first row
            for(var i = 1; i <str2.Length; i++)
            {
                dp[0, i] = i; //takes equal number of char count to edit empty stirng to str2
            }

            //fill second row
            for(var i = 1; i < str1.Length; i++)
            {
                dp[i, 0] = i; //takes same count as char to edit empty string to str1
            }

            for(var i = 1; i <= str1.Length; i++)
            {
                for (var j = 1; j <= str2.Length; j++)
                {
                    //look left upper diagonal
                    if (str1[i - 1] == str2[j - 1])
                    {
                        dp[i, j] = dp[i - 1, j - 1];
                    }
                    else
                    {
                        //min of left, upper, and upper left diagonal
                        dp[i, j] = 1 + (Math.Min(Math.Min(dp[i, j - 1], dp[i - 1, j]), dp[i - 1, j - 1]));
                    }
                }
            }

            return dp[str1.Length, str2.Length];
        }
    }
}
