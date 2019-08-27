using System.Collections.Generic;

public class RoyalFlushCombinationCalculator : ICombinationCalculator {
    private readonly bool[] suits = new bool[4];

    private int TrueCount(bool[] array) {
        int count = 0;
        for (int i = 0; i < array.Length; i++) {
            if (array[i]) {
                count++;
            }
        }

        return count;
    }

    private bool isTrue(bool value) {
        return value;
    }

    public int Combinations(IEnumerable<Card> held, IEnumerable<Card> discarded) {
        for (int i = 0; i < 4; i++) {
            this.suits[i] = false;
        }

        foreach (Card card in held) {
            // Holding a card less than 10 makes it impossible to get a royal flush
            if (card.Rank < Rank.Ten) {
                return 0;
            }

            this.suits[(int)card.Suit] = true;
        }
        
        // If more than 1 suit is held, it's game over.
        // If just 1 suit was held, that's the only suit that can win
        if (TrueCount(suits) > 1) {
            return 0;
        }

        if (TrueCount(this.suits) == 0) {
            for (int i = 0; i < 4; i++) {
                this.suits[i] = true;
            }
        }

        foreach (Card card in discarded) {
            if (card.Rank >= Rank.Ten) {
                this.suits[(int)card.Suit] = false;
            }
        }

        return TrueCount(suits);
    }
}
