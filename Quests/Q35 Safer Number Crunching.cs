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

namespace Quest35 {
    public class Quest {
        public static void Start() {
            string response;
            Console.WriteLine("Provide intiger type number:");
            do {
                response = Console.ReadLine();
            } while (!Int32.TryParse(response, out int resultInt));

            Console.WriteLine("Provide double type number:");
            do {
                response = Console.ReadLine();
            } while (Double.TryParse(response, out double resultDouble));

            Console.WriteLine("Provide boolean response:");
            do {
                response = Console.ReadLine();
            } while (!Boolean.TryParse(response, out bool resultBoolean));
            
        }
    }
}
