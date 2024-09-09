using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Methods;

namespace Quests.Quests
{
    public class Quest8
    {
        public static void Quest()
        {


            int number = AskFor.Number();
            int min = 10; int max = 100;
            int bumer = AskFor.NumberInRange($"Please enter a valid number between {min} and {max}:", min, max);
        }
    }
}
