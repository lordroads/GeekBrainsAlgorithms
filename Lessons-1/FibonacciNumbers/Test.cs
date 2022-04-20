public class Test
{
    public static void TestFibonacci(TestCase testCase, ICalculate function)
    {
        try
        {
            var actual = function.Calculations(testCase.Number);
            if (actual == testCase.Expected)
            {
                Console.WriteLine("VALID TEST");
            }
            else
            {
                Console.WriteLine("INVALID TEST");
            }
        }
        catch (Exception ex)
        {
            if (testCase.ExpectedException != null)
            {
                Console.WriteLine("VALID TEST");
            }
            else
            {
                Console.WriteLine("INVALID TEST");
            }
        }
    }
}
