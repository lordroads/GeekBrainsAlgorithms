List<TestCase> testCases = new List<TestCase>()
{
    new TestCase()
    {
        Number = 1,
        Expected = 1,
        ExpectedException = null
    },
    new TestCase()
    {
        Number = 2,
        Expected = 1,
        ExpectedException = null
    },
    new TestCase()
    {
        Number = 3,
        Expected = 2,
        ExpectedException = null
    },
    new TestCase()
    {
        Number = 10,
        Expected = 55,
        ExpectedException = null
    },
    new TestCase()
    {
        Number = -1,
        ExpectedException = new Exception("Negative number!")
    },
};

FibonacciRecursion fibonacciRecursion = new FibonacciRecursion();
FibonacciCicle fibonacciCicle = new FibonacciCicle();

foreach (var test in testCases)
{
    Console.WriteLine(test.ToString());
    Test.TestFibonacci(test, fibonacciRecursion);
    Console.WriteLine();
}
foreach (var test in testCases)
{
    Console.WriteLine(test.ToString());
    Test.TestFibonacci(test, fibonacciCicle);
    Console.WriteLine();
}
