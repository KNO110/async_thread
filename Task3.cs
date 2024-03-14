using System;
using System.Threading;

class Program
{
    static void Main()
    {
        int lowerBound = 0;
        int upperBound = 0;
        Thread primeThread = null;
        Thread fiboThread = null;

        Console.WriteLine("Дай начало диапазона:");
        int.TryParse(Console.ReadLine(), out lowerBound);

        Console.WriteLine("Дай конец диапазона(0 - для того чтобы не было границ):");
        int.TryParse(Console.ReadLine(), out upperBound);

        Console.WriteLine("Выбери поток для начала (1 - для простых чисел, 2 - для фиьоначи):");
        int choice = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1:
                primeThread = new Thread(() =>
                {
                    GeneratePrimes(lowerBound, upperBound);
                });
                primeThread.Start();
                break;
            case 2:
                fiboThread = new Thread(() =>
                {
                    GenerateFibonacci(lowerBound, upperBound);
                });
                fiboThread.Start();
                break;
            default:
                Console.WriteLine("Чё-то не то.");
                break;
        }

        Console.WriteLine("Нажми любую кнопку чтобы остановится.");
        Console.ReadKey();

        if (primeThread != null)
            primeThread.Abort();
        if (fiboThread != null)
            fiboThread.Abort();
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
                Console.WriteLine($"Простое число: {number}");
            }
        }
    }

    static void GenerateFibonacci(int lowerBound, int upperBound)
    {
        int a = 0;
        int b = 1;
        int temp;

        while (a <= upperBound || upperBound == 0)
        {
            Console.WriteLine($"Фибоанчи: {a}");

            temp = a;
            a = b;
            b = temp + b;
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
