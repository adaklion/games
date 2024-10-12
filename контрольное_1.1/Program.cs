using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите трёхзначное число:");
        int number = Convert.ToInt32(Console.ReadLine());

        if (number < 100 || number > 999)
        {
            Console.WriteLine("Ошибка: введено не трёхзначное число.");
            return;
        }

        int units = number % 10;
        int tens = (number / 10) % 10;
        int hundreds = number / 100;

        int sum = units + tens + hundreds;
        int product = units * tens * hundreds;

        Console.WriteLine($"Число единиц в введённом числе: {units}");
        Console.WriteLine($"Число десятков в введённом числе: {tens}");
        Console.WriteLine($"Сумма цифр в введённом числе: {sum}");
        Console.WriteLine($"Произведение цифр в введённом числе: {product}");
    }
}