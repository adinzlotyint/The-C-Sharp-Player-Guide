using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Methods;

namespace Quests.Quests
{
    public class Quest10
    {
        public static void Quest()
        {

            //int[] a = new int[] { 1, 2, 3 };
            //int[] b = new int[] { 1, 2, 3 };

            //int[] c = new int[] { 1, 2, 3, 4 };
            //int[] d = c;

            //Console.WriteLine(a == b); //false
            //Console.WriteLine(c == d); //true

            int manticore = AskFor.NumberInRange("Player 1 - Please enter a number between 0 and 100", 0, 100);
            Console.Clear();

            int cityHP = 15;
            int manticoreHP = 10;
            int currTurn = 0;
            int damage;

            do
            {
                currTurn++;
                damage = GetDamage(currTurn);

                Console.WriteLine("Turn " + currTurn + " | Manticore HP: " + manticoreHP + "/10 | City HP: " + cityHP + "/15");
                Console.WriteLine("This turn damage is expected to be: " + damage);

                int canonRange = AskFor.NumberInRange("Player 2 - Please enter a number between 0 and 100", 0, 100);

                if (canonRange > manticore)
                {
                    Console.WriteLine("Go lower!");
                }
                else if (canonRange < manticore)
                {
                    Console.WriteLine("Go higer!");
                }
                else
                {
                    Console.WriteLine("The manticore has been hit!");
                    manticoreHP -= damage;
                }
                cityHP--;

            } while (cityHP > 0 && manticoreHP > 0);

            if (cityHP == 0)
            {
                Console.WriteLine("The city has been destroyed!");
            }
            else if (manticoreHP == 0)
            {
                Console.WriteLine("The manticore has been slain!");
            }

        }

        static int GetDamage(int turn)
        {
            if (turn % 3 == 0 && turn % 5 == 0)
            {
                return 10;
            }
            else if (turn % 3 == 0)
            {
                return 3;
            }
            else if (turn % 3 == 0)
            {
                return 3;
            }
            else
            {
                return 1;
            }
        }

    }
}
