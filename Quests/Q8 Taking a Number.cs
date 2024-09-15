using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Methods;

namespace Quest8
{
    public class Quest
    {
        public static void Start()
        {


            int number = AskFor.Number();
            int min = 10; int max = 100;
            int bumer = AskFor.NumberInRange($"Please enter a valid number between {min} and {max}:", min, max);
        }
    }
}
