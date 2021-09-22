using System;
using System.Collections.Generic;
using System.Text;

namespace Strings.Problems
{
    public class StringMath
    {
        public bool IsDivisibleBy7(string numerator)
        {
            if (numerator.Length == 0)
            {
                return false;
            }

            if (numerator.Length == 1)
            {
                if (!int.TryParse(numerator[0].ToString(), out var val))
                {
                    return false;
                }

                return (val % 7 == 0);
            }

            var remainder = 0;
            var currNumber = string.Empty;
            var nextNum = 0;

            for (var i = 0; i < numerator.Length; i++)
            {
                if (string.IsNullOrEmpty(currNumber))
                {
                    currNumber = numerator[i].ToString();
                }                

                //not a number
                if (!int.TryParse(currNumber, out var num))
                {
                    return false;
                }

                if (num < 7)
                {
                    //no other numbers
                    if (i + 1 >= numerator.Length)
                    {
                        remainder = num;
                        break;
                    }

                    if (!int.TryParse(numerator[i + 1].ToString(), out nextNum))
                    {
                        return false;
                    }

                    currNumber = ((num * 10) + nextNum).ToString();
                    continue;
                }

                remainder = num % 7;

                //no more next numbers
                if (i + 1 >= numerator.Length)
                {
                    break;
                }

                if (!int.TryParse(numerator[i + 1].ToString(), out nextNum))
                {
                    return false;
                }

                currNumber = (remainder == 0) ? numerator[i + 1].ToString() : ((remainder * 10) + nextNum).ToString();
            }

            return remainder == 0;
        }
    }
}