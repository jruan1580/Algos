using System;


namespace Strings.Problems
{
    public class Pattern
    {
        public void PrintPatternKMP(string str, string pattern)
        {
            var kmp = KmpArray(pattern);
            var patternIndx = 0;
            var i = 0;

            while (i < str.Length)
            {
                if (str[i] == pattern[patternIndx])
                {                    
                    patternIndx++;
                    i++;
                    if (patternIndx == pattern.Length)
                    {
                        Console.WriteLine($"Found index at:{i - patternIndx}");
                        patternIndx = kmp[patternIndx - 1];
                    }
                }
                else
                {
                    if (patternIndx > 0)
                    {
                        patternIndx = kmp[patternIndx - 1];
                    }
                    else
                    {
                        i++;
                    }
                }            
            }           
        }
        public void PrintPatternRabinKarp(string str, string pattern)
        {
            var prime = 3;
            var hashForPattern = 0;
            var firstThreeStrHash = 0;         

            for(var i = 0; i < pattern.Length; i++)
            {
                hashForPattern += (pattern[i] * ((int)Math.Pow(prime, i)));
                firstThreeStrHash += (str[i] * ((int)Math.Pow(prime, i)));
            }

            var start = 0;
            for (var i = pattern.Length; i <= str.Length; i++)
            {
                if (hashForPattern == firstThreeStrHash)
                {
                    //check characters to pattern
                    int j;
                    for(j = 0; j < pattern.Length; j++)
                    {
                        if (str[j + start] != pattern[j])
                        {
                            break;
                        }
                    }

                    if (j == pattern.Length)
                    {
                        Console.WriteLine($"Index was found {start}");
                    }
                }

                //no more to slide
                if (i == str.Length)
                {
                    break;
                }

                //slide the window                
                var removeFirstResult = ((firstThreeStrHash - str[start]) / prime);
                firstThreeStrHash = removeFirstResult + (str[i] * (int)Math.Pow(prime, pattern.Length - 1));
                start++;
            }
        }

        private int[] KmpArray(string str)
        {
            var kmp = new int[str.Length];

            kmp[0] = 0;
            var i = 0;
            var j = 1;

            while (j < str.Length)
            {
                if (str[i] == str[j])
                {
                    kmp[j] = 1 + i;
                    i++;
                    j++;
                }
                else
                {
                    if (i > 0)
                    {
                        i = kmp[i - 1];
                    }
                    else
                    {
                        kmp[j] = 0;
                        j++;
                    }
                }
            }

            return kmp;
        }
    }
}
