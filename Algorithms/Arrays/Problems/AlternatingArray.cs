using System;
using System.Collections.Generic;
using System.Text;

namespace Arrays.Problems
{
    public class AlternatingArray
    {
        public int [] AlternatePosNegArr(int [] arr)
        {            
            //sort it with positive in front and negatives all in back
            var start = 0;
            var end = arr.Length - 1;

            var sortedArray = new int[arr.Length];

            foreach (var num in arr)
            {
                //positive, put int on the left side
                if (num >= 0)
                {
                    sortedArray[start] = num;
                    start++;
                }
                else
                {
                    //neg number, put at end
                    sortedArray[end] = num;
                    end--;
                }
            }

            var result = new int[arr.Length];
            start = 0;
            end = arr.Length;
            var index = 0;
            //alternate into result
            var currentState = "Positive"; //looking for positive first
            while (start <= end)
            {
                //look on left side
                if (currentState == "Positive")
                {
                    //found positive on left side, add to result
                    if (sortedArray[start] >= 0)
                    {
                        result[index] = sortedArray[start];
                        start++;
                        index++;
                        currentState = "Negative"; //need negative next
                    }
                    //not positive, we are out, add right side negative now.
                    else
                    {
                        result[index] = sortedArray[end];
                        end--;
                        index++;
                    }
                }
                //look on right side
                else
                {
                    //found negative on right side, add to result
                    if (sortedArray[end] < 0)
                    {
                        result[index] = sortedArray[end];
                        end--;
                        index++;
                        currentState = "Positive"; //need positive next
                    }
                    //not negative, we are out, add left side pos now.
                    else
                    {
                        result[index] = sortedArray[start];
                        start++;
                        index++;
                    }
                }
            }
            
            return result;
        }
    }
}
