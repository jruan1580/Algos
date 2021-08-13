using System;
using System.Collections.Generic;
using System.Text;

namespace Strings.Problems
{
    public class Palindrome
    {
        public bool IsPalindome(string str)
        {
            var i = 0;
            var j = str.Length - 1;

            while (i < j)
            {
                if (str[i] == str[j])
                {
                    i++;
                    j--;
                    continue;
                }

                return false;
            }

            return true;
        }

        //public string LongestPalindrome(string str)
        //{

        //}
    }
}
