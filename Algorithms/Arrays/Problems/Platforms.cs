
using System;

namespace Arrays.Problems
{
    public class Platforms
    {
        public int MinumumPlatformsByBruteForce(int [] arrivals, int [] departures)
        {
            var minPlatform = 1;
            for (int i = 0; i < arrivals.Length; i++)
            {
                var platformNeeded = 1; //min is 1 if no overlap
                for (int j = i + 1; j < departures.Length; j++)
                {
                    //next time overlaps with first
                    if ((arrivals[j] <= departures[i] && arrivals[j] >= arrivals[i])
                        || (arrivals[i] <= departures[j] && arrivals[i] >= arrivals[j]))
                    {
                        platformNeeded++;
                    }

                    minPlatform = Math.Max(minPlatform, platformNeeded);
                }
            }

            return minPlatform;
        }

        public int MinimumPlatformsWithoutBruteForce(int [] arrivals, int [] departures)
        {
            Array.Sort(arrivals);
            Array.Sort(departures);

            var i = 1;
            var j = 0;
            var len = arrivals.Length;
            var platformsNeeded = 1; //at least one is needed
            var result = 1; //final result is here

            while (i < len && j < len)
            {
                //next arrival is smaller than previous depature, meaning arrive sooner than dept, overlap, will need platform
                if (arrivals[i] <= departures[j])
                {
                    platformsNeeded++;
                }
                else
                {
                    //arrival is greater than previous dept, no overlap, will not need platform
                    platformsNeeded--;
                }

                if (platformsNeeded > result)
                {
                    result = platformsNeeded;
                }
            }

            return result;
        }
    }
}
