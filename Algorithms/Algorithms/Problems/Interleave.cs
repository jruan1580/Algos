using System;
using System.Collections.Generic;
using System.Text;

namespace Strings.Problems
{
    public class Interleave
    {
        //public bool AreInterleaveStringsRecursively(string str1, string str2, string str3)
        //{
        //    if (str1 == string.Empty && str2 == string.Empty && str3 == string.Empty)
        //    {
        //        return true;
        //    }

        //    if (str1 == string.Empty && (str2 != string.Empty || str3 != string.Empty))
        //    {
        //        return false;
        //    }

        //    return ((str1[0] == str2[0]) && AreInterleaveStringsRecursively(str1.Substring(1), str2.Substring(1), str3))
        //                || ((str1[0] == str3[0]) && AreInterleaveStringsRecursively(str1.Substring(1), str2, str3.Substring(1)));
        //}

        public bool AreInterleaveDp(string str1, string str2, string str3)
        {
            if (str1.Length != (str2.Length + str3.Length))
            {
                return false;
            }

            var dp = new bool[str2.Length + 1, str3.Length + 1];
            dp[0, 0] = true;

            //fill out first row
            for (var i = 1; i <= str3.Length; i++)
            {
                //compare each character of str3 to str1
                if (str1[i - 1] == str3[i - 1])
                {
                    dp[0, i] = dp[0, i - 1];
                }
                else
                {
                    dp[0, i] = false;
                }
            }

            //fill out first column
            for (var j = 1; j <= str2.Length; j++)
            {
                //compare each char in str1 and str2
                if (str2[j - 1] == str1[j - 1])
                {
                    dp[j, 0] = dp[j - 1, 0];
                }
                else
                {
                    dp[j, 0] = false;
                }
            }

            //fill out the rest
            for (var row = 1; row <= str2.Length; row++)
            {
                for (var col = 1; col <= str3.Length; col++)
                {
                    //matches with str2 and not str3
                    if (str1[row + col - 1] == str2[row - 1] && str1[row + col - 1] != str3[col - 1])
                    {
                        dp[row, col] = dp[row - 1, col];
                    }
                    //matches with str3 and not str2
                    else if (str1[row + col - 1] == str3[col - 1] && str1[row + col - 1] != str2[row - 1])
                    {
                        dp[row, col] = dp[row, col - 1];
                    }
                    //matches with both
                    else if (str1[row + col - 1] == str3[col - 1] && str1[row + col - 1] == str2[row - 1])
                    {
                        dp[row, col] = (dp[row - 1, col]) || (dp[row, col - 1]);
                    }
                    //does not match at all
                    else
                    {
                        dp[row, col] = false;
                    }
                }
            }

            return dp[str2.Length, str3.Length];
        }
    }
}
