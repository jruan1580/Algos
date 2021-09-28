using System;
using System.Collections.Generic;
using System.Text;

namespace Strings.Problems
{
    public class Substring
    {
        public int MinTimeRepeatToFormSub(string str1, string str2)
        {
            var repeatStr = str1;
            var timesRepeated = 0;

            while (repeatStr.Length < str2.Length)
            {
                repeatStr += str1;
                timesRepeated++;
            }

            if (repeatStr.IndexOf(str2) >= 0)
            {
                return timesRepeated;
            }

            repeatStr += str1;
            timesRepeated += 1;

            if (repeatStr.IndexOf(str2) >= 0)
            {
                return timesRepeated;
            }

            return -1;
        }

        public int LongestSubstringWithKUnique(string str, int k)
        {
            var count = new int[26]; //26 letters
            str = str.ToLower();
            var arr = str.ToCharArray();

            Array.Fill(count, 0);
            var start = 0;
            var end = 0;
            var maxLength = int.MinValue;
            for(var i = 0; i < arr.Length; i++)
            {
                count[arr[i] - 'a'] += 1;
                end++;

                while(NumberOfUniqueChars(count) > k)
                {
                    count[arr[start] - 'a'] -= 1;
                    start++;
                }

                //get maxLength
                if (NumberOfUniqueChars(count) == k)
                {
                    maxLength = Math.Max(maxLength, end - start);
                }
            }

            return maxLength;
        }

        public int LongestSubstringWithoutRepeatingChar(string str)
        {
            var count = new int[26];
            str = str.ToLower();
            var arr = str.ToCharArray();

            Array.Fill(count, 0);
            var start = 0;
            var end = 0;
            var max = int.MinValue;

            for(var i = 0; i < arr.Length; i++)
            {
                count[arr[i] - 'a'] += 1;
                end++;

                while (HasRepeatingChars(count))
                {
                    count[arr[start] - 'a'] -= 1;
                    start++;
                }

                if (!HasRepeatingChars(count))
                {
                    max = Math.Max(max, end - start);
                }
            }

            return max;
        }

        public int SmallestSubstringContainingPattern(string str, string pattern)
        {
            var pat_map = new int[26];
            var str_map = new int[26];

            var patternArr = pattern.ToLower().ToCharArray();            

            Array.Fill(pat_map, 0);
            foreach(var c in patternArr)
            {
                pat_map[c - 'a'] += 1;
            }

            Array.Fill(str_map, 0);
            var strArr = str.ToLower().ToCharArray();
            var count = 0;
            var start = 0;
            var end = 0;
            var minSubstr = int.MaxValue;

            for(var i = 0; i < strArr.Length; i++)
            {
                str_map[strArr[i] - 'a'] += 1;
                end++;

                if (str_map[strArr[i] - 'a'] <= pat_map[strArr[i] - 'a'])
                {
                    count += 1;
                }

                //found same pattern chars in str 
                if (count == pattern.Length)
                {
                    //minimize window as much as possible now
                    while(str_map[strArr[start] - 'a'] > pat_map[strArr[start] - 'a'] || pat_map[strArr[start] - 'a'] == 0)
                    {
                        if (str_map[strArr[start] - 'a'] > pat_map[strArr[start] - 'a'])
                        {
                            str_map[strArr[start] - 'a'] -= 1;
                        }

                        start++;
                    }

                    minSubstr = Math.Min(minSubstr, end - start);
                }
            }

            return minSubstr;
        }

        public int SubstringWithLengthKAndKDistinctChars(string str, int k)
        {
            var map = new Dictionary<char, int>();
            for (var i = 0; i < k; i++)
            {
                if (!map.ContainsKey(str[i]))
                {
                    map.Add(str[i], 1);
                }
                else
                {
                    map[str[i]] += 1;
                }
            }

            var answer = 0;
            if (map.Count == k)
            {
                answer++;
            }

            var start = 0;
            for (var i = k; i < str.Length; i++)
            {
                if (!map.ContainsKey(str[i]))
                {
                    map.Add(str[i], 1);
                }
                else
                {
                    map[str[i]] += 1;
                }

                //remove the first letter to ensure length is still k
                map[str[start]] -= 1;
                if (map[str[start]] == 0)
                {
                    //remove this key if no more
                    map.Remove(str[start]);
                }

                start++;

                //check to see if still has k unique chars
                if (map.Count == k)
                {
                    answer++;
                }
            }

            return answer;

        }

        public int SubstringWithKDistinctChars(string str, int k)
        {
            var map = new Dictionary<char, int>();
            var answer = 0;

            for (var i = 0; i < str.Length; i++)
            {
                map.Clear();

                for (var j = i; j < str.Length; j++)
                {
                    if (!map.ContainsKey(str[j]))
                    {
                        map.Add(str[j], 1);
                    }
                    else
                    {
                        map[str[j]] += 1;
                    }

                    if (map.Count == k)
                    {
                        answer++;
                    }

                    if (map.Count > k)
                    {
                        break;
                    }
                }
            }
          
            return answer;
        }

        private int NumberOfUniqueChars(int[] count)
        {
            var numOfUniqueChars = 0;
            foreach (var c in count)
            {
                if (c > 0)
                {
                    numOfUniqueChars++;
                }
            }

            return numOfUniqueChars;
        }

        private bool HasRepeatingChars(int [] count)
        {
            foreach(var c in count)
            {
                if (c > 1)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
