using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Methods;

namespace Quest18
{
    public class Quest
    {
        public static void Start()
        {
            Point punkt1 = new();
            Point punkt2 = new(2, 3);
            Point punkt3 = new(-4, 0);
            Console.WriteLine($"First point, X:{punkt1._x} Y:{punkt1._y}");
            Console.WriteLine($"Second point, X:{punkt2._x} Y:{punkt2._y}");
            Console.WriteLine($"Third point, X:{punkt3._x} Y:{punkt3._y}");
        }
    }
    public class Point
    {
        public readonly int _x;
        public readonly int _y;

        public Point() : this(0, 0) { }
        public Point(int x, int y)
        {
            _x = x;
            _y = y;
        }
    }
}

