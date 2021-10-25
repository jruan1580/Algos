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
            foreach (var level in levelOrder)
            {
                var nodes = level.Value;
                foreach (var node in nodes)
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

            return AreLeavesOnSameLevel(root.Left, level + 1, ref leafLevel) && AreLeavesOnSameLevel(root.Right, level + 1, ref leafLevel);
        }

        public bool IsMinHeapGivenLevel(int[] level)
        {
            for (var i = 0; i < level.Length; i++)
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
                if ((2 * i) + 2 < level.Length)
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

            while (stack1.Count > 0 || stack2.Count > 0)
            {
                //one of the stacks have extra leaves if other is empty
                if (stack1.Count == 0 || stack2.Count == 0)
                {
                    return false;
                }

                var tmp1 = stack1.Pop();
                while (tmp1 != null && (tmp1.Left != null || tmp1.Right != null))
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

        public bool IsPerfectTree(TreeNodes<int> root, int level, int depth)
        {
            if (root == null)
            {
                return true;
            }

            //not perfect since found node without 2 children
            if ((root.Left != null && root.Right == null) || (root.Left == null && root.Right != null))
            {
                return false;
            }

            //leaf node, check level and depth
            if (root.Left == null && root.Right == null)
            {
                return (depth == level);
            }

            return (IsPerfectTree(root.Left, level + 1, depth) && IsPerfectTree(root.Right, level + 1, depth));
        }

        public bool IsFullBinaryTree(TreeNodes<int> root)
        {
            if ((root == null) || (root.Left == null && root.Right == null))
            {
                return true;
            }

            if ((root.Left != null && root.Right == null) || (root.Left == null && root.Right != null))
            {
                return false;
            }

            return IsFullBinaryTree(root.Left) && IsFullBinaryTree(root.Right);
        }

        public bool IsFullBinaryTreeIterative(TreeNodes<int> root)
        {
            if (root == null || (root.Left == null && root.Right == null))
            {
                return true;
            }

            var stack = new Stack<TreeNodes<int>>();
            var curr = root;

            //in order traversal to check all nodes.
            while (curr != null || stack.Count > 0)
            {
                if (curr != null)
                {
                    //check if it has 2 children
                    if ((curr.Left != null && curr.Right == null) || (curr.Left == null && curr.Right != null))
                    {
                        return false;
                    }

                    //push into stack and go left
                    stack.Push(curr);
                    curr = curr.Left;
                }
                else
                {
                    curr = stack.Pop();
                    curr = curr.Right; //go right
                }
            }

            return true;
        }

        public bool IsCompleteIterative(TreeNodes<int> root)
        {
            if (root == null)
            {
                return true;
            }

            var queue = new Queue<TreeNodes<int>>();
            queue.Enqueue(root);
            var encounteredNonFull = false;

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                //if left is null and right is not, already not complete
                if (node.Left == null && node.Right != null)
                {
                    return false;
                }

                //already encountered non full node, rest must be leaf
                if (encounteredNonFull && (node.Left != null || node.Right != null))
                {
                    return false;
                }

                if (node.Left != null)
                {
                    queue.Enqueue(node.Left);
                }
                else
                {
                    encounteredNonFull = true;
                }

                if (node.Right != null)
                {
                    queue.Enqueue(node.Right);
                }
                else
                {
                    encounteredNonFull = true;
                }
            }

            return true;
        }

        public bool IsSubTree(TreeNodes<int> root1, TreeNodes<int> root2)
        {
            //finish traversing tree 2 and see it is part of bigger tree 1
            if (root2 == null && root1 != null)
            {
                return true;
            }

            //subtree bigger than base tree
            if (root1 == null && root2 != null)
            {
                return false;
            }

            //check at current node to see if identical
            if (IsIdentical(root1, root2))
            {
                return true;
            }

            return IsSubTree(root1.Left, root2) || IsSubTree(root1.Right, root2);
        }

        public bool HasDuplicates(TreeNodes<int> root)
        {
            var tracker = new HashSet<int>();

            var stack = new Stack<TreeNodes<int>>();
            var curr = root;

            while (curr != null || stack.Count > 0)
            {
                if (curr != null)
                {
                    if (tracker.Contains(curr.Data))
                    {
                        return false;
                    }

                    tracker.Add(curr.Data);
                    curr = curr.Left;
                }
                else
                {
                    curr = stack.Pop();
                    curr = curr.Right;
                }
            }

            return true;
        }

        public string HasDuplicateSubtreeOfSizeTwoOrMore(TreeNodes<int> root, HashSet<string> subtreeHash)
        {
            if (root == null)
            {
                return "$";
            }

            var leftStr = HasDuplicateSubtreeOfSizeTwoOrMore(root.Left, subtreeHash);
            if (leftStr == string.Empty)
            {
                return string.Empty;
            }

            var rightStr = HasDuplicateSubtreeOfSizeTwoOrMore(root.Right, subtreeHash);
            if (rightStr == string.Empty)
            {
                return string.Empty;
            }

            var str = root.Data + leftStr + rightStr;
            if (subtreeHash.Contains(str) && str.Length > 3)
            {
                return string.Empty;
            }

            subtreeHash.Add(str);
            return str;
        }

        public bool TwoTreesAreMirror(TreeNodes<int> root1, TreeNodes<int> root2)
        {
            if (root1 == null && root2 == null)
            {
                return true;
            }

            if ((root1 != null && root2 == null) || (root1 == null && root2 != null))
            {
                return false;
            }

            return root1.Data == root2.Data && TwoTreesAreMirror(root1.Left, root2.Right) && TwoTreesAreMirror(root1.Right, root2.Left);
        }

        public bool TwoTreesAreMirrorIterative(TreeNodes<int> root1, TreeNodes<int> root2)
        {
            if (root1 == null && root2 == null)
            {
                return true;
            }

            if ((root1 != null && root2 == null) || (root1 == null && root2 != null))
            {
                return false;
            }

            var stack1 = new Stack<TreeNodes<int>>();
            var stack2 = new Stack<TreeNodes<int>>();

            var curr1 = root1;
            var curr2 = root2;

            while ((curr1 != null && curr2 != null) || (stack1.Count > 0 && stack2.Count > 0))
            {
                if ((curr1 == null && curr2 != null) || (curr1 != null && curr2 == null))
                {
                    return false;
                }

                if (curr1 != null && curr2 != null)
                {
                    if (curr1.Data != curr2.Data)
                    {
                        return false;
                    }

                    stack1.Push(curr1);
                    curr1 = curr1.Left;

                    stack2.Push(curr2);
                    curr2 = curr2.Right;
                }
                else
                {
                    curr1 = stack1.Pop();
                    curr1 = curr1.Right;

                    curr2 = stack2.Pop();
                    curr2 = curr2.Left;
                }
            }

            return true;
        }

        public bool IsIdentical(TreeNodes<int> root1, TreeNodes<int> root2)
        {
            if (root1 == null && root2 == null)
            {
                return true;
            }

            if ((root1 != null && root2 == null) || (root1 == null && root2 != null) || (root1.Data != root2.Data))
            {
                return false;
            }

            return IsIdentical(root1.Left, root2.Left) && IsIdentical(root1.Right, root2.Right);
        }

        public bool IsIdenticalIterative(TreeNodes<int> root1, TreeNodes<int> root2)
        {
            var stack1 = new Stack<TreeNodes<int>>();
            var stack2 = new Stack<TreeNodes<int>>();

            stack1.Push(root1);
            stack2.Push(root2);

            while (stack1.Count > 0 && stack2.Count > 0)
            {
                var n1 = stack1.Pop();
                var n2 = stack2.Pop();

                if (n1.Data != n2.Data)
                {
                    return false;
                }

                if ((n1.Right != null && n2.Right == null) || (n1.Right == null && n2.Right != null))
                {
                    return false;
                }

                if (n1.Right != null && n2.Right != null)
                {
                    stack1.Push(n1.Right);
                    stack2.Push(n2.Right);
                }

                if ((n1.Left != null && n2.Left == null) || (n1.Left == null && n2.Left != null))
                {
                    return false;
                }

                if (n1.Left != null && n2.Left != null)
                {
                    stack1.Push(n1.Left);
                    stack2.Push(n2.Left);
                }
            }

            return true;
        }

        public bool IsSymmetrical(TreeNodes<int> root)
        {
            return TwoTreesAreMirror(root, root);
        }

        public bool IsSymmetricalIterative(TreeNodes<int> root)
        {
            if (root == null)
            {
                return true;
            }

            var queue = new Queue<TreeNodes<int>>();
            queue.Enqueue(root.Left);
            queue.Enqueue(root.Right);

            while (queue.Count > 0)
            {
                var left = queue.Dequeue();
                var right = queue.Dequeue();

                if (left == null && right == null)
                {
                    continue;
                }

                if ((left == null && right != null) || (left != null && right == null) || (left.Data != right.Data))
                {
                    return false;
                }

                queue.Enqueue(left.Left);
                queue.Enqueue(right.Right);
                queue.Enqueue(left.Right);
                queue.Enqueue(right.Left);
            }

            return true;
        }

        public bool ContainsSequence(TreeNodes<int> root, int[] arr, int index)
        {
            //reach end before we finish traversing sequence
            if (root == null && index < arr.Length)
            {
                return false;
            }

            if (root.Data != arr[index])
            {
                return false;
            }

            //end of sequence
            if (index == arr.Length - 1)
            {

                //not a leaf node
                if (root.Left != null || root.Right != null)
                {
                    return false;
                }

                return true;
            }

            return (root.Data == arr[index] && (ContainsSequence(root.Left, arr, index + 1) || ContainsSequence(root.Right, arr, index + 1)));
        }

        public void PrintMiddleWithoutHeight(TreeNodes<int> slow, TreeNodes<int> fast)
        {
            if (slow == null || fast == null)
            {
                return;
            }

            if (fast.Left == null && fast.Right == null)
            {
                Console.Write(slow.Data + " ");
                return;
            }

            if (fast.Left.Left != null)
            {
                PrintMiddleWithoutHeight(slow.Left, fast.Left.Left);
                PrintMiddleWithoutHeight(slow.Right, fast.Left.Left);
            }
            else
            {
                PrintMiddleWithoutHeight(slow.Left, fast.Left);
                PrintMiddleWithoutHeight(slow.Right, fast.Left);
            }
        }

        public void PrintRootToLeavePaths(TreeNodes<int> root, List<int> path, int index)
        {
            if (root == null)
            {
                return;
            }

            //leaf
            if (root.Left == null && root.Right == null)
            {

                for (var i = 0; i < index; i++)
                {
                    Console.Write(path[i] + " ");
                }

                Console.Write(root.Data);
                Console.Write("\n");
                return;
            }

            path.Insert(index, root.Data);

            if (root.Left != null)
            {
                PrintRootToLeavePaths(root.Left, path, index + 1);
            }

            if (root.Right != null)
            {
                PrintRootToLeavePaths(root.Right, path, index + 1);
            }
        }

        public void PrintRootToLeavePathsIterative(TreeNodes<int> root)
        {
            var parent = new Dictionary<TreeNodes<int>, TreeNodes<int>>();

            var stack = new Stack<TreeNodes<int>>();
            stack.Push(root);
            parent.Add(root, null); //parent to root is null

            while (stack.Count > 0)
            {
                var n = stack.Pop();
                if (n == null)
                {
                    continue;
                }

                //is leaf node
                if (n.Left == null && n.Right == null)
                {
                    PrintParentToLeave(n, parent);
                    Console.Write("\n");
                }

                if (n.Right != null)
                {
                    parent.Add(n.Right, n);
                    stack.Push(n.Right);
                }

                if (n.Left != null)
                {
                    parent.Add(n.Left, n);
                    stack.Push(n.Left);
                }
            }
        }

        public void PrintLongestPathRootToLeaf(TreeNodes<int> root, List<int> path, int index, int maxDepth, ref bool longestPathFound)
        {
            if (root == null || longestPathFound)
            {
                return;
            }

            //is leaf node
            if (root.Left == null && root.Right == null)
            {
                //check if path so far is equal to depth
                if (index + 1 != maxDepth)
                {
                    return;
                }

                //found longest path, print and set longestPathFound to true
                for (var i = 0; i < index; i++)
                {
                    Console.Write(path[i] + " ");
                }

                Console.Write(root.Data);
                Console.Write("\n");
                longestPathFound = true;
                return;
            }

            path.Insert(index, root.Data);

            if (root.Left != null)
            {
                PrintLongestPathRootToLeaf(root.Left, path, index + 1, maxDepth, ref longestPathFound);
            }

            if (root.Right != null)
            {
                PrintLongestPathRootToLeaf(root.Right, path, index + 1, maxDepth, ref longestPathFound);
            }
        }

        public void PrintRootToNodePath(TreeNodes<int> root, TreeNodes<int> node, List<int> path, int index)
        {
            if (root == null)
            {
                return;
            }

            if (root == node)
            {
                for (var i = 0; i < index; i++)
                {
                    Console.Write(path[i] + " ");
                }

                Console.Write(root.Data);
                Console.Write("\n");
                return;
            }

            path.Insert(index, root.Data);

            if (root.Left != null)
            {
                PrintRootToNodePath(root.Left, node, path, index + 1);
            }

            if (root.Right != null)
            {
                PrintRootToNodePath(root.Right, node, path, index + 1);
            }
        }

        public TreeNodes<int> FindMirrorNodeOfTarget(TreeNodes<int> target, TreeNodes<int> left, TreeNodes<int> right)
        {
            if (left == null || right == null)
            {
                return null;
            }

            if (left == target)
            {
                return right;
            }

            if (right == target)
            {
                return left;
            }

            //check outer 
            var mirrorNode = FindMirrorNodeOfTarget(target, left.Left, right.Right);
            //was found
            if (mirrorNode != null)
            {
                return mirrorNode;
            }

            //check inner
            return FindMirrorNodeOfTarget(target, left.Right, right.Left);
        }

        public bool GetSinglyNodeSubtreeCount(TreeNodes<int> root, ref int count)
        {
            if (root == null)
            {
                return true;
            }

            var isSinglyLeft = GetSinglyNodeSubtreeCount(root.Left, ref count);
            var isSinglyRight = GetSinglyNodeSubtreeCount(root.Right, ref count);

            if (isSinglyLeft == false || isSinglyRight == false)
            {
                return false;
            }

            //check left data and current node same if left exists
            if (root.Left != null && root.Left.Data != root.Data)
            {
                return false;
            }

            if (root.Right != null && root.Right.Data != root.Data)
            {
                return false;
            }

            count += 1; //inc subtree count
            return true;
        }

        public List<TreeNodes<int>> FindRootOfLargestIdenticalSub(TreeNodes<int> root, TreeNodes<int> largestRoot)
        {
            if (root == null)
            {
                return new List<TreeNodes<int>>();
            }

            var leftChilds = FindRootOfLargestIdenticalSub(root.Left, largestRoot);
            var rightChilds = FindRootOfLargestIdenticalSub(root.Right, largestRoot);

            var currNodeList = new List<TreeNodes<int>>();
            currNodeList.AddRange(leftChilds);
            currNodeList.Add(root);
            currNodeList.AddRange(rightChilds);

            //not identical since not equal amount of nodes
            if (leftChilds.Count != rightChilds.Count)
            {
                return currNodeList;
            }

            //check each node and position
            for (var i = 0; i < leftChilds.Count; i++)
            {
                //not same
                if (leftChilds[i].Data != rightChilds[i].Data)
                {
                    return currNodeList;
                }
            }

            largestRoot = root; //set largest root to current
            return currNodeList;
        }

        public int FindClosestLeafToNode(TreeNodes<int> root, TreeNodes<int> n)
        {
            var minDistToLeaf = int.MaxValue;
            //node is a leaf
            if (n.Left == null && n.Right == null)
            {
                return 0;
            }

            //node is root
            if (root == n)
            {
                return FindMinDepth(root); //min depth of tree is the dist
            }

            //find whether node is in left or right subtree
            if (NodeExists(root.Left, n))
            {
                //if left subtree, find min depth to root of right subtree
                //plus one to include depth of left to root
                var rightMinDepth = FindMinDepth(root.Right) + 1;
                //find distance from root to node oh left side
                var distToNode = FindDistanceFromNodeAToNodeB(root.Left, n) + 1;
                var rightLeafToNodeDist = rightMinDepth + distToNode;
                //find min depth from node
                var minDepthFromNode = FindMinDepth(n);
                minDistToLeaf = Math.Min(rightLeafToNodeDist, minDepthFromNode);
            }
            else if (NodeExists(root.Right, n))
            {
                //if right subtree, find min depth to root of left subtree
                var leftMinDepth = FindMinDepth(root.Left) + 1;
                //find distance from root to node oh right side
                var distToNode = FindDistanceFromNodeAToNodeB(root.Right, n) + 1;
                var leftLeafToNodeDist = leftMinDepth + distToNode;
                var minDepthFromNode = FindMinDepth(n);
                minDistToLeaf = Math.Min(leftLeafToNodeDist, minDepthFromNode);
            }
            else
            {
                return int.MaxValue;//node does not exist
            }

            return minDistToLeaf;
        }

        public void MaximumDistinctNodeInRootToLeave(TreeNodes<int> root, HashSet<int> unique, ref int max)
        {
            if (root == null)
            {
                return;
            }

            //leaf
            if (root.Left == null && root.Right == null)
            {
                if (!unique.Contains(root.Data))
                {
                    unique.Add(root.Data);
                }

                max = Math.Max(max, unique.Count);

                //remove last one
                unique.Remove(root.Data);
                return;
            }

            //not leaf, add only if hashset dont contain it
            if (!unique.Contains(root.Data))
            {
                unique.Add(root.Data);
            }

            MaximumDistinctNodeInRootToLeave(root.Left, unique, ref max);
            MaximumDistinctNodeInRootToLeave(root.Right, unique, ref max);

            unique.Remove(root.Data);
        }

        public int MaxConsecutiveLength(TreeNodes<int> root, int prev_val, int prev_max)
        {
            if (root == null)
            {
                return prev_max;
            }

            if (root.Data == prev_val + 1)
            {
                return Math.Max(MaxConsecutiveLength(root.Left, root.Data, prev_max + 1), MaxConsecutiveLength(root.Right, root.Data, prev_max + 1));    
            }

            var newLen = Math.Max(MaxConsecutiveLength(root.Left, root.Data, 1), MaxConsecutiveLength(root.Right, root.Data, 1));

            return Math.Max(prev_max, newLen);
        }

        public int LongestPathOfSameVal(TreeNodes<int> root, ref int max)
        {
            if (root == null)
            {
                return 0;
            }

            var leftLen = LongestPathOfSameVal(root.Left, ref max);
            var rightLen = LongestPathOfSameVal(root.Right, ref max);

            if (root.Left != null && root.Left.Data == root.Data)
            {
                leftLen += 1;
            }

            if (root.Right != null && root.Right.Data == root.Data)
            {
                rightLen += 1;
            }

            max = Math.Max(max, leftLen + rightLen);
            
            //if we dont have a match with either children
            if ((root.Left != null && root.Left.Data != root.Data) && (root.Right != null && root.Right.Data != root.Data))
            {
                return 0; //reset longest path
            }
            
            //only left match, return leftLen
            if ((root.Left != null && root.Left.Data == root.Data) && (root.Right == null || root.Right.Data != root.Data))
            {
                return leftLen;
            }

            //only right match
            if ((root.Left == null || root.Left.Data != root.Data) && (root.Right != null && root.Right.Data == root.Data))
            {
                return rightLen;
            }

            //both left and right match, return longest one between the two.
            return Math.Max(leftLen, rightLen);
        }

        public TreeNodes<int> RemoveNodeLessThanKLen(TreeNodes<int> root, int level, int k)
        {
            if (root == null)
            {
                return null;
            }

            var leftNode = RemoveNodeLessThanKLen(root.Left, level + 1, k);
            var rightNode = RemoveNodeLessThanKLen(root.Right, level + 1, k);

            root.Left = leftNode;
            root.Right = rightNode;

            //leaf node less than k length, remove
            if (root.Left == null && root.Right == null && level < k)
            {
                return null;
            }

            return root;
        }

        public void FirstNonMatchingLeafNode(TreeNodes<int> root1, TreeNodes<int> root2)
        {
            if (root1 == null || root2 == null)
            {
                return;
            }

            var stack1 = new Stack<TreeNodes<int>>();
            var stack2 = new Stack<TreeNodes<int>>();

            stack1.Push(root1);
            stack2.Push(root2);

            while(stack1.Count > 0 || stack2.Count > 0)
            {
                if (stack1.Count == 0 || stack2.Count == 0)
                {
                    return;
                }

                var tmp1 = stack1.Pop();
                while(tmp1 != null && !(tmp1.Left == null && tmp1.Right == null))
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
                while(tmp2 != null && !(tmp2.Left == null && tmp2.Right == null))
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

                if (tmp1 != null && tmp2 != null && tmp1.Data != tmp2.Data)
                {
                    Console.WriteLine(tmp1.Data + " " + tmp2.Data);
                    return;
                }
            }
        }

        public TreeNodes<int> FindNextRight(TreeNodes<int> root, TreeNodes<int> n, int currLevel, ref int levelOfN)
        {
            if (root == null)
            {
                return null;
            }

            //found first element
            if (n == root)
            {
                levelOfN = currLevel;
                return null;
            }

            if (levelOfN != -1 && currLevel == levelOfN && root != n)
            {
                return root;
            }

            var foundNodeOnLeft = FindNextRight(root.Left, n, currLevel + 1, ref levelOfN);
            if (foundNodeOnLeft != null)
            {
                return foundNodeOnLeft;
            }

            return FindNextRight(root.Right, n, currLevel + 1, ref levelOfN);
        }

        public bool NodeExists(TreeNodes<int> root, TreeNodes<int> n)
        {
            if (root == null)
            {
                return false;
            }

            if (root == n)
            {
                return true;
            }

            return NodeExists(root.Left, n) || NodeExists(root.Right, n);
        }

        public int FindLeftmostDepth(TreeNodes<int> root) 
        {
            var d = 0;
            var node = root;
            while (node != null)
            {
                d++;
                node = node.Left;
            }

            return d;
        }      

        public int FindMaxDepth(TreeNodes<int> root)
        {
            if (root == null)
            {
                return 0;
            }

            var leftDepth = FindMaxDepth(root.Left);
            var rightDepth = FindMaxDepth(root.Right);

            return Math.Max(1 + leftDepth, 1 + rightDepth);
        }

        public int FindMinDepth(TreeNodes<int> root)
        {
            if (root == null)
            {
                return 0;
            }

            if (root.Left == null && root.Right == null)
            {
                return 0;
            }

            var leftDepth = FindMinDepth(root.Left);
            var rightDepth = FindMinDepth(root.Right);

            return 1 + Math.Min(leftDepth, rightDepth);
        }

        public int FindDistanceFromNodeAToNodeB(TreeNodes<int> a, TreeNodes<int> b)
        {
            if (a == b)
            {
                return -1;
            }

            if (a == b)
            {
                return 0;
            }

            var leftDistance = FindDistanceFromNodeAToNodeB(a.Left, b);
            var rightDistance = FindDistanceFromNodeAToNodeB(a.Right, b);
           
            if (leftDistance == -1 && rightDistance == -1)
            {
                return -1;
            }

            return (leftDistance != -1) ? 1 + leftDistance : 1 + rightDistance;
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

        private void PrintParentToLeave(TreeNodes<int> leaf, Dictionary<TreeNodes<int>, TreeNodes<int>> parent)
        {
            var curr = leaf;
            var stack = new Stack<int>();
            while (curr != null)
            {
                stack.Push(curr.Data);
                curr = parent[curr]; //get current nodes parent
            }

            while (stack.Count > 0)
            {
                Console.Write(stack.Pop() + " ");
            }
        }
    }
}
