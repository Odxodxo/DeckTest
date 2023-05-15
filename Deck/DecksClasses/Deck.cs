using System.Collections;
using System.Collections.Generic;

namespace API_for_Cards.Models;

public class Deck : IEnumerable<Deck>
{
    public List<Card> DeckOfCards { get; set; } = new List<Card>();

    public Deck()
    {
        Init();
    }

    private void Init()
    {
        var suit = new[]
        {
            "Spades", "Hearts", "Diamonds", "Clubs"
        };

        var cardsAmount = 52;
        for (var s = 0; s < suit.Length; s++)
        {
            for (var j = 1; j < cardsAmount / suit.Length + 1; j++)
            {
                var cardSuit = suit[s];
                switch (j.ToString())
                {
                    case "11":
                        DeckOfCards.Add(new Card("J " + cardSuit));
                        break;
                    case "12":
                        DeckOfCards.Add(new Card("Q " + cardSuit));
                        break;
                    case "13":
                        DeckOfCards.Add(new Card("K " + cardSuit));
                        break;
                    case "1":
                        DeckOfCards.Add(new Card("A " + cardSuit));
                        break;
                    default:
                        DeckOfCards.Add(new Card(j + " " + cardSuit));
                        break;
                }
            }
        }
    }

    public Deck(int cardsAmount, string[] suit)
    {
        InitSomeDeck(cardsAmount, suit);
    }

    private void InitSomeDeck(int cardsAmount, string[] suit)
    {
        for (var s = 0; s < suit.Length; s++)
        {
            for (var j = 1; j < cardsAmount / suit.Length + 1; j++)
            {
                DeckOfCards.Add(new Card(j + " " + suit[s]));
            }
        }
    }

    IEnumerator<Deck> IEnumerable<Deck>.GetEnumerator()
    {
        return (IEnumerator<Deck>) ((IEnumerable) DeckOfCards).GetEnumerator();
    }

    public IEnumerator GetEnumerator()
    {
        return ((IEnumerable) DeckOfCards).GetEnumerator();
    }
}