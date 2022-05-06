public class FibonacciRecursion : ICalculate
{
    public int Calculations(int number)
    {
        if (number < 0)
            throw new Exception("Negative number!");

        if (number < 2)
        {
            return number;
        }
        return Calculations(number - 2) + Calculations(number - 1);
    }
}