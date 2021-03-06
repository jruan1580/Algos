using System;
using System.Collections.Generic;
using System.Text;

namespace Strings.Problems
{
    public class Prefix
    {
        public string LongestCommonPrefix(string [] strs)
        {
            if (strs.Length == 0)
            {
                return "";
            }

            if (strs.Length == 1)
            {
                return strs[0];
            }

            Array.Sort(strs);

            //sorting should have put the shortest in front and longest str in back
            var firstWord = strs[0];
            var lastWord = strs[strs.Length - 1];

            //find the shortest length in array
            var shortestLen = Math.Min(firstWord.ToCharArray().Length, lastWord.ToCharArray().Length);
            
            var i = 0;
            //find common prefix between first and last element            
            var longestCommonPrefix = "";
            while(i < shortestLen && firstWord[i] == lastWord[i])
            {
                longestCommonPrefix += firstWord[i];
            }

            return longestCommonPrefix;
        }

        public int LongestPrefixSuffix(string str)
        {
            var arr = str.ToCharArray();
            var lps = new int[str.Length];

            lps[0] = 0;
            var i = 0;
            var j = 1;
            while (j < arr.Length)
            {
                if (arr[i] == arr[j])
                {
                    lps[j] = i + 1;
                    i++;
                    j++;
                }
                else
                {
                    if (i > 0)
                    {
                        i = lps[i - 1];
                    }
                    else
                    {
                        lps[j] = 0;
                        j++;
                    }
                }
            }
            int res = lps[arr.Length - 1];

            // Since we are looking for
            // non overlapping parts.
            return (res > arr.Length / 2) ? arr.Length / 2 : res;
        }
    }
}
