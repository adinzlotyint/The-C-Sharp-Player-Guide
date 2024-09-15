using Methods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quest31
{
    internal class Quest
    {
        public static void Start()
        {
            Game game;
            string response;
            Console.WriteLine("Menu:\n1. Single Player\n2. Multi Player");

            do {
                response = Console.ReadLine();
            } while (response != "1" && response != "2");
            Console.Clear();
            if (response == "1") {
                game = new Game.SinglePlayer();
            } else {
                game = new Game.MultiPlayer();
            }
            
            game.Run();
        }

        public class Game {
            private int _manticorePosition;
            public int _currTurn = 0;

            public virtual void Run() {
                Manticore manticore = new(10, _manticorePosition);
                City city = new(15);
                int damage; int canonRange;
                Console.Clear();
                do {
                    _currTurn++;
                    damage = GetDamage(_currTurn);
                    Console.WriteLine("Turn " + _currTurn + " | Manticore HP: " + manticore.HP + "/10 | City HP: " + city.HP + "/15");
                    Console.WriteLine("This turn damage is expected to be: " + damage);

                    canonRange = AskFor.NumberInRange("City - Please enter a number between 0 and 100", 0, 100);
                    if (ManticoreHit(canonRange, damage) == true) { manticore.HP -= damage; }

                    city.HP--;
                } while (manticore.HP > 0 && city.HP > 0);
                Console.Clear();
                string displayWinner = manticore.HP > city.HP ? manticore.ToString() : city.ToString();
                Console.WriteLine($"The {displayWinner} wins!");

            }

            public int GetDamage(int turn) {
                if (turn % 3 == 0 && turn % 5 == 0) {
                    return (int)Elements.Combined;
                } else if (turn % 5 == 0) {
                    return (int)Elements.Electric;
                } else if (turn % 3 == 0) {
                    return (int)Elements.Fire;
                } else {
                    return (int)Elements.Normal;
                }
            }

            public bool ManticoreHit(int canonRange, int damage)  {
                if (canonRange > _manticorePosition) {
                    Console.WriteLine("Go lower!");
                    return false;
                } else if (canonRange < _manticorePosition) {
                    Console.WriteLine("Go higer!");
                    return false;
                } else {
                    Console.WriteLine("The manticore has been hit!");
                    return true;
                }
            }

            public class SinglePlayer: Game {
                public override void Run() {
                    Random random = new();
                    _manticorePosition = random.Next(101);
                    base.Run();
                }
            }

            public class MultiPlayer : Game {
                public override void Run() {
                    _manticorePosition = AskFor.NumberInRange("Manticore - Please enter a number between 0 and 100", 0, 100);
                    base.Run();
                }
            }

        }

        public record Manticore(int HP, int _playersAmount) {
            public int HP { get; set; } = HP;
            public int _position { get; }

            public override string ToString() {
                return "Manticore";
            }
        }
        public record City(int HP) {
            public int HP { get; set; } = HP;
        }
        public override string ToString() {
            return "City";
        }
        public enum Elements { Normal = 1, Electric = 3, Fire = 3, Combined = 10 }
    }
}
