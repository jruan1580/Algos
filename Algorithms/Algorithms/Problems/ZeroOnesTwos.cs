using System;
using System.Collections.Generic;
using System.Text;

namespace Strings.Problems
{
    public class ZeroOnesTwos
    {
        public int EqualZerosOnesTwos(string str)
        {
            var dict = new Dictionary<string, int>();

            var zc = 0;
            var oc = 0;
            var tc = 0;

            var ans = 0;

            dict.Add("0*0", 1);
            foreach(var c in str.ToCharArray())
            {
                if (c == '0')
                {
                    zc += 1;
                }
                else if (c == '1')
                {
                    oc += 1;
                }
                else
                {
                    tc += 1;
                }

                var key = (zc - oc) + "*" + (zc - tc);
                if (!dict.ContainsKey(key))
                {
                    dict.Add(key, 1);
                }
                else
                {
                    ans += dict[key];
                    dict[key] += 1;
                }
            }

            return ans;
        }
    }
}
