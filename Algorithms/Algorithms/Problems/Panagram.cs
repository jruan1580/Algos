using System;
using System.Collections.Generic;
using System.Text;

namespace Strings.Problems
{
    public class Panagram
    {
        public bool IsPanagram(string sentence)
        {
            var tracker = new bool[26];
            sentence = sentence.ToLower();

            foreach(var c in sentence.ToCharArray())
            {                
                if ('a' <= c && c <= 'z')
                {
                    tracker[c - 'a'] = true;
                }
            }

            foreach(var b in tracker)
            {
                if (!b)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
