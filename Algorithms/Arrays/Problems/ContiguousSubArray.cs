using System;

namespace Arrays.Problems
{
    public class ContiguousSubArray
    {
        public int MaxSumFormByContigousSubArray(int [] arr)
        {
            var maxSoFar = int.MinValue;
            var maxHere = 0;

            foreach(var num in arr)
            {
                maxHere += num;

                if (maxSoFar < maxHere)
                {
                    maxSoFar = maxHere;
                }

                if (maxHere < 0)
                {
                    maxHere = 0;
                }
            }

            return maxSoFar;
        }

        public int MaxProductFormByContiguousSubArray(int [] arr)
        {
            var maxSoFar = int.MinValue;
            var maxHere = 1; //keeps track of pos
            var minHere = 1; //keeps track of neg

            foreach(var num in arr)
            {
                //reset
                if (num == 0)
                {
                    maxHere = 1;
                    minHere = 1;
                }
                //current number is pos
                else if (num > 0)
                {
                    maxHere *= num;
                    minHere = Math.Min((minHere * num), 1); //minHere can either be 1 or some negative. take the smallest to keep track of min
                }
                //neg number
                else
                {
                    //max here depends on min. If min is negative, negative * negative = big positive.
                    //otherwise, it is 1
                    var temp = maxHere;
                    maxHere = Math.Max((minHere * num), 1);
                    //min is orig max (which is 1 or always pos) times the current neg number
                    //min cant be min * current neg because thatll result in pos. we want minHere to keep track of min so far
                    minHere = temp * num;
                }

                if (maxSoFar < maxHere)
                {
                    maxSoFar = maxHere;
                }
            }

            return maxSoFar;
        }
    }
}
