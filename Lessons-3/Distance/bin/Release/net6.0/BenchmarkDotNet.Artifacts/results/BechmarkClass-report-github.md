``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19044.1052 (21H2)
Intel Core i7-3820 CPU 3.60GHz (Ivy Bridge), 1 CPU, 8 logical and 4 physical cores
.NET SDK=6.0.202
  [Host]     : .NET 6.0.4 (6.0.422.16404), X64 RyuJIT  [AttachedDebugger]
  DefaultJob : .NET 6.0.4 (6.0.422.16404), X64 RyuJIT


```
|        Method |    N |        Mean |     Error |    StdDev |
|-------------- |----- |------------:|----------:|----------:|
|   **Class_Float** |   **10** |    **31.97 ns** |  **0.572 ns** |  **0.507 ns** |
| Struct_Double |   10 |    15.51 ns |  0.313 ns |  0.278 ns |
|  Struct_Float |   10 |    31.70 ns |  0.668 ns |  0.820 ns |
|  Struct_Short |   10 |    32.29 ns |  0.503 ns |  0.471 ns |
|   **Class_Float** |  **100** |   **341.49 ns** |  **6.594 ns** |  **6.771 ns** |
| Struct_Double |  100 |   175.99 ns |  2.446 ns |  2.288 ns |
|  Struct_Float |  100 |   344.32 ns |  6.916 ns |  8.993 ns |
|  Struct_Short |  100 |   353.18 ns |  7.034 ns |  7.818 ns |
|   **Class_Float** | **1000** | **3,376.75 ns** | **44.947 ns** | **37.532 ns** |
| Struct_Double | 1000 | 1,729.65 ns | 29.523 ns | 27.616 ns |
|  Struct_Float | 1000 | 3,412.33 ns | 66.265 ns | 86.163 ns |
|  Struct_Short | 1000 | 3,426.69 ns | 31.700 ns | 29.653 ns |
