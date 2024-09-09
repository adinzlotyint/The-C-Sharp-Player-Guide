using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Methods;

namespace Quests.Quests
{
    public class Quest20
    {
        public static void Quest()
        {
            Card[] deck = Card.CreateDeck();
            Random r = new Random();
            while (true)
            {
                int rInt = r.Next(deck.Length);
                Console.WriteLine($"{rInt} " + deck[rInt].GetCard());
                Console.ReadLine();
            }
        }
    }
}

public class Card
{
    public CardColor Color { get; set; }
    public CardRank Rank { get; set; }

    public Card(CardColor col, CardRank ran)
    {
        Color = col;
        Rank = ran;
    }

    public string GetCard() => $"{Color} {Rank}";

    public static Card[] CreateDeck()
    {
        Card[] tempArray = new Card[56];
        int i = 0;
        foreach (CardColor col in Enum.GetValues(typeof(CardColor)))
        {
            foreach (CardRank ran in Enum.GetValues(typeof(CardRank)))
            {
                Debug.WriteLine(col);
                Debug.WriteLine(ran);
                tempArray[i] = new Card(col, ran);
                i++;
            }

        }
        return tempArray;
    }
}

public enum CardColor { Red, Green, Blue, Yellow }
public enum CardRank { One, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, DollarSign, Percent, Caret, Ampersand }