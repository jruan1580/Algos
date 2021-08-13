using System;
using System.Collections.Generic;
using System.Text;

namespace Arrays.Problems
{
    public class Sum
    {
        public void PrintAllPairsEqualToSum(int sum, int[] nums)
        {
            var tracker = new Dictionary<int, bool>();

            foreach (var num in nums)
            {
                //found a pair.
                if (tracker.ContainsKey(sum - num))
                {
                    Console.WriteLine($"{sum - num},{num}");
                }
                else
                {
                    tracker.Add(num, true);
                }
            }
        }
    }
}
