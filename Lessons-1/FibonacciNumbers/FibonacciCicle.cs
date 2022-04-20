public class FibonacciCicle : ICalculate
{
    public int Calculations(int number)
    {
        if (number < 0)
            throw new Exception("Negative number!");

        if (number < 2)
        {
            return number;
        }

        int first = 0, second = 1, next = 0;

        for (int i = 1; i < number; i++)
        {
            next = first + second;
            first = second;
            second = next;
        }

        return next;
    }
}