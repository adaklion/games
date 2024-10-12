using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        string filePath = "f.txt";

        using (StreamWriter writer = new StreamWriter(filePath))
        {
            writer.WriteLine("x sin(x)");

            for (double x = 0; x <= 1; x += 0.1)
            {
                double sinValue = Math.Sin(x);

                writer.WriteLine($"{x:F1} {sinValue:F5}");
            }
        }

        Console.WriteLine("Таблица значений sin(x) успешно записана в файл f.txt.");
    }
}