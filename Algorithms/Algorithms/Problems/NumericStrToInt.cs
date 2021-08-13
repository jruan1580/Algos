using System;
using System.Collections.Generic;
using System.Text;

namespace Strings.Problems
{
    public class NumericStrToInt
    {
        public int ConvertStringToInt(string str)
        {
            var charArr = str.ToCharArray();
            var isNegative = (charArr[0] == '-');
            var startIndex = (charArr[0] == '-' || charArr[0] == '+') ? 1 : 0;

            var result = 0;
            for (int i = startIndex; i < charArr.Length; i++)
            {
                if (!int.TryParse(charArr[i].ToString(), out var res))
                {
                    throw new Exception("Not an integer");
                }

                result = ((result * 10) + res);
            }

            return (isNegative) ? (result * -1) : result;
        }
    }
}
