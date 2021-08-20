using System.Collections.Generic;

namespace Arrays.Problems
{
    public class ZeroesAndOnes
    {
        public void SortArrayIntoZerosOnesTwos(int [] arr)
        {
            var low = 0; //keep track of where our 0s are at
            var mid = 0; //keeps track of 1s
            var high = arr.Length - 1; //keeps track of 2s
            var tmp = 0;
            while (mid <= high)
            {
                switch (arr[mid])
                {
                    case 0:
                        tmp = arr[low];
                        arr[low] = 0; //move 0 to start
                        arr[mid] = tmp;
                        low++;
                        mid++;
                        break;
                    case 1:
                        mid++; //perfect, leave it in middle
                        break;
                    case 2:
                        tmp = arr[high];
                        arr[high] = 2; //move two to end
                        arr[mid] = tmp;
                        high--;
                        break;
                }
            }
        }

        public int SubArrWithEqualZeroAndOne(int [] arr)
        {
            //convert all zeros to -1
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] != 0)
                {
                    continue;
                }

                arr[i] = -1;
            }

            var sum = 0;
            var tracker = new Dictionary<int, int>();
            var count = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];

                //from 0 to i, we have equal 0 and 1s, increment count
                if (sum == 0)
                {
                    count++;
                }

                //never seen sum before, add to tracker
                if (!tracker.ContainsKey(sum))
                {
                    tracker.Add(sum, 1);
                }
                else
                {
                    //seen sum before, num of occurences with equal 0 and 1 equal to number currently in dictionary
                    count += tracker[sum];
                    tracker[sum]++;
                }
            }

            return count;
        }

        public int LongestSubArrWithEqualZeroAndOne(int [] arr)
        {
            //replace all 0 with -1
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] != 0)
                {
                    continue;
                }

                arr[i] = -1;
            }

            var tracker = new Dictionary<int, int>();
            var maxLength = 0;
            var sum = 0;
            
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];

                //equal 0 and 1s from 0 to i, length is (i + 1) since i is 0 base
                if (sum == 0)
                {
                    var len = i + 1;
                    if (maxLength < len)
                    {
                        maxLength = len;
                    }
                }

                if (!tracker.ContainsKey(sum))
                {
                    tracker.Add(sum, i); //add index of first occurence.
                }
                else
                {
                    //longest is i subtract index of first occurrence of sum
                    var len = i - tracker[sum];
                    if (maxLength < len)
                    {
                        maxLength = len;
                    }
                }
            }

            return maxLength;
        }
    }
}
