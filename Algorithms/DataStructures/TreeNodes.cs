using System;

namespace DataStructures
{
    public class TreeNodes<T>
    {
        public TreeNodes(T data, TreeNodes<T> left, TreeNodes<T> right)
        {
            Data = data;
            Left = left;
            Right = right;
        }

        public T Data { get; set; }

        public TreeNodes<T> Left { get; set; }

        public TreeNodes<T> Right { get; set; }
    }
}
