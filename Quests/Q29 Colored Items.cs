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
    public class Quest29
    {
        public static void Quest()
        {
            ColoredItem<Swordx> sword = new ColoredItem<Swordx>(new Swordx(), ConsoleColor.Blue);
            ColoredItem<Bow> bow = new ColoredItem<Bow>(new Bow(), ConsoleColor.Red);
            ColoredItem<Axe> axe = new ColoredItem<Axe>(new Axe(), ConsoleColor.Green);

            sword.Display();
            bow.Display();
            axe.Display();
        }
    }

    public class ColoredItem<T> {
        public T Item { get; }
        public ConsoleColor Color { get; }

        public ColoredItem(T item, ConsoleColor color) {
            Item = item;
            Color = color;
        }

        public void Display() {
            Console.ForegroundColor = Color;
            Console.Write(Item);
        }
    }


    public class Swordx { public string Color { get; set; } }
    public class Bow { }
    public class Axe { }


}

