using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Methods;
using static Quests.Quests.RobotCommand;

namespace Quests.Quests
{
    public class Quest26
    {
        public static void Quest()
        {

            Robot robot = new();
            Console.WriteLine("Give your commands");
            string command;
            for (int i = 0; i<3; i++) {
                command = Console.ReadLine();
                RobotCommand newCommand = command switch {
                    "on" => new OnCommand(),
                    "off" => new OffCommand(),
                    "north" => new NorthCommand(),
                    "south" => new SouthCommand(),
                    "east" => new EastCommand(),
                    "west" => new WestCommand(),
                };
                robot.Commands[i] = newCommand;
            }

            robot.Run();
        }
    }

    public class Robot {
        public int X { get; set; }
        public int Y { get; set; }
        public bool IsPowered { get; set; }
        public RobotCommand?[] Commands { get; } = new RobotCommand?[3];
        public void Run() {
            foreach (RobotCommand? command in Commands) {
                command?.Run(this);
                Console.WriteLine($"[{X} {Y} {IsPowered}]");
            }
        }
    }
    public abstract class RobotCommand {
        public abstract void Run(Robot robot);

        public class OnCommand : RobotCommand {
            public override void Run(Robot robot) {
                robot.IsPowered = true;
            }
        }

        public class OffCommand : RobotCommand {
            public override void Run(Robot robot) {
                robot.IsPowered = false;
            }
        }

        public class NorthCommand : RobotCommand {
            public override void Run(Robot robot) {
                if (robot.IsPowered) { robot.Y += 1; }
            }
        }

        public class SouthCommand : RobotCommand {
            public override void Run(Robot robot) {
                if (robot.IsPowered) { robot.Y -= 1; }
            }
        }

        public class WestCommand : RobotCommand {
            public override void Run(Robot robot) {
                if (robot.IsPowered) { robot.X += 1; }
            }
        }

        public class EastCommand : RobotCommand {
            public override void Run(Robot robot) {
                if (robot.IsPowered) { robot.X -= 1; }
            }
        }

    }

}