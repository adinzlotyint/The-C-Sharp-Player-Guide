using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Methods;

namespace Quests.Quests
{
    public class Quest9
    {
        public static void Quest()
        {

            for (int x = 10; x > 0; x--)
            {
                Console.WriteLine(x);
            }

            CountDown(10);

        }

        static void CountDown(int number)
        {
            if (number == 0)
            {
                return;
            }
            else
            {
                Console.WriteLine(number);
                CountDown(number - 1);
            }
        }
    }
}
