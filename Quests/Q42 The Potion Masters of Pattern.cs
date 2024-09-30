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

namespace Quest42 {
    public class Quest {
        public static void Start() {
            while (true) {
                MixedPotion currPotion = new();
                while (true) {
                    Console.Clear();
                    Console.WriteLine($"Current potion: {currPotion._currPotionName}");
                    Console.WriteLine($"Available ingredients:\n1. Stardust\n2. Snake Venom\n3. Dragon Breath\n4. Shadow Glass\n5. Eyeshine Gem");

                    int response = AskFor.NumberInRange(1, 5);
                    currPotion.AddIngredient((Ingredient)response);

                    Console.Clear();
                    
                    if (currPotion._currPotionName == Potion.Ruined) {
                        Console.WriteLine("You've ruined the potion.\nPress any key to start again...");
                        Console.ReadKey();
                        break;
                    }

                    Console.WriteLine($"Current potion: {currPotion._currPotionName}\nPress Enter if you want to continue, else click any other key to start a new Potion.");

                    if (Console.ReadKey().Key != ConsoleKey.Enter) break;
                }
            }
        } 
    }

    public class MixedPotion {
        public Potion _currPotionName { get; set; } = Potion.Water;
        public void AddIngredient(Ingredient ingredient) {
            _currPotionName = (_currPotionName, ingredient) switch {
                (Potion.Water, Ingredient.Stardust)             => Potion.Elixir,
                (Potion.Elixir, Ingredient.SnakeVenom)          => Potion.Poison,
                (Potion.Elixir, Ingredient.DragonBreath)        => Potion.Flying,
                (Potion.Elixir, Ingredient.ShadowGlass)         => Potion.Invisibility,
                (Potion.Elixir, Ingredient.EyeshineGem)         => Potion.NightSight,
                (Potion.NightSight, Ingredient.ShadowGlass)     => Potion.Cloudy,
                (Potion.Invisibility, Ingredient.EyeshineGem)   => Potion.Cloudy,
                (Potion.Cloudy, Ingredient.Stardust)            => Potion.Wraith,
                _                                               => Potion.Ruined
            };
        }
    }

    public enum Potion { Water, Elixir, Poison, Flying, Invisibility, NightSight, Cloudy, Wraith, Ruined}
    public enum Ingredient { Stardust = 1, SnakeVenom, DragonBreath, ShadowGlass, EyeshineGem }
}
