using System;
using System.Collections.Generic;

namespace Algorithms.Strings
{
    public class DuplicateCharacters
    {
        public void PrintDuplicateChars(string str)
        {
            var mapper = new Dictionary<char, int>();

            foreach (var c in str.ToCharArray())
            {
                if (mapper.ContainsKey(c))
                {
                    mapper[c] += 1;
                }
                else
                {
                    mapper.Add(c, 1);
                }
            }

            foreach (var map in mapper)
            {
                if (map.Value <= 1)
                {
                    continue;
                }

                Console.WriteLine(map.Key + ": " + map.Value);
            }
        }

        public string RemoveDuplicates(string str)
        {
            var noDuplicateString = string.Empty;
            var mapper = new Dictionary<char, bool>();

            foreach(var c in str)
            {
                //duplicate found
                if (mapper.ContainsKey(c))
                {
                    continue;
                }

                //not duplicate, add it to new string and add it to tracker mapper
                noDuplicateString += c;
                mapper.Add(c, true);
            }

            return noDuplicateString;
        }

        public char? FindHighestDuplicateChar(string str)
        {
            var tracker = new Dictionary<char, int>();
            foreach (var c in str)
            {
                if (tracker.ContainsKey(c))
                {
                    tracker[c] += 1;
                }
                else
                {
                    tracker.Add(c, 1);
                }
            }

            var max = -1;
            char? currentMaxChar = null;
            foreach(var obj in tracker)
            {
                if (obj.Value <= max)
                {
                    continue;
                }
                
                max = obj.Value;
                currentMaxChar = obj.Key;
            }

            return currentMaxChar;
        }
    }
}
