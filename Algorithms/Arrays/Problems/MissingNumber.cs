using System;
using System.Collections.Generic;
using System.Text;

namespace Arrays.Problems
{
    public class MissingNumber
    {
        /// <summary>
        /// using sort method costs us sorting performance.
        /// </summary>
        /// <param name="oneToHundredArr"></param>
        /// <returns></returns>
        public int MissingNumberBetweenOneToHundredSort(int [] oneToHundredArr)
        {
            Array.Sort(oneToHundredArr);

            var numberToLookFor = 1;
            var missingNumber = 0;
            foreach (var num in oneToHundredArr)
            {
                if (num != numberToLookFor)
                {
                    missingNumber = num;
                    break;
                }

                numberToLookFor++;
            }

            return missingNumber;
        }

        /// <summary>
        /// finding it without sorting saving us sorting performance.
        /// used dictionary to track numbers we have in array.
        /// check dictionary later to find missing number between 1 and 100.
        /// no sorting but using dictionary used extra space
        /// </summary>
        /// <param name="oneToHundredArr"></param>
        /// <returns></returns>
        public int MissingNumberBetweenOneToHundredNoSortExtraMem(int[] oneToHundredArr)
        {
            var numberTracker = new Dictionary<int, bool>();
            foreach(var num in oneToHundredArr)
            {
                numberTracker.Add(num, true);
            }

            var missingNumber = 0;
            //check between 1 and 100 now
            for (int i = 1; i <= 100; i++)
            {
                //found it
                if (numberTracker.ContainsKey(i))
                {
                    continue;
                }

                //did not find it, missing number
                missingNumber = i;
                break;
            }

            return missingNumber;
        }

        /// <summary>
        /// no sorting, no extra space
        /// </summary>
        /// <param name="oneToHundredArr"></param>
        /// <returns></returns>
        public int MissingNumberBetweenOneToHundredNoSortNoExtraMem(int[] oneToHundredArr)
        {
            //sum 1 to 100
            var expectedSum = 0;
            for (var i = 1; i <= 100; i++)
            {
                expectedSum += i;
            }

            //sum up array
            var sumOfArray = 0;
            foreach(int num in oneToHundredArr)
            {
                sumOfArray += num;
            }

            //difference is the missing number.
            //since there is missing number, expected sum is bigger
            return expectedSum - sumOfArray;
        }
    }
}
