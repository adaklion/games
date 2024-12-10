using System;

class MazeGame
{
    private const int Width = 20; // Ширина лабиринта
    private const int Height = 10; // Высота лабиринта
    private char[,] maze;
    private bool[,] visible; // Видимость клеток
    private int playerX, playerY; // Координаты игрока
    private int exitX, exitY; // Координаты выхода
    private int timeLimit = 120; // Ограничение по времени (в секундах)
    private DateTime startTime;

    private Random random = new Random();

    public void Start()
    {
        GenerateMaze();
        InitializeVisibility();

        startTime = DateTime.Now;

        while (true)
        {
            Console.Clear();
            Render();

            if (IsTimeUp())
            {
                Console.WriteLine("⏳ Время вышло! Вы проиграли.");
                break;
            }

            if (playerX == exitX && playerY == exitY)
            {
                Console.WriteLine("🎉 Вы нашли выход! Победа!");
                break;
            }

            ConsoleKey key = Console.ReadKey(true).Key;
            switch (key)
            {
                case ConsoleKey.W: Move(0, -1); break; // Вверх
                case ConsoleKey.S: Move(0, 1); break;  // Вниз
                case ConsoleKey.A: Move(-1, 0); break; // Влево
                case ConsoleKey.D: Move(1, 0); break;  // Вправо
            }
        }
    }

    private void GenerateMaze()
    {
        maze = new char[Height, Width];
        for (int y = 0; y < Height; y++)
        {
            for (int x = 0; x < Width; x++)
            {
                maze[y, x] = (random.Next(0, 4) == 0) ? '#' : ' '; // 25% шанс на стену
            }
        }

        // Установить игрока
        playerX = random.Next(0, Width);
        playerY = random.Next(0, Height);
        maze[playerY, playerX] = ' ';

        // Установить выход
        do
        {
            exitX = random.Next(0, Width);
            exitY = random.Next(0, Height);
        } while (exitX == playerX && exitY == playerY || maze[exitY, exitX] == '#');

        maze[exitY, exitX] = 'E'; // Символ выхода
    }

    private void InitializeVisibility()
    {
        visible = new bool[Height, Width];
        for (int y = 0; y < Height; y++)
        {
            for (int x = 0; x < Width; x++)
            {
                visible[y, x] = false;
            }
        }

        visible[playerY, playerX] = true;
    }

    private void Move(int dx, int dy)
    {
        int newX = playerX + dx;
        int newY = playerY + dy;

        if (newX < 0 || newX >= Width || newY < 0 || newY >= Height) return; // Выход за границы
        if (maze[newY, newX] == '#') return; // Стена

        playerX = newX;
        playerY = newY;

        visible[playerY, playerX] = true; // Открываем клетку
    }

    private void Render()
    {
        Console.WriteLine("⏳ Осталось времени: " + (timeLimit - (int)(DateTime.Now - startTime).TotalSeconds) + " сек.");
        Console.WriteLine("WASD — для перемещения");

        for (int y = 0; y < Height; y++)
        {
            for (int x = 0; x < Width; x++)
            {
                if (visible[y, x])
                {
                    if (x == playerX && y == playerY)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write('C');
                    }
                    else if (maze[y, x] == '#')
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write('#');
                    }
                    else if (maze[y, x] == 'E')
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write('E');
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(' ');
                    }
                }
                else
                {
                    Console.Write('░'); // Неоткрытые клетки
                }
            }
            Console.WriteLine();
        }
        Console.ResetColor();
    }

    private bool IsTimeUp()
    {
        return (DateTime.Now - startTime).TotalSeconds >= timeLimit;
    }
}

class Program
{
    static void Main(string[] args)
    {
        new MazeGame().Start();
    }
}