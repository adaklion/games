using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите размер массива:");
        int n = Convert.ToInt32(Console.ReadLine());

        int[] array = new int[n];

        Console.WriteLine("Введите элементы массива:");
        for (int i = 0; i < n; i++)
        {
            array[i] = Convert.ToInt32(Console.ReadLine());
        }

        BubbleSort(array);

        Console.WriteLine("Отсортированный массив:");
        foreach (var item in array)
        {
            Console.Write(item + " ");
        }
    }

    static void BubbleSort(int[] array)
    {
        int n = array.Length;

        for (int i = 0; i < n - 1; i++)
        {
            Console.WriteLine($"\nПроход {i + 1}:");

            for (int j = 0; j < n - 1 - i; j++)
            {
                if (array[j] > array[j + 1])
                {
                    Console.WriteLine($"  Действие {j + 1}: Меняем {array[j]} и {array[j + 1]}");

                    int temp = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = temp;
                }
                else
                {
                    Console.WriteLine($"  Действие {j + 1}: {array[j]} и {array[j + 1]} в правильном порядке");
                }
            }

            Console.WriteLine("  Текущий массив: " + string.Join(", ", array));
        }
    }
}