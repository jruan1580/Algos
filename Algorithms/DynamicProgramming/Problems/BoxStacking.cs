using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DynamicProgramming.Problems
{
    public class BoxStacking
    {
        public int FindMaxHeight(List<Box> boxes)
        {
            var allRotationsInSortedOrder = GetAllBoxRotationsInDecOrder(boxes);
            var dp = new int[allRotationsInSortedOrder.Count];

            //initial max heigh at each cell is the heigh of the individual box
            for (var i = 0; i < dp.Length; i++)
            {
                dp[i] = allRotationsInSortedOrder[i].Height;
            }

            for(var i = 1; i < dp.Length; i++)
            {
                var boxToStack = allRotationsInSortedOrder[i];
                for (var j = 0; j < i; j++)
                {
                    //check if box can at i can fit onto j
                    var boxOnBottom = allRotationsInSortedOrder[j];
                    if (boxToStack.Length < boxOnBottom.Length && boxToStack.Width < boxOnBottom.Width)
                    {
                        dp[i] = Math.Max(dp[i], boxToStack.Height + dp[j]);
                    }                    
                }
            }

            //traverse to find max value
            var maxHeight = int.MinValue;
            foreach(var h in dp)
            {
                if (h > maxHeight)
                {
                    maxHeight = h;
                }
            }

            return maxHeight;
        }

        public List<Box> GetAllBoxRotationsInDecOrder(List<Box> boxes)
        {
            var listOfBoxesSorted = new List<Box>();
            foreach(var box in boxes)
            {
                //original box
                var box1 = new Box(Math.Max(box.Length, box.Width), Math.Min(box.Length, box.Width), box.Height);
                listOfBoxesSorted.Add(box1);

                //rotate box
                var box2 = new Box(Math.Max(box.Height, box.Length), Math.Min(box.Height, box.Length), box.Width);
                listOfBoxesSorted.Add(box2);

                //last rotation
                var box3 = new Box(Math.Max(box.Width, box.Height), Math.Min(box.Width, box.Height), box.Length);
                listOfBoxesSorted.Add(box3);
            }

            return listOfBoxesSorted.OrderByDescending(b => b.GetBaseArea()).ToList();
        }
    }

    public class Box
    {
        public int Length { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public Box(int l, int w, int h)
        {
            Length = l;
            Width = w;
            Height = h;
        }

        public int GetBaseArea()
        {
            return Length * Width;
        }
    }
}
