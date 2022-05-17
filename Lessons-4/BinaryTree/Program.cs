using BinaryTree.Interfaces;

Tree tree = new Tree();

Random random = new Random();

for (int i = 0; i < 50; i++)
{
    tree.AddItem(random.Next(10, 100));
}
tree.PrintTree();
Console.WriteLine($"[BALANCE] - {TreeHelper.GetStateTree(tree.GetRoot())}");

for (int i = 0; i < 10; i++)
{
    tree.RemoveItem(random.Next(10, 100));
}
tree.PrintTree();
Console.WriteLine($"[BALANCE] - {TreeHelper.GetStateTree(tree.GetRoot())}");

Console.WriteLine($"[NODE TREE] - {tree.GetNodeByValue(random.Next(10, 100))?.Value}");