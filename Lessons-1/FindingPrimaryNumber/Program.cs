for (int i = 0; i < 100; i++)
{
    Console.WriteLine($"Number [{i}] is [{SimpleOrComplexNumber(i)}]");
}

string SimpleOrComplexNumber(int number)
{
    int d = 0;

    for (int i = 2; i < number; i++)
    {
        if (number % i == 0)
        {
            d++;
        }
    }
    return d == 0 ? "Simple" : "Complex";
}