using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите коэффициенты a, b и c:");

        Console.Write("a: ");
        double a = Convert.ToDouble(Console.ReadLine());

        Console.Write("b: ");
        double b = Convert.ToDouble(Console.ReadLine());

        Console.Write("c: ");
        double c = Convert.ToDouble(Console.ReadLine());

        SolveEquation(a, b, c);
    }

    static void SolveEquation(double a, double b, double c)
    {
        if (a != 0)
        {
            double discriminant = b * b - 4 * a * c;

            if (discriminant > 0)
            {
                double x1 = (-b + Math.Sqrt(discriminant)) / (2 * a);
                double x2 = (-b - Math.Sqrt(discriminant)) / (2 * a);
                Console.WriteLine($"Два решения: x1 = {x1}, x2 = {x2}");
            }
            else if (discriminant == 0)
            {
                double x = -b / (2 * a);
                Console.WriteLine($"Одно решение: x = {x}");
            }
            else
            {
                Console.WriteLine("Нет решений (дискриминант меньше нуля).");
            }
        }
        else if (b != 0)
        {
            double x = -c / b;
            Console.WriteLine($"Одно решение: x = {x}");
        }
        else
        {
            if (c == 0)
            {
                Console.WriteLine("Бесконечно много решений (равенство 0 = 0).");
            }
            else
            {
                Console.WriteLine("Нет решений (равенство c = 0, где c != 0).");
            }
        }
    }
}