using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Methods;

namespace Quest11
{
    public class Quest
    {
        public static void Start()
        {
            Chest chest = Chest.Locked; //enum
            bool checkAnswer;
            int answer;
            Console.ForegroundColor = ConsoleColor.DarkBlue; //enum

            while (true)
            {
                if (chest == Chest.Locked)
                {
                    Console.WriteLine("Chest is locked. What do you want to do?");
                }
                else if (chest == Chest.Closed)
                {
                    Console.WriteLine("Chest is closed. What do you want to do?");
                }
                else if (chest == Chest.Open)
                {
                    Console.WriteLine("Chest is opened. What do you want to do?");
                }

                do
                {
                    Console.WriteLine("Write a number which describes the action you want to take." +
                        "\n 1. Lock \n 2. Unlock \n 3. Open \n 4. Close");
                    checkAnswer = int.TryParse(Console.ReadLine(), out answer);
                } while (checkAnswer == false && (answer > 4 || answer < 1));

                if (answer == 1 && (chest == Chest.Locked || chest == Chest.Open))
                {
                    Console.WriteLine($"Chest is {chest}.");
                }
                else
                {
                    Console.WriteLine($"Chest is now locked.");
                }

                //...

            }
        }
    }
}
enum Chest { Locked, Closed, Open }