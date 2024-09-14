using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quests.Quests
{
    internal class Quest3
    {
        public static void Quest()
        {

            Console.WriteLine("The following items are available:\r\n1 – Rope\r\n2 – Torches\r\n3 – Climbing Equipment\r\n4 – Clean Water\r\n5 – Machete\r\n6 – Canoe\r\n7 – Food Supplies");
            string input = Console.ReadLine();
            int.TryParse(input, out int item);
            float response = item switch
            {
                1 => 10,
                2 => 15,
                3 => 25,
                4 => 1,
                5 => 20,
                6 => 200,
                7 => 1,
                _ => 0
            };

            if (response == 0)
            {
                Console.WriteLine("Invalid input. Please provide a number between 1 and 7.");
                return;
            }

            Console.WriteLine("What's your name?");
            string name = Console.ReadLine();
            if (name == "Adrian")
            {
                response /= 2;
            }


            Console.WriteLine(response);

        }
    }
}
