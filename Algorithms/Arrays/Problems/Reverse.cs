using System;
using System.Collections.Generic;
using System.Text;

namespace Arrays.Problems
{
    public class Reverse
    {
        public int [] ReverseArrayInPlace(int[] arr)
        {
            var start = 0;
            var end = arr.Length - 1;

            while(start < end)
            {
                var tmp = arr[start];
                arr[start] = arr[end];
                arr[end] = tmp;
            }

            return arr;
        }
    }
}
