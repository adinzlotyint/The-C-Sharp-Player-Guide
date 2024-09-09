using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quests.Quests
{
    internal class Quest7
    {
        public static void Quest()
        {
            int[] numbers = { 12, 25, 38, -4, -51, 16, 87, -81, 9, 100 };

            int newSmallest = int.MaxValue;

            foreach (int num in numbers)
            {
                if (num < newSmallest)
                {
                    newSmallest = num;
                }
            }

            int totalSum = 0;

            foreach (int num in numbers)
            {
                totalSum += num;
            }

            Console.WriteLine(totalSum);

            Console.WriteLine($"The smallest number is {newSmallest}");
            Console.WriteLine($"The average of all numbers is {totalSum / numbers.Length}");


        }
    }
}
