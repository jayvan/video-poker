using System.Collections.Generic;

public class RoyalFlushCombinationCalculator : ICombinationCalculator {
    public int Combinations(IEnumerable<Card> held, IEnumerable<Card> discarded) {
        return 5;
    }
}
