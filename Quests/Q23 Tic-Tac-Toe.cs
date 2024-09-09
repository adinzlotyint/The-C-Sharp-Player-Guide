using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;
using Methods;

namespace Quests.Quests
{
    public class Quest23
    {
        public static void Quest()
        {
            Game game = new Game();
            Game.Player playerOne = game.CreatePlayer(Signs.X);
            Game.Player playerTwo = game.CreatePlayer(Signs.O);

            Game.Player currPlayer;
            int currRound = 1;
            int selectedSquare;
            bool gameState = false;
            Console.Clear();
            do
            {
                currPlayer = currRound % 2 == 0 ? playerOne : playerTwo;
                Console.WriteLine($"{currPlayer._playerName} ({currPlayer._playerSign}), your turn.");
                game.GetBoard();

                do
                {
                    Console.WriteLine($"Select free square 1 to 9.");
                    selectedSquare = int.Parse(Console.ReadLine());
                } while (selectedSquare > 9 || selectedSquare < 1 || game.CheckSquare(selectedSquare) == false);
                Console.Clear();
                game.UpdateBoard(selectedSquare, currPlayer._playerSign);
                gameState = game.CheckForWin(currPlayer._playerSign, currPlayer._playerName);
                currRound++;
                if (currRound == 10)
                {
                    gameState = true;
                }
            } while (gameState == false);

            if (currRound < 10)
            {
                Console.WriteLine($"Winner is: {currPlayer._playerName}!");
            }
            else
            {
                Console.WriteLine($"It's a draw!");
            }


        }
    }
}

public class Game
{
    public string[] _squares = new string[10];
    string[] _winCombination = new string[8] { "123", "456", "789", "147", "258", "369", "159", "357" };
    public Game()
    {
        int i = 0;
        foreach (string x in _squares)
        {
            _squares[i] = " ";
            i++;
        }
    }
    public void GetBoard()
    {
        Console.WriteLine($"{_squares[1]} | {_squares[2]} | {_squares[3]}\n" +
                          $"--+---+--\n" +
                          $"{_squares[4]} | {_squares[5]} | {_squares[6]}\n" +
                          $"--+---+--\n" +
                          $"{_squares[7]} | {_squares[8]} | {_squares[9]}\n");
    }

    public bool CheckSquare(int square)
    {

        if (_squares[square] != " ")
        {
            return false;
        }

        return true;
    }

    public bool CheckForWin(Signs sign, string player)
    {
        string winString = "";
        string currString = sign.ToString();
        int i;
        for (i = 1; i < _squares.Length; i++)
        {
            if (_squares[i] == currString)
            {
                winString += i;
            }
        }

        int count;
        char[] winArray = winString.ToCharArray();

        foreach (string x in _winCombination)
        {
            count = 0;
            foreach (char y in winArray)
            {
                if (x.Contains(y))
                {
                    count++;
                    if (count == 3)
                    {
                        return true;
                    }
                }
            }
        }

        for (i = 0; i < _winCombination.Length; i++)
        {
            if (winString.Contains(_winCombination[i]))
            {
                return true;
            }
        }

        return false;
    }

    public void UpdateBoard(int square, Signs sign)
    {
        _squares[square] = sign.ToString();
    }

    public Player CreatePlayer(Signs sign)
    {
        Console.WriteLine($"Player playing {sign}, provide your name:");
        string name = Console.ReadLine();
        return new Player(sign, name);
    }
    public class Player
    {
        public string _playerName;
        public Signs _playerSign;
        public int winAmount = 0;

        public Player(Signs playerSign, string name)
        {
            _playerName = name;
            _playerSign = playerSign;
        }
    }
}

public enum Signs { X, O }