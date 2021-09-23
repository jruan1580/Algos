using System;
using System.Collections.Generic;
using System.Text;

namespace Strings.Problems
{
    public class StringRotation
    {
        public bool IsRotation(string source, string rotatedStr)
        {
            return ((source + source).IndexOf(rotatedStr) > -1);
        }

        public bool IsTwoRotation(string source, string rotatedStr)
        {
            //check if left rotate
            var isLeftRotate = (rotatedStr.Substring(2) + rotatedStr.Substring(0, 2)) == source;

            //check if right rotate
            var isRightRotate = (rotatedStr.Substring(rotatedStr.Length - 2) + rotatedStr.Substring(0, rotatedStr.Length - 2)) == source;

            return isLeftRotate || isRightRotate;
        }
    }
}
