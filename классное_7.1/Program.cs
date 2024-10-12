using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите целое число:");

        try
        {
            string input = Console.ReadLine();
            int number = ConvertToInt(input);
            Console.WriteLine($"Вы ввели число: {number}");
        }
        catch (FormatException)
        {
            Console.WriteLine("Ошибка: введено не число.");
        }
        catch (OverflowException)
        {
            Console.WriteLine("Ошибка: введенное число слишком большое или слишком маленькое.");
        }
    }

    static int ConvertToInt(string input)
    {
        return int.Parse(input);
    }
}

