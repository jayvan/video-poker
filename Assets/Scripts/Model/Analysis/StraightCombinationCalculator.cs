using System;
using System.Collections.Generic;

public class StraightCombinationCalculator : ICombinationCalculator {
	public int Combinations(IEnumerable<Card> held, IEnumerable<Card> discarded) {
		return int.MaxValue;
	}
}