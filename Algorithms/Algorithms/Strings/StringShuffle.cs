using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Strings
{
    public class StringShuffle
    {
        public bool IsShuffle(string str1, string str2, string shuffled)
        {
            //length dont match, not valid shuffle
            if (shuffled.Length != (str1.Length + str2.Length))
            {
                return false;
            }

            var str1Tracker = 0;
            var str2Tracker = 0;

            foreach(var c in shuffled)
            {
                if (str1Tracker < str1.Length && c == str1[str1Tracker])
                {
                    str1Tracker++;
                }
                else if(str2Tracker < str2.Length &&  c == str2[str2Tracker]){
                    str2Tracker++;
                }
                else
                {
                    return false;
                }
            }

            return true;
        }
    }
}
