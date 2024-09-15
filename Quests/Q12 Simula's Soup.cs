using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Methods;

namespace Quest12
{
    public class Quest
    {
        public static void Start()
        {
            (Food Food, MainIngredient Main, Seasoning Seasoning) dish;
            string answer;

            Console.WriteLine("Choose food:\nsoup\nstew\ngumbo");
            do
            {
                answer = Console.ReadLine();
            } while (answer != "soup" && answer != "stew" && answer != "gumbo");

            if (answer == "soup")
            {
                dish.Item1 = Food.soup;
            }
            else if (answer == "stew")
            {
                dish.Item1 = Food.stew;
            }
            else
            {
                dish.Item1 = Food.gumbo;
            }

            Console.WriteLine("Choose main ingredient:\nmushrooms\nchicken\ncarotts\npotatoes");
            do
            {
                answer = Console.ReadLine();
            } while (answer != "mushrooms" && answer != "chicken" && answer != "carotts" && answer != "potatoes");

            if (answer == "mushrooms")
            {
                dish.Item2 = MainIngredient.mushrooms;
            }
            else if (answer == "chicken")
            {
                dish.Item2 = MainIngredient.chicken;
            }
            else if (answer == "carotts")
            {
                dish.Item2 = MainIngredient.carotts;
            }
            else
            {
                dish.Item2 = MainIngredient.potatoes;
            }

            Console.WriteLine("Choose seasoning:\nspicy\nsalty\nsweet");
            do
            {
                answer = Console.ReadLine();
            } while (answer != "spicy" && answer != "salty" && answer != "sweet");

            if (answer == "spicy")
            {
                dish.Item3 = Seasoning.spicy;
            }
            else if (answer == "salty")
            {
                dish.Item3 = Seasoning.salty;
            }
            else
            {
                dish.Item3 = Seasoning.sweet;
            }

            Console.WriteLine($"Your dish: {dish.Seasoning} {dish.Main} {dish.Food}");

        }
    }
}

enum Food { soup, stew, gumbo };
enum MainIngredient { mushrooms, chicken, carotts, potatoes };
enum Seasoning { spicy, salty, sweet };