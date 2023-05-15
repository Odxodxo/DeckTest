using System.Collections.Generic;

namespace Cards;

public interface IShuffleProvider<T>
        where T : class
    {
        IEnumerable<T> Shuffle(IEnumerable<T> items);
    }
