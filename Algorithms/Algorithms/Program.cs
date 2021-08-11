using Algorithms.Strings;
using System;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //easy
            var anagram = new Anagrams();
            Console.WriteLine(anagram.IsAnagram("army", "mary"));
            Console.WriteLine(anagram.IsAnagramBySort("army", "mary"));
            Console.WriteLine(anagram.IsAnagram("asgf", "as"));
            Console.WriteLine(anagram.IsAnagramBySort("asgf", "as"));
            Console.WriteLine(anagram.IsAnagram("arm", "maa"));
            Console.WriteLine(anagram.IsAnagramBySort("arm", "maa"));

            //easy
            Console.WriteLine("----------------------------------------");
            var nonRepeatChar = new FirstNonRepeatChar();
            Console.WriteLine(nonRepeatChar.FirstNonRepeatingChar("Morning"));
            Console.WriteLine(nonRepeatChar.FirstNonRepeatingChar("aaabbbbc"));
            try
            {
                Console.WriteLine(nonRepeatChar.FirstNonRepeatingChar("aa"));
            }
            catch(Exception)
            {
                Console.WriteLine("No repeating chars in aa");
            }

            //easy
            Console.WriteLine("----------------------------------------");
            var reverseStr = new ReverseString();
            Console.WriteLine(reverseStr.ReverseStrIteratively("a"));
            Console.WriteLine(reverseStr.ReverseStrIteratively("apple"));
            Console.WriteLine(reverseStr.ReverseStrRecursively("a"));
            Console.WriteLine(reverseStr.ReverseStrRecursively("apple"));
            Console.ReadLine();
        }
    }
}
