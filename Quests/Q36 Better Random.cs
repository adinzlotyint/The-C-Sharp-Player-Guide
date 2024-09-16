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

namespace Quest36 {
    public class Quest {
        public static void Start() {
            Random rnd = new Random();
            Console.WriteLine(rnd.NextDouble(20));
            Console.WriteLine(rnd.NextString(new string[] { "up", "left", "right", "down" }));
            Console.WriteLine(rnd.CoinFlip(120)); // winProbability {empty or 50 - equal chances, 70 - 70% for win etc...}
        }
    }

    public static class RandomExtensions {

        public static double NextDouble(this Random rnd, double maxValue) {
            return rnd.NextDouble() * maxValue; //increased resolution
        }
        public static string NextString(this Random rnd, params string[] strings) {
            return strings[rnd.Next(0, strings.Length)];
        }

        public static bool? CoinFlip(this Random rnd, double winProbability = 50) {
            if (winProbability > 100 || winProbability < 0) { return null; }
            if (rnd.Next(101) < winProbability) {
                return true;
            };
            return false;
        }

    }
}
