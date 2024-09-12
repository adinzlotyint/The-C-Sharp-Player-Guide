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

namespace Quests.Quests 
   {
    public class Quest28
    {
        public static void Quest()
        {
            Sword originalSword = new Sword(10, 2, Material.Iron, Gemstone.Empty);
            Sword firstSword = originalSword with { material = Material.Binarium, gemstone = Gemstone.Sapphire };
            Sword secondSword = originalSword with { material = Material.Wood, gemstone = Gemstone.Bitstone };

            Console.WriteLine(originalSword);
            Console.WriteLine(firstSword);
            Console.WriteLine(secondSword);
        }
    }

    public record Sword (double length, double width, Material material, Gemstone gemstone);
    public enum Material { Wood, Bronze, Iron, Steel, Binarium}
    public enum Gemstone { Empty, Emerald, Amber, Sapphire, Diamond, Bitstone}
}

