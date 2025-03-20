using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quests.Notes {
    public class LINQ {
        public static void Start() {
            List<GameObject> objects = new List<GameObject>();
            objects.Add(new Ship { ID = 1, X = 0, Y = 0, HP = 50, MaxHP = 100, PlayerID = 1 });
            objects.Add(new Ship { ID = 2, X = 4, Y = 2, HP = 75, MaxHP = 100, PlayerID = 1 });
            objects.Add(new Ship { ID = 3, X = 9, Y = 3, HP = 0, MaxHP = 100, PlayerID = 2 });
            List<Player> players = new List<Player>();
            players.Add(new Player(1, "Player 1", "Red"));
            players.Add(new Player(2, "Player 2", "Blue"));

            var healthStatus = from o in objects
                               select (o, $"{o.HP}/{o.MaxHP}"); // Tuple

            foreach (var obj in healthStatus) {
                Console.WriteLine($"healthStatus: {obj.Item2}");
            }

            var aliveObjects = from o in objects
                               where o.PlayerID == 1
                               where o.HP > 0
                               orderby o.HP, o.MaxHP descending
                               select o;

            foreach (var obj in aliveObjects) {
                Console.WriteLine($"aliveObjects: {obj.X}");
            }

            var aliveObjects2 = objects
                                    .Where((o) => o.PlayerID == 1 & o.HP > 50)
                                    .OrderByDescending((o) => o.HP);

            foreach (var obj in aliveObjects2) {
                Console.WriteLine($"aliveObjects2: {obj.X}");
            }

            int player1ObjectCount = objects.Count(x => x.PlayerID == 1);
            bool anyAlive = objects.Any(y => y.HP > 0);
            bool allDead = objects.All(y => y.HP == 0);
            var allButFirst = objects.OrderBy(m => m.HP).Skip(1);
            var firstThree = objects.OrderBy(m => m.HP).Take(3);
            int longestName = players.Max(p => p.UserName.Length);
            int shortestName = players.Min(p => p.UserName.Length);
            double averageNameLength = players.Average(p => p.UserName.Length);
            int totalHP = objects.Sum(o => o.HP);

        }
    }
    public class GameObject {
        public int ID { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public int MaxHP { get; set; }
        public int HP { get; set; }
        public int PlayerID { get; set; }
    }
    public class Ship : GameObject { }
    public record Player(int ID, string UserName, string TeamColor);
}
