using System.Collections.Generic;

public class StraightFlushCombinationCalculator : ICombinationCalculator {
    private readonly bool[] suits = new bool[4];

    public int Combinations(IEnumerable<Card> held, IEnumerable<Card> discarded) {
        return int.MaxValue;
    }
}
