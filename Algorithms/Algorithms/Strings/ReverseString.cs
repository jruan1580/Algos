using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Strings
{
    public class ReverseString
    {
        public string ReverseStrIteratively(string str)
        {
            if (str.Length == 1)
            {
                return str;
            }

            var start = 0;
            var end = str.Length - 1;

            var arr = str.ToCharArray();
            while(start < end)
            {
                var temp = arr[start];
                arr[start] = arr[end];
                arr[end] = temp;
                start++;
                end--;
            }

            return new string(arr);
        }

        public string ReverseStrRecursively(string str)
        {
            if (str.Length == 1)
            {
                return str;
            }

            var firstChar = str[0];
            return ReverseStrRecursively(str.Substring(1)) + firstChar;
        }
    }
}
