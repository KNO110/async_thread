using System;
using System.Threading;

class Program
{
    static void Main()
    {
        int lowerBound = 0;
        int upperBound = 0;

        Console.WriteLine("Дай начало диапазона:");
        int.TryParse(Console.ReadLine(), out lowerBound);

        Console.WriteLine("Дай конец диапазона(0 - для того чтобы не было границ):");
        int.TryParse(Console.ReadLine(), out upperBound);

        Thread primeThread = new Thread(() =>
        {
            GeneratePrimes(lowerBound, upperBound);
        });

        primeThread.Start();
    }

    static void GeneratePrimes(int lowerBound, int upperBound)
    {
        if (upperBound == 0)
        {
            upperBound = int.MaxValue;
        }

        for (int number = lowerBound; number <= upperBound; number++)
        {
            if (IsPrime(number))
            {
                Console.WriteLine(number);
            }
        }
    }

    static bool IsPrime(int number)
    {
        if (number <= 1)
            return false;
        if (number == 2)
            return true;
        if (number % 2 == 0)
            return false;

        int boundary = (int)Math.Floor(Math.Sqrt(number));

        for (int i = 3; i <= boundary; i += 2)
        {
            if (number % i == 0)
                return false;
        }

        return true;
    }
}
