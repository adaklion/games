using System;

public class ComplexNumber
{
    public double Real { get; }
    public double Imaginary { get; }

    public ComplexNumber(double real, double imaginary)
    {
        Real = real;
        Imaginary = imaginary;
    }

    public static ComplexNumber operator +(ComplexNumber a, ComplexNumber b)
    {
        return new ComplexNumber(a.Real + b.Real, a.Imaginary + b.Imaginary);
    }

    public static ComplexNumber operator *(ComplexNumber a, ComplexNumber b)
    {
        return new ComplexNumber(
            a.Real * b.Real - a.Imaginary * b.Imaginary,
            a.Real * b.Imaginary + a.Imaginary * b.Real);
    }

    public static ComplexNumber operator /(ComplexNumber a, ComplexNumber b)
    {
        double denominator = b.Real * b.Real + b.Imaginary * b.Imaginary;
        return new ComplexNumber(
            (a.Real * b.Real + a.Imaginary * b.Imaginary) / denominator,
            (a.Imaginary * b.Real - a.Real * b.Imaginary) / denominator);
    }

    public ComplexNumber Power(int exponent)
    {
        ComplexNumber result = new ComplexNumber(1, 0);
        ComplexNumber baseNumber = this;

        for (int i = 0; i < exponent; i++)
        {
            result *= baseNumber;
        }

        return result;
    }

    public ComplexNumber SquareRoot()
    {
        double r = Math.Sqrt(Real * Real + Imaginary * Imaginary);
        double theta = Math.Atan2(Imaginary, Real) / 2;

        return new ComplexNumber(r * Math.Cos(theta), r * Math.Sin(theta));
    }

    public double Modulus()
    {
        return Math.Sqrt(Real * Real + Imaginary * Imaginary);
    }

    public double Angle()
    {
        return Math.Atan2(Imaginary, Real);
    }

    public override string ToString()
    {
        return $"{Real} + {Imaginary}i";
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите действительную часть первого комплексного числа:");
        double real1 = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Введите мнимую часть первого комплексного числа:");
        double imaginary1 = Convert.ToDouble(Console.ReadLine());
        ComplexNumber a = new ComplexNumber(real1, imaginary1);

        Console.WriteLine("Введите действительную часть второго комплексного числа:");
        double real2 = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Введите мнимую часть второго комплексного числа:");
        double imaginary2 = Convert.ToDouble(Console.ReadLine());
        ComplexNumber b = new ComplexNumber(real2, imaginary2);

        Console.WriteLine($"\na = {a}");
        Console.WriteLine($"b = {b}");

        Console.WriteLine($"Сложение: a + b = {a + b}");
        Console.WriteLine($"Умножение: a * b = {a * b}");
        Console.WriteLine($"Деление: a / b = {a / b}");
        Console.WriteLine($"Возведение в степень: a^2 = {a.Power(2)}");
        Console.WriteLine($"Извлечение корня: √a = {a.SquareRoot()}");
        Console.WriteLine($"Модуль a: |a| = {a.Modulus()}");
        Console.WriteLine($"Угол a: θ = {a.Angle()}");
    }
}

