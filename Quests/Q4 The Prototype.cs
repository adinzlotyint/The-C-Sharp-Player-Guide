using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quests.Quests
{
    internal class Quest4
    {
        public static void Quest()
        {
            int pilot;
            int hunter;
            do
            {
                Console.WriteLine("Pilot, enter the valid number (0-100): ");
                string input = Console.ReadLine();
                int.TryParse(input, out pilot);

            } while (pilot < 0 || pilot > 100);

            Console.Clear();

            do
            {

                do
                {
                    Console.WriteLine("Hunter, enter the valid number (0-100): ");
                    string input = Console.ReadLine();
                    int.TryParse(input, out hunter);

                } while (hunter < 0 || hunter > 100);

                if (pilot > hunter)
                {
                    Console.WriteLine($"{hunter} is too low");
                }
                else if (pilot < hunter)
                {
                    Console.WriteLine($"{hunter} is too high");
                }
                else
                {
                    Console.WriteLine("You guessed the number!");
                }

            } while (pilot != hunter);


        }
    }
}
