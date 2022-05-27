using Sorts;

int[] arr = new int[15];
Random rnd = new Random();

for (int i = 0; i < arr.Length; ++i)
{
    arr[i] = rnd.Next(-99, 100);
}

Console.WriteLine($"NOT Sort array\n{String.Join(" ", arr)}");
Utils.BucketSort(arr);
Console.WriteLine($"Sort array\n{String.Join(" ", arr)}");