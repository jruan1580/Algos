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

        public void PrintAllPathWithKSum(TreeNodes<int> root, List<int> path, int k)
        {
            if (root == null)
            {
                return;
            }

            path.Add(root.Data);

            PrintAllPathWithKSum(root.Left, path, k);

            PrintAllPathWithKSum(root.Right, path, k);

            var sum = 0;
            for(var i = path.Count - 1; i >= 0; i++)
            {
                sum += path[i];
                if (sum == k)
                {
                    //print from i to end
                    for(var j = i; j < path.Count; j++)
                    {
                        Console.Write(path[j] + " ");
                    }
                    Console.Write("\n");
                }
            }

            path.RemoveAt(path.Count - 1);
        }

        public int SumOfIndividualNodeHeight(TreeNodes<int> root, ref int sum)
        {
            if (root == null)
            {
                return 0;
            }

            var lh = SumOfIndividualNodeHeight(root.Left, ref sum);
            var rh = SumOfIndividualNodeHeight(root.Right, ref sum);

            var currHeight = Math.Max(lh, rh) + 1;

            sum += lh + rh + currHeight;

            return currHeight;
        }

        public int SubTreeWithGivenSum(TreeNodes<int> root, int sum, ref bool sumFound)
        {           
            if (root == null)
            {                
                return 0;
            }

            var leftSubTreeSum = SubTreeWithGivenSum(root.Left, sum, ref sumFound);
            var rightSubTreeSum = SubTreeWithGivenSum(root.Right, sum, ref sumFound);

            var currSum = leftSubTreeSum + rightSubTreeSum + root.Data;

            if (currSum == sum)
            {
                sumFound = true;
            }

            return currSum;
        }

        public int CountSubTreeWithGivenSum(TreeNodes<int> root, int sum, ref int count)
        {
            if (root == null)
            {
                return 0;
            }

            var leftSubTreeSum = CountSubTreeWithGivenSum(root.Left, sum, ref count);
            var rightSubTreeSum = CountSubTreeWithGivenSum(root.Right, sum, ref count);

            var currSum = leftSubTreeSum + rightSubTreeSum + root.Data;

            if (currSum == sum)
            {
                count++;
            }

            return currSum;
        }

        public void SumAtMaxLevel(TreeNodes<int> root, int level, ref int maxLevel, ref int sum)
        {
            if (root == null)
            {
                return;
            }

            if (level > maxLevel)
            {
                maxLevel = level;
                sum = root.Data;
            }

            if (level == maxLevel)
            {
                sum += root.Data;
            }

            SumAtMaxLevel(root.Left, level + 1, ref maxLevel, ref sum);
            SumAtMaxLevel(root.Right, level + 1, ref maxLevel, ref sum);
        }

        public int DiffInEvenAndOddLevelSum(TreeNodes<int> root)
        {
            if (root == null)
            {
                return 0;
            }

            return Math.Abs(SumAlternateLevels(root) - (SumAlternateLevels(root.Left) + SumAlternateLevels(root.Right)));
        }

        public TreeNodes<int> MergeTwoTreeWithNodeSum(TreeNodes<int> root1, TreeNodes<int> root2)
        {
            if (root1 == null && root2 == null)
            {
                return null;
            }

            TreeNodes<int> currNode = null;
            if (root1 != null && root2 == null)
            {
                var leftRoot = MergeTwoTreeWithNodeSum(root1.Left, null);
                var rightRoot = MergeTwoTreeWithNodeSum(root1.Right, null);
                currNode = new TreeNodes<int>(root1.Data, leftRoot, rightRoot);
            }
            else if (root1 == null && root2 != null)
            {
                var leftRoot = MergeTwoTreeWithNodeSum(null, root2.Left);
                var rightRoot = MergeTwoTreeWithNodeSum(null, root2.Right);
                currNode = new TreeNodes<int>(root2.Data, leftRoot, rightRoot);
            }
            else
            {
                var leftRoot = MergeTwoTreeWithNodeSum(root1.Left, root2.Left);
                var rightRoot = MergeTwoTreeWithNodeSum(root1.Right, root2.Right);
                currNode = new TreeNodes<int>(root1.Data + root2.Data, leftRoot, rightRoot);
            }           
           
            return currNode;
        }

        public void PrintVerticalSums(TreeNodes<int> root)
        {
            var tracker = new Dictionary<int, List<TreeNodes<int>>>();

            GetVerticalPath(root, tracker, 0);

            foreach(var verticalNode in tracker)
            {
                var vertLevel = verticalNode.Key;
                var sum = 0;
                
                foreach (var node in verticalNode.Value)
                {
                    sum += node.Data;
                }
                Console.WriteLine($"level {vertLevel} - {sum}");
            }
        }

        public int FindRootGivenChildIdSum(Dictionary<int, int> pairIdChildSum)
        {
            var childSum = 0;
            var idSum = 0;
            foreach(var pair in pairIdChildSum)
            {
                idSum += pair.Key;
                childSum += pair.Value;
            }

            return idSum - childSum;
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

        private void GetVerticalPath(TreeNodes<int> root, Dictionary<int, List<TreeNodes<int>>> tracker, int vertical)
        {
            if (root == null)
            {
                return;
            }

            if (tracker.ContainsKey(vertical))
            {
                tracker[vertical].Add(root);
            }
            else
            {
                tracker.Add(vertical, new List<TreeNodes<int>>() { root });
            }

            GetVerticalPath(root.Left, tracker, vertical - 1);
            GetVerticalPath(root.Right, tracker, vertical + 1);            
        }
    }
}
