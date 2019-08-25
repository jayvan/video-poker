using System.Collections.Generic;

namespace Model {
    public class HandEvaluator {
        Dictionary<Rank, int> rankCount = new Dictionary<Rank, int>(13);
        Dictionary<Suit, int> suitCount = new Dictionary<Suit, int>(4);
        
        public HandEvaluator() {
        }
        
        public HandResult Evaluate(Card[] hand) {
            return HandResult.Nothing;
        }
    }
}