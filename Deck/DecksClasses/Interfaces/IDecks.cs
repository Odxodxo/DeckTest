using System.Collections.Generic;
using API_for_Cards.Models;
using Cards;


public interface IDecks
{
    void Add(string name);
    void Remove(string name);
    Deck Get(string name);
    IEnumerable<string> GetDecksNames();
    void ShuffleDeck(string name);
}