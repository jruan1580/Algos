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
    }
}
