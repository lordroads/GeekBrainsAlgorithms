using Tree_DFS_BFS;

SimpleTree simpleTree = new SimpleTree();

simpleTree.RandomTree(50);

int searchValue = new Random().Next(10, 100);
TreeNode searchNodeBFS = simpleTree.SearchBFS(searchValue);
string text = searchNodeBFS != null ? searchNodeBFS.Value.ToString() : "NULL";
Console.WriteLine($"[SEARCH NODE]: {text}");

TreeNode searchNodeDFS = simpleTree.SearchDFS(searchValue);
text = searchNodeDFS != null ? searchNodeDFS.Value.ToString() : "NULL";
Console.WriteLine($"[SEARCH NODE]: {text}");