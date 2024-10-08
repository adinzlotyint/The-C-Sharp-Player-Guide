﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Methods;

namespace Quest13
{
    public class Quest
    {

        public static void Start()
        {


            //Need to provide full names as written below eg. turkeyFeathers
            Console.WriteLine("Which arrowhead? 1. steel 2. wood 3. obsidian");
            string arrowhead = Console.ReadLine();
            Console.WriteLine("Which fletching? 1. plastic 2. turkeyFeathers 3. gooseFeathers");
            string fletching = Console.ReadLine();
            Console.WriteLine("How long the shaft?");
            double shaft = int.Parse(Console.ReadLine());

            Arrow purchase = new();
            double totalCost = purchase.GetCost(arrowhead, fletching, shaft);
            Console.WriteLine(totalCost);
        }
    }
    public class Arrow {
        public enum Arrowhead { steel = 10, wood = 3, obsidian = 5 };
        public enum Fletching { plastic = 10, turkeyFeathers = 5, gooseFeathers = 3 }
        public double _shaft = 0.05;

        public double GetCost(string arrowhead, string fletching, double shaft) {
            Arrowhead selectedArrowhead = (Arrowhead)Enum.Parse(typeof(Arrowhead), arrowhead);
            Fletching selectedFletching = (Fletching)Enum.Parse(typeof(Fletching), fletching);

            double cost1 = (int)selectedArrowhead;
            double cost2 = (int)selectedFletching;
            double cost3 = shaft * _shaft;

            return cost1 + cost2 + cost3;
        }

    }
}

