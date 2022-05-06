using BenchmarkDotNet.Attributes;
using Distance;

public class BechmarkClass
{
    PointClass[] pointsClass;
    PointStructFloat[] pointStructFloats;
    PointStructDoudle[] pointStructDoudles;

    [Params(10, 100, 1000)]
    public int N;

    [GlobalSetup]
    public void Setup()
    {
        pointStructDoudles = new PointStructDoudle[N];
        pointStructFloats = new PointStructFloat[N];
        pointsClass = new PointClass[N];

        for (int i = 0; i < N; i++)
        {
            pointStructDoudles[i] = new PointStructDoudle(
                new Random(-10).NextDouble(),
                new Random(10).NextDouble()
                );

            pointStructFloats[i] = new PointStructFloat(
                new Random(-10).NextSingle(),
                new Random(10).NextSingle()
                );

            pointsClass[i] = new PointClass(
                new Random(-10).NextSingle(),
                new Random(10).NextSingle()
                );
        }
    }

    public static double PointDistanceFloat(PointClass pointOne, PointClass pointTwo)
    {
        double x = pointOne.X - pointTwo.X;
        double y = pointOne.Y - pointTwo.Y;
        return Math.Sqrt((x * x) + (y * y));
    }
    public static double PointDistanceDouble(PointStructDoudle pointOne, PointStructDoudle pointTwo)
    {
        double x = pointOne.X - pointTwo.X;
        double y = pointOne.Y - pointTwo.Y;
        return Math.Sqrt((x * x) + (y * y));
    }
    public static float PointDistanceFloat(PointStructFloat pointOne, PointStructFloat pointTwo)
    {
        float x = pointOne.X - pointTwo.X;
        float y = pointOne.Y - pointTwo.Y;
        return MathF.Sqrt((x * x) + (y * y));
    }
    public static float PointDistanceShort(PointStructFloat pointOne, PointStructFloat pointTwo)
    {
        float x = pointOne.X - pointTwo.X;
        float y = pointOne.Y - pointTwo.Y;
        return (x * x) + (y * y);
    }

    [Benchmark(Description = "Class_Float")]
    public void BenchmarkPointDistanceClass()
    {
        for (int i = 0; i < pointsClass.Length - 1; i++)
        {
            PointDistanceFloat(pointsClass[i], pointsClass[i + 1]);
        }
    }

    [Benchmark(Description = "Struct_Double")]
    public void BenchmarkPointDistanceStructDouble()
    {
        for (int i = 0; i < pointStructDoudles.Length - 1; i++)
        {
            PointDistanceDouble(pointStructDoudles[i], pointStructDoudles[i + 1]);
        }
    }

    [Benchmark(Description = "Struct_Float")]
    public void BenchmarkPointDistanceStructFloat()
    {
        for (int i = 0; i < pointStructFloats.Length - 1; i++)
        {
            PointDistanceFloat(pointStructFloats[i], pointStructFloats[i + 1]);
        }
    }
    [Benchmark(Description = "Struct_Short")]
    public void BenchmarkPointDistanceShort()
    {
        for (int i = 0; i < pointStructFloats.Length - 1; i++)
        {
            PointDistanceShort(pointStructFloats[i], pointStructFloats[i + 1]);
        }
    }
}
