using System.Collections.Generic;

namespace Arrays.Problems
{
    public class LongestSequence
    {
        public int GetLongestSequenceLength(int [] arr)
        {
            var longestSequence = 0;
            var tracker = new HashSet<int>();

            foreach(var num in arr)
            {
                //add to our tracker
                tracker.Add(num);
            }

            foreach(var num in arr)
            {
                //not start of sequence since number before it is in tracer
                if (tracker.Contains(num - 1))
                {
                    continue;
                }

                //is the start of sequence, check sequence length now
                var longestSequenceThusFar = 1; //first number of sequence
                var nextNum = num + 1;
                //while tracker contains next num of sequence, add to length
                while (tracker.Contains(nextNum))
                {
                    longestSequenceThusFar++;
                    nextNum++;
                }

                if (longestSequence < longestSequenceThusFar)
                {
                    longestSequence = longestSequenceThusFar;
                }
            }

            return longestSequence;
        }
    }
}
