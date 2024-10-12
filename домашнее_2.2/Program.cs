using System;
using System.Numerics;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите номер числа Фибоначчи для подсчета:");
        int n = Convert.ToInt32(Console.ReadLine());

        // Итеративный вариант
        BigInteger fibIterative = FibonacciIterative(n);
        Console.WriteLine($"Итеративный вариант: F({n}) = {fibIterative}");

        // Рекурсивный вариант
        BigInteger fibRecursive = FibonacciRecursive(n);
        Console.WriteLine($"Рекурсивный вариант: F({n}) = {fibRecursive}");

        MeasurePerformance(n);
    }

    static BigInteger FibonacciIterative(int n)
    {
        if (n < 0) throw new ArgumentException("n должен быть неотрицательным.");
        if (n == 0) return 0;
        if (n == 1) return 1;

        BigInteger a = 0, b = 1;

        for (int i = 2; i <= n; i++)
        {
            BigInteger temp = a + b;
            a = b;
            b = temp;
        }

        return b;
    }

    static BigInteger FibonacciRecursive(int n)
    {
        if (n < 0) throw new ArgumentException("n должен быть неотрицательным.");
        if (n == 0) return 0;
        if (n == 1) return 1;

        return FibonacciRecursive(n - 1) + FibonacciRecursive(n - 2);
    }

    static void MeasurePerformance(int n)
    {
        var watch = System.Diagnostics.Stopwatch.StartNew();
        FibonacciRecursive(n);
        watch.Stop();
        Console.WriteLine($"Время выполнения рекурсивного метода для n = {n}: {watch.ElapsedMilliseconds} ms");

        watch.Restart();
        FibonacciIterative(n);
        watch.Stop();
        Console.WriteLine($"Время выполнения итеративного метода для n = {n}: {watch.ElapsedMilliseconds} ms");
    }
}
