using System;
using System.Collections.Generic;
using System.Text;

namespace Arrays.Problems
{
    public class Rotation
    {
        public void RotateLeftNTimes(int [] arr, int n)
        {
            //outer keeps track of how many times we've rotated left
            for (int i = 0; i < n; i++)
            {                
                var tmp = arr[0]; //first element and we want to move it towards end as rotate left
                //shifts element left
                var j = 0;                
                while(j < (arr.Length - 1))
                {
                    arr[j] = arr[j + 1];
                    j++;
                }

                //replace last empty array shell with first element
                arr[arr.Length - 1] = tmp;
            }
        }

        public void RotateRightNTimes(int [] arr, int n)
        {
            //outer keeps track of how many times we've rotated right
            for (int i = 0; i < n; i++)
            {
                var tmp = arr[arr.Length - 1]; //last element we want to rotate right and move it to beginning
                //shift elements right
                var j = arr.Length - 1;
                while(j > 0)
                {
                    arr[j] = arr[j - 1]; //shift right
                    j--;
                }

                //replce first element with last
                arr[0] = tmp;
            }
        }
    }
}
