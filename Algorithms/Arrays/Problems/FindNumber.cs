using System;
using System.Collections.Generic;
using System.Text;

namespace Arrays.Problems
{
    public class FindNumber
    {
        public bool HasNumberInArray(int [] nums, int target)
        {
            foreach (var num in nums)
            {
                if (num != target)
                {
                    continue;
                }

                //found it
                return true;
            }

            //never found it, otw, would have returned true by now
            return false;
        }

        public void PrintLargetAndSmallestNumberWithoutSorting(int[] nums)
        {
            var min = int.MaxValue; //min right now is the biggest number for int. anything found will be smaller
            var max = int.MinValue; //max is smallest number for int. anything found will def. be bigger

            foreach(var num in nums)
            {
                //curent num in array is less than min, set min to num for new min so far
                if (num < min)
                {
                    min = num;
                }

                //curent num in array is bigger than max, set max to num for new max so far
                if (num > max)
                {
                    max = num;
                }
            }

            Console.WriteLine($"Min: {min} | Max: {max}");
        }
    }
}
