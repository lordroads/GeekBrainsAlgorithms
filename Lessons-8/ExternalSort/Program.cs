using Sorts;

string inFileName = "dataIn_1000000.txt"; // 1 000 000 lines = 3s.

Console.WriteLine($"NOT Sort array - stast");
Utils.ExternalSort(inFileName);
Console.WriteLine($"Sort array - done");
