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

namespace Quest37 {
    public class Quest {
        public static void Start() {
            Random rnd = new();
            int oatmealCookie = rnd.Next(10);
            List<int> eatenCookies = new List<int>();
            bool gameEnd = false;
            do {
                Console.WriteLine("Select the cookie, by picking number between 0 and 9");
                try {
                    Int32.TryParse(Console.ReadLine(), out int response);
                    if (response < 0 || response > 9) { throw new ArgumentOutOfRangeException(); }
                    if (eatenCookies.Contains(response)) { throw new ArgumentException(); }
                    if (response == oatmealCookie) { 
                        throw new Exception();
                    } else {
                        Console.WriteLine("Uff, you've eaten chocolate chip cookie.");
                        eatenCookies.Add(response);
                    }
                } catch (ArgumentOutOfRangeException) {
                    Console.WriteLine("Provided number is not between 0 and 9");
                } catch (ArgumentException) {
                    Console.WriteLine("Cookie has already been eaten.");
                } catch (Exception) {
                    Console.WriteLine("Bleh, you've eaten oatmeal raisin cookie and you lost!");
                    gameEnd = true;
                }
            } while (gameEnd == false);
        }
    }
}
