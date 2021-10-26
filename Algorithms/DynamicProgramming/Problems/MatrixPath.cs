using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicProgramming.Problems
{
    public class MatrixPath
    {
        public int LongestMatrixPath(int [,] mat)
        {
            var dp = new int[mat.GetLength(0), mat.GetLength(1)];

            for(var i = 0; i < dp.GetLength(0); i++)
            {
                for (var j = 0; j < dp.GetLength(1); j++)
                {
                    dp[i, j] = -1;
                }
            }

            var result = int.MinValue;
            for (var i = 0; i < dp.GetLength(0); i++)
            {
                for (var j = 0; j < dp.GetLength(1); j++)
                {
                    if (dp[i, j] == -1)
                    {
                        LongestPathForCell(i, j, mat, dp);
                    }

                    result = Math.Max(result, dp[i, j]);
                }
            }

            return result;
        }

        private int LongestPathForCell(int i, int j, int[,] mat, int [,] dp)
        {
            if (i >= mat.GetLength(0) || i < 0 || j >= mat.GetLength(1) || j < 0)
            {
                return 0;
            }

            if (dp[i, j] != -1)
            {
                return dp[i, j];
            }

            var right = int.MinValue;
            var left = int.MinValue;
            var up = int.MinValue;
            var down = int.MinValue;

            //go right
            if (j < mat.GetLength(1) - 1 && ((mat[i, j] + 1) == mat[i, j + 1]))
            {
                right = 1 + LongestPathForCell(i, j + 1, mat, dp);
            }

            //go down
            if (i < mat.GetLength(0) - 1 && ((mat[i, j] + 1) == mat[i + 1, j]))
            {
                down = 1 + LongestPathForCell(i + 1, j, mat, dp);
            }

            //go up
            if (i > 0 && ((mat[i,j] + 1) == mat[i - 1, j]))
            {
                up = 1 + LongestPathForCell(i - 1, j, mat, dp);
            }

            //go left
            if (j > 0 && ((mat[i, j] + 1) == mat[i, j - 1]))
            {
                left = 1 + LongestPathForCell(i, j - 1, mat, dp);
            }

            dp[i, j] = Math.Max(right, Math.Max(down, Math.Max(left, Math.Max(up, 1))));
            return dp[i, j];
        }
    }
}
