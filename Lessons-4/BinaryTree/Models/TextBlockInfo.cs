namespace BinaryTree.Models;

class TextBlockInfo
{
    public TreeNode Node;
    public string Text;
    public int StartPos;
    public int Size { get { return Text.Length; } }
    public int EndPos { get { return StartPos + Size; } set { StartPos = value - Size; } }
    public TextBlockInfo Parent, Left, Right;
}