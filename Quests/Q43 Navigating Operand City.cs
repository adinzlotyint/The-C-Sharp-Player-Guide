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

namespace Quest43 {
    public class Quest {
        public static void Start() {
            
            Console.WriteLine(new BlockCoordinate(2,0) + new BlockOffset(1,4));
            Console.WriteLine(new BlockCoordinate(4, 3) + Direction.East);
            BlockCoordinate blockCoordinate = new(5, 9);
            Console.WriteLine(blockCoordinate[0]);
            Console.WriteLine(blockCoordinate[5]);
        }
    }

    public record BlockCoordinate(int Row, int Column) {
        public static BlockCoordinate operator +(BlockCoordinate a, BlockOffset b) =>
                new BlockCoordinate(a.Row + b.RowOffset, a.Column + b.ColumnOffset);

        public static BlockCoordinate operator +(BlockCoordinate a, Direction direction) {
            return a + (direction switch {
                Direction.North => new BlockOffset(0, -1),
                Direction.East => new BlockOffset(1, 0),
                Direction.South => new BlockOffset(0, 1),
                Direction.West => new BlockOffset(-1, 0),
                _ => new BlockOffset(0, 0)
            });

        }

        public int this[int index] {
            get {
                if (index == 0) {
                    return Row;
                } else {
                    return Column;
                }
            }
        }
    }
    public record BlockOffset(int RowOffset, int ColumnOffset);
    public enum Direction { North, East, South, West }
}
