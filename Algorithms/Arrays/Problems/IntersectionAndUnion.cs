using System;
using System.Collections.Generic;
using System.Text;

namespace Arrays.Problems
{
    //methods can be used for both sorted and unsorted arrays
    public class IntersectionAndUnion
    {
        /// <summary>
        /// essentially find elements that exists in both arrays
        /// </summary>
        /// <param name="arr1"></param>
        /// <param name="arr2"></param>
        public void PrintIntersection(int [] arr1, int [] arr2)
        {
            var tracker = new Dictionary<int, int>();
            foreach (var num in arr1)
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

            foreach(var num in arr2)
            {
                //was in array one and now its also in array 2, intersection, print it
                if (tracker.ContainsKey(num))
                {
                    Console.WriteLine(num);
                    continue;
                }
            }
        }

        /// <summary>
        /// find all unique elements of both arrays
        /// </summary>
        /// <param name="arr1"></param>
        /// <param name="arr2"></param>
        public void PrintUnion(int[] arr1, int[] arr2)
        {
            var tracker = new Dictionary<int, int>();
            foreach (var num in arr1)
            {
                //only want unique, if already contained, dont want to track again
                if (tracker.ContainsKey(num))
                {
                    continue;
                }

                tracker.Add(num, 1);
            }

            foreach (var num in arr2)
            {
                //only want unique, if already contained, dont want to track again
                if (tracker.ContainsKey(num))
                {
                    continue;
                }

                tracker.Add(num, 1);
            }

            //since we only stored unique, everything in tracker should be unique (aka union of both array)
            //loop through and print out
            foreach(var union in tracker)
            {
                Console.WriteLine($"{union.Key}");
            }
        }
    }
}
