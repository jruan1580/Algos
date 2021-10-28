using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicProgramming.Problems
{
    public class EggDropping
    {
        public int MinimumEggDropToFindFloor(int eggs, int floors)
        {
            var dp = new int[eggs, floors];

            //fill out first row
            for(var i = 1; i <= floors; i++)
            {
                //given only one egg, min attempt is the number of floors itself
                dp[0, i - 1] = i;
            }

            for(var i = 2; i <= eggs; i++)
            {
                for(var j = 1; j <= floors; j++)
                {
                    if (i > j)
                    {
                        dp[i - 1, j - 1] = dp[i - 2, j - 1];
                        continue;
                    }

                    var currFloor = 1;
                    var attempsNeeded = int.MaxValue;
                    while(currFloor <= j)
                    {
                        if (currFloor == 1)
                        {
                            //if it breaks on first floor, then we found floor, attemps needed is 0
                            var eggBreak = 0;
                            //if it doesnt break, we have j - 1 floors left with 2 eggs left to test
                            var noBreak = dp[i - 1, j - 2];
                            attempsNeeded = Math.Min(1 + Math.Max(eggBreak, noBreak), attempsNeeded);
                        }
                        else if (currFloor == j)
                        {
                            //if it breaks, we have 1 egg and j - 1 floors left to test
                            var eggBreak = dp[i - 2, j - 2];
                            var noBreak = 0; //doesnt break, we have 2 eggs and no floors left and found out answer
                            attempsNeeded = Math.Min(1 + Math.Max(eggBreak, noBreak), attempsNeeded);
                        }
                        else
                        {
                            var eggBreak = dp[i - 2, currFloor - 2]; //egg breaks, we have 1 egg left and currfloor - 1 floors left
                            var noBreak = dp[i - 1, j - currFloor - 1]; //eggs dont break, we have 2 eggs left and j - currFloors left to test
                            attempsNeeded = Math.Min(1 + Math.Max(eggBreak, noBreak), attempsNeeded);
                        }
                        currFloor++;
                    }

                    dp[i - 1, j - 1] = attempsNeeded;
                }
            }

            return dp[eggs - 1, floors - 1];
        }
    }
}
