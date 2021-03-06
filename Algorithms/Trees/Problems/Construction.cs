using DataStructures;
using System;
using System.Collections.Generic;
using System.Text;

namespace Trees.Problems
{
    public class Construction
    {
        public TreeNodes<int> ConstructTreeWithInAndPre(int [] inorder, int[] preorder, int startIn, int endIn, int startPre)
        {
            if (startIn > endIn)
            {
                return null;
            }

            var rootIndex = Search(inorder, startIn, endIn, preorder[startPre]);
            var leftTreeNode = ConstructTreeWithInAndPre(inorder, preorder, startIn, rootIndex - 1, startPre + 1);
            var rightTreeNode = ConstructTreeWithInAndPre(inorder, preorder, rootIndex + 1, endIn, startPre + 1 + (rootIndex - startIn));

            var currNode = new TreeNodes<int>(inorder[rootIndex], leftTreeNode, rightTreeNode);
            return currNode;
        }
        public TreeNodes<int> ConstructTreeWithPostAndIn(int [] inorder, int[] postorder, int startIn, int endIn, int endPost)
        {
            if (startIn > endIn)
            {
                return null;
            }

            var rootIndex = Search(inorder, startIn, endIn, postorder[endPost]);
            var left = ConstructTreeWithPostAndIn(inorder, postorder, startIn, rootIndex - 1, endPost - 1 - (endIn - rootIndex));
            var right = ConstructTreeWithPostAndIn(inorder, postorder, rootIndex + 1, endIn, endPost - 1);

            return new TreeNodes<int>(inorder[rootIndex], left, right);
        }

        public TreeNodes<int> ConstructTreeWithInAndLevel(int[] inorder, int[] levelorder, int startIn, int endIn)
        {
            if (startIn > endIn)
            {
                return null;
            }
         
            var rootIndex = Search(inorder, startIn, endIn, levelorder[0]);
            var lenOfLeft = (rootIndex - startIn);
            var newLeftLevelOrder = new int[lenOfLeft];
            if (lenOfLeft > 0)
            {
                var leftIndex = 0;
                for (var i = 1; i < levelorder.Length; i++)
                {
                    for (var j = startIn; j < rootIndex; j++)
                    {
                        if (inorder[j] == levelorder[i])
                        {
                            newLeftLevelOrder[leftIndex] = levelorder[i];
                            leftIndex++;
                        }
                    }
                }
            }
           

            var lenOfRight = (endIn - rootIndex);
            var newRightLevelOrder = new int[lenOfRight];
            if (lenOfRight > 0)
            {
                var rightIndex = 0;
                for (var i = 1; i < levelorder.Length; i++)
                {
                    for (var j = rootIndex + 1; j < endIn; j++)
                    {
                        if (inorder[j] == levelorder[i])
                        {
                            newRightLevelOrder[rightIndex] = levelorder[i];
                            rightIndex++;
                        }
                    }
                }
            }          

            var left = ConstructTreeWithInAndLevel(inorder, newLeftLevelOrder, startIn, rootIndex - 1);
            var right = ConstructTreeWithInAndLevel(inorder, newRightLevelOrder, rootIndex + 1, endIn);

            return new TreeNodes<int>(inorder[rootIndex], left, right);
        }

        public TreeNodes<int> ConstructCompleteTreeWithList(ListNode<int> head)
        {
            if (head == null)
            {
                return null;
            }

            var queue = new Queue<TreeNodes<int>>();
            var root = new TreeNodes<int>(head.Data, null, null);
            queue.Enqueue(root);
            var curr = head.Next;
            var isLeft = true;
            while(curr != null)
            {
                var parentNode = queue.Peek();
                if (isLeft)
                {
                    var leftChild = new TreeNodes<int>(curr.Data, null, null);
                    parentNode.Left = leftChild;
                    queue.Enqueue(leftChild);
                    isLeft = false;

                }
                else
                {
                    var rightChild = new TreeNodes<int>(curr.Data, null, null);
                    parentNode.Right = rightChild;
                    queue.Enqueue(rightChild);
                    isLeft = true;
                    queue.Dequeue();//remove parent from queue now that even right child has been populated
                }

                curr = curr.Next;                
            }            

            return root;
        }

        public TreeNodes<int> ConstructCompleteTreeWithLevel(int[] level)
        {
            if (level.Length == 0)
            {
                return null;
            }

            var root = new TreeNodes<int>(level[0], null, null);
            var queue = new Queue<TreeNodes<int>>();
            queue.Enqueue(root);
            var i = 1;
            var isLeft = true;
            while (i < level.Length)
            {
                var parentNode = queue.Peek();
                if (isLeft)
                {
                    var leftChild = new TreeNodes<int>(level[i], null, null);
                    parentNode.Left = leftChild;
                    queue.Enqueue(leftChild);
                    isLeft = false;
                }
                else
                {
                    var rightChild = new TreeNodes<int>(level[i], null, null);
                    parentNode.Right = rightChild;
                    queue.Enqueue(rightChild);
                    isLeft = true;
                    queue.Dequeue();
                }
                i++;
            }

            return root;
        }

        public TreeNodes<int> ConstructFullBaseOnPreAndPost(int[] postOrder, int[] preOrder, int startPost, int endPost, int startPre, int endPre)
        {
            if (startPre > endPre)
            {
                return null;
            }

            if (startPre + 1 > endPre)
            {
                return new TreeNodes<int>(preOrder[startPre], null, null);
            }

            var nextRoot = preOrder[startPre + 1];
            var indexOfNextRootInPost = Search(postOrder, startPost, endPost, nextRoot);
            var leftChild = ConstructFullBaseOnPreAndPost(postOrder, preOrder, startPost, indexOfNextRootInPost, startPre + 1, startPre + 1 + (indexOfNextRootInPost - startPost));
            var rightChild = ConstructFullBaseOnPreAndPost(postOrder, preOrder, indexOfNextRootInPost + 1, endPost - 1, startPre + 1 + (indexOfNextRootInPost - startPost + 1) , endPre);
            var node = new TreeNodes<int>(preOrder[startPre], leftChild, rightChild);

            return node;
        }

        public TreeNodes<int> ConstructTreeByPreAndMirror(int [] preorder, int[] mirror, int startPre, int endPre, int startMirror, int endMirror)
        {
            if (startPre > endPre)
            {
                return null;
            }

            if (startPre + 1 > endPre)
            {
                return new TreeNodes<int>(preorder[startPre], null, null);
            }

            var nextRoot = preorder[startPre + 1];
            var indexOfNexRoot = Search(mirror, startMirror, endMirror, nextRoot);
            var leftChild = ConstructTreeByPreAndMirror(preorder, mirror, startPre + 1, startPre + (endMirror - indexOfNexRoot) + 1, indexOfNexRoot, endMirror);
            var rightChild = ConstructTreeByPreAndMirror(preorder, mirror, startPre + 1 + (endMirror - indexOfNexRoot + 1), endPre, startMirror + 1, indexOfNexRoot - 1);

            return new TreeNodes<int>(preorder[startPre], leftChild, rightChild);
        }

        public TreeNodes<int> ConstructSpecialTreeGivenPreNL(int [] preoder, char [] nl, ref int index)
        {
            if (index >= nl.Length)
            {
                return null;
            }

            if (index >= nl.Length || nl[index] == 'L')
            {
                return new TreeNodes<int>(preoder[index], null, null);
            }

            var current = preoder[index];

            index++;
            var left = ConstructSpecialTreeGivenPreNL(preoder, nl, ref index);

            index++;
            var right = ConstructSpecialTreeGivenPreNL(preoder, nl, ref index);

            return new TreeNodes<int>(current, left, right);
        }

        public TreeNodes<int> SpecialWithInNodeGreaterThanKids(int[] inorder, int startIn, int endIn)
        {
            if (startIn > endIn)
            {
                return null;
            }

            var maxIndex = FindMaxIndex(inorder, startIn, endIn);
            var left = SpecialWithInNodeGreaterThanKids(inorder, startIn, maxIndex - 1);
            var right = SpecialWithInNodeGreaterThanKids(inorder, maxIndex + 1, endIn);

            return new TreeNodes<int>(inorder[maxIndex], left, right);
        }

        public TreeNodes<int> ConstructBaseOnArrayIndex(int [] arr)
        {
            //add all indexes to dictionary
            var tracker = new Dictionary<int, List<int>>();
            for(var i = 0; i < arr.Length; i++)
            {
                if (tracker.ContainsKey(arr[i]))
                {
                    tracker[arr[i]].Add(i);
                }
                else
                {
                    tracker.Add(arr[i], new List<int>() { i });
                }
            }

            if (!tracker.ContainsKey(-1))
            {
                return null;
            }

            var queue = new Queue<TreeNodes<int>>();
            var rootIndex = tracker[-1][0]; //should contain only one -1
            var root = new TreeNodes<int>(rootIndex, null, null);
            queue.Enqueue(root);
            while (queue.Count > 0)
            {                
                var parentNode = queue.Dequeue();
                var key = parentNode.Data;
                if (!tracker.ContainsKey(key))
                {
                    continue;
                }

                var childIndexes = tracker[key];

                var left = new TreeNodes<int>(childIndexes[0], null, null);
                parentNode.Left = left;
                queue.Enqueue(left);

                //if right
                if (childIndexes.Count > 1)
                {
                    var right = new TreeNodes<int>(childIndexes[1], null, null);
                    parentNode.Right = right;
                    queue.Enqueue(right);
                }
            }

            return root;
        }

        public int ConvertTreeToSumTree(TreeNodes<int> root)
        {
            if(root == null)
            {
                return 0;
            }

            var left = ConvertTreeToSumTree(root.Left);
            var right = ConvertTreeToSumTree(root.Right);

            var tmp = root.Data + left + right;
            root.Data = left + right;

            return tmp;
        }

        public int ConvertTreeToLeftSum(TreeNodes<int> root)
        {
            if (root == null)
            {
                return 0;
            }

            if (root.Left == null && root.Right == null)
            {
                return root.Data;
            }

            // Update left and right subtrees
            var leftsum = ConvertTreeToLeftSum(root.Left);
            var rightsum = ConvertTreeToLeftSum(root.Right);

            root.Data += leftsum;
            return root.Data + rightsum;

        }

        public TreeNodes<int> ConvertToMirrorTree(TreeNodes<int> root)
        {
            //leaf node
            if (root.Left == null && root.Right == null)
            {
                return root;
            }

            var left = ConvertToMirrorTree(root.Left);
            var right = ConvertToMirrorTree(root.Right);

            root.Left = right;
            root.Right = left;

            return root;
        }        

        public int MinimumSwapForBst(int[] arr)
        {
            var inorder = new List<int>();

            FindInorderBst(arr, inorder, 0);

            var minSwap = 0;
            //now we compare and swap
            for (var i = 0; i < arr.Length; i++)
            {
                if (arr[i] == inorder[i])
                {
                    continue;
                }

                var indexOf = inorder.IndexOf(arr[i]);
                var tmp = inorder[i];
                inorder[i] = inorder[indexOf];
                inorder[indexOf] = tmp;
                minSwap += 1;
            }

            return minSwap;
        }

        private void FindInorderBst(int [] arr, List<int> inorder, int index)
        {
            if (index >= arr.Length)
            {
                return;
            }

            FindInorderBst(arr, inorder, (2 * index) + 1);
            inorder.Add(arr[index]);
            FindInorderBst(arr, inorder, (2 * index) + 2);
        }

        private int FindMaxIndex(int [] arr, int start, int end)
        {
            var max = int.MinValue;
            var maxIndex = -1;
            for(var i = start; i <= end; i++)
            {
                if (arr[i] > max)
                {
                    max = arr[i];
                    maxIndex = i;
                }
            }

            return maxIndex;
        }

        private int Search(int[] arr, int start, int end, int element)
        {
            var i = start;
            for (i = start; i <= end; i++)
            {
                if (arr[i] == element)
                {
                    break;
                }
            }

            return i;
        }
    }
}
