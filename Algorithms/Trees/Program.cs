using DataStructures;
using System;
using System.Collections.Generic;
using Trees.Problems;

namespace Trees
{
    class Program
    {
        static void Main(string[] args)
        {
            //TreeNodes<int> root = new TreeNodes<int>(10, null, null);
            //TreeNodes<int> left = new TreeNodes<int>(20, null, null);
            //TreeNodes<int> right = new TreeNodes<int>(30, null, null);
            //TreeNodes<int> leftLeft = new TreeNodes<int>(40, null, null);
            //TreeNodes<int> leftLeftLeft = new TreeNodes<int>(70, null, null);
            //TreeNodes<int> leftRight = new TreeNodes<int>(50, null, null);
            //TreeNodes<int> rightLeft = new TreeNodes<int>(60, null, null);
            //TreeNodes<int> leftLeftRight = new TreeNodes<int>(80, null, null);

            //root.Left = left;
            //root.Right = right;
            //left.Left = leftLeft;
            //leftLeft.Left = leftLeftLeft;
            //left.Right = leftRight;
            //right.Left = rightLeft;
            //leftLeft.Right = leftLeftRight;

            //var traversal = new Traversals();
            //traversal.PostOrderTraversalIterative(root);
            //Console.WriteLine("\n");
            //traversal.PostOrderTraversalIterative(root);

            //TreeNodes<int> root = new TreeNodes<int>(1, null, null);
            //root.Left = new TreeNodes<int>(2, null, null);
            //root.Right = new TreeNodes<int>(3, null, null);
            //root.Left.Left = new TreeNodes<int>(4, null, null);
            //root.Right.Left = new TreeNodes<int>(5, null, null);
            //root.Right.Right = new TreeNodes<int>(6, null, null);
            //root.Right.Left.Left = new TreeNodes<int>(7, null, null);
            //root.Right.Left.Right = new TreeNodes<int>(8, null, null);

            //var traversal = new Traversals();
            //traversal.InOrderTraversalIterative(root);
            //Console.WriteLine("\n");
            //traversal.InOrderTraversalRecursively(root);
            //traversal.PostOrderTraversalIterative(root);
            //Console.WriteLine("\n");
            //traversal.PostOrderTraversalRecursively(root);

            //TreeNodes<int> root1 = new TreeNodes<int>(1, null, null);
            //root1.Left = new TreeNodes<int>(2, null, null);
            //root1.Right = new TreeNodes<int>(3, null, null);
            //root1.Left.Left = new TreeNodes<int>(4, null, null);
            //root1.Right.Left = new TreeNodes<int>(5, null, null);
            //root1.Right.Right = new TreeNodes<int>(6, null, null);
            //root1.Right.Left.Left = new TreeNodes<int>(7, null, null);
            //root1.Right.Left.Right = new TreeNodes<int>(8, null, null);

            //TreeNodes<int> root2 = new TreeNodes<int>(1, null, null);
            //root2.Left = new TreeNodes<int>(2, null, null);
            //root2.Right = new TreeNodes<int>(3, null, null);
            //root2.Left.Left = new TreeNodes<int>(4, null, null);
            //root2.Right.Left = new TreeNodes<int>(5, null, null);
            //root2.Right.Right = new TreeNodes<int>(6, null, null);
            //root2.Right.Left.Left = new TreeNodes<int>(7, null, null);
            //root2.Right.Left.Right = new TreeNodes<int>(8, null, null);

            //var identical = new Identical();
            //Console.WriteLine(identical.IsIdentical(root1, root2));

            // int[] inOrd = new int[] { 70, 40, 80, 20, 50, 10, 60, 30 };
            //int[] preOrder = new int[] { 10, 20, 40, 70, 80, 50, 30, 60 };
            //int[] postOrder = new int[] { 70, 80, 40, 50, 20 ,60, 30, 10};
            //int[] pre = new int[] { 10, 20, 40, 70, 80, 50, 30, 60 };
            //var inOrd = new int[] { 4, 2, 1, 7, 5, 8, 3, 6 };
            //var postOrd = new int[] { 4, 2, 7, 8, 5, 6, 3, 1 };
            //var postOrder = new int[] { 4, 2, 7, 8, 5, 6, 3, 1 };
            //var preOrder = new int[] { 1, 2, 4, 3, 5, 7, 8, 6 };
            //var preOrder = new int[] { 1, 2, 4, 8, 9, 5, 3, 6, 7 };
            //var postOrder = new int[] { 8, 9, 4, 5, 2, 6, 7, 3, 1 };


            //var preBst = new int[] { 40, 30, 35, 80, 100 };
            //var preBst = new int[] { 40, 30, 32, 35, 80, 90, 100, 120 };
            //var traversal = new Traversals();
            //traversal.PrintPostGivePreBst(preBst, 0, preBst.Length - 1);
            //traversal.PrintPostGivenInAndPre(inOrd, pre, 0, inOrd.Length - 1, 0);
            //traversal.PrintPreGivenInAndPost(inOrd, postOrd, 0, inOrd.Length - 1, postOrd.Length - 1);
            //traversal.PrintInGivenPreAndPost(postOrder, preOrder, 0, postOrder.Length - 1, 0, preOrder.Length - 1);

            //var root = new TreeNodes<int>(1, null, null);
            //root.Left = new TreeNodes<int>(2, null, null);
            //root.Left.Left = new TreeNodes<int>(4, null, null);
            //root.Left.Right = new TreeNodes<int>(5, null, null);

            //root.Right = new TreeNodes<int>(3, null, null);
            //root.Right.Left = new TreeNodes<int>(6, null, null);
            //root.Right.Right = new TreeNodes<int>(7, null, null);

            //var traversal = new Traversals();
            //var tracker = new Dictionary<int, List<TreeNodes<int>>>();
            //traversal.PrintDiagonalTraversal(root, 1, tracker);
            //foreach (var obj in tracker)
            //{
            //    foreach (var node in obj.Value)
            //    {
            //        Console.Write(node.Data + " ");
            //    }
            //}

            //traversal.SwapNodeWithSumInorderPreAndSuc(root);
            //traversal.InOrderTraversalIterative(root);

            //var treePat = "nlnnlll";
            //var traversal = new Traversals();
            //Console.WriteLine(traversal.FindDepthGivenNLStr(treePat, 0));

            //var traversal = new Traversals();
            //Console.WriteLine(traversal.FindNumOfPreorderSequence(4));

            //int[] inOrd = new int[] { 70, 40, 80, 20, 50, 10, 60, 30 };
            //int[] preOrder = new int[] { 10, 20, 40, 70, 80, 50, 30, 60 };
            //var inorder = new int[] { 4, 8, 10, 12, 14, 20, 22 };
            //var levelorder = new int[] { 20, 8, 22, 4, 12, 10, 14 };

            //var preOrder = new int[] { 1, 2, 4, 8, 9, 5, 3, 6, 7 };
            //var postOrder = new int[] { 8, 9, 4, 5, 2, 6, 7, 3, 1 };
            //var preOrder = new int[] { 1, 2, 4, 5, 3, 6, 7 };
            //var mirrored = new int[] { 1, 3, 7, 6, 2, 5, 4 };
            //var preorder = new int[] { 10, 20, 40, 70, 80, 50, 30, 60 };
            //var preorderNl = new char[] { 'N', 'N', 'N', 'L', 'L', 'L', 'N', 'L' };
            //var head = new ListNode<int>(10, new ListNode<int>(12, new ListNode<int>(15, new ListNode<int>(25, new ListNode<int>(30, new ListNode<int>(36, null))))));
            //var inorderSpecial = new int[] { 1, 5, 10, 40, 30, 15, 28, 20 };
            //var arr = new int[] { 1, 5, 5, 2, 2, -1, 3 };

            //var inorder = new int[] { 4, 8, 2, 5, 1, 6, 3, 7 };
            //var postorder = new int[] { 8, 4, 5, 2, 6, 7, 3, 1 };
            //var traversal = new Traversals();
            //traversal.PrintPostGivenInAndPre(inOrd, preOrder, 0, inOrd.Length - 1, 0);
            //var construct = new Construction();
            //var root = construct.ConstructTreeWithInAndPre(inOrd, preOrder, 0, inOrd.Length - 1, 0);
            //var root = construct.ConstructTreeWithInAndLevel(inorder, levelorder, 0, inorder.Length - 1);
            //var root = construct.ConstructCompleteTreeWithList(head);
            //var root = construct.ConstructCompleteTreeWithLevel(new int[] { 1, 2, 3, 4, 5, 6, 6, 6, 6, 6 });
            //traversal.PostOrderTraversalIterative(root);
            //var tracker = new Dictionary<int, List<TreeNodes<int>>>();
            //traversal.PrintLevelOrderTraversal(root, 0, tracker);
            //foreach (var obj in tracker)
            //{
            //    foreach (var node in obj.Value)
            //    {
            //        Console.Write(node.Data + " ");
            //    }
            //}

            //var root = construct.ConstructFullBaseOnPreAndPost(postOrder, preOrder, 0, postOrder.Length - 1, 0, preOrder.Length - 1);
            //var root = construct.ConstructTreeByPreAndMirror(preOrder, mirrored, 0, preOrder.Length - 1, 0, mirrored.Length - 1);
            //var index = 0;
            //var root = construct.ConstructSpecialTreeGivenPreNL(preorder, preorderNl, ref index);
            //var root = construct.SpecialWithInNodeGreaterThanKids(inorderSpecial, 0, inorderSpecial.Length - 1);
            //var root = construct.ConstructTreeWithPostAndIn(inorder, postorder, 0, inorder.Length - 1, postorder.Length - 1);

            //var root = new TreeNodes<int>(10, null, null);
            //root.Left = new TreeNodes<int>(-2, null, null);
            //root.Right = new TreeNodes<int>(6, null, null);
            //root.Left.Left = new TreeNodes<int>(8, null, null);
            //root.Left.Right = new TreeNodes<int>(-4, null, null);
            //root.Right.Left = new TreeNodes<int>(7, null, null);
            //root.Right.Right = new TreeNodes<int>(5, null, null);

            //construct.ConvertToMirrorTree(root);

            //traversal.InOrderTraversalIterative(root);

            //var arr = new int[] { 1,2,3 };
            //Console.WriteLine(construct.MinimumSwapForBst(arr));

            //var root = new TreeNodes<int>(6, null, null);
            //root.Left = new TreeNodes<int>(3, null, null);
            //root.Right = new TreeNodes<int>(5, null, null);
            //root.Left.Left = new TreeNodes<int>(7, null, null);
            //root.Left.Right = new TreeNodes<int>(8, null, null);
            //root.Right.Left = new TreeNodes<int>(1, null, null);
            //root.Right.Right = new TreeNodes<int>(3, null, null);

            //var root1 = new TreeNodes<int>(5, null, null);
            //root1.Left = new TreeNodes<int>(2, null, null);
            //root1.Right = new TreeNodes<int>(3, null, null);
            //root1.Left.Left = new TreeNodes<int>(1, null, null);
            //root1.Left.Right = new TreeNodes<int>(4, null, null);
            //root1.Left.Right.Left = new TreeNodes<int>(6, null, null);
            //root1.Left.Right.Right = new TreeNodes<int>(8, null, null);
            //root1.Right.Left = new TreeNodes<int>(4, null, null);
            //root1.Right.Right = new TreeNodes<int>(3, null, null);

            //var root2 = new TreeNodes<int>(1, null, null);
            //root2.Left = new TreeNodes<int>(3, null, null);
            //root2.Right = new TreeNodes<int>(2, null, null);
            //root2.Left.Left = new TreeNodes<int>(4, null, null);
            //root2.Left.Right = new TreeNodes<int>(5, null, null);
            //root2.Right.Left = new TreeNodes<int>(5, null, null);
            //root2.Right.Right = new TreeNodes<int>(4, null, null);


            //var checkAndPrint = new CheckAndPrint();
            //Console.WriteLine(checkAndPrint.AreCousins(root, root.Left.Left, root.Right.Left));
            //Console.WriteLine(checkAndPrint.AreCousins(root, root.Left, root.Right));
            //Console.WriteLine(checkAndPrint.AreCousins(root, root.Left, root.Right));
            //var leafLevel = 0;
            //Console.WriteLine(checkAndPrint.AreLeavesOnSameLevel(root, 0, ref leafLevel));

            //var level = new int[] { 30, 56, 22, 49, 30, 51, 2, 67 };
            //var level2 = new int[] { 10, 15, 14, 25, 30 };

            //Console.WriteLine(checkAndPrint.IsMinHeapGivenLevel(level));
            //Console.WriteLine(checkAndPrint.IsMinHeapGivenLevel(level2));

            //var depth = checkAndPrint.FindLeftmostDepth(root1);
            //Console.WriteLine(checkAndPrint.FindMaxDepth(root1));
            //var maxDepth = checkAndPrint.FindMaxDepth(root1);
            //var longestFound = false;
            //checkAndPrint.PrintRootToLeavePathsIterative(root1);


            var root = new TreeNodes<int>(1, null, null);
            root.Left = new TreeNodes<int>(2, null, null);
            root.Right = new TreeNodes<int>(3, null, null);
            root.Left.Left = new TreeNodes<int>(4, null, null);
            root.Left.Right = new TreeNodes<int>(5, null, null);
            root.Right.Left = new TreeNodes<int>(6, null, null);
            root.Right.Right = new TreeNodes<int>(7, null, null);

            //var root1 = new TreeNodes<int>(2, null, null);
            //root1.Left = new TreeNodes<int>(1, null, null);
            //root1.Right = new TreeNodes<int>(4, null, null);
            //root1.Left.Left = new TreeNodes<int>(5, null, null);
            //root1.Left.Left.Left = new TreeNodes<int>(5, null, null);

            //var root2 = new TreeNodes<int>(3, null, null);
            //root2.Left = new TreeNodes<int>(6, null, null);
            //root2.Right = new TreeNodes<int>(1, null, null);
            //root2.Left.Right = new TreeNodes<int>(2, null, null);
            //root2.Right.Right = new TreeNodes<int>(7, null, null);

            var sum = new Summation();
            //Console.WriteLine(sum.SumOfAllRightLeaf(root));
            //var maxDepth = new CheckAndPrint().FindMaxDepth(root);
            //Console.WriteLine(sum.SumOfLongestRootToLeafPath(root, maxDepth, new List<int>()));

            //var allPaths = new List<List<int>>();
            //var maxSum = 0;
            //sum.LargestSubtreeSum(root, ref maxSum);
            //Console.WriteLine(maxSum);
            //var count = 0;
            //sum.CountSubTreeWithGivenSum(root, 17, ref count);
            //Console.WriteLine(count);

            //var mergedRoot = sum.MergeTwoTreeWithNodeSum(root1, root2);
            //new Traversals().InOrderTraversalIterative(mergedRoot);
            sum.PrintVerticalSums(root);
        }
    }
}
