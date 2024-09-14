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
using NewQuests;

namespace Quests.NewQuests {
    public class Quest33 {
        public static void Quest() {
            Robotx robot = new();
            Console.WriteLine("Give your commands");
            string command;
            for (int i = 0; i < 3; i++) {
                command = Console.ReadLine();
                IRobotCommand newCommand = command switch {
                    "on" => new OnCommand(),
                    "off" => new OffCommand(),
                    "north" => new NorthCommand(),
                    "south" => new SouthCommand(),
                    "east" => new EastCommand(),
                    "west" => new WestCommand(),
                };
                robot.Commands.Add(newCommand);
            }

            robot.Run();

        }
    }

    public class Robotx {
        public int X { get; set; }
        public int Y { get; set; }
        public bool IsPowered { get; set; }
        public List<IRobotCommand?> Commands { get; } = new List<IRobotCommand?>();
        public void Run() {
            foreach (IRobotCommand? command in Commands) {
                command?.Run(this);
                Console.WriteLine($"[{X} {Y} {IsPowered}]");
            }
        }
    }

    public interface IRobotCommand {
        void Run(Robotx robot) { }
    }

    public class OnCommand : IRobotCommand {
        public void Run(Robotx robot) {
            robot.IsPowered = true;
        }
    }

    public class OffCommand : IRobotCommand {
        public void Run(Robotx robot) {
            robot.IsPowered = false;
        }
    }

    public class NorthCommand : IRobotCommand {
        public void Run(Robotx robot) {
            if (robot.IsPowered) { robot.Y += 1; }
        }
    }

    public class SouthCommand : IRobotCommand {
        public void Run(Robotx robot) {
            if (robot.IsPowered) { robot.Y -= 1; }
        }
    }

    public class WestCommand : IRobotCommand {
        public void Run(Robotx robot) {
            if (robot.IsPowered) { robot.X += 1; }
        }
    }

    public class EastCommand : IRobotCommand {
        public void Run(Robotx robot) {
            if (robot.IsPowered) { robot.X -= 1; }
        }
    }
}

