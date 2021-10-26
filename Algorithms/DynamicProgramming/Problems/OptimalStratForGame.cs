using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicProgramming.Problems
{
    public class OptimalStratForGame
    {
        public int MaxValueForCoinGame(int[] arr)
        {
            var dp = new CoinGamePlayerValues[arr.Length, arr.Length];
            //fill diagonal
            for (var i = 0; i < dp.GetLength(0); i++)
            {
                dp[i, i] = new CoinGamePlayerValues() { FirstPlayerVal = arr[i], SecondPlayerVal = 0 };
            }

            for(var cl = 2; cl <= arr.Length; cl++)
            {
                for (var row = 0; row < arr.Length - cl + 1; row++)
                {
                    var col = cl + row - 1;

                    var val = new CoinGamePlayerValues();
                    val.FirstPlayerVal = Math.Max(arr[row] + dp[row + 1, col].SecondPlayerVal, arr[col] + dp[row, col - 1].SecondPlayerVal); //max between taking first coin and last coin
                    val.SecondPlayerVal = Math.Max(arr[row] + dp[row + 1, col].FirstPlayerVal, arr[col] + dp[row, col - 1].FirstPlayerVal); //min remaining goes to second player

                    dp[row, col] = val;
                }
            }

            return dp[0, arr.Length - 1].FirstPlayerVal;
        }

        private class CoinGamePlayerValues
        {            
            public int FirstPlayerVal { get; set; }
            public int SecondPlayerVal { get; set; }
        }
    }
}
