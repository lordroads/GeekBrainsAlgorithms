using BinaryTree.Models;

namespace BinaryTree.Interfaces;

public interface ITree
{
    TreeNode GetRoot();
    void AddItem(int value); // добавить узел
    void RemoveItem(int value); // удалить узел по значению
    TreeNode GetNodeByValue(int value); //получить узел дерева по значению
    void PrintTree(); //вывести дерево в консоль
}
