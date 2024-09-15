using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Methods;

namespace Quest15
{
    public class Quest
    {

        public static void Start()
        {
            Arrowa purchase = new();
            Console.WriteLine("Set the arrowhead:");
            purchase.Arrowhead = Console.ReadLine();
            Console.WriteLine("Set the fletching:");
            purchase.Fletching = Console.ReadLine();
            Console.WriteLine("Set the shaft length:");
            double.TryParse(Console.ReadLine(), out double length);
            purchase.Shaft = length;


            Console.WriteLine(purchase.GetArrow());

        }
    }

    public class Arrowa
    {
        public string Arrowhead { get; set; } = "none";
        public string Fletching { get; set; } = "none";
        public double Shaft { get; set; } = 0;

        public string GetArrow() => string.Concat(Arrowhead, Fletching, Shaft);

    }
}









