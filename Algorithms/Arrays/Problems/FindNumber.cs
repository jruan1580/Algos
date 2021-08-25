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

        public void PrintTopTwoNumberWithoutSorting(int [] arr)
        {
            int max1 = int.MinValue;
            int max2 = int.MinValue;

            foreach (var num in arr)
            {
                //num less than both max1 and max2.
                if (num < max1 && num < max2)
                {
                    continue;
                }

                //num is greater than both max1 and max2, assign to max1
                if (num > max1 && num > max2)
                {
                    max1 = num;
                    continue;
                }

                //num is less than max1 but greater than max2
                if (num < max1 && num > max2)
                {
                    max2 = num;
                    continue;
                }
            }

            Console.WriteLine($"Max1: {max1}, Max2: {max2}");
        }

        public int FindSmallestPositiveNumberThatCannotBeSum(int [] arr)
        {
            var smallestPosNum = 1;
            var index = 0;
            while (index < arr.Length && arr[index] <= smallestPosNum)
            {
                smallestPosNum += arr[index];
                index++;
            }

            return smallestPosNum;
        }

        public void PrintNumAppearingMoreThanNOverKTimes(int [] arr, int k)
        {
            var n = 0;
            var tracker = new Dictionary<int, int>();
            foreach(var num in arr)
            {
                n++; //find n which is length of array
                if (!tracker.ContainsKey(num))
                {
                    tracker[num] += 1;
                }
                else
                {
                    tracker.Add(num, 1);
                }
            }

            var occurences = (n / k);
            foreach(var numToCount in tracker)
            {
                if (numToCount.Value < occurences)
                {
                    continue;
                }

                Console.WriteLine(numToCount.Key);
            }
        }

        public int FindSmallestMissingPositiveWithExtraSpace(int [] arr)
        {
            var tracker = new Dictionary<int, bool>();

            foreach (var num in arr)
            {
                if (num <= 0)
                {
                    continue;
                }

                //already tracked in
                if (tracker.ContainsKey(num))
                {
                    continue;
                }                
                
                tracker.Add(num, true);            
            }

            var smallestPos = 1;
            while (tracker.ContainsKey(smallestPos))
            {
                smallestPos++;
            }

            return smallestPos;
        }

        public int FindSmallestMissingPositiveWithoutExtraSpace(int [] arr)
        {
            //segregate pos and negatives
            var pos = 0;            

            for (var neg = 0; neg < arr.Length; neg++)
            {
                if (arr[neg] <= 0)
                {
                    var tmp = arr[pos];
                    arr[pos] = arr[neg];
                    arr[neg] = tmp;
                    pos++;
                }
            }

            var startOfPos = pos;
            for (var i = startOfPos; i < arr.Length; i++)
            {
                if ((Math.Abs(arr[i]) - 1) + startOfPos < arr.Length && arr[(Math.Abs(arr[i]) - 1) + startOfPos] > 0)
                {
                    arr[(Math.Abs(arr[i]) - 1) + startOfPos] = (arr[(Math.Abs(arr[i]) - 1) + startOfPos] * -1);
                }
            }

            for (var i = startOfPos; i < arr.Length; i++)
            {
                if (arr[i] > 0)
                {
                    return i - startOfPos + 1;
                }
            }

            return (arr.Length - startOfPos) + 1;
        }

        public void PrintMissingAndRepeat(int [] arr)
        {
            for (var i = 0; i < arr.Length; i++)
            {
                //seen it before, this is repeat/
                if (arr[Math.Abs(arr[i]) - 1] < 0)
                {
                    Console.WriteLine($"Repeated: {arr[i]}");
                    continue;
                }

                //set index to 0
                arr[Math.Abs(arr[i]) - 1] = (arr[Math.Abs(arr[i]) - 1] * -1);
            }

            for(var i = 0; i < arr.Length; i++)
            {
                if (arr[i] < 0)
                {
                    continue;
                }

                Console.WriteLine($"Missing: {i + 1}");
            }
        }
    }
}
