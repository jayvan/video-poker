using System;
using System.Collections.Generic;

public class StraightFlushCombinationCalculator : ICombinationCalculator {

    private int ScoreStraightCombinations(Dictionary<Suit, bool[]> availableCardsBySuit) {
        int score = 0;

        // look for length 5 straight combinations in the bool that exists by suit
        foreach(bool[] isCardAvailable in availableCardsBySuit.Values) {
            int head = 0;
            int tail = 0;
            while(head < isCardAvailable.Length) {
                
                if (isCardAvailable[head] == false) {
                    head++;
                    tail = head;
                } else {
                    head++;
                }
                if(head - tail == 5) {
                    score++;
                    tail++;
                }
            }
        }

        return score;
    }

    public int Combinations(IEnumerable<Card> held, IEnumerable<Card> discarded) {
        int numCombinations = 0;

        HashSet<Suit> suitsToRemove = new HashSet<Suit>() {Suit.Club, Suit.Diamond, Suit.Heart, Suit.Spade };
        Dictionary<Suit, bool[]> availableCardsBySuit = new Dictionary<Suit, bool[]>();

        foreach (Suit suit in Enum.GetValues(typeof(Suit))) { 
            bool[] isCardAvailable = new bool[13];
            foreach (Rank rank in Enum.GetValues(typeof(Rank))) {
                isCardAvailable[(int)rank] = true;
                if(rank == Rank.Ace) {
                    isCardAvailable[(int)rank] = false;
                }
            }
            availableCardsBySuit.Add(suit, isCardAvailable);
        }
        
        // for each suit have an object that tracks the ranges of the cards inputted

        foreach (Card card in held) {

            suitsToRemove.Remove(card.Suit);
            // set all cards not around the card range to be false,
            // indicating it is invalid given what is in the hand
            bool[] isCardAvailable = availableCardsBySuit[card.Suit];
            for (int i = 0; i < isCardAvailable.Length; i++) {
                if(i < (int)(card.Rank)-4 || i > (int)(card.Rank)+4) {
                    isCardAvailable[i] = false;
                }
            }
        }

        // if my hand had at least some suits in it, I need to remove suits that didn't
        // appear. Room for an early exit path here
        if(suitsToRemove.Count < 4) { 
            foreach (Suit suit in suitsToRemove) {
                availableCardsBySuit.Remove(suit);
            }
        }
        
        // use discarded cards to create breaks in the possible 5 card windows
        foreach (Card card in discarded) {
           if(availableCardsBySuit.ContainsKey(card.Suit)) {
                bool[] isCardAvailable = availableCardsBySuit[card.Suit];
                isCardAvailable[(int)card.Rank] = false;
           }
        }

        if(availableCardsBySuit.Count == 1 || availableCardsBySuit.Count == 4) {
            numCombinations = ScoreStraightCombinations(availableCardsBySuit);
        }
        
        return numCombinations;
    }
}
