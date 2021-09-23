using System;
using System.Collections.Generic;
using System.Text;

namespace Strings.Problems
{
    public class Anagrams
    {
        public bool IsAnagram(string input1, string input2)
        {
            if (input1.Length != input2.Length)
            {
                return false;
            }

            var mapper = new Dictionary<char, int>();            
            foreach (char c in input1.ToCharArray())
            {
                if (mapper.ContainsKey(c))
                {
                    mapper[c] += 1;
                }
                else
                {
                    mapper.Add(c, 1);
                }
            }

            foreach(var c in input2.ToCharArray())
            {
                if (mapper.ContainsKey(c))
                {
                    mapper[c] -= 1;
                }
                //doesnt contain letter, not anagram
                else
                {
                    return false;
                }
            }

            foreach (var map in mapper)
            {
                //0 is good. same numbers of the letter in both strings
                if (map.Value == 0)
                {
                    continue;
                }

                return false;
            }

            return true;
        }

        public bool IsAnagramBySort(string input1, string input2)
        {
            if (input1.Length != input2.Length)
            {
                return false;
            }

            var input1Arr = input1.ToCharArray();
            var input2Arr = input2.ToCharArray();

            Array.Sort(input1Arr);
            Array.Sort(input2Arr);

            for (var i = 0; i < input1Arr.Length; i++)
            {
                if (input1Arr[i] == input2Arr[i])
                {
                    continue;
                }

                return false;
            }

            return true;
        }

        public bool IsKAnagram(string str1, string str2, int k)
        {
            if (str1.Length != str2.Length)
            {
                return false;
            }

            var tracker = new Dictionary<char, int>();

            var charArr1 = str1.ToCharArray();
            foreach(var c in charArr1)
            {
                if (tracker.ContainsKey(c))
                {
                    tracker[c] += 1;
                }
                else
                {
                    tracker.Add(c, 1);
                }
            }

            var charArr2 = str2.ToCharArray();
            //remove chars from tracker
            foreach(var c in charArr2)
            {
                if (!tracker.ContainsKey(c))
                {
                    continue;
                }

                tracker[c] -= 1;
            }

            var numOfCharsRemaining = 0; //num of chars not accounted for in str1 after removing similar chars from str2
            foreach (var map in tracker)
            {
                if (map.Value > 0)
                {
                    numOfCharsRemaining += map.Value;
                }
            }

            return numOfCharsRemaining <= k;
        }
    }
}
