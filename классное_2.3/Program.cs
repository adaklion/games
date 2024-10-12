using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите число n:");
        int n = Convert.ToInt32(Console.ReadLine());

        int steps = CountStepsToReachOne(n);
        Console.WriteLine($"Количество замен, необходимых для достижения 1: {steps}");
    }

    static int CountStepsToReachOne(int n)
    {
        int count = 0;

        while (n != 1)
        {
            count++;

            if (n % 2 == 0)
            {
                Console.WriteLine($"Замена {count}: {n} -> {n / 2}");
                n /= 2; 
            }
            else
            {
                Console.WriteLine($"Замена {count}: {n} -> {3 * n + 1}");
                n = 3 * n + 1;
            }
        }

        return count;
    }
}