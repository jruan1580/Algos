using System;
using System.Collections.Generic;
using System.Text;

namespace Strings.Problems
{
    public class ClosestString
    {
        public int ClosestDistanceBetweenWords(string sentence, string word1, string word2)
        {
            if (word1.Equals(word2))
            {
                return 0;
            }

            var min_dist = int.MaxValue;
            var words = sentence.Split(' ');
            //find first occurrence of either word
            var occurrence = 0;
            for (var i = 0; i < words.Length; i++)
            {
                if (!words[i].Equals(word1) && !words[i].Equals(word2))
                {
                    continue;
                }

                occurrence = i;
                break;
            }

            var index = occurrence + 1;
            //traverse remaining sentence after first occurrence
            while(index < words.Length)
            {
                //found occurrence of word that matches word1 or word2
                if (words[index].Equals(word1) || words[index].Equals(word2))
                {
                    //does not equal to first occurrence, update min dist
                    if (words[index].Equals(words[occurrence]))
                    {
                        min_dist = Math.Min(min_dist, index - occurrence - 1);
                        occurrence = index;
                    }
                    else
                    {
                        //same word, update occurence to this
                        occurrence = index;
                    }
                }                             
            }

            return min_dist;
        }
    }
}
