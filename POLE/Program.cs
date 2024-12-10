using System;

class SokobanGame
{
    private const int Width = 10;
    private const int Height = 10;
    private char[,] map;
    private int playerX, playerY;
    private int currentLevel = 0;

    private readonly string[][] levels = new string[][]
    {
        new string[]
        {
            "##########",
            "#C   O   #",
            "# R  TT  #",
            "#   R    #",
            "#  O     #",
            "#   T    #",
            "#        #",
            "#    TT  #",
            "#   O    #",
            "##########"
        },
        new string[]
        {
            "##########",
            "#C   T   #",
            "# O  RR  #",
            "#    TT  #",
            "#   O    #",
            "#        #",
            "#  T     #",
            "#   O R  #",
            "#     T  #",
            "##########"
        }
    };

    public void Start()
    {
        while (true)
        {
            LoadLevel();
            PlayLevel();

            currentLevel++;
            if (currentLevel >= levels.Length)
            {
                Console.Clear();
                Console.WriteLine("Поздравляем! Вы завершили игру!");
                break;
            }
        }
    }

    private void LoadLevel()
    {
        string[] levelData = levels[currentLevel];
        map = new char[Height, Width];
        for (int y = 0; y < Height; y++)
        {
            for (int x = 0; x < Width; x++)
            {
                map[y, x] = levelData[y][x];
                if (map[y, x] == 'C')
                {
                    playerX = x;
                    playerY = y;
                }
            }
        }
    }

    private void PlayLevel()
    {
        while (true)
        {
            Console.Clear();
            Render();

            if (IsLevelComplete())
            {
                Console.WriteLine("Уровень завершён!");
                Console.ReadKey();
                return;
            }

            ConsoleKey key = Console.ReadKey(true).Key;
            switch (key)
            {
                case ConsoleKey.W: Move(0, -1); break;
                case ConsoleKey.S: Move(0, 1); break;
                case ConsoleKey.A: Move(-1, 0); break;
                case ConsoleKey.D: Move(1, 0); break;
            }
        }
    }

    private void Move(int dx, int dy)
    {
        int newX = playerX + dx;
        int newY = playerY + dy;

        if (!IsWalkable(newX, newY)) return;

        if (map[newY, newX] == 'R')
        {
            int pushX = newX + dx;
            int pushY = newY + dy;

            if (!IsWalkable(pushX, pushY) || map[pushY, pushX] == 'R')
                return;

            map[pushY, pushX] = 'R';
            map[newY, newX] = ' ';
        }

        map[playerY, playerX] = ' ';
        playerX = newX;
        playerY = newY;

        map[playerY, playerX] = map[playerY, playerX] == 'O' ? 'Ⓒ' : 'C';
    }

    private bool IsWalkable(int x, int y)
    {
        if (x < 0 || x >= Width || y < 0 || y >= Height) return false;

        char tile = map[y, x];
        return tile == ' ' || tile == 'O' || tile == 'R';
    }

    private bool IsLevelComplete()
    {
        for (int y = 0; y < Height; y++)
        {
            for (int x = 0; x < Width; x++)
            {
                if (map[y, x] == 'O') return false;
            }
        }
        return true;
    }

    private void Render()
    {
        for (int y = 0; y < Height; y++)
        {
            for (int x = 0; x < Width; x++)
            {
                Console.ForegroundColor = GetTileColor(map[y, x]);
                Console.Write(map[y, x]);
            }
            Console.WriteLine();
        }
        Console.ResetColor();
    }

    private ConsoleColor GetTileColor(char tile)
    {
        return tile switch
        {
            '#' => ConsoleColor.DarkGray,
            'T' => ConsoleColor.Green,
            'R' => ConsoleColor.Red,
            'O' => ConsoleColor.Yellow,
            'Ⓒ' => ConsoleColor.Cyan,
            'Ⓡ' => ConsoleColor.Blue,
            _ => ConsoleColor.White
        };
    }
}

class Program
{
    static void Main(string[] args)
    {
        new SokobanGame().Start();
    }
}
