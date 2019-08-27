using System;
using System.Collections.Generic;
using UnityEditor;

namespace Model {
    public class HandEvaluator {
        Dictionary<Rank, int> rankCount = new Dictionary<Rank, int>(5);
        Dictionary<Suit, int> suitCount = new Dictionary<Suit, int>(4);
        
        public HandEvaluator() {
        }
        
        public HandResult Evaluate(Card[] hand) {
            this.rankCount.Clear();
            this.suitCount.Clear();

            int highest = (int)Rank.Two;
            int lowest = (int)Rank.Ace;
            bool duplicateRank = false;

            foreach (Card card in hand) {
                int rankEncounters;
                this.rankCount.TryGetValue(card.Rank, out rankEncounters);
                this.rankCount[card.Rank] = rankEncounters + 1;

                duplicateRank = duplicateRank || rankEncounters > 0;
                
                int suitEncounters;
                this.suitCount.TryGetValue(card.Suit, out suitEncounters);
                this.suitCount[card.Suit] = suitEncounters + 1;

                highest = Math.Max(highest, (int)card.Rank);
                lowest = Math.Min(lowest, (int)card.Rank);
            }

            bool flush = this.suitCount.ContainsValue(5);

            if (flush &&
                this.rankCount.ContainsKey(Rank.Ace) &&
                this.rankCount.ContainsKey(Rank.King) &&
                this.rankCount.ContainsKey(Rank.Queen) &&
                this.rankCount.ContainsKey(Rank.Jack) &&
                this.rankCount.ContainsKey(Rank.Ten)) {
                return HandResult.RoyalFlush;
            }

            if (flush && highest - lowest == 4) {
                return HandResult.StraightFlush;
            }

            if (this.rankCount.ContainsValue(4)) {
                return HandResult.FourOfKind;
            }

            if (this.rankCount.ContainsValue(3) && this.rankCount.ContainsValue(2)) {
                return HandResult.FullHouse;
            }

            if (flush) {
                return HandResult.Flush;
            }

            if (!duplicateRank && highest - lowest == 4) {
                return HandResult.Straight;
            }

            if (this.rankCount.ContainsValue(3)) {
                return HandResult.ThreeOfKind;
            }

            // If there are three distinct ranks of cards, the counts are 1,2,2
            // since 1,1,3 was ruled out earlier
            if (this.rankCount.Values.Count == 3) {
                return HandResult.TwoPair;
            }

            if (this.rankCount.ContainsValue(2)) {
                foreach (KeyValuePair<Rank, int> kvp in this.rankCount) {
                    if (kvp.Value == 2) {
                        if (kvp.Key >= Rank.Jack) {
                            return HandResult.JackOrBetterPair;
                        }

                        return HandResult.Nothing;
                    }
                }
            }
            
            return HandResult.Nothing;
        }
    }
}