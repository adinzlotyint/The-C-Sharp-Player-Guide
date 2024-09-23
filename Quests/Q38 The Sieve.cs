using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Methods;

namespace Quest38 {
    public class Quest {
        public static void Start() {
            while (true) {
                Console.Clear();
                Console.WriteLine("Select the type of program by typing it's number:\n1. Check if is even.\n2.Check if number is positivte.\n3. Check if number is multiple of ten.");
            
                Int32.TryParse(Console.ReadLine(), out int selection);

                Sieve sieve;
                switch (selection) {
                    case 1:
                        sieve = new Sieve(IsEvenNumber); break;
                    case 2:
                        sieve = new Sieve(IsPositiveNumber); break;
                    case 3:
                        sieve = new Sieve(IsMultipleOfTenNumber); break;
                    default: 
                        sieve = new Sieve(IsEvenNumber); break;
                }

                Console.WriteLine("Provide the number to be checked:");
                Console.WriteLine(sieve.isGood(Int32.Parse(Console.ReadLine())));
                Console.ReadLine();
            }

            bool IsEvenNumber(int number) {
                if (number % 2 == 0) {
                    return true;
                } else {
                    return false;
                }
            }
            bool IsPositiveNumber(int number) {
                if (number >= 0) {
                    return true;
                } else {
                    return false;
                }
            }
            bool IsMultipleOfTenNumber(int number) {
                if (number % 10 == 0) {
                    return true;
                } else {
                    return false;
                }
            }
        }

    }

    public class Sieve {
        private Func<int, bool> _method;

        public Sieve(Func<int, bool> method) {
            _method = method;
        }
        public bool isGood(int number) {
            return _method(number);
        }
    }


}
