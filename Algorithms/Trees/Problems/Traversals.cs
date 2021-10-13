using DataStructures;
using System;
using System.Collections.Generic;
using System.Text;

namespace Trees.Problems
{
    public class Traversals
    {
        public void InOrderTraversalRecursively(TreeNodes<int> root)
        {
            if (root == null)
            {
                return;
            }

            InOrderTraversalRecursively(root.Left);
            Console.Write(root.Data + " ");
            InOrderTraversalRecursively(root.Right);
        }

        public void InOrderTraversalIterative(TreeNodes<int> root)
        {
            if (root == null)
            {
                return;
            }

            var stack = new Stack<TreeNodes<int>>();

            var curr = root;
            while(stack.Count > 0 || curr != null)
            {
                if (curr != null)
                {
                    stack.Push(curr);
                    curr = curr.Left;
                }
                else
                {
                    curr = stack.Pop();
                    Console.Write(curr.Data + " ");
                    curr = curr.Right;
                }                
            }
        }

        public void PreOrderTraversalRecursively(TreeNodes<int> root)
        {
            if (root == null)
            {
                return;
            }

            Console.Write(root.Data + " ");
            PreOrderTraversalRecursively(root.Left);
            PreOrderTraversalRecursively(root.Right);
        }

        public void PreOrderTraversalIterative(TreeNodes<int> root)
        {
            if (root == null)
            {
                return;
            }

            var stack = new Stack<TreeNodes<int>>();
            stack.Push(root);
            
            while(stack.Count > 0)
            {
                var node = stack.Pop();
                Console.Write(node.Data + " ");
                if (node.Right != null)
                {
                    stack.Push(node.Right);
                }

                if (node.Left != null)
                {
                    stack.Push(node.Left);
                }               
            }
        }

        public void PostOrderTraversalRecursively(TreeNodes<int> root)
        {
            if(root == null)
            {
                return;
            }

            PostOrderTraversalRecursively(root.Left);
            PostOrderTraversalRecursively(root.Right);
            Console.Write(root.Data + " ");
        }

        public void PostOrderTraversalIterative(TreeNodes<int> root)
        {
            if (root == null)
            {
                return;
            }
            
            var s1 = new Stack<TreeNodes<int>>();
            var s2 = new Stack<TreeNodes<int>>();

            s1.Push(root);
            while(s1.Count > 0)
            {
                var node = s1.Pop();
                s2.Push(node);
                if (node.Left != null)
                {
                    s1.Push(node.Left);
                }

                if (node.Right != null)
                {
                    s1.Push(node.Right);
                }
            }

            while (s2.Count > 0)
            {
                Console.Write(s2.Pop().Data + " ");
            }
        }

        public void PrintPostGivenInAndPre(int [] inOrder, int [] preOrder, int startIn, int endIn, int startPre)
        {
            if (startIn > endIn)
            {
                return;
            }          

            //find the root in inorder
            int rootIndex = Search(inOrder, startIn, endIn, preOrder[startPre]);
            //traverse left
            PrintPostGivenInAndPre(inOrder, preOrder, startIn, rootIndex - 1, startPre + 1);
            //traverse right
            PrintPostGivenInAndPre(inOrder, preOrder, rootIndex + 1, endIn, startPre + (rootIndex - startIn) + 1);
            Console.Write(inOrder[rootIndex] + " ");
        }

        public void PrintPreGivenInAndPost(int [] inOrder, int [] postOrder, int startIn, int endIn, int endPost)
        {
            if (startIn > endIn)
            {
                return;
            }

            var rootIndex = Search(inOrder, startIn, endIn, postOrder[endPost]);
            Console.Write(inOrder[rootIndex] + " ");
            //left
            PrintPreGivenInAndPost(inOrder, postOrder, startIn, rootIndex - 1, endPost - (endIn - rootIndex) - 1);
            //right
            PrintPreGivenInAndPost(inOrder, postOrder, rootIndex + 1, endIn, endPost - 1);
        }

        public void PrintInGivenPreAndPost(int [] postOrder, int [] preOrder, int startPost, int endPost, int startPre, int endPre)
        {
            if (startPre > endPre)
            {
                return;
            }

            if (startPre + 1 > endPre)
            {
                Console.Write(preOrder[startPre] + " ");
                return;
            }

            //traverse all the way left first
            var nextRoot = preOrder[startPre + 1];
            var indexOfNextRootInPost = Search(postOrder, startPost, endPost, nextRoot);
            //everything to the left of next root in post is left child
            PrintInGivenPreAndPost(postOrder, preOrder, startPost, indexOfNextRootInPost, startPre + 1, startPre + (indexOfNextRootInPost - startPost) + 1);
            //after traversing down to left, print root
            Console.Write(preOrder[startPre] + " ");
            //now traverse the right
            PrintInGivenPreAndPost(postOrder, preOrder, indexOfNextRootInPost + 1, endPost - 1, startPre + 1 + (indexOfNextRootInPost - startPost + 1), endPre);
        }

        public void PrintPostGivePreBst(int [] pre, int startPre, int endPre)
        {
            if (startPre > endPre)
            {
                return;
            }

            var root = pre[startPre];
            //find index of first element smaller than root
            var indexOfFirstSmallestEl = FindFirstLessThan(pre, root, startPre + 1, endPre);
            //find index of first element bigger than root
            var indexOfFirstBiggestEl = FindFirstGreaterThan(pre, root, startPre + 1, endPre);

            //traverse left only if there is element for left
            if (indexOfFirstSmallestEl != -1)
            {
                var end = (indexOfFirstBiggestEl == -1) ? endPre : (indexOfFirstBiggestEl - indexOfFirstSmallestEl);
                PrintPostGivePreBst(pre, indexOfFirstSmallestEl, end);
            }
            
            //traverse right only if there is element for right
            if (indexOfFirstBiggestEl != -1)
            {
                PrintPostGivePreBst(pre, indexOfFirstBiggestEl, endPre);
            }
            
            //print current
            Console.Write(root + " ");
        }

        public void SwapNodeWithSumInorderPreAndSuc(TreeNodes<int> root)
        {
            var inOrderArr = new List<int>();
            inOrderArr.Add(0);
            var stack = new Stack<TreeNodes<int>>();
            var curr = root;
            while(curr != null || stack.Count > 0)
            {
                if (curr != null)
                {
                    stack.Push(curr);
                    curr = curr.Left;
                }
                else
                {
                    curr = stack.Pop();
                    inOrderArr.Add(curr.Data);
                    curr = curr.Right;
                }
            }

            inOrderArr.Add(0);
            var i = 1;
            stack.Clear();
            curr = root;
            while(curr != null || stack.Count > 0)
            {
                if (curr != null)
                {
                    stack.Push(curr);
                    curr = curr.Left;
                }
                else
                {
                    curr = stack.Pop();
                    curr.Data = inOrderArr[i - 1] + inOrderArr[i + 1];
                    i += 1;
                    curr = curr.Right;
                }
            }
        }

        public void PrintLevelOrderTraversal(TreeNodes<int> root, int level, Dictionary<int, List<TreeNodes<int>>> tracker)
        {
            if (root == null)
            {
                return;
            }

            if (tracker.ContainsKey(level))
            {
                tracker[level].Add(root);
            }
            else
            {
                tracker.Add(level, new List<TreeNodes<int>>() { root });
            }

            //move left
            PrintLevelOrderTraversal(root.Left, level + 1, tracker);
            //move right
            PrintLevelOrderTraversal(root.Right, level + 1, tracker);

            //print everything
            //if (level == 1)
            //{
            //    foreach(var obj in tracker)
            //    {
            //        foreach(var node in obj.Value)
            //        {
            //            Console.Write(node.Data + " ");
            //        }
            //    }
            //}
        }

        public void PrintDiagonalTraversal(TreeNodes<int> root, int slope, Dictionary<int, List<TreeNodes<int>>> tracker)
        {
            if (root == null)
            {
                return;
            }

            if (tracker.ContainsKey(slope))
            {
                tracker[slope].Add(root);
            }
            else
            {
                tracker.Add(slope, new List<TreeNodes<int>>() { root });
            }

            //go left, inc. slope
            PrintDiagonalTraversal(root.Left, slope + 1, tracker);
            //go right, same slope
            PrintDiagonalTraversal(root.Right, slope, tracker);
        }

        public int FindDepthGivenNLStr(string treePattern, ref int index)
        {
            if (index >= treePattern.Length || treePattern[index] == 'l')
            {
                return 0;
            }

            index++;//go to next char
            //traverse left for left height
            var left = FindDepthGivenNLStr(treePattern, ref index);

            //now check right height
            index++;
            var right = FindDepthGivenNLStr(treePattern, ref index);

            return Math.Max(left, right) + 1;
        }

        public int FindNumOfPreorderSequence(int n)
        {
            var dp = new int[n + 1];
            Array.Fill(dp, 0);
            dp[0] = dp[1] = 1;

            for(var i = 2; i < dp.Length; i++)
            {
                for (var j = 0; j < i; j++)
                {
                    dp[i] += (dp[j] * dp[i - j - 1]);
                }
            }

            return dp[n];
        }

        private int Search(int [] arr, int start, int end, int element)
        {
            var i = start;
            for (i = start; i < end; i++)
            {
                if (arr[i] == element)
                {
                    break;
                }
            }

            return i;
        }
        private int FindFirstLessThan(int [] arr, int element, int start, int end)
        {            
            var indexFound = -1;
            for (var i = start; i <= end; i++)
            {
                if (arr[i] <= element)
                {
                    indexFound = i;
                    break;
                }
            }

            return indexFound;
        }

        private int FindFirstGreaterThan(int [] arr, int element, int start, int end)
        {
            var indexFound = -1;
            for(var i = start; i <= end; i++)
            {
                if (arr[i] > element)
                {
                    indexFound = i;
                    break;
                }                
            }

            return indexFound;
        }
    }
}
