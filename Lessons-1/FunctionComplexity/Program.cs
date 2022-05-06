
int StrangeSum(int[] inputArray)
{
    int sum = 0;
    for (int i = 0; i < inputArray.Length; i++) //O(n)
    {
        for (int j = 0; j < inputArray.Length; j++) //O(n)
        {
            for (int k = 0; k < inputArray.Length; k++) //O(n)
            {
                int y = 0;
                if (j != 0)
                {
                    y = k / j;
                }
                sum += inputArray[i] + i + k + j + y;
            }
        }
    }
    return sum;
}

//Асимптотическая сложность функции = O(n^3)