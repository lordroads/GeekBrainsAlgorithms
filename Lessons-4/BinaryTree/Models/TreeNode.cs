namespace BinaryTree.Models;

public class TreeNode
{
    public int Value { get; set; }
    public TreeNode? LeftChild { get; set; }
    public TreeNode? RightChild { get; set; }

    public TreeNode(int value)
    {
        Value = value;
    }

    public int CompareTo(int other)
    {
        return Value.CompareTo(other);
    }

    public override bool Equals(object obj)
    {
        var node = obj as TreeNode;
        if (node == null)
            return false;
        return node.Value == Value;
    }
    public override int GetHashCode()
    {
        return HashCode.Combine(Value, LeftChild, RightChild);
    }
}