


public class LinkedList : ILinkedList
{
    private Node _headNode;

    public void AddNode(int value)
    {
        if (_headNode == null)
        {
            _headNode = new Node()
            {
                Value = value
            };
        }
        else
        {
            Node node = _headNode;
            while (node.NextNode != null)
            {
                node = node.NextNode;
            }

            node.NextNode = new Node()
            {
                Value = value,
                PrevNode = node
            };
        }
    }

    public void AddNodeAfter(Node node, int value)
    {
        if (_headNode == null)
        {
            _headNode = new Node()
            {
                Value = value
            };
        }
        else
        {
            Node currentNode = _headNode;
            while (currentNode.NextNode != null)
            {
                if (currentNode == node)
                {
                    break;
                }
                else
                {
                    currentNode = currentNode.NextNode;
                }
            }

            Node nextNode = currentNode.NextNode;

            currentNode.NextNode = new Node()
            {
                Value = value,
                PrevNode = currentNode,
                NextNode = nextNode
            };

            if (nextNode != null)
            {
                nextNode.PrevNode = currentNode.NextNode; 
            }
        }
    }

    public Node FindNode(int searchValue)
    {
        Node currentNode = _headNode;

        while (currentNode.NextNode != null)
        {
            if (currentNode.Value == searchValue)
            {
                break;
            }
            currentNode = currentNode.NextNode;
        }

        return currentNode;
    }

    public int GetCount()
    {
        int result = 1;
        Node currentNode = _headNode;
        
        while (currentNode.NextNode != null)
        {
            currentNode = currentNode.NextNode;
            result++;
        }

        return result;
    }

    public void RemoveNode(int index)
    {
        int count = 0;
        Node currentNode = _headNode;

        while (currentNode.NextNode != null)
        {
            if (count == index)
            {
                Node prev = currentNode.PrevNode;
                currentNode.PrevNode = null;

                Node next = currentNode.NextNode;
                currentNode.PrevNode = null;

                prev.NextNode = next;
                if (next != null)
                {
                    next.PrevNode = prev;
                }

                break;
            }
            currentNode = currentNode.NextNode;
            count++;
        }
    }

    public void RemoveNode(Node node)
    {
        Node currentNode = _headNode;

        while (currentNode.NextNode != null)
        {
            if (currentNode == node)
            {
                Node prev = currentNode.PrevNode;
                currentNode.PrevNode = null;

                Node next = currentNode.NextNode;
                currentNode.PrevNode = null;

                if (prev != null)
                {
                    prev.NextNode = next; 
                }
                else
                {
                    _headNode = next;
                }
                if (next != null)
                {
                    next.PrevNode = prev;
                }

                break;
            }
            currentNode = currentNode.NextNode;
        }
    }
}