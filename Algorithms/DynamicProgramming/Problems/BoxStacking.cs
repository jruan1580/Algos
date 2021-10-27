using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicProgramming.Problems
{
    public class BoxStacking
    {
        //public int FindMaxHeight(List<Box> boxes)
        //{

        //}      

        public List<Box> GetAllBoxRotationsInDecOrder(List<Box> boxes)
        {
            foreach(var box in boxes)
            {

            }
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
