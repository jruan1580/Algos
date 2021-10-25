using DynamicProgramming.Problems;
using System;

namespace DynamicProgramming
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var maxAndMin = new MinAndMax();
            Console.WriteLine(maxAndMin.MaxProductByCut(10));
        }
    }
}
