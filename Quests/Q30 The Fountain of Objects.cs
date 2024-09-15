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

namespace Quest30
   {
    public class Quest
    {
        public static void Start() {
            bool success = false;
            bool check;
            Console.WriteLine("Select map size (use numbers):\n(1) Small (4x4)\n(2) Medium (6x6) \n(3) Large (8x8)");
            int mapSize = Int32.Parse(Console.ReadLine());
            GameGrid grid = new(mapSize);

            do {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("To navigate use arrows keys on your keyboard, to enable fountain press 'e'.");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"You are in the room at (Row={grid._currentPosition.row}, Column={grid._currentPosition.col}).");
                Console.ForegroundColor = ConsoleColor.Green;
                if (grid._grid[grid._currentPosition.row, grid._currentPosition.col] == "entrance" && grid._fountainState == false) {
                    Console.WriteLine("You see light in this room coming from outside the cavern. This is the entrance.");
                } else if (grid._grid[grid._currentPosition.row, grid._currentPosition.col] == "fountain" && grid._fountainState == false) {
                    Console.WriteLine("You hear water dripping in this room. The Fountain of Objects is here!");
                } else if (grid._grid[grid._currentPosition.row, grid._currentPosition.col] == "fountain" && grid._fountainState == true) {
                    Console.WriteLine("You hear the rushing waters from the Fountain of Objects. It has been reactivated!");
                }

                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("What do you want to do? ");

                do {
                    var key = Console.ReadKey().Key;
                    check = grid.AnswerValidate(key);
                } while (check == false);

                Console.Clear();
                grid.CheckForHazards();
                success = grid.CheckCurrentPositionEvents();

            } while (success == false);

        }
    }

    public class GameGrid {
        public (int row, int col) _currentPosition = new(0, 0);
        public string[,] _grid;
        public bool _fountainState = false;
        public int _mapSize;
        public GameGrid(int mapSize) {
            Random rnd = new Random();
            switch (mapSize) {
                case 1:
                    _mapSize = 4; break;
                case 2:
                    _mapSize = 6; break;
                case 3:
                    _mapSize = 8; break;
                default:
                    _mapSize = 4; break;
            }

            _grid = new string[_mapSize, _mapSize];
            _grid[rnd.Next(1, _mapSize), rnd.Next(1, _mapSize)] = "fountain";
            _grid[0, 0] = "entrance";
            SettleHazards(_mapSize);
        }

        public bool AnswerValidate(ConsoleKey answer) {
            switch (answer) {
                case ConsoleKey.DownArrow:
                    if (_currentPosition.row + 1 < _grid.GetLength(0)) { _currentPosition.row += 1; return true; } else { Console.WriteLine("Met a wall."); return false; }
                case ConsoleKey.UpArrow:
                    if (_currentPosition.row - 1 >= 0) { _currentPosition.row -= 1; return true; } else { Console.WriteLine("Met a wall."); return false; }
                case ConsoleKey.RightArrow:
                    if (_currentPosition.col + 1 < _grid.GetLength(1)) { _currentPosition.col += 1; return true; } else { Console.WriteLine("Met a wall."); return false; }
                case ConsoleKey.LeftArrow:
                    if (_currentPosition.col - 1 >= 0) { _currentPosition.col -= 1; return true; } else { Console.WriteLine("Met a wall."); return false; }
                case ConsoleKey.E:
                    return EnableFountain();
                default:
                    Console.WriteLine("Undefined command.");
                    return false;
            }
        }

        public void CheckForHazards() {

            bool IsWithinBounds(int row, int col, string[,] grid) {
                return row >= 0 && row < grid.GetLength(0) && col >= 0 && col < grid.GetLength(1);
            }

            int row = _currentPosition.row;
            int col = _currentPosition.col;

            int[,] checkGrid = new int[4,2] { { row - 1, col }, { row + 1, col }, { row, col - 1 }, { row, col + 1 } };

            for (int i = 0; i < checkGrid.GetLength(0); i++) {
                if (IsWithinBounds(checkGrid[i,0], checkGrid[i, 1], _grid)) {
                    if (_grid[checkGrid[i, 0], checkGrid[i, 1]] == "pit") {
                        Console.WriteLine("You feel a draft. There is a pit in a nearby room");
                    } 
                    if (_grid[checkGrid[i, 0], checkGrid[i, 1]] == "maelstorm") {
                        Console.WriteLine("You hear the growling and groaning of a maelstrom nearby");
                    }
                }
            }
        }

        public bool CheckCurrentPositionEvents() {
            if (_currentPosition == (0, 0) && _fountainState == true) {
                Console.WriteLine("The Fountain of Objects has been reactivated, and you have escaped with your life!\r\nYou win!");
                return true;
            }

            if (_grid[_currentPosition.row, _currentPosition.col] == "pit") {
                Console.WriteLine("You fell into the pit\r\nYou loose!");
                return true;
            }

            if (_grid[_currentPosition.row, _currentPosition.col] == "maelstorm") {
                Console.WriteLine("You've been pushed by maelstorm!");
                _grid[_currentPosition.row, _currentPosition.col] = null;

                Random rnd = new Random();
                int row;
                int col;
                do {
                    row = rnd.Next(1, _mapSize);
                    col = rnd.Next(1, _mapSize);
                    if (_grid[row, col] == null) {
                        _grid[row, col] = "maelstorm";
                    }
                } while (_grid[row, col] != "maelstorm");

                do {
                    row = rnd.Next(1, _mapSize);
                    col = rnd.Next(1, _mapSize);
                    if (_grid[row, col] == null) {
                        _currentPosition.row = row;
                        _currentPosition.col = col;
                    }
                } while (_grid[row, col] != null);

                return CheckCurrentPositionEvents();
            }

            return false;
        }

        public bool EnableFountain() {
            if (_grid[_currentPosition.row, _currentPosition.col] == "fountain") {
                _fountainState = true;
                Console.WriteLine("Fountain is now enabled!");
                return true;
            } else {
                Console.WriteLine("Nothing to enable.");
                return false;
            }
        }

        public int SettleHazards(int _mapSize) {
            int pits = 0; int maelstorms = 0;
            int maxPits; int maxMaelstorms;
            Random rnd = new Random();
            switch (_mapSize) {
                case 4:
                    maxPits = 1; 
                    maxMaelstorms = 0; break;
                case 6:
                    maxPits = 2; 
                    maxMaelstorms = 1; break;
                case 8:
                    maxPits = 4;
                    maxMaelstorms = 2; break;
                default:
                    maxPits = 1;
                    maxMaelstorms = 0; break;
            }

            do {
                int row = rnd.Next(1, _mapSize);
                int col = rnd.Next(1, _mapSize);
                if (_grid[row, col] == null) {
                    _grid[row, col] = "pit";
                    pits++;
                }
            } while (pits < maxPits);

            do {
                int row = rnd.Next(1, _mapSize);
                int col = rnd.Next(1, _mapSize);
                if (_grid[row, col] == null) {
                    _grid[row, col] = "maelstorm";
                    maelstorms++;
                }
            } while (maelstorms < maxMaelstorms);


            return 0;
        }
    }

}

