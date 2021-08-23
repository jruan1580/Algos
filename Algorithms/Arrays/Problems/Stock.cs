using System;
using System.Collections.Generic;
using System.Text;

namespace Arrays.Problems
{
    public class Stock
    {
        public int [] StockSpan(int [] arr)
        {
            var stockSpan = new int[arr.Length];
            var stack = new Stack<int>();

            stockSpan[0] = 1;
            stack.Push(0);

            for (var i = 1; i < arr.Length; i++)
            {
                while (stack.Count > 0 && arr[stack.Peek()] <= arr[i])
                {
                    stack.Pop();
                }

                stockSpan[i] = (stack.Count == 0) ? (i + 1) : (i - stack.Peek());

                stack.Push(i);
            }


            return stockSpan;
        }
    }
}
