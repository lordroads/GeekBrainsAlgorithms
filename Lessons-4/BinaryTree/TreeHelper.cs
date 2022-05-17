using BinaryTree.Models;

public static class TreeHelper
{
    public static TreeState GetStateTree(TreeNode node)
    {
        if (TreeHelper.MaxChildHeight(node.LeftChild) - TreeHelper.MaxChildHeight(node.RightChild) > 1)
        {
            return TreeState.LeftHeavy;
        }

        if (TreeHelper.MaxChildHeight(node.RightChild) - TreeHelper.MaxChildHeight(node.LeftChild) > 1)
        {
            return TreeState.RightHeavy;
        }

        return TreeState.Balanced;
    }
    public static int MaxChildHeight(TreeNode node)
    {
        if (node != null)
        {
            return 1 + Math.Max(MaxChildHeight(node.LeftChild), MaxChildHeight(node.RightChild));
        }

        return 0;
    }
}
