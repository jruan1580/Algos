using DataStructures;
using System;
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
            //traversal.PreOrderTraversalIterative(root);
            //Console.WriteLine("\n");
            //traversal.PreOrderTraversalRecursively(root);

            TreeNodes<int> root = new TreeNodes<int>(1, null, null);
            root.Left = new TreeNodes<int>(2, null, null);
            root.Right = new TreeNodes<int>(3, null, null);
            root.Left.Left = new TreeNodes<int>(4, null, null);
            root.Right.Left = new TreeNodes<int>(5, null, null);
            root.Right.Right = new TreeNodes<int>(6, null, null);
            root.Right.Left.Left = new TreeNodes<int>(7, null, null);
            root.Right.Left.Right = new TreeNodes<int>(8, null, null);

            var traversal = new Traversals();
            //traversal.InOrderTraversalIterative(root);
            //Console.WriteLine("\n");
            //traversal.InOrderTraversalRecursively(root);
            traversal.PostOrderTraversalIterative(root);
            Console.WriteLine("\n");
            traversal.PostOrderTraversalRecursively(root);
        }
    }
}
