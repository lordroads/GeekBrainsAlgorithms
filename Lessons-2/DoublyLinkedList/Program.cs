//Создание двусвязного списока
LinkedList linkedList = new LinkedList();

//Добавление нодов
linkedList.AddNode(10);
linkedList.AddNode(20);
linkedList.AddNode(30);

//Поиск ноды
Node findNode = linkedList.FindNode(20);

//Добавление после указаной ноды
linkedList.AddNodeAfter(findNode, 25);

//Удаление указаной ноды
linkedList.RemoveNode(findNode);

//Удаление по индексу
linkedList.RemoveNode(2);

//Кол-во нод в списке
int count = linkedList.GetCount();
