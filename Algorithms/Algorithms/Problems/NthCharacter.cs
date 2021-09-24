using System;
using System.Collections.Generic;
using System.Text;

namespace Strings.Problems
{
    public class NthCharacter
    {
        public int FindIndexOfNthChar(string str, char c, int n)
        {
            var timesEncountered = 0;
            for (var i = 0; i < str.Length; i++)
            {
                if (str[i] != c)
                {
                    continue;
                }

                timesEncountered++;
                if (timesEncountered == n)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
