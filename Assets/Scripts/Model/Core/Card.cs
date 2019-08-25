using System;

public struct Card {
    public static Card TWO_HEARTS = new Card(Rank.Two, Suit.Heart);
    public static Card THREE_HEARTS = new Card(Rank.Three, Suit.Heart);
    public static Card FOUR_HEARTS = new Card(Rank.Four, Suit.Heart);
    public static Card FIVE_HEARTS = new Card(Rank.Five, Suit.Heart);
    public static Card SIX_HEARTS = new Card(Rank.Six, Suit.Heart);
    public static Card SEVEN_HEARTS = new Card(Rank.Seven, Suit.Heart);
    public static Card EIGHT_HEARTS = new Card(Rank.Eight, Suit.Heart);
    public static Card NINE_HEARTS = new Card(Rank.Nine, Suit.Heart);
    public static Card TEN_HEARTS = new Card(Rank.Ten, Suit.Heart);
    public static Card JACK_HEARTS = new Card(Rank.Jack, Suit.Heart);
    public static Card QUEEN_HEARTS = new Card(Rank.Queen, Suit.Heart);
    public static Card KING_HEARTS = new Card(Rank.King, Suit.Heart);
    public static Card ACE_HEARTS = new Card(Rank.Ace, Suit.Heart);
    public static Card TWO_DIAMONDS = new Card(Rank.Two, Suit.Diamond);
    public static Card THREE_DIAMONDS = new Card(Rank.Three, Suit.Diamond);
    public static Card FOUR_DIAMONDS = new Card(Rank.Four, Suit.Diamond);
    public static Card FIVE_DIAMONDS = new Card(Rank.Five, Suit.Diamond);
    public static Card SIX_DIAMONDS = new Card(Rank.Six, Suit.Diamond);
    public static Card SEVEN_DIAMONDS = new Card(Rank.Seven, Suit.Diamond);
    public static Card EIGHT_DIAMONDS = new Card(Rank.Eight, Suit.Diamond);
    public static Card NINE_DIAMONDS = new Card(Rank.Nine, Suit.Diamond);
    public static Card TEN_DIAMONDS = new Card(Rank.Ten, Suit.Diamond);
    public static Card JACK_DIAMONDS = new Card(Rank.Jack, Suit.Diamond);
    public static Card QUEEN_DIAMONDS = new Card(Rank.Queen, Suit.Diamond);
    public static Card KING_DIAMONDS = new Card(Rank.King, Suit.Diamond);
    public static Card ACE_DIAMONDS = new Card(Rank.Ace, Suit.Diamond);
    public static Card TWO_CLUBS = new Card(Rank.Two, Suit.Club);
    public static Card THREE_CLUBS = new Card(Rank.Three, Suit.Club);
    public static Card FOUR_CLUBS = new Card(Rank.Four, Suit.Club);
    public static Card FIVE_CLUBS = new Card(Rank.Five, Suit.Club);
    public static Card SIX_CLUBS = new Card(Rank.Six, Suit.Club);
    public static Card SEVEN_CLUBS = new Card(Rank.Seven, Suit.Club);
    public static Card EIGHT_CLUBS = new Card(Rank.Eight, Suit.Club);
    public static Card NINE_CLUBS = new Card(Rank.Nine, Suit.Club);
    public static Card TEN_CLUBS = new Card(Rank.Ten, Suit.Club);
    public static Card JACK_CLUBS = new Card(Rank.Jack, Suit.Club);
    public static Card QUEEN_CLUBS = new Card(Rank.Queen, Suit.Club);
    public static Card KING_CLUBS = new Card(Rank.King, Suit.Club);
    public static Card ACE_CLUBS = new Card(Rank.Ace, Suit.Club);
    public static Card TWO_SPADES = new Card(Rank.Two, Suit.Spade);
    public static Card THREE_SPADES = new Card(Rank.Three, Suit.Spade);
    public static Card FOUR_SPADES = new Card(Rank.Four, Suit.Spade);
    public static Card FIVE_SPADES = new Card(Rank.Five, Suit.Spade);
    public static Card SIX_SPADES = new Card(Rank.Six, Suit.Spade);
    public static Card SEVEN_SPADES = new Card(Rank.Seven, Suit.Spade);
    public static Card EIGHT_SPADES = new Card(Rank.Eight, Suit.Spade);
    public static Card NINE_SPADES = new Card(Rank.Nine, Suit.Spade);
    public static Card TEN_SPADES = new Card(Rank.Ten, Suit.Spade);
    public static Card JACK_SPADES = new Card(Rank.Jack, Suit.Spade);
    public static Card QUEEN_SPADES = new Card(Rank.Queen, Suit.Spade);
    public static Card KING_SPADES = new Card(Rank.King, Suit.Spade);
    public static Card ACE_SPADES = new Card(Rank.Ace, Suit.Spade);
    
    public Suit Suit;
    public Rank Rank;

    public Card(Rank rank, Suit suit) {
        this.Rank = rank;
        this.Suit = suit;
    }
}
