using System;

namespace Arrays.Problems
{
    public class CoinChange
    {
        public int GetWaysToMakeChange(int [] coins, int change)
        {
            var arr2D = new int[coins.Length + 1, change + 1];

            //populate first row, with 0 coins, cannot make change
            for(var col = 1; col < arr2D.GetLength(1); col++)
            {
                arr2D[0, col] = 0;
            }

            //populate first column with 1 since there is only one way to make 0 change - by excluding the coins
            for(var row = 0; row < arr2D.GetLength(0); row++)
            {
                arr2D[row, 0] = 1;
            }

            for(var row = 1; row < arr2D.GetLength(0); row++)
            {
                for(var col = 1; col < arr2D.GetLength(1); col++)
                {
                    var currentCoin = coins[row - 1];

                    //current coin is bigger than change we want to make, cannot use two coin
                    if (currentCoin > col)
                    {
                        //if we cannot use the coin, out only choice is to exclude the coin
                        arr2D[row, col] = arr2D[row - 1, col];
                    }
                    //otw, we have two choices - use the coin AND do not use the coin.
                    //sum of the two gives us number of unique ways to make change with current coins we have
                    else
                    {
                        //dont use + do use
                        arr2D[row, col] = arr2D[row - 1, col] + arr2D[row, (col - currentCoin)];
                    }                    
                }
            }

            return arr2D[arr2D.GetLength(0) - 1, arr2D.GetLength(1) - 1];
        }

        public int FewestCoinsToMakeChange(int [] coins, int change)
        {
            var fewestCoinsTracker = new int[change + 1];

            fewestCoinsTracker[0] = 0; //fewest num of coins to make 0 is 0.

            //populate rest with max int
            for (var i = 1; i < fewestCoinsTracker.Length; i++)
            {
                fewestCoinsTracker[i] = int.MaxValue;
            }

            for (var i = 1; i < fewestCoinsTracker.Length; i++)
            {
                for(var j = 0; j < coins.Length; j++)
                {
                    //cannot make change with a coin greater than change amount
                    if (coins[j] > i)
                    {
                        continue; 
                    }

                    //otw, we can make change with the coin. Using the coin costs 1 coin to be used.
                    //subtract the coin from change to find out fewest coin needed to make the diff
                    var coinsNeeded = 1 + fewestCoinsTracker[i - coins[j]];

                    fewestCoinsTracker[i] = Math.Min(fewestCoinsTracker[i], coinsNeeded);
                }
            }

            return fewestCoinsTracker[fewestCoinsTracker.Length - 1];
        }
    }
}
