using DataStructures;
using System;
using System.Collections.Generic;
using System.Text;

namespace Trees.Problems
{
    public class LCA
    {
        public TreeNodes<int> FindLowestCommonAncestor(TreeNodes<int> root, TreeNodes<int> n1, TreeNodes<int> n2)
        {
            if (root == null)
            {
                return null;
            }

            if (root == n1 || root == n2)
            {
                return root;
            }

            var ls = FindLowestCommonAncestor(root.Left, n1, n2);
            var rs = FindLowestCommonAncestor(root.Right, n1, n2);

            //node exists on left and right subtree making current node the connection of the two
            //thus it is the lowest common ancestor
            if (ls != null && rs != null)
            {
                return root;
            }

            return (ls == null) ? rs : ls;
        }

        public int FindDistanceBetweenTwoNodes(TreeNodes<int> root, TreeNodes<int> n1, TreeNodes<int> n2)
        {
            var lca = FindLowestCommonAncestor(root, n1, n2);

            var d1 = FindLevelFromRootToN(lca, n1, 0);
            var d2 = FindLevelFromRootToN(lca, n2, 0);

            return d1 + d2;
        }

        public TreeNodes<int> PrintAncestorToNode(TreeNodes<int> root, TreeNodes<int> n)
        {
            if (root == null)
            {
                return null;
            }

            //found it
            if (root == n)
            {
                return n;
            }

            var left = PrintAncestorToNode(root.Left, n);
            if (left == null)
            {
                var right = PrintAncestorToNode(root.Right, n);
                if (right != null)
                {
                    Console.Write(root.Data + " ");
                }
                return right;
            }
            else
            {
                Console.Write(root.Data + " ");
            }
            
            return left;
        }

        public void PrintCommonNodes(TreeNodes<int> root, TreeNodes<int> n1, TreeNodes<int> n2)
        {
            var lca = FindLowestCommonAncestor(root, n1, n2);

            PrintAncestorToNodeIterative(root, lca);

            Console.Write(lca.Data);
        }

        public int MaximumDiffOfAncestorAndChildNode(TreeNodes<int> root, ref int maxDiff)
        {
            if (root == null)
            {
                return int.MaxValue;
            }

            //leaf node
            if (root.Left == null && root.Right == null)
            {
                return root.Data;
            }

            var minLeftChild = MaximumDiffOfAncestorAndChildNode(root.Left, ref maxDiff);
            var minRighChild = MaximumDiffOfAncestorAndChildNode(root.Right, ref maxDiff);

            var minValOfChild = Math.Min(minLeftChild, minRighChild);

            maxDiff = Math.Max(root.Data - minValOfChild, maxDiff);

            //return min number between child or current node
            return Math.Min(minValOfChild, root.Data);
        }

        public void PrintAncestorToNodeIterative(TreeNodes<int> root, TreeNodes<int> n)
        {
            var parent = new Dictionary<TreeNodes<int>, TreeNodes<int>>();
            var stack = new Stack<TreeNodes<int>>();

            stack.Push(root);
            parent.Add(root, null);
            while(stack.Count > 0)
            {
                var node = stack.Pop();
                if(node == null)
                {
                    continue;
                }

                if (node == n)
                {
                    //print parents
                    var curr = n;
                    while (curr != null)
                    {
                        curr = parent[curr];
                        if (curr != null)
                        {
                            Console.Write(curr.Data + " ");
                        }                        
                    }

                    return;
                }

                if (node.Right != null)
                {
                    parent.Add(node.Right, node);
                    stack.Push(node.Right);
                }

                if (node.Left != null)
                {
                    parent.Add(node.Left, node);
                    stack.Push(node.Left);
                }
            }
        }

        public void PrintKthAncestorToNode(TreeNodes<int> root, TreeNodes<int> n, int k)
        {
            var parent = new Dictionary<TreeNodes<int>, TreeNodes<int>>();
            var stack = new Stack<TreeNodes<int>>();

            stack.Push(root);
            parent.Add(root, null);
            while (stack.Count > 0)
            {
                var node = stack.Pop();
                if (node == null)
                {
                    continue;
                }
                //found node
                if (node == n)
                {
                    //print parents
                    var curr = n;
                    var i = 0;
                    while (curr != null)
                    {
                        i += 1;
                        curr = parent[curr];
                        if (i == k && curr != null)
                        {
                            Console.WriteLine(curr.Data);
                            return;
                        }
                    }

                    Console.WriteLine("-1");//no kth ancestor
                    return;
                }

                if (node.Right != null)
                {
                    parent.Add(node.Right, node);
                    stack.Push(node.Right);
                }

                if (node.Left != null)
                {
                    parent.Add(node.Left, node);
                    stack.Push(node.Left);
                }
            }
        }

        private int FindLevelFromRootToN(TreeNodes<int> root, TreeNodes<int> n, int level)
        {
            if (root == null)
            {
                return -1;
            }

            if (root == n)
            {
                return level;
            }

            var leftLevel = FindLevelFromRootToN(root.Left, n, level + 1);
            //path from n to root exists in left side.
            if (leftLevel != -1)
            {
                return leftLevel;
            }

            //did not exist left side so go searching in right side
            return FindLevelFromRootToN(root.Right, n, level + 1);
        }

    }
}
