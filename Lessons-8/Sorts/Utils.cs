namespace Sorts;

public static class Utils
{
    public static void BucketSort(int[] array)
    {
        List<int>[] buckets = new List<int>[array.Length];

        for (int i = 0; i < buckets.Length; ++i)
        {
            buckets[i] = new List<int>();
        }

        int minValue = array[0];
        int maxValue = array[0];

        for (int i = 1; i < array.Length; ++i)
        {
            if (array[i] < minValue)
            {
                minValue = array[i];
            }
            else if (array[i] > maxValue)
            {
                maxValue = array[i];
            }
        }

        double numbersRange = maxValue - minValue;

        for (int i = 0; i < array.Length; ++i)
        {
            int bucketIndex = (int)Math.Floor((array[i] - minValue) / numbersRange * (buckets.Length - 1));

            buckets[bucketIndex].Add(array[i]);
        }

        for (int i = 0; i < buckets.Length; ++i)
        {
            var bucket = buckets[i].ToArray();
            if (bucket.Length > 1)
            {
                QuickSort(bucket, 0, bucket.Length - 1);
            }            
            buckets[i] = bucket.ToList();
        }

        int index = 0;

        for (int i = 0; i < buckets.Length; ++i)
        {
            for (int j = 0; j < buckets[i].Count; ++j)
            {
                array[index++] = buckets[i][j];
            }
        }
    }

    public static void QuickSort(int[] array, int first, int last)
    {
        int i = first;
        int j = last;
        int x = array[(first + last) / 2];

        do
        {
            while (array[i] < x)
            {
                i++;
            }
            while (array[j] > x)
            {
                j--;
            }
            if (i <= j)
            {
                if (array[i] > array[j])
                {
                    var tmp = array[i];
                    array[i] = array[j];
                    array[j] = tmp;
                }
                i++;
                j--;
            }
        } while (i <= j);

        if (i < last)
        {
            QuickSort(array, i, last);
        }

        if (first < j)
        {
            QuickSort(array, first, j);
        }
    }
}
