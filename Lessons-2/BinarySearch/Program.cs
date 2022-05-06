int[] array = new int[1000];

for (int i = 0; i < array.Length; i++)
{
    array[i] = i;
}

int resul = BinarySearch(array, 32);

Console.WriteLine(resul);

//O (log 2 n), где n - количество элементов в массиве
int BinarySearch(int[] inputArray, int searchValue)
{
    int min = 0;
    int max = inputArray.Length - 1;
    while (min <= max)
    {
        int mid = (min + max) / 2;
        if (searchValue == inputArray[mid])
        {
            return mid;
        }
        else if (searchValue < inputArray[mid])
        {
            max = mid - 1;
        }
        else
        {
            min = mid + 1;
        }
    }
    return -1;
}