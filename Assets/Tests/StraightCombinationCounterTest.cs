using System;
using NUnit.Framework;

namespace Tests {
    public class StraightCombinationCounterTest {
        private StraightCombinationCalculator calculator = new StraightCombinationCalculator();

        [Test]
        public void ValueOutOfStraightWindow() {
            Card[] held = {Card.TWO_CLUBS, Card.THREE_SPADES, Card.FOUR_HEARTS, Card.FIVE_DIAMONDS, Card.SEVEN_CLUBS};
            Card[] discarded = {};
            Assert.AreEqual(0, this.calculator.Combinations(held, discarded));
        }

        [Test]
        public void DuplicateRankPreventingCompleteStraight() {
            Card[] held = {Card.TWO_CLUBS, Card.THREE_SPADES, Card.FOUR_HEARTS, Card.FIVE_DIAMONDS, Card.TWO_HEARTS};
            Card[] discarded = { };
            Assert.AreEqual(0, this.calculator.Combinations(held, discarded));
        }

        [Test]
        public void DiscardedMultipleSameRankAbovePreventingCompleteStraight() {
            Card[] held = {Card.TWO_CLUBS};
            Card[] discarded = {Card.THREE_SPADES, Card.THREE_HEARTS, Card.THREE_DIAMONDS, Card.THREE_CLUBS};
            Assert.AreEqual(0, this.calculator.Combinations(held, discarded));
        }

        [Test]
        public void DiscardedMultipleSameRankBelowPreventingCompleteStraight() {
            Card[] held = {Card.ACE_CLUBS};
            Card[] discarded = {Card.KING_SPADES, Card.KING_HEARTS, Card.KING_DIAMONDS, Card.KING_CLUBS};
            Assert.AreEqual(0, this.calculator.Combinations(held, discarded));
        }

        [Test]
        public void AllCombinationsAvailable() {
            Card[] held = {};
            Card[] discarded = {};
            Assert.AreEqual(9216, this.calculator.Combinations(held, discarded));
        }

        [Test]
        public void DiscardedAllInARowSameSuit() {
            Card[] held = {};
            Card[] discarded = {Card.TWO_CLUBS, Card.THREE_CLUBS, Card.FOUR_CLUBS, Card.FIVE_CLUBS, Card.SIX_CLUBS};
            Assert.AreEqual(6439, this.calculator.Combinations(held, discarded));
        }

        [Test]
        public void DiscardedAllInARowRandomSuit() {
            Card[] held = {};
            Card[] discarded = {Card.TWO_CLUBS, Card.THREE_SPADES, Card.FOUR_HEARTS, Card.FIVE_DIAMONDS, Card.SIX_CLUBS };
            Assert.AreEqual(6439, this.calculator.Combinations(held, discarded));
        }

        [Test]
        public void DiscardHighestCanBeAnySuit() {
            Card[] held = {Card.TWO_CLUBS, Card.THREE_SPADES, Card.FOUR_HEARTS, Card.FIVE_DIAMONDS};
            Card[] discarded = {Card.TEN_CLUBS};
            Assert.AreEqual(4, this.calculator.Combinations(held, discarded));
        }

        [Test]
        public void DiscardLowestCanBeAnySuit() {
            Card[] held = {Card.ACE_CLUBS, Card.KING_HEARTS, Card.QUEEN_DIAMONDS, Card.JACK_SPADES};
            Card[] discarded = {Card.THREE_SPADES};
            Assert.AreEqual(4, this.calculator.Combinations(held, discarded));
        }
    }
}