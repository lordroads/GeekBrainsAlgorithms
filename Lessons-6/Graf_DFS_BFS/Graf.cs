





public class Graf<T>
{
    private Node<T> _root;

    public Graf(object [,] grafTable)
    {
        Node<T>[] nodes = GetNodes(grafTable);

        _root = nodes[0];

        for (int r = 0; r < nodes.Length; r++)
        {
            for (int i = 1; i < nodes.Length + 1; i++)
            {
                nodes[r].Edges.Add(new Edge<T>()
                {
                    Weight = Convert.ToInt32(grafTable[r,i]),
                    Node = nodes[i - 1]
                });
            }
        }
    }

    public Node<T> GetRoot()
    {
        return _root;
    }

    public Node<T> SearchBFS(T value)
    {
        Console.WriteLine("/Search BFS/");
        Node<T> searchNode = null;
        Queue<Node<T>> queue = new Queue<Node<T>>();
        HashSet<Node<T>> visited = new HashSet<Node<T>>();

        queue.Enqueue(_root);

        Console.Write("Nodes -");
        while (queue.Count != 0)
        {
            Node<T> currentNode = queue.Dequeue();

            if (currentNode != null)
            {
                if (!visited.Contains(currentNode))
                {
                    if (currentNode.Value.Equals(value))
                    {
                        searchNode = currentNode;
                        return searchNode;
                    }

                    Console.Write($" {currentNode.Value} ");

                    visited.Add(currentNode);

                    foreach (Edge<T> edge in currentNode.Edges)
                    {
                        if (edge.Weight > 0)
                        {
                            queue.Enqueue(edge.Node);
                        }
                    }
                }
            }
        }

        return searchNode;
    }

    public Node<T> SearchDFS(T value)
    {
        Console.WriteLine("/Search DFS/");
        Node<T> searchNode = null;
        Stack<Node<T>> stack = new Stack<Node<T>>();
        HashSet<Node<T>> visited = new HashSet<Node<T>>();

        stack.Push(_root);

        Console.Write("Nodes -");
        while (stack.Count != 0)
        {
            Node<T> currentNode = stack.Pop();

            if (currentNode != null)
            {
                if (!visited.Contains(currentNode))
                {
                    if (currentNode.Value.Equals(value))
                    {
                        searchNode = currentNode;
                        return searchNode;
                    }

                    visited.Add(currentNode);

                    Console.Write($" {currentNode.Value} ");

                    foreach (Edge<T> edge in currentNode.Edges)
                    {
                        if (edge.Weight > 0)
                        {
                            stack.Push(edge.Node);
                        }
                    }
                }
            }
        }

        return searchNode;
    }


    private Node<T>[] GetNodes(object[,] grafTable)
    {
        int row = grafTable.GetUpperBound(0) + 1;
        Node<T>[] nodes = new Node<T>[row];

        for (int i = 0; i < row; i++)
        {
            Node<T> node = new Node<T>()
            {
                Value = (T)grafTable[i,0],
                Edges = new List<Edge<T>>()
            };

            nodes[i] = node;
        }

        return nodes;
    }
}


