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

        public string NextHighestPalindromicNumber(string str)
        {
            if (str.Length < 3)
            {
                return str;
            }

            var charArr = str.ToCharArray();

            var mid = (str.Length / 2) - 1;
            var i = 0;
            //find first number smaller than number to right
            for(i = mid - 1; i >= 0; i--)
            {
                if (charArr[i] < charArr[i + 1])
                {
                    break;
                }
            }

            if (i < 0)
            {
                return str;
            }

            //find next smallest number to right of i
            //num must be bigger than i
            var j = 0;
            var smallestSoFarIndex = i + 1;
            for (j = i + 1; j <= mid; j++)
            {
                if (charArr[j] > charArr[i] && charArr[j] < charArr[smallestSoFarIndex])
                {
                    smallestSoFarIndex = j;
                }
            }

            //swap the two values
            var tmp = charArr[i];
            charArr[i] = charArr[smallestSoFarIndex];
            charArr[smallestSoFarIndex] = tmp;

            //do the same on right side to retain palindrom pattern
            tmp = charArr[charArr.Length - i - 1];
            charArr[charArr.Length - i - 1] = charArr[charArr.Length - smallestSoFarIndex - 1];
            charArr[charArr.Length - smallestSoFarIndex - 1] = tmp;

            //reverse from i + 1 to mid
            Reverse(charArr, i + 1, mid);

            //to retain the palindromic pattern
            if (charArr.Length % 2 == 0)
            {
                Reverse(charArr, mid + 1, charArr.Length - i - 2);
            }
            else
            {
                Reverse(charArr, mid + 2, charArr.Length - i - 2);
            }

            return new string(charArr);
        }

        //public string LongestPalindrome(string str)
        //{

        //}

        private void Reverse(char[] num, int i, int j)
        {
            while (i < j)
            {
                char temp = num[i];
                num[i] = num[j];
                num[j] = temp;
                i++;
                j--;
            }
        }
    }
}
