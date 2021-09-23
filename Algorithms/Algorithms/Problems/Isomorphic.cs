using System;
using System.Collections.Generic;
using System.Text;

namespace Strings.Problems
{
    public class Isomorphic
    {
        public bool IsIsomorphic(string str1, string str2)
        {
            if (str1.Length != str2.Length)
            {
                return false;
            }

            var mapper = new Dictionary<char, char>();
            var str1CharArr = str1.ToCharArray();
            var str2CharArr = str2.ToCharArray();

            mapper.Add(str1CharArr[0], str2CharArr[0]);
            var currChar = str1CharArr[0];

            for(var i = 1; i < str1.Length; i++)
            {
                var mapChar = mapper[currChar];
                //check to see if second str has same character to curr char mapping 
                if (str1CharArr[i] == currChar)
                {                    
                    //not equal to the mapped char, return false
                    if (str2CharArr[i] != mapChar)
                    {
                        return false;
                    }
                }
                //curr char is diff than now
                else
                {
                    //since it is diff, need to make sure the char in str2 is also diff.
                    //second char equal to old map char, return false
                    if (str2CharArr[i] == mapChar)
                    {
                        return false;
                    }

                    //str2 char is also diff, add it to mapping and update curr char
                    mapper.Add(str1CharArr[i], str2CharArr[i]);
                    currChar = str2CharArr[i];
                }
            }
            return true;
        }
    }
}
