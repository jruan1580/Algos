using Strings.Problems;
using System;
using System.Collections.Generic;

namespace Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            ////easy
            //var anagram = new Anagrams();
            //anagram.PrintAnagramsTogether(new string[] { "cat", "dog", "tac", "god", "act" });
            //Console.WriteLine(anagram.IsKAnagram("fodr", "gork", 2));
            //Console.WriteLine(anagram.IsKAnagram("anagram", "grammar", 3));
            //Console.WriteLine(anagram.IsKAnagram("geeks", "eggkf", 1));
            //Console.WriteLine(anagram.IsKAnagram("geeks", "eggkf", 2));
            //Console.WriteLine(anagram.IsAnagram("army", "mary"));
            //Console.WriteLine(anagram.IsAnagramBySort("army", "mary"));
            //Console.WriteLine(anagram.IsAnagram("asgf", "as"));
            //Console.WriteLine(anagram.IsAnagramBySort("asgf", "as"));
            //Console.WriteLine(anagram.IsAnagram("arm", "maa"));
            //Console.WriteLine(anagram.IsAnagramBySort("arm", "maa"));

            ////easy
            //Console.WriteLine("----------------------------------------");
            //var nonRepeatChar = new FirstNonRepeatChar();
            //Console.WriteLine(nonRepeatChar.FirstNonRepeatingChar("Morning"));
            //Console.WriteLine(nonRepeatChar.FirstNonRepeatingChar("aaabbbbc"));
            //try
            //{
            //    Console.WriteLine(nonRepeatChar.FirstNonRepeatingChar("aa"));
            //}
            //catch(Exception)
            //{
            //    Console.WriteLine("No repeating chars in aa");
            //}

            ////easy
            //Console.WriteLine("----------------------------------------");
            //var reverseStr = new ReverseString();
            //Console.WriteLine(reverseStr.ReverseStrIteratively("a"));
            //Console.WriteLine(reverseStr.ReverseStrIteratively("apple"));
            //Console.WriteLine(reverseStr.ReverseStrRecursively("a"));
            //Console.WriteLine(reverseStr.ReverseStrRecursively("apple"));

            ////easy
            //Console.WriteLine("----------------------------------------");
            //var dupicateChars = new DuplicateCharacters();
            //dupicateChars.PrintDuplicateChars("aab");
            //dupicateChars.PrintDuplicateChars("aabbcc");
            //Console.WriteLine(dupicateChars.RemoveDuplicates("aab"));
            //Console.WriteLine(dupicateChars.RemoveDuplicates("bananas"));
            //Console.WriteLine(dupicateChars.FindHighestDuplicateChar("aaaaaabbc"));
            //Console.WriteLine(dupicateChars.FindHighestDuplicateChar("abc"));

            ////easy
            //Console.WriteLine("----------------------------------------");
            //var strToInt = new NumericStrToInt();
            //Console.WriteLine(strToInt.ConvertStringToInt("123"));
            //Console.WriteLine(strToInt.ConvertStringToInt("1"));
            //Console.WriteLine(strToInt.ConvertStringToInt("0"));

            //try
            //{
            //    strToInt.ConvertStringToInt("122a");
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //}

            ////easy but tedious
            //Console.WriteLine("----------------------------------------");
            //var replaceCharInStr = new ReplaceCharacterInString();
            //Console.WriteLine(replaceCharInStr.ReplaceCharInStrWithTarget("this is sparta!!!", ' ', "%20"));
            //Console.WriteLine(replaceCharInStr.ReplaceCharInStrWithTarget("this is sparta!!!", ' ', "|"));

            ////hard
            //Console.WriteLine("----------------------------------------");
            var permute = new Permutation();
            //permute.Permute("abc", string.Empty);
            //permute.Permute("abcd", string.Empty);
            //permute.Permute("aa", string.Empty);
            //permute.DistinctPermute("aa", string.Empty, new Dictionary<string, bool>());
            //permute.DistinctPermute("aba", string.Empty, new Dictionary<string, bool>());
            Console.WriteLine(permute.GetPermutationRank("acb"));
            Console.WriteLine(permute.GetPermutationRank("string"));

            ////easy
            //Console.WriteLine("----------------------------------------");
            //var palindrome = new Palindrome();
            //Console.WriteLine(palindrome.IsPalindome("aba"));
            //Console.WriteLine(palindrome.IsPalindome("radar"));
            //Console.WriteLine(palindrome.IsPalindome("java"));
            //Console.WriteLine(palindrome.IsPalindome("madam"));

            ////easy
            //Console.WriteLine("----------------------------------------");
            //var shuffle = new StringShuffle();
            //Console.WriteLine(shuffle.IsShuffle("abc", "def", "adbecf"));
            //Console.WriteLine(shuffle.IsShuffle("abc", "def", "abcdef"));
            //Console.WriteLine(shuffle.IsShuffle("abc", "def", "abdecf"));
            //Console.WriteLine(shuffle.IsShuffle("abc", "def", "dabecf"));
            //Console.WriteLine(shuffle.IsShuffle("abc", "def", "asg"));
            //Console.WriteLine(shuffle.IsShuffle("abc", "def", "adfcbe"));

            ////easy
            //Console.WriteLine("----------------------------------------");
            //var rotation = new StringRotation();
            //Console.WriteLine(rotation.IsRotation("IndiaUSAEngland", "USAEnglandIndia"));
            //Console.WriteLine(rotation.IsRotation("IndiaUSAEngland", "IndiaEnglandUSA"));
            //Console.WriteLine(rotation.IsTwoRotation("amazon", "azonam"));
            //Console.WriteLine(rotation.IsTwoRotation("amazon", "onamaz"));
            //Console.WriteLine(rotation.IsTwoRotation("amazon", "zonama"));

            //var stringMath = new StringMath();
            //Console.WriteLine(stringMath.IsDivisibleBy7("100000000000"));
            //Console.WriteLine(stringMath.IsDivisibleBy7("214"));

            //var bracket = new Brackets();
            //Console.WriteLine(bracket.EqualBrackets("{}{}{"));
            //Console.WriteLine(bracket.EqualBrackets("{}{}"));

            //var iso = new Isomorphic();

            //Console.WriteLine(iso.IsIsomorphic("aab", "xxy"));
            //Console.WriteLine(iso.IsIsomorphic("aab", "xyz"));

            //var pan = new Panagram();
            //Console.WriteLine(pan.IsPanagram("The quick brown fox jumps over the lazy dog"));
            //Console.WriteLine(pan.IsPanagram("The quick brown fox jumps over the dog"));

            //var zot = new ZeroOnesTwos();
            //Console.WriteLine(zot.EqualZerosOnesTwos("0102010"));
            //Console.WriteLine(zot.EqualZerosOnesTwos("102100211"));
            //Console.ReadLine();

            //var sub = new Substring();
            //Console.WriteLine(sub.MinTimeRepeatToFormSub("abcd", "cdabcdab"));
            //Console.WriteLine(sub.MinTimeRepeatToFormSub("ab", "cab"));
            //Console.WriteLine(sub.LongestSubstringWithKUnique("aabbcc", 1));
            //Console.WriteLine(sub.LongestSubstringWithKUnique("aabbcc", 2));
            //Console.WriteLine(sub.LongestSubstringWithKUnique("aabbcc", 3));
            //Console.WriteLine(sub.LongestSubstringWithKUnique("aabbcc", 4));
            //Console.WriteLine(sub.LongestSubstringWithoutRepeatingChar("ABDEFGABEF"));
            //Console.WriteLine(sub.LongestSubstringWithoutRepeatingChar("BBBB"));
            //Console.WriteLine(sub.LongestSubstringWithoutRepeatingChar("GEEKSFORGEEKS"));

            //Console.WriteLine(sub.SmallestSubstringContainingPattern("thisisateststring", "tist"));
            //Console.WriteLine(sub.SmallestSubstringContainingPattern("geeksforgeeks", "ork"));
            //Console.WriteLine(sub.SubstringWithLengthKAndKDistinctChars("abcc", 2));
            //Console.WriteLine(sub.SubstringWithLengthKAndKDistinctChars("aabab", 3));

            //Console.WriteLine(sub.SubstringWithKDistinctChars("abc", 2));
            //Console.WriteLine(sub.SubstringWithKDistinctChars("aba", 2));
            //Console.WriteLine(sub.SubstringWithKDistinctChars("aa", 1));

            //var nth = new NthCharacter();
            //Console.WriteLine(nth.FindIndexOfNthChar("Geeks", 'e', 2));
            //Console.WriteLine(nth.FindIndexOfNthChar("GFG", 'e', 2));
            //Console.WriteLine(nth.FindIndexOfNthChar("Geeks", 'e', 3));
            //Console.WriteLine(nth.FindIndexOfNthChar("Stir Fry", 'r', 2));

            //var pal = new Palindrome();
            //Console.WriteLine(pal.NextHighestPalindromicNumber("4697557964"));
            //Console.WriteLine(pal.NextHighestPalindromicNumber("543212345"));
        }
    }
}
