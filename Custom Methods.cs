using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Methods {
    public class AskFor {
        public static int Number() {
            bool isNumber = false;
            int number;
            do {
            Console.WriteLine("Please enter a valid number:");
            isNumber = Int32.TryParse(Console.ReadLine(), out number);
            } while ( isNumber == false);
            return number;
        }

        public static int NumberInRange(string text, int min, int max) {
            bool isNumber = false;
            int number;
            do {
                Console.WriteLine(text);
                isNumber = Int32.TryParse(Console.ReadLine(), out number);
                if (number < min || number > max) {
                    isNumber = false;
                }
            } while (isNumber == false);
            return number;
        }

        public static int NumberInRange(int min, int max) {
            bool isNumber = false;
            int number;
            do {
                isNumber = Int32.TryParse(Console.ReadLine(), out number);
                if (number < min || number > max) {
                    isNumber = false;
                }
            } while (isNumber == false);
            return number;
        }
    }
}
