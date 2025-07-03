using System.ComponentModel.DataAnnotations;

namespace Bludiště
{
    internal class Program
    {
        static int hracX = 0, hracY = 0;
        static char[,] pole;
        static int numbers = 1;
        static string path = $"Blud{numbers}.txt";
        
        static void Main(string[] args)
        {
            NactiMapu(path);
            //0 - zed 1- cesta 2- hráč 3 - cíl
            while (true)
            {
                
                Console.SetCursorPosition(0, 0);
                Vypis();
                Pohyb();
                
            }


        }
        static void NactiMapu(string path)
        {
            try
            {
                string[] radky = File.ReadAllLines(path);
                int vyska = radky.Length;
                int sirka = radky[0].Length;
                pole = new char[vyska, sirka];

                for (int y = 0; y < vyska; y++)
                {
                    for (int x = 0; x < sirka; x++)
                    {
                        pole[y, x] = radky[y][x];
                        if (pole[y, x] == '2')
                        {
                            hracX = x;
                            hracY = y;
                        }
                    }
                }
            }
            catch 
            {
                Console.Clear();
                Console.WriteLine("Už není žádné další bludiště ");
                Environment.Exit(0);

            }
            
        }
        static void Vypis()
        {
            for (int i = 0; i < pole.GetLength(0); i++)
            {
                for (int j = 0; j < pole.GetLength(1); j++)
                {
                    if (pole[i, j] == '1')
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.Write("  ");
                        Console.ResetColor();
                    }
                    else if (pole[i, j] == '0')
                    {
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.Write("  ");
                        Console.ResetColor();
                    }
                    else if (pole[i, j] == '2')
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.Write("  ");
                        Console.ResetColor();
                    }
                    else if (pole[i, j] == '3')
                    {
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        Console.Write("  ");
                        Console.ResetColor();
                    }

                }
                Console.WriteLine();
            }
        }

        static void Pohyb()
        {
            
            Console.CursorVisible = false;
            ConsoleKey key = Console.ReadKey(true).Key;
            int novyX = hracX, novyY = hracY;
           
            switch (key)
            {
                case ConsoleKey.W: 
                   
                    if (novyY != 0) { novyY--; } break;
                case ConsoleKey.S: 
                    if (pole.GetLength(0) - 1 > novyY) novyY++; break;
                case ConsoleKey.A: 
                    if (novyX != 0) { novyX--; } break;
                case ConsoleKey.D: 
                    if (pole.GetLength(1) - 1 > novyX) novyX++; break;

            }
            if (pole[novyY, novyX] == '0' )
            {
                
            }
            else
            {
                if (pole[novyY, novyX] == '3')
                {
                    Console.Clear();
                    Console.WriteLine("Vyhrál jsi!");
                    Console.ReadKey();
                    numbers++;
                    path = $"Blud{numbers}.txt";
                    NactiMapu(path);
                }
                pole[hracY, hracX] = '1';

                hracX = novyX;
                hracY = novyY;
                pole[hracY, hracX] = '2';
            }
            
        }
        
        
        
    }
}
