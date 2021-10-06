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

        public int LongestPalindromeSubSequence(string str)
        {
            var lps = new int[str.Length, str.Length];

            //if just character itself, lps is 1
            for (var i = 0; i < str.Length; i++)
            {
                lps[i, i] = 1;
            }

            //fill up top diagonal half
            //pl is current palindrome length, starting at 2 since we took care of 1 above
            for (var pl = 2; pl <= str.Length; pl++)
            {
                for(var i = 0; i < str.Length - pl + 1; i++)
                {
                    var j = i + pl - 1;
                    if (pl == 2 && str[i] == str[j])
                    {
                        lps[i, j] = 2; //palindrome of length 2 equals meaning length is 2
                    }
                    else if(str[i] == str[j])
                    {
                        lps[i, j] = 2 + lps[i + 1, j - 1];
                    }
                    else
                    {
                        lps[i, j] = Math.Max(lps[i, j - 1], lps[i + 1, j]);
                    }
                }
            }

            return lps[0, str.Length - 1];
        }

        /// <summary>
        /// same as longest subseq
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string LongestPalindromeSubstring(string str)
        {
            var lps = new int[str.Length, str.Length];

            for (var i = 0; i < str.Length; i++)
            {
                lps[i, i] = 1; //char by itself is a pal with length 1
            }

            for(var pl = 2; pl <= str.Length; pl++)
            {
                for(var row = 0; row < str.Length - pl + 1; row++)
                {
                    var col = row + pl - 1;
                    if (pl == 2 && str[row] == str[col])
                    {
                        lps[row, col] = 2;
                    }
                    else if(str[row] == str[col])
                    {
                        if (lps[row + 1, col - 1] == 0)
                        {
                            lps[row, col] = 0;
                        }
                        else
                        {
                            lps[row, col] = 2 + lps[row + 1, col - 1];
                        }                        
                    }
                    else
                    {
                        lps[row, col] = 0;
                    }
                }
            }

            var maxLen = 0;
            var maxRow = -1;
            var maxCol = -1;

            for(var row = 0; row < str.Length; row++)
            {
                for(var col = row; col < str.Length; col++)
                {
                    if (lps[row, col] > maxLen)
                    {
                        maxLen = lps[row, col];
                        maxRow = row;
                        maxCol = col;
                    }
                }
            }

            return str.Substring(maxRow, (maxCol - maxRow + 1));
        }

        public int MinimumDeletionToFormPalindrome(string str)
        {
            var lpsLen = LongestPalindromeSubSequence(str);

            return str.Length - lpsLen;
        }

        public int LongestCommonSubsequence(string str1, string str2)
        {
            var lcs = new int[str1.Length + 1, str2.Length + 1];

            for(var i = 0; i < str1.Length + 1; i++)
            {
                lcs[i, 0] = 0;
                lcs[0, i] = 0;
            }

            for(var row = 1; row < lcs.GetLength(0); row++)
            {
                for(var col = 1; col < lcs.GetLength(1); col++)
                {
                    if (str1[row - 1] == str2[col - 1])
                    {
                        lcs[row, col] = 1 + lcs[row - 1, col - 1]; 
                    }
                    else
                    {
                        lcs[row, col] = Math.Max(lcs[row - 1, col], lcs[row, col - 1]);
                    }
                }
            }

            return lcs[str1.Length, str2.Length];
        }

        public int MinimumInsertionToFormPalindrome(string str)
        {
            var reverseArr = str.ToCharArray();

            Reverse(reverseArr, 0, str.Length - 1);

            var lcsLen = LongestCommonSubsequence(str, new string(reverseArr));

            return str.Length - lcsLen;
        }

        public int LongestPalindromicSubWithRearrangement(string str)
        {
            str = str.ToLower(); 
            var charFrequence = new int[26];
            Array.Fill(charFrequence, 0);

            for(var i = 0; i < str.Length; i++)
            {
                charFrequence[str[i] - 'a'] += 1;
            }

            //consider entire string first for that is the longest
            for(var i = str.Length - 1; i >= 0; i--)
            {
                var evenCount = 0;
                var oddCount = 0;

                for (var j = 0; j < 26; j++)
                {
                    //find out even/odd letter count
                    if (charFrequence[j] % 2 == 0)
                    {
                        evenCount++;
                    }
                    else
                    {
                        oddCount++;
                    }                   
                }

                //check to see if its a palindrome by satisfying two rules:
                //1. all evens and 1 odd
                //2. all evens
                if ((oddCount == 1 && (evenCount == 0 || evenCount > 0)) || (oddCount == 0 && evenCount > 0))
                {
                    //since we are starting at the very longest a string can be, if we find something, return length immediatley for that can only be the longest
                    return (i - 0) + 1;                      
                }

                //decrease count of the current character
                charFrequence[str[i] - 'a'] -= 1;
            }

            return -1; //cannot find 
        }

        public int DistinctPalindromicSubstrings(string str)
        {
            var dp = new int[str.Length, str.Length];
            var distinct = new HashSet<string>();

            //take care of individual char
            for(var i = 0; i < str.Length; i++)
            {
                dp[i, i] = 1;
                //individual chars are palindromes
                if (!distinct.Contains(str[i].ToString()))
                {
                    distinct.Add(str[i].ToString());
                }
            }

            //take care of pal starting with length 2
            for(var pl = 2; pl <= str.Length; pl++)
            {
                for(var row = 0; row < str.Length - pl + 1; row++)
                {
                    var col = row + pl - 1;
                    if (pl == 2 && str[row] == str[col])
                    {
                        dp[row, col] = 2;
                        if (!distinct.Contains(str.Substring(row, pl)))
                        {
                            distinct.Add(str.Substring(row, pl));
                        }
                    }
                    else if (str[row] == str[col])
                    {
                        if (dp[row + 1, col - 1] == 0)
                        {
                            dp[row, col] = 0;
                        }
                        else
                        {
                            dp[row, col] = 2 + dp[row + 1, col - 1];
                            if (!distinct.Contains(str.Substring(row, pl)))
                            {
                                distinct.Add(str.Substring(row, pl));
                            }
                        }
                    }
                    else
                    {
                        dp[row, col] = 0;
                    }
                }
            }

            return distinct.Count;
        }

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
