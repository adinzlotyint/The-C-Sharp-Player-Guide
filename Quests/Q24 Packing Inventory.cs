using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;
using Methods;

namespace Quest24
{
    public class Quest
    {
        public static void Start()
        {
            Console.WriteLine("You are creating a pack. Please indicate the max capacity:");
            int maxItems = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Please indicate the max weight:");
            double maxWeight = Double.Parse(Console.ReadLine());
            Console.WriteLine("Please indicate the max volume:");
            double maxVolume = Double.Parse(Console.ReadLine());
            Pack pack = new Pack(maxItems, maxWeight, maxVolume);
            bool stillPreparing = true;
            string choice;
            do {
                Console.Clear();
                Console.WriteLine("What would you like to do with your backpack?\n 1. Get actual items\n 2. Get actual weight \n 3. Get actual volume" +
                    "\n 4. Add new item do pack \n 5. Finish preparping backpack.");
                string response1 = Console.ReadLine();
                choice = response1 switch {
                    "1" => ($"There is {pack.GetItems()}/{pack._packContent.Length} items in the pack."),
                    "2" => ($"Pack weight is {pack.GetWeight()}/{pack._maxWeight}."),
                    "3" => ($"Actual pack volume is {pack.GetVolume()}/{pack._maxVolume}."),
                    "4" => "Please select which item to add: \n a) Arrow \n b) Bow \n c) Rope \n d) Water \n e) Food rations \n f) Sword",
                    "5" => "Good luck!",
                    _ => "Please select item 1 to 4."
                };

                Console.WriteLine(choice);
                if (response1 == "4") {
                    string response2;
                    do {
                        response2 = Console.ReadLine();
                    } while (response2 != "a" && response2 != "b" && response2 != "c" && response2 != "d" && response2 != "e" && response2 != "f");

                    if (response2 == "a") {
                        pack.Add(new Arrow());
                    } else if ((response2 == "b")) {
                        pack.Add(new Bow());
                    } else if ((response2 == "c")) {
                        pack.Add(new Rope());
                    } else if ((response2 == "d")) {
                        pack.Add(new Water());
                    } else if ((response2 == "e")) {
                        pack.Add(new FoodRations());
                    } else if ((response2 == "f")) {
                        pack.Add(new Sword());
                    }
                    
                } else if (response1 == "5") {
                    stillPreparing = false;
                }

                Console.ReadLine();

            } while (stillPreparing == true);
            
        }
    }

    public class Pack {
        public readonly double _maxWeight;
        public readonly double _maxVolume;
        public readonly InventoryItem[] _packContent;
        public Pack(int maxItems, double maxWeight, double maxVolume) {
            _packContent = new InventoryItem[maxItems]; _maxWeight = maxWeight; _maxVolume = maxVolume;
        }

        public bool Add(InventoryItem item) {
            bool test1 = CountItems();
            bool test2 = CountWeight(item._itemWeight);
            bool test3 = CountVolume(item._itemVolume);
            if (test1 == true && test2 == true && test3 == true) {
                _packContent[GetItems()] = item;
                Console.WriteLine($"{item.GetType().Name} added.");
                return true;
            } else if (test1 == false) {
                Console.WriteLine($"No capacity left in the pack to add {item.GetType().Name}.");
                return false;
            } else if (test2 == false) {
                Console.WriteLine($"Max weight achieved, cannot add {item.GetType().Name}.");
                return false;
            } else if (test3 == false) {
                Console.WriteLine($"Max volume achieved, cannot add {item.GetType().Name}.");
                return false;
            } else {
                return false;
            }
        }

        public int GetItems() {
            int i = 0;
            foreach (InventoryItem item in _packContent) {
                if (item == null) break;
                i++;
            }
            return i;
        }

        public double GetWeight() {
            double totalWeight = 0;
            foreach (InventoryItem item in _packContent) {
                if (item == null) break;
                totalWeight += item._itemWeight;
            }
            return totalWeight;
        }

        public double GetVolume() {
            double totalVolume = 0;
            foreach (InventoryItem item in _packContent) {
                if (item == null) break;
                totalVolume += item._itemVolume;
            }
            return totalVolume;
        }

        private bool CountItems() {
            int i=0;
            foreach (InventoryItem item in _packContent) {
                if (item == null) break;
                i++;
            }
            if (i>=_packContent.Length) {
                return false;
            } else {
                return true;
            }
        }
        private bool CountWeight(double weight) {
            double totalWeight = 0;
            foreach (InventoryItem item in _packContent) {
                if (item == null) break;
                totalWeight += item._itemWeight;
            }
            if (totalWeight + weight >= _maxWeight) {
                return false;
            } else {
                return true;
            }
        }
        private bool CountVolume(double volume) {
            double totalVolume = 0;
            foreach (InventoryItem item in _packContent) {
                if (item == null) break;
                totalVolume += item._itemWeight;
            }

            if (totalVolume + volume >= _maxVolume) {
                return false;
            } else {
                return true;
            }
        }

    }

    public class InventoryItem {
        public double _itemVolume;
        public double _itemWeight;

        public InventoryItem(double itemVolume, double itemWeight) {
            _itemVolume = itemVolume;
            _itemWeight = itemWeight;
        }

    }

    public class Arrow : InventoryItem {
        public Arrow(): base(0.1, 0.05) {
        }
    }
    public class Bow : InventoryItem {
        public Bow() : base(1, 4) {
        }
    }
    public class Rope : InventoryItem {
        public Rope() : base(1, 1.5) {
        }
    }
    public class Water : InventoryItem {
        public Water() : base(2, 3) {
        }
    }
    public class FoodRations : InventoryItem {
        public FoodRations() : base(1, 0.5) {
        }
    }
    public class Sword : InventoryItem {
        public Sword() : base(5, 3) {
        }
    }

}
