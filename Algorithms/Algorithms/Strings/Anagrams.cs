using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Strings
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
    }
}
