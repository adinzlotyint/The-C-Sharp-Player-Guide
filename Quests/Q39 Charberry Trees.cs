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

namespace Quest39 {
    public class Quest {
        public static void Start() {
            CharberryTree tree = new CharberryTree();
            Notifier notifier = new Notifier(tree);
            Harvester harvester = new Harvester(tree);
            while (true) {
                tree.MaybeGrow();
            }
        }
    }

    public class CharberryTree {
        private Random _random = new Random();
        public bool Ripe { get; set; }

        public event Action<CharberryTree>? Ripened;

        public void MaybeGrow() {
            // Only a tiny chance of ripening each time, but we try a lot!
            if (_random.NextDouble() < 0.00000001 && !Ripe) {
                Ripe = true;
                Ripened(this);
            }
        }
    }

    public class Notifier {
        public Notifier(CharberryTree tree) {
            tree.Ripened += OnRipen;
        }
        public void OnRipen(CharberryTree _) {
            Console.WriteLine("A charberry fruit has ripened!");
        }
    }

    public class Harvester {
        public Harvester(CharberryTree tree) {
            tree.Ripened += OnRipen;
        }
        public void OnRipen(CharberryTree tree) {
            tree.Ripe = false;
        }
    }
}
