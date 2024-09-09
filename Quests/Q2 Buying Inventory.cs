using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quests.Quests
{
    internal class Quest2
    {
        public static void Quest()
        {

            Console.WriteLine("The following items are available:\r\n1 – Rope\r\n2 – Torches\r\n3 – Climbing Equipment\r\n4 – Clean Water\r\n5 – Machete\r\n6 – Canoe\r\n7 – Food Supplies");
            string input = Console.ReadLine();
            int.TryParse(input, out int item);
            string response = item switch
            {
                1 => "Rope: 10 gold",
                2 => "Torches: 15 gold",
                3 => "Climbing Equipment: 25 gold",
                4 => "Clean Water: 1 gold",
                5 => "Machete: 20 gold",
                6 => "Canoe: 200 gold",
                7 => "Food Supplies: 1 gold",
                _ => "Invalid input. Please provide a number between 1 and 7."
            };



            Console.WriteLine(response);

        }
    }
}
