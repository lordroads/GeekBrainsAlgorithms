
object[,] grafTab = new object[,] {
    {"A", 0, 4, 0, 0, 1 },
    {"B", 0, 0, 3, 6, 0 },
    {"C", 0, 0, 2, 0, 0 },
    {"D", 5, 6, 0, 0, 0 },
    {"F", 1, 1, 0, 0, 0 },
};

Graf<string> graf = new Graf<string>(grafTab);

var searchNodeBFS = graf.SearchBFS("F");
Console.WriteLine($"Search node - {searchNodeBFS?.Value}");

Console.WriteLine();

var searchNodeDFS = graf.SearchDFS("F");
Console.WriteLine($"Search node - {searchNodeDFS?.Value}");

Console.WriteLine();


