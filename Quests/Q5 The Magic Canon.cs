using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quest5
{
    internal class Quest
    {
        public static void Start()
        {
            const int fireCanon = 3;
            const int electricCanon = 5;

            for (int i = 1; i <= 100; i++)
            {
                Console.Write(i + $": ");
                if (i % fireCanon == 0 && i % electricCanon == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Combined");
                }
                else if (i % electricCanon == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Electric");
                }
                else if (i % fireCanon == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Fire");
                }
                else
                {
                    Console.WriteLine("Normal");
                }
                Console.ResetColor();
            }
        }
    }
}
