using System;
using System.Collections.Generic;
using System.Text;

namespace Arrays.Problems
{
    public class CommonAndRepeating
    {
        public List<int> FindCommonNumberInThreeArrays(int [] num1, int [] num2, int [] num3)
        {
            var tracker = new Dictionary<int, int>();
            foreach (var num in num1)
            {
                //dont want duplicates from num 1 to affect count
                if (tracker.ContainsKey(num))
                {
                    continue;
                }

                tracker.Add(num, 1); //all unique num from first array added with count of 1
            }

            foreach (var num in num2)
            {
                //was not in arr1
                if (!tracker.ContainsKey(num))
                {
                    continue;
                }

                //was it arr1, check count now to ensure count is 1. If anything higher, it means we've encountered in both arr1 and arr2 already
                if (tracker[num] > 1)
                {
                    continue;
                }

                //only 1 means only encountered in arr1 and now in arr2
                tracker[num] += 1;
            }

            foreach (var num in num3)
            {
                //was not in arr1 or arr2 
                if (!tracker.ContainsKey(num))
                {
                    continue;
                }

                //was it arr1, check count now to ensure count is 2. If anything higher, it means we've encountered already in all 3 arrays
                if (tracker[num] > 2)
                {
                    continue;
                }

                //only 2 means only encountered in arr1 and arr2 and first time in arr3, increment count
                tracker[num] += 1;
            }

            var numInAllArrays = new List<int>();
            //find all with count 3
            foreach (var numToCount in tracker)
            {
                if (numToCount.Value != 3)
                {
                    continue;
                }

                numInAllArrays.Add(numToCount.Key);
            }

            return numInAllArrays;
        }

        public int? FirstRepeatingNumber (int [] arr)
        {
            var tracker = new Dictionary<int, int>();
            foreach (var num in arr)
            {
                if (!tracker.ContainsKey(num))
                {
                    tracker.Add(num, 1);
                }
                else
                {
                    tracker[num] += 1;
                }
            }

            int? firstRepeatingNum = null;
            foreach(var numToCount in tracker)
            {
                //not repeating
                if (numToCount.Value <= 1)
                {
                    continue;
                }

                firstRepeatingNum = numToCount.Key;
                break;
            }

            return firstRepeatingNum;
        }

        public int? FirstNonRepeatingNum(int [] arr)
        {
            var tracker = new Dictionary<int, int>();
            foreach (var num in arr)
            {
                if (!tracker.ContainsKey(num))
                {
                    tracker.Add(num, 1);
                }
                else
                {
                    tracker[num] += 1;
                }
            }

            int? firstNonRepeatingNum = null;
            foreach (var numToCount in tracker)
            {
                //repeating
                if (numToCount.Value != 1)
                {
                    continue;
                }

                firstNonRepeatingNum = numToCount.Key;
                break;
            }

            return firstNonRepeatingNum;
        }
    }
}
