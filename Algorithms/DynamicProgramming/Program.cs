using DynamicProgramming.Problems;
using System;
using System.Collections.Generic;

namespace DynamicProgramming
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //var maxAndMin = new MinAndMax();
            //var price = new int[] { 3, 5, 8, 9, 10, 17, 17, 20 };
            //Console.WriteLine(maxAndMin.CuttingRod(8, price));

            //var mat = new int[3, 3];
            //mat[0, 0] = 1;
            //mat[0, 1] = 2;
            //mat[0, 2] = 9;
            //mat[1, 0] = 5;
            //mat[1, 1] = 3;
            //mat[1, 2] = 8;
            //mat[2, 0] = 4;
            //mat[2, 1] = 6;
            //mat[2, 2] = 7;

            //var matrix = new MatrixPath();
            //Console.WriteLine(matrix.LongestMatrixPath(mat));

            //var dictionary = new HashSet<string>
            //{
            //    "i", "like", "sam",
            //    "sung", "samsung", "mobile",
            //    "ice","cream", "icecream",
            //    "man", "go", "mango"
            //};

            //var word = new WordBreak();
            //Console.WriteLine(word.WordSplit("ilikesa", dictionary));

            //var dice = new DiceRoll();
            //Console.WriteLine(dice.NumOfWaysToGetSumGiveNDiceWithMFace(3, 2, 6));

            //var boxes = new List<Box>()
            //{
            //    new Box(4, 6, 7),
            //    new Box(1, 2, 3),
            //    new Box(4, 5, 6),
            //    new Box(10, 12, 32)
            //};

            //var boxStack = new BoxStacking();
            //Console.WriteLine(boxStack.FindMaxHeight(boxes));

            //var eggDrop = new EggDropping();
            //Console.WriteLine(eggDrop.MinimumEggDropToFindFloor(2, 36));

            //var pairs = new Pair[2] { new Pair(6,8), new Pair(3,4)};
            //var chain = new Chaining();
            //Console.WriteLine(chain.LongestChain(pairs));

            //var str = new StringDp();
            //Console.WriteLine(str.LongestCommonSubstring("geeksforgeeks", "geeksquiz"));

            //var number = new Numbers();
            //var arr = new int[] { 10, 5, 4, 3 };

            //Console.WriteLine(number.MinimumSquareWhereSumIsN(6));

            var word = new WordBreak();
            word.WordWrap("Tushar Roy likes to code", 10);
        }
    }
}
