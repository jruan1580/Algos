using System;

namespace Arrays.Problems
{
    public class Jumps
    {
        public int MinJumpToEnd(int [] arr)
        {
            //end will never be reach
            if (arr.Length == 0 || arr[0] == 0)
            {
                return int.MaxValue;
            }

            var jumpTracker = new int[arr.Length];
            jumpTracker[0] = 0; //takes 0 jumps to reach first index

            for (int i = 1; i < arr.Length; i++)
            {
                jumpTracker[i] = int.MaxValue;//lets assume right now, it takes max jumps to reach here

                //calculate how min jumps from beginning to i
                for (int j = 0; j < i; j++)
                {
                    //we can reach index i with j and it seems like since jumptrakcer[j] is not max value, we've reached it before
                    if (i <= j + arr[j] && jumpTracker[j] != int.MaxValue)
                    {
                        jumpTracker[i] = Math.Min(jumpTracker[i], jumpTracker[j] + 1);
                        break;//exit loop, found min jumps
                    }
                }
            }

            return jumpTracker[arr.Length - 1];
        }
    }
}
