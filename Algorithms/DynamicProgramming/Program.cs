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
            var price = new int[] { 3, 5, 8, 9, 10, 17, 17, 20 };
            Console.WriteLine(maxAndMin.CuttingRod(8, price));

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
        }
    }
}
