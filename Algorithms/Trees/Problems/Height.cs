using DataStructures;
using System;
using System.Collections.Generic;
using System.Text;

namespace Trees.Problems
{
    public class Height
    {
        public int FindHeightBaseOnEvenLevelLeaf(TreeNodes<int> root, bool isEven)
        {
            if (root == null)
            {
                return 0;
            }

            //leave node, check if even level
            if (root.Left == null && root.Right == null)
            {
                if (isEven)
                {
                    return 1;
                }

                return 0;
            }

            var leftHeight = FindHeightBaseOnEvenLevelLeaf(root.Left, !isEven);
            var rightHeight = FindHeightBaseOnEvenLevelLeaf(root.Right, !isEven);

            if (leftHeight == 0 && rightHeight == 0)
            {
                return 0;
            }

            return 1 + Math.Max(leftHeight, rightHeight);
        }

        public int FindHeightBaseOnParentArray(int [] parent)
        {
            var tracker = new Dictionary<int, List<int>>();
            for(var i = 0; i < parent.Length; i++)
            {
                if (tracker.ContainsKey(parent[i]))
                {
                    tracker[parent[i]].Add(i);
                }
                else
                {
                    tracker.Add(parent[i], new List<int>() { i });
                }
            }
            
            var maxDepth = new int[parent.Length];

            //get index of root, -1;
            if (!tracker.ContainsKey(-1))
            {
                return 0; //no root, no height
            }

            var rootIndex = tracker[-1][0];
            maxDepth[rootIndex] = 1;
            var queue = new Queue<int>();
            queue.Enqueue(rootIndex);
            while(queue.Count > 0)
            {
                var parentIndex = queue.Dequeue();
                if (!tracker.ContainsKey(parentIndex))
                {
                    continue;
                }

                var childIndex = tracker[parentIndex];
                if (childIndex.Count > 2) 
                {
                    throw new Exception("can not have more than 2 child");
                }

                //left child
                maxDepth[childIndex[0]] = maxDepth[parentIndex] + 1;
                queue.Enqueue(childIndex[0]);
                //has right child
                if (childIndex.Count == 1)
                {
                    maxDepth[childIndex[1]] = maxDepth[parentIndex] + 1;
                    queue.Enqueue(childIndex[1]);
                }
            }

            //find max and return
            var maxHeight = int.MinValue;
            foreach(var h in maxDepth)
            {
                if (h > maxHeight)
                {
                    maxHeight = h;
                }
            }

            return maxHeight;
        }

        public int IsHeightBalanced(TreeNodes<int> root, ref bool isBalanced)
        {
            if (root == null)
            {
                return 0;
            }

            var leftHeight = IsHeightBalanced(root.Left, ref isBalanced);
            var rightHeight = IsHeightBalanced(root.Right, ref isBalanced);

            if (Math.Abs(leftHeight - rightHeight) > 1)
            {
                isBalanced = false;
            }

            return 1 + Math.Max(leftHeight, rightHeight);
        }

        public int DiameterOfTree(TreeNodes<int> root, ref int maxDiameter)
        {
            if (root == null)
            {
                return 0;
            }

            var leftHeight = DiameterOfTree(root.Left, ref maxDiameter);
            var rightHeight = DiameterOfTree(root.Right, ref maxDiameter);

            maxDiameter = Math.Max(1 + leftHeight + rightHeight, maxDiameter);

            return 1 + Math.Max(leftHeight, rightHeight); //return height
        }

        public TreeNodes<int> DeepestRightLeafNode(TreeNodes<int> root)
        {
            if (root == null)
            {
                return null;
            }

            var queue = new Queue<TreeNodes<int>>();
            TreeNodes<int> result = null;
            queue.Enqueue(root);

            while(queue.Count > 0)
            {
                var n = queue.Dequeue();
                if (n.Left != null)
                {
                    queue.Enqueue(n.Left);
                }

                if (n.Right != null)
                {
                    queue.Enqueue(n.Right);
                    if (n.Right.Left == null && n.Right.Right == null)
                    {
                        result = n.Right;
                    }
                }
            }

            return result;
        }

        public int VerticalWidth(TreeNodes<int> root)
        {
            if (root == null)
            {
                return 0;
            }

            //go as far left
            var width = 0;
            var curr = root;
            while(curr != null)
            {
                if (curr.Left != null)
                {
                    width += 1;
                }
                curr = curr.Left;
            }

            //go as far right
            curr = root;
            while (curr != null)
            {
                if (curr.Right != null)
                {
                    width += 1;
                }

                curr = curr.Right;
            }

            return width + 1; //one includes vertices of root
        }
    }
}
