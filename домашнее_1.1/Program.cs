using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите число n:");
        int n = Convert.ToInt32(Console.ReadLine());

        if (n < 2)
        {
            Console.WriteLine("Простых чисел не существует.");
            return;
        }

        Console.WriteLine($"Простые числа до {n}:");
        PrintPrimes(n);
    }

    static void PrintPrimes(int n)
    {
        bool[] isPrime = new bool[n + 1];

        for (int i = 2; i <= n; i++)
        {
            isPrime[i] = true;
        }

        for (int i = 2; i * i <= n; i++)
        {
            if (isPrime[i])
            {
                for (int j = i * i; j <= n; j += i)
                {
                    isPrime[j] = false;
                }
            }
        }

        for (int i = 2; i <= n; i++)
        {
            if (isPrime[i])
            {
                Console.Write(i + " ");
            }
        }
        Console.WriteLine();
    }
}
