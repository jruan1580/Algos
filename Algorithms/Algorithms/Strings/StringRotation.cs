using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Strings
{
    public class StringRotation
    {
        public bool IsRotation(string source, string rotatedStr)
        {
            return ((source + source).IndexOf(rotatedStr) > -1);
        }
    }
}
