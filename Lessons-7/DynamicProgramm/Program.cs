int[,] Map =  {
   { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
   { 1, 0, 1, 1, 1, 0, 1, 1, 1, 1},
   { 1, 0, 0, 1, 0, 0, 0, 1, 1, 1},
   { 1, 0, 1, 1, 1, 1, 1, 1, 0, 1},
   { 1, 1, 1, 1, 1, 1, 1, 1, 0, 1},
   { 1, 1, 1, 1, 0, 0, 0, 1, 1, 1},
   { 1, 1, 1, 1, 1, 1, 0, 1, 1, 1},
   { 1, 0, 1, 1, 0, 1, 1, 1, 1, 1},
   { 1, 1, 1, 1, 1, 1, 1, 1, 0, 0},
   { 1, 1, 0, 1, 1, 1, 0, 1, 1, 1}
};

int rows = Map.GetUpperBound(0) + 1;
int columns = Map.Length / rows;

int[,] queenStepMap = new int[rows, columns];

for (int i = 0; i < rows; i++)
{
    for (int j = 0; j < columns; j++)
    {
        if (i == 0 || j == 0)
        {
            queenStepMap[i, j] = 1;
            continue;
        }
        else if (Map[i,j] == 1)
        {
            queenStepMap[i, j] = queenStepMap[i, j - 1] + queenStepMap[i - 1, j];
        }
        else
        {
            queenStepMap[i, j] = 0;
        }
    } 
}

Console.WriteLine($"Number of routes with obstacles - {queenStepMap[rows - 1, columns - 1]}");
Console.WriteLine();
Console.WriteLine("Map");
PrintMap(rows, columns, Map);
Console.WriteLine();
Console.WriteLine("Map of the number of steps of the queen");
PrintMap(rows, columns, queenStepMap);



void PrintMap(int rows, int columns, int[,] map)
{
    int i, j;
    for (i = 0; i < rows; i++)
    {
        for (j = 0; j < columns; j++)
            Console.Write($"{map[i, j]} \t");
        Console.WriteLine();
    }

}