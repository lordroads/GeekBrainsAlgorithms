





public class Node<T> //Вершина
{
    public T Value { get; set; }
    public List<Edge<T>> Edges { get; set; } //исходящие связи
}


