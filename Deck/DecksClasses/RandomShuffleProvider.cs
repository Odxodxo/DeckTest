using System;
using System.Collections.Generic;
using System.Linq;
using Cards;


public class RandomShuffleProvider<T> : IShuffleProvider<T>
    where T : class
{
    public IEnumerable<T> Shuffle(IEnumerable<T> items)
    {
        var random = new Random();
        return items.OrderBy(_ => random.Next());
    }
}