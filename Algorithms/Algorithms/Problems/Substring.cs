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
    }
}
