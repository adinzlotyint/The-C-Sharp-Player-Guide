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

namespace Quest45 {
    public class Quest {
        public static void Start() {
            int[] arr = [1, 9, 2, 8, 3, 7, 4, 6, 5];
            IEnumerable<int> evenNumbers = arr.Where(o => o % 2 == 0);
            IEnumerable<int> orderedNumbers = evenNumbers.OrderBy(o => o);
            IEnumerable<int> doubledNumbers = evenNumbers.Select(o => o*2);

            foreach (var o in doubledNumbers) {
                Console.WriteLine(o);
            }
        }
    }

}
