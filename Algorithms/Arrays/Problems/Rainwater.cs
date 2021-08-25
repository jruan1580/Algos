using System;
using System.Collections.Generic;
using System.Text;

namespace Arrays.Problems
{
    public class Rainwater
    {
        public int RainWaterWithExtraMem(int [] arr)
        {
            var leftMax = new int[arr.Length];
            var rightMax = new int[arr.Length];

            //fill left array
            leftMax[0] = arr[0];
            for (var i = 1; i < arr.Length; i++)
            {
                leftMax[i] = Math.Max(leftMax[i - 1], arr[i]);
            }

            //fill right arra
            rightMax[arr.Length - 1] = arr[arr.Length - 1];
            for (var i = arr.Length - 2; i >= 0; i--)
            {
                rightMax[i] = Math.Max(rightMax[i + 1], arr[i]);
            }

            var water = 0;
            for (var i = 0; i < arr.Length; i++)
            {
                water += (Math.Min(leftMax[i], rightMax[i]) - arr[i]);
            }

            return water;
        }

        public int RainWaterWithoutExtraMem(int [] arr)
        {
            var leftMax = arr[0]; 
            var rightMax = arr[arr.Length - 1];

            var leftPointer = 1;
            var rightPointer = arr.Length - 2;
            var sum = 0;

            while (leftPointer <= rightPointer)
            {
                if (leftMax < rightMax)
                {
                    if (arr[leftPointer] > leftMax)
                    {
                        leftMax = arr[leftPointer];
                    }
                    else
                    {
                        sum += (leftMax - arr[leftPointer]);
                    }
                    leftPointer++;
                }
                else
                {
                    if (arr[rightPointer] > rightMax)
                    {
                        rightMax = arr[rightPointer];
                    }
                    else
                    {
                        sum += (rightMax - arr[rightPointer]);
                    }
                    rightPointer--;
                }
            }

            return sum;
        }
    }
}
