namespace Tree_DFS_BFS;

public class SimpleTree
{
    public TreeNode Root { get; set; }

    public void Add(int value)
    {
        if (Root == null)
        {
            Root = new TreeNode(value);
        }
        else
        {
            Add(new TreeNode(value));
        }
    }
    public void RandomTree(int count)
    {
        Random random = new Random();
        for (int i = 0; i < count; i++)
        {
            Add(random.Next(10,100));
        }
    }
    private void Add(TreeNode newNode)
    {
        TreeNode currentNode = Root;
        while (currentNode != null)
        {
            if (currentNode.Value > newNode.Value)
            {
                if (currentNode.Rieght == null)
                {
                    currentNode.Rieght = newNode;
                }
                else
                {
                    currentNode = currentNode.Rieght;
                }
            }
            else if(currentNode.Value < newNode.Value)
            {
                if (currentNode.Left == null)
                {
                    currentNode.Left = newNode;
                }
                else
                {
                    currentNode = currentNode.Left;
                }
            }
            else
            {
                break;
            }
        }
    }

    public TreeNode SearchBFS(int value)
    {
        Console.WriteLine("/Search BFS/");
        Console.WriteLine($"Search value: {value}");
        Queue<TreeNode> queue = new Queue<TreeNode>();

        queue.Enqueue(Root);

        Console.Write("Nodes -");
        while (queue.Count != 0)
        {
            TreeNode currentNode = queue.Dequeue();

            if (currentNode != null)
            {
                Console.Write($" {currentNode.Value} ");
                if (currentNode.Value == value)
                {
                    return currentNode;
                }
                else
                {
                    queue.Enqueue(currentNode.Left);
                    queue.Enqueue(currentNode.Rieght);
                } 
            }
        }

        return null;
    }
    public TreeNode SearchDFS(int value)
    {
        Console.WriteLine("/Search DFS/");
        Console.WriteLine($"Search value: {value}");

        Stack<TreeNode> stack = new Stack<TreeNode>();

        stack.Push(Root);

        Console.Write("Nodes -");
        while (stack.Count != 0)
        {
            TreeNode currentNode = stack.Pop();

            if (currentNode != null)
            {
                Console.Write($" {currentNode.Value} ");
                if (currentNode.Value == value)
                {
                    return currentNode;
                }
                else
                {
                    stack.Push(currentNode.Rieght);
                    stack.Push(currentNode.Left);
                } 
            }
        }

        return null;
    }
}
