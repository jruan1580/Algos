using System;
using System.Collections.Generic;
using System.Text;

namespace Strings.Problems
{
    public class ReplaceCharacterInString
    {
        public string ReplaceCharInStrWithTarget(string src, char target, string replacement)
        {
            //find number of occurences of target char first
            var occurences = 0;
            foreach (char c in src)
            {
                if (c != target)
                {
                    continue;
                }

                occurences++;
            }

            var newStrArr = new char[src.Length + ((replacement.Length - 1) * occurences)];
            var currIndex = 0;
            foreach(var c in src)
            {
                if (c != target)
                {
                    newStrArr[currIndex] = c;
                    currIndex++;
                    continue;
                }

                for(int i = 0; i < replacement.Length; i++)
                {
                    newStrArr[currIndex] = replacement[i];
                    currIndex++;
                }
            }

            return new string(newStrArr);
        }
    }
}
