using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Methods;

namespace Quest41 {
    public class Quest {
        public static void Start() {
            Console.WriteLine("Provide your name.");
            string name = Console.ReadLine();
            int score = 0;
            bool exit = false;

            if (name == null || name == "") { name = "Player1"; }

            if (File.Exists($"./TempFiles/{name}.txt")) {
                Int32.TryParse(File.ReadAllText($"./TempFiles/{name}.txt"), out score);
            }

            do {
                Console.Clear();
                Console.WriteLine($"{name}'s score: {score}");
                if (Console.ReadKey().Key == ConsoleKey.Enter) {
                    exit = true;
                } else {
                    score++;
                }
            } while (!exit);

            //TempFiles folder manually added in the project directory
            File.WriteAllText($"./TempFiles/{name}.txt", score.ToString());

        }
    }
}
