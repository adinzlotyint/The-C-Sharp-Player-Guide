using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Methods;

namespace Quest20
{
    public class Quest
    {
        public static void Start()
        {
            Card[] deck = Card.CreateDeck();
            Random rnd = new Random();
            while (true)
            {
                Console.WriteLine(deck.Length);
                Console.WriteLine(Array.IndexOf(deck, deck[^1]));
                int randomValue = rnd.Next(deck.Length);
                Console.WriteLine($"{randomValue} " + deck[randomValue].GetCard());
                Console.ReadLine();
            }
        }
    }
}

public class Card
{
    private CardColor _color;
    private CardRank _rank;

    public Card(CardColor color, CardRank rank)
    {
        _color = color;
        _rank = rank;
    }

    public string GetCard() => $"{_color} {_rank}";
    public static Card[] CreateDeck()
    {
        Card[] tempArray = new Card[56];
        int i = 0;
        foreach (CardColor color in Enum.GetValues(typeof(CardColor)))
        {
            foreach (CardRank rank in Enum.GetValues(typeof(CardRank)))
            {
                Debug.WriteLine(color);
                Debug.WriteLine(rank);
                tempArray[i] = new Card(color, rank);
                i++;
            }
        }
        return tempArray;
    }
}

public enum CardColor { Red, Green, Blue, Yellow }
public enum CardRank { One, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, DollarSign, Percent, Caret, Ampersand }