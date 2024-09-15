using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quest6
{
    internal class Quest
    {
        public static void Start()
        {
            //int[] test = new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            //Console.WriteLine(test[^1]);

            int[] arr = new int[5];
            bool answer;
            for (int i = 0; i < 5; i++)
            {
                answer = false;
                while (answer == false)
                {
                    Console.WriteLine("Enter a number: ");
                    answer = int.TryParse(Console.ReadLine(), out arr[i]);
                }
            }

            int[] result = new int[arr.Length];

            for (int i = 0; i < 5; i++)
            {
                result[i] = arr[i];
                Console.WriteLine($"Original {arr[i]}");
                Console.WriteLine($"New {result[i]}");
            }

        }
    }
}
