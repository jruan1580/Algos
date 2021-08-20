
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
        }
    }
}
