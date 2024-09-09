using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Methods;
using static Arrow;

namespace Quests.Quests
{
    public class Quest16
    {

        public static void Quest()
        {
            Console.WriteLine("What arrow do you want?");
            Console.WriteLine("1 - Elite Arrow");
            Console.WriteLine("2 - Beginner Arrow");
            Console.WriteLine("3 - Marksman Arrow");
            Console.WriteLine("4 - Custom Arrow");

            string choice = Console.ReadLine();

            Arrowss arrow = choice switch
            {
                "1" => Arrowss.CreateEliteArrow(),
                "2" => Arrowss.CreateBeginnerArrow(),
                "3" => Arrowss.CreateMarksmanArrow(),
                _ => CreateCustomArrow(),
            };

            Console.WriteLine($"That arrow costs {arrow.Cost} gold.");

            Arrowss CreateCustomArrow()
            {
                Arrowhead arrowhead = GetArrowheadType();
                Fletching fletching = GetFletchingType();
                float length = GetLength();

                return new Arrowss(arrowhead, fletching, length);
            }

            Arrowhead GetArrowheadType()
            {
                Console.Write("Arrowhead type (steel, wood, obsidian): ");
                string input = Console.ReadLine();
                return input switch
                {
                    "steel" => Arrowhead.Steel,
                    "wood" => Arrowhead.Wood,
                    "obsidian" => Arrowhead.Obsidian
                };
            }

            Fletching GetFletchingType()
            {
                Console.Write("Fletching type (plastic, turkey feather, goose feather): ");
                string input = Console.ReadLine();
                return input switch
                {
                    "plastic" => Fletching.Plastic,
                    "turkey feather" => Fletching.TurkeyFeathers,
                    "goose feather" => Fletching.GooseFeathers
                };
            }

            float GetLength()
            {
                float length = 0;

                while (length < 60 || length > 100)
                {
                    Console.Write("Arrow length (between 60 and 100): ");
                    length = Convert.ToSingle(Console.ReadLine());
                }

                return length;
            }

        }
    }

}

public class Arrowss
{
    public Arrowhead Arrowhead { get; }
    public Fletching Fletching { get; }
    public float Length { get; }

    public Arrowss(Arrowhead arrowhead, Fletching fletching, float length)
    {
        Arrowhead = arrowhead;
        Fletching = fletching;
        Length = length;
    }

    public float Cost
    {
        get
        {
            float arrowheadCost = Arrowhead switch
            {
                Arrowhead.Steel => 10,
                Arrowhead.Wood => 3,
                Arrowhead.Obsidian => 5
            };

            float fletchingCost = Fletching switch
            {
                Fletching.Plastic => 10,
                Fletching.TurkeyFeathers => 5,
                Fletching.GooseFeathers => 3
            };

            float shaftCost = 0.05f * Length;

            return arrowheadCost + fletchingCost + shaftCost;
        }
    }

    public static Arrowss CreateEliteArrow() => new Arrowss(Arrowhead.Steel, Fletching.Plastic, 95);
    public static Arrowss CreateBeginnerArrow() => new Arrowss(Arrowhead.Wood, Fletching.GooseFeathers, 75);
    public static Arrowss CreateMarksmanArrow() => new Arrowss(Arrowhead.Steel, Fletching.GooseFeathers, 65);
}

public enum Arrowhead { Steel, Wood, Obsidian }
public enum Fletching { Plastic, TurkeyFeathers, GooseFeathers }











