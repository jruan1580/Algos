using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicProgramming.Problems
{
    public class DiceRoll
    {
        public int NumOfWaysToGetSumGiveNDiceWithMFace(int n, int m, int sum)
        {
            var dp = new int[n, sum + 1];

            for(var row = 0; row < dp.GetLength(0); row++)
            {
                dp[row, 0] = 0; //sum of 0 results in 0 ways to get sum of 0 regardless of how many dice we have
            }

            //populate first row with 1 die up to m faces.
            var i = 1;
            while(i <= m)
            {
                dp[0, i] = 1; //only one way to get sum with 1 die
                i++;
            }

            while(i <= sum)
            {
                dp[0, i] = 0; //sum more than num of faces, cant reach it with 1 die
                i++;
            }

            for(var row = 1; row < dp.GetLength(0); row++)
            {
                for (var col = 1; col < dp.GetLength(1); col++)
                {
                    var totalWays = 0;
                    var faces = 1;
                    while(faces <= m && col - faces >= 0)
                    {
                        totalWays += dp[row - 1, col - faces];
                        faces++;
                    }

                    dp[row, col] = totalWays;
                }
            }

            return dp[n - 1, sum];
        }
    }
}
