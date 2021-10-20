using DataStructures;
using System;
using System.Collections.Generic;
using System.Text;

namespace Trees.Problems
{
    public class Summation
    {
        public int SumOfTree(TreeNodes<int> root)
        {
            if (root == null)
            {
                return 0;
            }

            return root.Data + SumOfTree(root.Left) + SumOfTree(root.Right);
        }

        public int SumOfNodesWithChildN(TreeNodes<int> root, int n)
        {
            if (root == null)
            {
                return 0;
            }

            var leftSum = SumOfNodesWithChildN(root.Left, n);
            var rightSum = SumOfNodesWithChildN(root.Right, n);

            var currSum = 0;
            if ((root.Left != null && root.Left.Data == n) || (root.Right != null && root.Right.Data == n))
            {
                currSum += root.Data;
            }

            return currSum + leftSum + rightSum;
        }

        public int SumOfAllLeftLeaf(TreeNodes<int> root)
        {
            if (root == null)
            {
                return 0;
            }

            var result = 0;
            //left sub a leaf
            if (root.Left != null && root.Left.Left == null && root.Left.Right == null)
            {
                result += root.Left.Data;
            }
            else
            {
                result += SumOfAllLeftLeaf(root.Left);
            }

            result += SumOfAllLeftLeaf(root.Right);
            return result;
        }

        public int SumOfAllRightLeaf(TreeNodes<int> root)
        {
            if (root == null)
            {
                return 0;
            }

            var result = 0;
            //right sub a leaf
            if (root.Right != null && root.Right.Right == null && root.Right.Right == null)
            {
                result += root.Right.Data;
            }
            else
            {
                result += SumOfAllRightLeaf(root.Right);
            }

            result += SumOfAllRightLeaf(root.Left);
            return result;
        }

        public int SumOfPerfectTreeGivenLevel(int l)
        {
            var numOfLeafNodes = (int)Math.Pow(2, l - 1);

            var sumOfLeaves = (numOfLeafNodes * (numOfLeafNodes + 1)) / 2;

            return sumOfLeaves * l;
        }

        public void DiagonalSum(TreeNodes<int> root)
        {
            var dict = new Dictionary<int, List<TreeNodes<int>>>();

            var traversal = new Traversals();
            traversal.PrintDiagonalTraversal(root, 0, dict);

            foreach(var obj in dict)
            {
                var nodes = obj.Value;
                var sum = 0;
                foreach(var n in nodes)
                {
                    sum += n.Data;
                }

                Console.WriteLine(sum);
            }
        }

        public bool HasPairNodeEqualToRoot(TreeNodes<int> root, HashSet<int> tracker, int target)
        {            
            if (root == null)
            {
                return false;
            }

            if (tracker.Contains(target - root.Data))
            {
                return true;
            }

            tracker.Add(root.Data);
            var res = HasPairNodeEqualToRoot(root.Left, tracker, target) || HasPairNodeEqualToRoot(root.Right, tracker, target);
            tracker.Remove(root.Data);

            return res;
        }

        public int SumOfLongestRootToLeafPath(TreeNodes<int> root, int maxDepth, List<int> path)
        {
            if (root == null)
            {
                return 0;
            }

            if (root.Left == null && root.Right == null)
            {
                path.Add(root.Data);
                if (path.Count != maxDepth)
                {
                    path.Remove(root.Data);
                    return 0;
                }

                var sum = 0;
                foreach(var num in path)
                {
                    sum += num;
                }

                path.Remove(root.Data);
                return sum;
            }

            var leftSum = 0;
            var rightSum = 0;
            path.Add(root.Data);
            if (root.Left != null)
            {
                leftSum += SumOfLongestRootToLeafPath(root.Left, maxDepth, path);
            }

            if (root.Right != null)
            {
                rightSum += SumOfLongestRootToLeafPath(root.Right, maxDepth, path);
            }

            path.Remove(root.Data);
            return leftSum + rightSum;
        }

        public void PrintPathOfMaxSum(TreeNodes<int> root)
        {
            var allPaths = new List<List<int>>();
            
            GetAllPaths(root, new List<int>(), allPaths);

            var index = 0;
            var maxSum = int.MinValue;

            for(var i = 0; i < allPaths.Count; i++)
            {
                var sum = 0;
                foreach(var data in allPaths[i])
                {
                    sum += data;
                }

                if (sum > maxSum)
                {
                    maxSum = sum;
                    index = i;
                }
            }

            var maxPath = allPaths[index];
            foreach(var data in maxPath)
            {
                Console.Write(data + " ");
            }
        }

        public int MaxSumFromLeafToLeaf(TreeNodes<int> root, ref int maxSum)
        {
            if (root == null)
            {
                return 0;
            }

            if (root.Left == null && root.Right == null)
            {
                return root.Data;
            }

            var ls = MaxSumFromLeafToLeaf(root.Left, ref maxSum);
            var rs = MaxSumFromLeafToLeaf(root.Right, ref maxSum);

            if (root.Left != null && root.Right != null)
            {
                maxSum = Math.Max(maxSum, root.Data + ls + rs);

                return Math.Max(ls, rs) + root.Data;
            }

            return (root.Left == null) ? root.Data + rs : root.Data + ls;
        }

        public int MaxSumOfNonAdjacentLevels(TreeNodes<int> root)
        {
            if (root == null)
            {
                return 0;
            }

            return Math.Max(SumAlternateLevels(root), (SumAlternateLevels(root.Left) + SumAlternateLevels(root.Right)));
        }

        public int SumAlternateLevels(TreeNodes<int> root)
        {
            if (root == null)
            {
                return 0;
            }

            var sum = 0;
            if (root.Left != null)
            {
                sum += SumAlternateLevels(root.Left.Left);
                sum += SumAlternateLevels(root.Left.Right);
            }

            if (root.Right != null)
            {
                sum += SumAlternateLevels(root.Right.Left);
                sum += SumAlternateLevels(root.Right.Right);
            }

            return sum;
        }

        public int LargestSubtreeSum(TreeNodes<int> root, ref int maxSum)
        {
            if (root == null)
            {
                return 0;
            }

            if (root.Left == null && root.Right == null)
            {
                return root.Data;
            }

            var left = LargestSubtreeSum(root.Left, ref maxSum);
            var right = LargestSubtreeSum(root.Right, ref maxSum);

            maxSum = Math.Max(maxSum, root.Data + left + right);

            return root.Data + left + right;
        }

        public void GetAllPaths(TreeNodes<int> root, List<int> currPath, List<List<int>> allPaths)
        {
            if (root == null)
            {
                return;
            }

            if (root.Left == null && root.Right == null)
            {
                var path = new List<int>();
                path.AddRange(currPath);
                path.Add(root.Data);
                allPaths.Add(path);              
                return;
            }

            currPath.Add(root.Data);
            if (root.Left != null)
            {
                GetAllPaths(root.Left, currPath, allPaths);
            }

            if (root.Right != null)
            {
                GetAllPaths(root.Right, currPath, allPaths);
            }

            if (currPath.Count > 0)
            {
                currPath.RemoveAt(currPath.Count - 1); //remove last again
            }
            
        }
    }
}
