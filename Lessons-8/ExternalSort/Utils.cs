namespace Sorts;

public static class Utils
{
    public static void ExternalSort(string pathToDataFile)
    {

        int sizeBlock = 100000;
        decimal dataLength = File.ReadLines(pathToDataFile).Count();
        int countBuckets = (int)Math.Ceiling(dataLength / sizeBlock);

        string nameFileOut = "out_data.txt";
        if (File.Exists(nameFileOut))
        {
            File.Delete(nameFileOut);
        }

        string directoryName = "temp";
        if (!Directory.Exists(directoryName))
        {
            Directory.CreateDirectory(directoryName);
        }
        else
        {
            string[] tmpFiles = Directory.GetFiles(directoryName);
            for (int i = 0; i < tmpFiles.Length; i++)
            {
                string fileName = tmpFiles[i];
                File.Delete(fileName);
            }
        }

        string[] buckets = new string[countBuckets];
        for (int i = 0; i < buckets.Length; ++i)
        {
            buckets[i] = $"tmp_IN_{i}.txt";
        }

        using (StreamReader readerData = new StreamReader(Path.Combine(Directory.GetCurrentDirectory(), pathToDataFile)))
        {
            for (int i = 0; i < buckets.Length; i++)
            {

                using (StreamWriter writerBucket = File.AppendText(Path.Combine(Directory.GetCurrentDirectory(), directoryName, buckets[i])))
                {
                        
                    for (int c = 0; c < sizeBlock; c++)
                    {
                        string tempLine = readerData.ReadLine();
                        if (tempLine == null) break;
                        writerBucket.WriteLine(tempLine);
                    }
                }
            }
        }

        for (int i = 0; i < buckets.Length; ++i)
        {
            string pathToTemp = Path.Combine(Directory.GetCurrentDirectory(), directoryName, buckets[i]);
            int tempLength = File.ReadAllLines(pathToTemp).Length;
            int[] bucket = new int[tempLength];
            int count = 0;
            using (StreamReader readerTempBucket = new StreamReader(pathToTemp))
            {
                while (true)
                {
                    string l = readerTempBucket.ReadLine();
                    int tempLine = Convert.ToInt32(l);

                    if (tempLine == null || count >= tempLength)
                    {
                        break;
                    }

                    bucket[count++] = tempLine;
                }
            }

            QuickSort(bucket, 0, bucket.Length - 1);

            using (StreamWriter writerTempBucket = new StreamWriter(pathToTemp))
            {
                for(int c = 0; c < bucket.Length; ++c)
                {
                    writerTempBucket.WriteLine(bucket[c]);
                }
            }
        }

        while(Directory.GetFiles(directoryName).Length > 1)
        {
            string[] tmpFiles = Directory.GetFiles(directoryName);
            string dataLeft = tmpFiles[0];
            string dataRight = tmpFiles[tmpFiles.Length - 1];

            MergeIntegersFiles(dataLeft, dataRight, "temp.txt");

            using (StreamReader readerTemp = new StreamReader("temp.txt"))
            {
                using (StreamWriter writerTemp = new StreamWriter(dataLeft))
                {
                    foreach (var value in GetSortedValues(ToIterator(readerTemp)))
                    {
                        writerTemp.WriteLine(value);
                    }
                }
            }
            
            File.Delete(dataRight);
            File.Delete("temp.txt");
        }

        File.Move(Path.Combine(Directory.GetCurrentDirectory(), directoryName, buckets[0]), Path.Combine(Directory.GetCurrentDirectory(), nameFileOut));

        if (Directory.Exists(directoryName))
        {
            string[] tmpFiles = Directory.GetFiles(directoryName);
            for (int i = 0; i < tmpFiles.Length; i++)
            {
                string fileName = tmpFiles[i];
                File.Delete(fileName);
            }

            Directory.Delete(directoryName);
        }
    }

    static void QuickSort(int[] array, int first, int last)
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

    static IEnumerator<int> ToIterator(StreamReader reader)
    {
        string line;
        while ((line = reader.ReadLine()) != null)
        {
            yield return Convert.ToInt32(line);
        }
    }
    static IEnumerable<T> GetSortedValues<T>(IEnumerator<T> iterator1, IEnumerator<T> iterator2) where T : IComparable<T>
    {
        var iterator1StillAvailable = iterator1.MoveNext();
        var iterator2StillAvailable = iterator2.MoveNext();

        while (iterator1StillAvailable && iterator2StillAvailable)
        {
            if (iterator1.Current.CompareTo(iterator2.Current) < 1)
            {
                yield return iterator1.Current;
                iterator1StillAvailable = iterator1.MoveNext();
            }
            else
            {
                yield return iterator2.Current;
                iterator2StillAvailable = iterator2.MoveNext();
            }
        }

        var iteratorRemaining = iterator1StillAvailable
           ? iterator1
           : iterator2StillAvailable ? iterator2 : null;

        if (iteratorRemaining != null)
        {
            do
            {
                yield return iteratorRemaining.Current;
            } while (iteratorRemaining.MoveNext());
        }
    }
    static IEnumerable<T> GetSortedValues<T>(IEnumerator<T> iterator) where T : IComparable<T>
    {
        var iterator1StillAvailable = iterator.MoveNext();

        while (iterator1StillAvailable)
        {
            yield return iterator.Current;
            iterator1StillAvailable = iterator.MoveNext();
        }
    }
    static void MergeIntegersFiles(string source1, string source2, string destination)
    {
        using (var reader1 = new StreamReader(source1))
        {
            using (var reader2 = new StreamReader(source2))
            {
                using (var writer = new StreamWriter(destination))
                {
                    foreach (var value in GetSortedValues(ToIterator(reader1), ToIterator(reader2)))
                    {
                        writer.WriteLine(value);
                    }
                }
            }
        }
    }
}
