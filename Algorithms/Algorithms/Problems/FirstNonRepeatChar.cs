using System;
using System.Collections.Generic;
using System.Text;

namespace Strings.Problems
{
    public class FirstNonRepeatChar
    {
        public char FirstNonRepeatingChar(string str)
        {
            var mapper = new Dictionary<char, int>();
            foreach (var c in str.ToCharArray())
            {
                if (!mapper.ContainsKey(c))
                {
                    mapper.Add(c, 1);
                }
                else
                {
                    mapper[c] += 1;
                }
            }

            foreach(var map in mapper)
            {
                if (map.Value != 1)
                {
                    continue;
                }

                return map.Key;
            }

            throw new Exception("Unable to find nonreapting char");
        }
    }
}
