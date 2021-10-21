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
    }
}
