using System;
using System.Collections.Generic;
using System.Text;

namespace Strings.Problems
{
    public class CandyCrush
    {
        public string RestrictiveCandyCrush(string str, int k)
        {
            if (k == 1)
            {
                return string.Empty;
            }

            var stack = new Stack<char>();
            var tmpStack = new Stack<char>();

            foreach(var c in str)
            {
                if (stack.Count == 0 || stack.Peek() != c)
                {
                    stack.Push(c);
                    continue;
                }
                             
                stack.Push(c);
                var numOfOccurrencesSoFar = 0;
                while(numOfOccurrencesSoFar < k && stack.Count > 0 && stack.Peek() == c)
                {
                    tmpStack.Push(stack.Pop());
                    numOfOccurrencesSoFar++;
                }

                //same num of occurrences as k, so got k consecutive same character
                if (numOfOccurrencesSoFar == k)
                {
                    tmpStack.Clear();
                    continue;
                }

                //less than k count of characters, add everything back to original stack
                if (numOfOccurrencesSoFar < k)
                {
                    while(tmpStack.Count > 0)
                    {
                        stack.Push(tmpStack.Pop());
                    }
                }
                else
                {
                    //add back the excess chars back to original stack
                    var excessCharCnt = numOfOccurrencesSoFar - k;
                    var i = 0;
                    while(i < excessCharCnt)
                    {
                        stack.Push(c);
                        i++;
                    }

                    tmpStack.Clear();
                }                
            }

            var result = string.Empty;
            while(stack.Count > 0)
            {
                result = stack.Pop() + result;
            }

            return result;
        }
    }
}
