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
    }
}
