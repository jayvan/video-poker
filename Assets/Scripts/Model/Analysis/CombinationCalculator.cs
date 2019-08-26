using System.Collections.Generic;

public interface ICombinationCalculator {
    int Combinations(IEnumerable<Card> held, IEnumerable<Card> discarded);
}
