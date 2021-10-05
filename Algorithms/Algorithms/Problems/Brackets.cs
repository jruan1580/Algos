using System;
using System.Collections.Generic;
using System.Text;

namespace Strings.Problems
{
    public class Brackets
    {
        public bool EqualBrackets(string brackets)
        {
            var stack = new Stack<char>();

            foreach(var bracket in brackets.ToCharArray())
            {
                if (stack.Count == 0 || bracket == '{') 
                {
                    stack.Push(bracket);
                    continue;
                }

                stack.Pop();
            }

            return stack.Count == 0;
        }

        public int LongestValidParan(string strOfParan)
        {
            var stack = new Stack<int>();

            stack.Push(-1);
            var maxValidLen = 0;

            for (var i = 0; i < strOfParan.Length; i++)
            {
                if (strOfParan[i] == '(')
                {
                    stack.Push(i);
                }
                else
                {
                    stack.Pop();
                    if (stack.Count == 0)
                    {
                        stack.Push(i);
                    }
                    else
                    {
                        maxValidLen = Math.Max(maxValidLen, i - stack.Peek());
                    }
                }
            }

            return maxValidLen;
        }
    }
}
