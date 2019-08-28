using System;
using NUnit.Framework;

namespace Tests {
    public class StraightFlushCombinationCounterTest {
        private StraightFlushCombinationCalculator calculator = new StraightFlushCombinationCalculator();

        [Test]
        public void HoldingCardsNotInRowHasNoChance() {
            Card[] held = { Card.TWO_CLUBS, Card.THREE_CLUBS, Card.FOUR_CLUBS, Card.SIX_CLUBS, Card.SEVEN_CLUBS };
            Card[] discarded = { };
            Assert.AreEqual(0, this.calculator.Combinations(held, discarded));
        }

        [Test]
        public void HoldingCardsNotSameSuitHasNoChance() {
            Card[] held = { Card.TWO_CLUBS, Card.THREE_CLUBS, Card.FOUR_CLUBS, Card.FIVE_CLUBS, Card.SIX_SPADES };
            Card[] discarded = { };
            Assert.AreEqual(0, this.calculator.Combinations(held, discarded));
        }

        [Test]
        public void DiscardingAboveAndBelowHasNoChance() {
            // With the jack and nine gone, we can't get a straight
            Card[] held = {Card.TEN_HEARTS};
            Card[] discarded = {Card.TWO_HEARTS, Card.THREE_CLUBS, Card.JACK_HEARTS, Card.NINE_HEARTS};
            Assert.AreEqual(0, this.calculator.Combinations(held, discarded));
        }

        [Test]
        public void KeepingAceHasNoChance() {
            // An ace high straight flush is a royal flush
            Card[] held = { Card.ACE_HEARTS };
            Card[] discarded = { Card.TWO_HEARTS, Card.TWO_HEARTS, Card.TWO_DIAMONDS, Card.TWO_SPADES };
            Assert.AreEqual(0, this.calculator.Combinations(held, discarded));
        }

        [Test]
        public void OneAwayButLastIsDiscardedHasNoChance() {
            // Only the nine of clubs will satisfy this but it's been discarded
            Card[] held = { Card.QUEEN_CLUBS, Card.TEN_CLUBS, Card.EIGHT_CLUBS, Card.SEVEN_CLUBS };
            Card[] discarded = { Card.NINE_CLUBS };
            Assert.AreEqual(0, this.calculator.Combinations(held, discarded));
        }

        [Test]
        public void AllAvailableForThreeSuits() {
            // Clubs are out, but Diamond, heart, spade can each do six through king high (8*3 = 24)
            Card[] held = {};
            Card[] discarded = {Card.TWO_CLUBS, Card.SEVEN_CLUBS, Card.QUEEN_CLUBS, Card.ACE_CLUBS, Card.FOUR_CLUBS};
            Assert.AreEqual(24, this.calculator.Combinations(held, discarded));
        }
        
        [Test]
        public void AllAvailableForThreeSevenAvailableForOne() {
            // King-high clubs is out, but Diamond, heart, spade can each do six through king high (8*3 = 24)
            Card[] held = {};
            Card[] discarded = {Card.ACE_CLUBS, Card.ACE_DIAMONDS, Card.ACE_HEARTS, Card.ACE_SPADES, Card.KING_CLUBS};
            Assert.AreEqual(31, this.calculator.Combinations(held, discarded));
        }
        
        [Test]
        public void KeepingOneMiddleCardLeavesFive() {
            // Seven through jack high straight flushes are all possible
            Card[] held = {Card.SEVEN_HEARTS};
            Card[] discarded = {Card.TWO_CLUBS, Card.TWO_HEARTS, Card.TWO_DIAMONDS, Card.TWO_SPADES};
            Assert.AreEqual(5, this.calculator.Combinations(held, discarded));
        }
        
        [Test]
        public void KeepingLowestLeavesOne() {
            // Only a six high straight flush is eligible
            Card[] held = {Card.TWO_HEARTS};
            Card[] discarded = {Card.ACE_HEARTS, Card.TWO_CLUBS, Card.TWO_DIAMONDS, Card.TWO_SPADES};
            System.Diagnostics.Debug.WriteLine(this.calculator.Combinations(held, discarded));
            Assert.AreEqual(1, this.calculator.Combinations(held, discarded));
        }
        
        [Test]
        public void KeepingHighestLeavesOne() {
            // Only a king high straight flush is eligible
            Card[] held = {Card.KING_HEARTS};
            Card[] discarded = {Card.TWO_HEARTS, Card.TWO_HEARTS, Card.TWO_DIAMONDS, Card.TWO_SPADES};
            Assert.AreEqual(1, this.calculator.Combinations(held, discarded));
        } 
        
        [Test]
        public void OutsideHasTwoOptions() {
            // King or seven of clubs gets us a straight flush
            Card[] held = {Card.QUEEN_CLUBS, Card.TEN_CLUBS, Card.NINE_CLUBS, Card.JACK_CLUBS};
            Card[] discarded = {Card.TWO_SPADES};
            Assert.AreEqual(2, this.calculator.Combinations(held, discarded));
        }
        
        [Test]
        public void InsideHasOneOptions() {
            // Only the nine of clubs will satisfy this
            Card[] held = {Card.QUEEN_CLUBS, Card.TEN_CLUBS, Card.EIGHT_CLUBS, Card.JACK_CLUBS};
            Card[] discarded = {Card.TWO_HEARTS};
            Assert.AreEqual(1, this.calculator.Combinations(held, discarded));
        }
    }
}