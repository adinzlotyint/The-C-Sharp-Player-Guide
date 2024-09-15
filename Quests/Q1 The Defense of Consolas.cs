using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quest1
{
    class Quest
    {
        struct Coordinates
        {
            public int row;
            public int col;
        }
        public static void Start()
        {
            bool repeat = true;
            int row = 0;
            int column = 0;
            while (repeat)
            {
                Console.WriteLine("Provide the row number (2 to 9):");
                var answer = Console.ReadLine();
                int.TryParse(answer, out row);
                Console.WriteLine("Provide the column number (2 to 9):");
                var answer2 = Console.ReadLine();
                int.TryParse(answer2, out column);

                if (row >= 2 && row <= 9 && column >= 2 && column <= 9)
                {
                    repeat = false;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please provide a number between 2 and 9.");
                }
            }

            Console.WriteLine($"The provided row {row} and the provided column {column} will be detonated.");
            Thread.Sleep(2000);

            Dictionary<string, Coordinates> localization = new Dictionary<string, Coordinates>();
            localization.Add("Guard1", new Coordinates { row = row, col = column - 1 });
            localization.Add("Guard2", new Coordinates { row = row - 1, col = column });
            localization.Add("Guard3", new Coordinates { row = row, col = column + 1 });
            localization.Add("Guard4", new Coordinates { row = row + 1, col = column });

            Console.WriteLine($"Guards distributed");

            Console.WriteLine($"Creating map");
            Thread.Sleep(2000);

            for (int i = 0; i < 10; i++)
            {
                for (int y = 0; y < 10; y++)
                {
                    if (i == row && y == column)
                    {
                        Console.ResetColor();
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.Write(" X ");
                        Console.ResetColor();

                    }
                    else if (i == localization["Guard1"].row && y == localization["Guard1"].col)
                    {
                        Console.ResetColor();
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.Write(" G ");
                        Console.ResetColor();
                    }
                    else if (i == localization["Guard2"].row && y == localization["Guard2"].col)
                    {
                        Console.ResetColor();
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.Write(" G ");
                        Console.ResetColor();
                    }
                    else if (i == localization["Guard3"].row && y == localization["Guard3"].col)
                    {
                        Console.ResetColor();
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.Write(" G ");
                        Console.ResetColor();
                    }
                    else if (i == localization["Guard4"].row && y == localization["Guard4"].col)
                    {
                        Console.ResetColor();
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.Write(" G ");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ResetColor();
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write(":) ");
                        Console.ResetColor();
                    }
                }
                Console.Write("\n");
            }
        }
    }
}
