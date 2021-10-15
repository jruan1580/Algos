using DataStructures;
using System;
using System.Collections.Generic;
using System.Text;

namespace Trees.Problems
{
    public class CheckAndPrint
    {
        public bool IsChildSumTree(TreeNodes<int> root)
        {
            if ((root == null) || (root.Left == null && root.Right == null))
            {
                return true;
            }

            var isChildSumRoot = false;
            if (root.Left != null && root.Right != null)
            {
                isChildSumRoot = (root.Data == (root.Left.Data + root.Right.Data));
            }

            if (root.Left != null && root.Right == null)
            {
                isChildSumRoot = (root.Data == root.Left.Data);
            }

            if (root.Left == null && root.Right != null)
            {
                isChildSumRoot = (root.Data == root.Right.Data);
            }           

            return isChildSumRoot && IsChildSumTree(root.Left) && IsChildSumTree(root.Right);
        }

        public bool IsSumTree(TreeNodes<int> root)
        {
            if (root == null || (root.Left == null && root.Right == null))
            {
                return true;
            }

            var ls = Sum(root.Left);
            var rs = Sum(root.Right);

            return (root.Data == (ls + rs));
        }

        public bool AreCousins(TreeNodes<int> root, TreeNodes<int> cousin1, TreeNodes<int> cousin2)
        {
            var levelOrder = new Dictionary<int, List<TreeNodes<int>>>();
            var traversal = new Traversals();
            traversal.PrintLevelOrderTraversal(root, 0, levelOrder);

            var cousin1Level = -1;
            var cousin2Level = -1;
            foreach(var level in levelOrder)
            {
                var nodes = level.Value;
                foreach(var node in nodes)
                {
                    if (node != cousin1 && node != cousin2)
                    {
                        continue;
                    }

                    if (node == cousin1)
                    {
                        cousin1Level = level.Key;
                    }

                    if (node == cousin2)
                    {
                        cousin2Level = level.Key;
                    }
                }
            }

            //not cousins
            if (cousin1Level != cousin2Level)
            {
                return false;
            }

            //same level, check if they are siblings sharing same parent, if they are return false, if not siblings, return true
            return !AreSiblings(root, cousin1, cousin2);
        }

        public bool AreLeavesOnSameLevel(TreeNodes<int> root, int level, ref int leafLevel)
        {
            if (root == null)
            {
                return true;
            }

            //leave node
            if (root.Left == null && root.Right == null)
            {
                //first leaf level
                if (leafLevel == 0)
                {
                    leafLevel = level;
                    return true; //return since first leaf found
                }

                return (level == leafLevel); //check if other leaves are same level as first leaf
            }

            return AreLeavesOnSameLevel(root.Left, level +1, ref leafLevel) && AreLeavesOnSameLevel(root.Right, level + 1, ref leafLevel);
        }

        public bool IsMinHeapGivenLevel(int [] level)
        {
            for(var i = 0; i < level.Length; i++)
            {
                var root = level[i];
                //no left child, break
                if ((2 * i) + 1 >= level.Length)
                {
                    break;
                }

                var leftChild = level[(2 * i) + 1];
                var rightChild = int.MinValue;

                //has right child
                if ((2*i) + 2 < level.Length)
                {
                    rightChild = level[(2 * i) + 2];
                }

                if (root > leftChild || root > rightChild)
                {
                    return false;
                }
            }

            return true;
        }

        public bool HasSameLeafTraversal(TreeNodes<int> root1, TreeNodes<int> root2)
        {
            var stack1 = new Stack<TreeNodes<int>>();
            var stack2 = new Stack<TreeNodes<int>>();

            stack1.Push(root1);
            stack2.Push(root2);

            while(stack1.Count > 0 || stack2.Count > 0)
            {
                //one of the stacks have extra leaves if other is empty
                if (stack1.Count == 0 || stack2.Count == 0)
                {
                    return false;
                }

                var tmp1 = stack1.Pop();
                while(tmp1 != null && (tmp1.Left != null || tmp1.Right != null))
                {
                    if (tmp1.Right != null)
                    {
                        stack1.Push(tmp1.Right);
                    }

                    if (tmp1.Left != null)
                    {
                        stack1.Push(tmp1.Left);
                    }

                    tmp1 = stack1.Pop();
                }

                var tmp2 = stack2.Pop();
                while (tmp2 != null && (tmp2.Left != null || tmp2.Right != null))
                {
                    if (tmp2.Right != null)
                    {
                        stack2.Push(tmp2.Right);
                    }

                    if (tmp2.Left != null)
                    {
                        stack2.Push(tmp2.Left);
                    }

                    tmp2 = stack2.Pop();
                }
                
                if ((tmp1 == null && tmp2 != null) || (tmp1 != null && tmp2 == null) || (tmp1 != null && tmp2 != null && tmp1.Data != tmp2.Data))
                {
                    return false;
                }
            }
            return true;
        }

        private bool AreSiblings(TreeNodes<int> root, TreeNodes<int> sibling1, TreeNodes<int> sibling2)
        {
            if (root == null || (root.Left == null && root.Right == null))
            {
                return false;
            }

            if ((root.Left == sibling1 && root.Right == sibling2) || (root.Left == sibling2 && root.Right == sibling1))
            {
                return true;
            }

            return AreSiblings(root.Left, sibling1, sibling2) || AreSiblings(root.Right, sibling1, sibling2);
        }

        private int Sum(TreeNodes<int> root)
        {
            if (root == null)
            {
                return 0;
            }

            return Sum(root.Left) + Sum(root.Right) + root.Data;
        }
    }
}
