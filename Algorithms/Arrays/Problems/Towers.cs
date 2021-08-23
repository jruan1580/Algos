using System;

namespace Arrays.Problems
{
    public class Towers
    {
        public int MinimalDiffBetweenSmallestAndTallestTower(int [] towers, int k)
        {
            Array.Sort(towers);
            var currSmall = towers[0] + k;
            var currBig = towers[towers.Length - 1] - k;
            var minDiffInHieght = currBig - currSmall;

            //traverse middle elements to find if there is another smallest/biggest tht can give smaller diff in height
            for (int i = 1; i < towers.Length - 1; i++)
            {
                var subtractK = towers[i] - k;
                var addK = towers[i] + k;

                //not biggest or smallest
                if (subtractK >= currSmall || addK <= currBig)
                {
                    continue;
                }
                
                if (currBig - subtractK <= addK - currSmall)
                {
                    currSmall = subtractK;
                }
                else
                {
                    currBig = addK;
                }
            }

            return Math.Min(minDiffInHieght, (currBig - currSmall));
        }
    }
}
