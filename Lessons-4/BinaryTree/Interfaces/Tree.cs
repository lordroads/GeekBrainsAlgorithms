using BinaryTree.Models;

namespace BinaryTree.Interfaces;

public class Tree : ITree
{
    TreeNode _root { get; set; }

    public void AddItem(int value)
    {
        if (_root == null)
        {
            _root = new TreeNode(value);
        }
        else
        {
            if (GetNodeByValue(value) == null)
            {
                Add(_root, value);
            }
        }
        
    }
    private void Add(TreeNode headNode, int value)
    {
        if (headNode.Value > value)
        {
            if (headNode.RightChild == null)
            {
                headNode.RightChild = new TreeNode(value);
            }
            else
            {
                Add(headNode.RightChild, value);
            }
        }
        else
        {
            if (headNode.LeftChild == null)
            {
                headNode.LeftChild = new TreeNode(value);
            }
            else
            {
                Add(headNode.LeftChild, value);
            }
        }

        Balance(_root);
    }

    public TreeNode GetNodeByValue(int value)
    {
        TreeNode current = _root;

        while (current != null)
        {
            int result = current.CompareTo(value);

            if (result > 0)
            {
                current = current.RightChild;
            }
            else if (result < 0)
            {         
                current = current.LeftChild;
            }
            else
            {  
                break;
            }
        }
        return current;
    }

    public TreeNode GetRoot()
    {
        return _root;
    }

    public void PrintTree()
    {
        if (_root == null) return;
        string textFormat = "(0)";
        int spacing = 1;
        int topMargin = 2;
        int leftMargin = 2;
        int rootTop = Console.CursorTop + topMargin;
        var listTextBlockInfo = new List<TextBlockInfo>();
        var nextNode = _root;
        for (int level = 0; nextNode != null; level++)
        {
            var textBlockInfo = new TextBlockInfo { Node = nextNode, Text = nextNode.Value.ToString(textFormat) };
            if (level < listTextBlockInfo.Count)
            {
                textBlockInfo.StartPos = listTextBlockInfo[level].EndPos + spacing;
                listTextBlockInfo[level] = textBlockInfo;
            }
            else
            {
                textBlockInfo.StartPos = leftMargin;
                listTextBlockInfo.Add(textBlockInfo);
            }
            if (level > 0)
            {
                textBlockInfo.Parent = listTextBlockInfo[level - 1];
                if (nextNode == textBlockInfo.Parent.Node.LeftChild)
                {
                    textBlockInfo.Parent.Left = textBlockInfo;
                    textBlockInfo.EndPos = Math.Max(textBlockInfo.EndPos, textBlockInfo.Parent.StartPos - 1);
                }
                else
                {
                    textBlockInfo.Parent.Right = textBlockInfo;
                    textBlockInfo.StartPos = Math.Max(textBlockInfo.StartPos, textBlockInfo.Parent.EndPos + 1);
                }
            }
            nextNode = nextNode.LeftChild ?? nextNode.RightChild;
            for (; nextNode == null; textBlockInfo = textBlockInfo.Parent)
            {
                int top = rootTop + 2 * level;
                Print(textBlockInfo.Text, top, textBlockInfo.StartPos);
                if (textBlockInfo.Left != null)
                {
                    Print("/", top + 1, textBlockInfo.Left.EndPos);
                    Print("_", top, textBlockInfo.Left.EndPos + 1, textBlockInfo.StartPos);
                }
                if (textBlockInfo.Right != null)
                {
                    Print("_", top, textBlockInfo.EndPos, textBlockInfo.Right.StartPos - 1);
                    Print("\\", top + 1, textBlockInfo.Right.StartPos - 1);
                }
                if (--level < 0) break;
                if (textBlockInfo == textBlockInfo.Parent.Left)
                {
                    textBlockInfo.Parent.StartPos = textBlockInfo.EndPos + 1;
                    nextNode = textBlockInfo.Parent.Node.RightChild;
                }
                else
                {
                    if (textBlockInfo.Parent.Left == null)
                        textBlockInfo.Parent.EndPos = textBlockInfo.StartPos - 1;
                    else
                        textBlockInfo.Parent.StartPos += (textBlockInfo.StartPos - 1 - textBlockInfo.Parent.EndPos) / 2;
                }
            }
        }
        Console.SetCursorPosition(0, rootTop + 2 * listTextBlockInfo.Count - 1);
    }
    private void Print(string text, int top, int left, int right = -1)
    {
        Console.SetCursorPosition(left, top);
        if (right < 0)
        {
            right = left + text.Length;
        }
        while (Console.CursorLeft < right)
        {
            Console.Write(text);
        }
    }

    public void RemoveItem(int value)
    {
        TreeNode current = GetNodeByValue(value);
        TreeNode parentNodeToBalance = GetParentNode(current);
        if (current == null)
        {
            return;
        }

        if (current.LeftChild == null && current.RightChild == null)
        {
            TreeNode parentNode = GetParentNode(current);
            int result = parentNode.CompareTo(current.Value);

            if (result < 0)
            {
                parentNode.LeftChild = current.LeftChild;
            }
            else if (result > 0)
            {
                parentNode.RightChild = current.LeftChild;
            }
        }
        else if (current.RightChild == null)
        {
            if (current.Equals(_root))
            {
                _root = current.LeftChild;
            }
            else
            {
                TreeNode parentNode = GetParentNode(current);
                int result = parentNode.CompareTo(current.Value);

                if (result < 0)
                {
                    parentNode.LeftChild = current.LeftChild;
                }
                else if (result > 0)
                {
                    parentNode.RightChild = current.LeftChild;
                }
            }
        }
        else if (current.LeftChild == null)
        {
            if (current.Equals(_root))
            {
                _root = current.RightChild;
            }
            else
            {
                TreeNode parentNode = GetParentNode(current);
                int result = parentNode.CompareTo(current.Value);

                if (result < 0)
                {
                    parentNode.LeftChild = current.RightChild;
                }
                else if (result > 0)
                {
                    parentNode.RightChild = current.RightChild;
                }
            }
        }
        else
        {
            TreeNode rightLeftNode = current.RightChild.LeftChild;
            if (rightLeftNode != null)
            {
                TreeNode lastLeftNode = rightLeftNode;

                while (lastLeftNode.LeftChild != null)
                {
                    lastLeftNode = lastLeftNode.LeftChild;
                }

                TreeNode parentLeftNode = GetParentNode(lastLeftNode);
                parentLeftNode.LeftChild = lastLeftNode.RightChild;

                lastLeftNode.LeftChild = current.LeftChild;
                lastLeftNode.RightChild = current.RightChild;

                if (current.Equals(_root))
                {
                    _root = lastLeftNode;
                }
                else
                {
                    TreeNode parentNode = GetParentNode(current);
                    int result = parentNode.CompareTo(current.Value);

                    if (result < 0)
                    {
                        parentNode.LeftChild = lastLeftNode;
                    }
                    else if (result > 0)
                    {
                        parentNode.RightChild = lastLeftNode;
                    }
                }
            }
            else
            {
                current.RightChild.LeftChild = current.LeftChild;

                TreeNode parentNode = GetParentNode(current);
                int result = parentNode.CompareTo(current.Value);

                if (result < 0)
                {
                    parentNode.LeftChild = current.RightChild;
                }
                else if (result > 0)
                {
                    parentNode.RightChild = current.RightChild;
                }
            }
            
        }

        if (parentNodeToBalance != null)
        {
            Balance(parentNodeToBalance);
        }
        else
        {
            Balance(_root);
        }
    }

    private TreeNode GetParentNode(TreeNode node)
    {
        if (node == _root || node == null)
        {
            return null;
        }

        TreeNode head = _root;
        TreeNode current = head;

        while (current != node)
        {
            int result = current.CompareTo(node.Value);

            if (result > 0)
            {
                head = current;
                current = current.RightChild;
            }
            else if (result < 0)
            {
                head = current;
                current = current.LeftChild;
            }
            else
            {
                return head;
            }
        }

        return head;
    }
    #region Balance Tree
    private void Balance(TreeNode node)
    {
        TreeState State = TreeHelper.GetStateTree(node);

        if (State == TreeState.RightHeavy)
        {
            if (node.RightChild != null && TreeHelper.MaxChildHeight(node.RightChild.RightChild) - TreeHelper.MaxChildHeight(node.RightChild.LeftChild) < 0)
            {
                LeftRightRotation(node);
            }

            else
            {
                LeftRotation(node);
            }
        }
        else if (State == TreeState.LeftHeavy)
        {
            if (node.LeftChild != null && TreeHelper.MaxChildHeight(node.LeftChild.RightChild) - TreeHelper.MaxChildHeight(node.LeftChild.LeftChild) > 0)
            {
                RightLeftRotation(node);
            }
            else
            {
                RightRotation(node);
            }
        }
    }
    private void LeftRotation(TreeNode node)
    {
        TreeNode parentNode = GetParentNode(node);
        TreeNode newRoot = node.RightChild;
        if (node == _root)
        {
            _root = newRoot;
            node.RightChild = newRoot.LeftChild;
            newRoot.LeftChild = node;
        }
        else
        {
            if (parentNode.RightChild == node)
            {
                parentNode.RightChild = newRoot;
            }
            else
            {
                parentNode.LeftChild = newRoot;
            }

            newRoot.LeftChild = node;
            node.RightChild = null;
        }
    }
    private void LeftRightRotation(TreeNode node)
    {
        RightRotation(node.RightChild);
        LeftRotation(node);
    }
    private void RightRotation(TreeNode node)
    {
        TreeNode parentNode = GetParentNode(node);
        TreeNode newRoot = node.LeftChild;
        if (node == _root)
        {
            _root = newRoot;
            node.LeftChild = newRoot.RightChild;
            newRoot.RightChild = node;
        }
        else
        {
            if (parentNode.RightChild == node)
            {
                parentNode.RightChild = newRoot;
            }
            else
            {
                parentNode.LeftChild = newRoot;
            }

            newRoot.RightChild = node;
            node.LeftChild = null;
        }
    }
    private void RightLeftRotation(TreeNode node)
    {
        LeftRotation(node.LeftChild);
        RightRotation(node);
    } 
    #endregion
}