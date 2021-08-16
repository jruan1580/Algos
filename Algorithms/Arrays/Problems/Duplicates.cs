using System;
using System.Collections.Generic;
using System.Text;

namespace Arrays.Problems
{
    public class Duplicates
    {
        /// <summary>
        /// use the same way to find missing number.
        /// find expected sum from 0 to n.
        /// find sum of the array. 
        /// the diff is the duplicate
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public int FindTheDuplicateBetweenZeroAndN(int[] nums, int n)
        {
            var expectedSum = 0;
            for (var i = 0; i <= n; i++)
            {
                expectedSum += i;
            }

            var sumOfArr = 0;
            foreach(var num in nums)
            {
                sumOfArr += num;
            }

            //since there is an extra number, sum of array is bigger. 
            return sumOfArr - expectedSum;
        }

        public void PrintAllDuplicates(int [] nums)
        {
            var tracker = new Dictionary<int, int>();
            
            foreach(var num in nums)
            {
                if (tracker.ContainsKey(num))
                {
                    tracker[num] += 1;
                }
                else
                {
                    tracker.Add(num, 1);
                }
            }

            foreach(var map in tracker)
            {
                if (map.Value <= 1) 
                {
                    continue;
                }

                //duplicate since we found it more than one time
                Console.WriteLine(map.Key);
            }
        }

        public int FindUniqueElementInDuplicateArray(int [] nums)
        {
            //tracks count
            var tracker = new Dictionary<int, int>();
            foreach(var num in nums)
            {
                //never seen number, add it with count of 1
                if (!tracker.ContainsKey(num))
                {
                    tracker.Add(num, 1);
                }
                else
                {
                    //seen it before, increment count
                    tracker[num]++;
                }
            }

            foreach(var numToCount in tracker)
            {
                //not unique, duplicate
                if (numToCount.Value > 1)
                {
                    continue;
                }

                //found unique, with value not greater than 1, return it
                return numToCount.Key;
            }

            //never found a unique or else would have been returned.
            throw new Exception("no unique found");
        }
    }
}
