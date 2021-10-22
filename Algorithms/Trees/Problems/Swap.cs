using DataStructures;
using System;
using System.Collections.Generic;
using System.Text;

namespace Trees.Problems
{
    public class Swap
    {
        public void SwapAtEveryKLevel(TreeNodes<int> root, int k, int level) 
        { 
            if (root == null || (root.Left == null && root.Right == null))
            {
                return;
            }

            if ((level + 1) % k == 0)
            {
                var tmp = root.Left;
                root.Left = root.Right;
                root.Right = tmp;
            }

            SwapAtEveryKLevel(root.Left, k, level + 1);
            SwapAtEveryKLevel(root.Right, k, level + 1);
        }

        public void PairwiseSwapLeafNode(TreeNodes<int> root)
        {
            TreeNodes<int> firstPtr = null;
            var curr = root;
            var stack = new Stack<TreeNodes<int>>();
            while (curr != null || stack.Count > 0)
            {
                if (curr != null)
                {
                    //check if leaf node
                    if (curr.Left == null && curr.Right == null)
                    {
                        if (firstPtr == null)
                        {
                            firstPtr = curr;
                        }
                        else
                        {
                            //already found first leaf and right now we encounter our second one for pair swap
                            var tmp = curr.Data;
                            curr.Data = firstPtr.Data;
                            firstPtr.Data = tmp;
                            firstPtr = null; //set to null for next swap
                        }                       
                    }

                    stack.Push(curr);
                    curr = curr.Left;
                }
                else
                {
                    curr = stack.Pop();
                    curr = curr.Right;
                }
            }
        }
    }
}
