using DataStructures;

namespace Trees.Problems
{
    public class Identical
    {
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

            var isLeftIdentical = IsIdentical(root1.Left, root2.Left);
            var isRightIdentical = IsIdentical(root1.Right, root2.Right);

            return isLeftIdentical && isRightIdentical;
        }
    }
}
