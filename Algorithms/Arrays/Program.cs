using Arrays.Problems;
using System;

namespace Arrays
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var wave = new Wave();
            var arr = new int[8] { 10, 22, 9, 33, 49, 50, 31, 60 };
            Console.WriteLine(wave.LongestAlternatingSubsequence(arr, arr.Length));
        }
    }
}
