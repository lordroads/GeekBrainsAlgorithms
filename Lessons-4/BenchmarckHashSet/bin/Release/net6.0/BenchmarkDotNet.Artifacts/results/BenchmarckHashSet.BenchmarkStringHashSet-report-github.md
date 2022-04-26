``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19044.1052 (21H2)
Intel Core i7-3820 CPU 3.60GHz (Ivy Bridge), 1 CPU, 8 logical and 4 physical cores
.NET SDK=6.0.202
  [Host]     : .NET 6.0.4 (6.0.422.16404), X64 RyuJIT  [AttachedDebugger]
  DefaultJob : .NET 6.0.4 (6.0.422.16404), X64 RyuJIT


```
|                       Method | Count |           Mean |        Error |       StdDev | Rank |
|----------------------------- |------ |---------------:|-------------:|-------------:|-----:|
| **&#39;Contains string in HashSet&#39;** | **10000** |       **277.6 μs** |      **5.24 μs** |      **4.91 μs** |    **1** |
|   &#39;Contains string in Array&#39; | 10000 |   289,768.7 μs |  5,474.35 μs |  6,304.27 μs |    4 |
| **&#39;Contains string in HashSet&#39;** | **15000** |       **467.5 μs** |      **7.99 μs** |      **7.48 μs** |    **2** |
|   &#39;Contains string in Array&#39; | 15000 |   650,264.1 μs | 10,599.39 μs |  9,396.09 μs |    5 |
| **&#39;Contains string in HashSet&#39;** | **20000** |       **590.7 μs** |      **5.44 μs** |      **4.54 μs** |    **3** |
|   &#39;Contains string in Array&#39; | 20000 | 1,162,316.5 μs | 12,343.17 μs | 10,307.10 μs |    6 |
