using System;
using System.Collections.Generic;
using System.Linq;
using Cards;


public class HandShuffle<T> : IShuffleProvider<T>
    where T : class
{
    public IEnumerable<T> Shuffle(IEnumerable<T> items)
    {
        var random = new Random();
        var shuffeld = items.ToList();
        for (int i = 0; i < 20; i++)
        {
            var slice = random.Next(0, shuffeld.Count-1);
            shuffeld.GetRange(0, slice)
                .InsertRange(0,shuffeld.GetRange(slice, shuffeld.Count - slice));
        }
        return shuffeld;
    }
}