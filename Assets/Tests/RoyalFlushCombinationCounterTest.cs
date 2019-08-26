using System;
using NUnit.Framework;

namespace Tests {
    public class RoyalFlushCombinationCounterTest {
        private RoyalFlushCombinationCalculator calculator = new RoyalFlushCombinationCalculator();

        [Test]
        public void HoldingTwoDifferentSuitsHasNoChance() {
            Card[] held = {Card.ACE_CLUBS, Card.KING_SPADES};
            Card[] discarded = {Card.TWO_HEARTS, Card.THREE_CLUBS, Card.FOUR_SPADES};
            Assert.AreEqual(0, this.calculator.Combinations(held, discarded));
        }
        
        [Test]
        public void DiscardingRoyalFlushMemberHasNoChance() {
            Card[] held = {Card.ACE_CLUBS};
            Card[] discarded = {Card.TWO_HEARTS, Card.THREE_CLUBS, Card.FOUR_SPADES, Card.TEN_CLUBS};
            Assert.AreEqual(0, this.calculator.Combinations(held, discarded));
        }
        
        [Test]
        public void HoldingLowCardHasNoChance() {
            Card[] held = {Card.FIVE_CLUBS};
            Card[] discarded = {Card.TWO_HEARTS, Card.THREE_CLUBS, Card.FOUR_SPADES, Card.TEN_CLUBS};
            Assert.AreEqual(0, this.calculator.Combinations(held, discarded));
        }
        
        [Test]
        public void DiscardingRoyalOfEachSuitHasNoChance() {
            Card[] held = {};
            Card[] discarded = {Card.ACE_HEARTS, Card.KING_CLUBS, Card.JACK_DIAMONDS, Card.QUEEN_SPADES, Card.TWO_CLUBS};
            Assert.AreEqual(0, this.calculator.Combinations(held, discarded));
        }
        
        [Test]
        public void AllAvailableHasFourCombinations() {
            Card[] held = {};
            Card[] discarded = {Card.TWO_CLUBS, Card.THREE_DIAMONDS, Card.FIVE_CLUBS, Card.SIX_CLUBS, Card.SIX_HEARTS};
            Assert.AreEqual(4, this.calculator.Combinations(held, discarded));
        }
        
        [Test]
        public void DiscardingOneRoyalRemovesChanceOfThatSuitsRoyalFlush() {
            Card[] held = {};
            Card[] discarded = {Card.TWO_CLUBS, Card.THREE_DIAMONDS, Card.KING_CLUBS, Card.SIX_CLUBS, Card.SIX_HEARTS};
            Assert.AreEqual(3, this.calculator.Combinations(held, discarded));
        }
        
        [Test]
        public void KeepingOneRoyalLeavesOneCombination() {
            Card[] held = {Card.KING_CLUBS};
            Card[] discarded = {Card.TWO_CLUBS, Card.THREE_DIAMONDS, Card.SIX_CLUBS, Card.SIX_HEARTS};
            Assert.AreEqual(1, this.calculator.Combinations(held, discarded));
        }
        
        [Test]
        public void OneAwayHasOneCombination() {
            Card[] held = {Card.KING_CLUBS, Card.JACK_CLUBS, Card.QUEEN_CLUBS, Card.TEN_CLUBS};
            Card[] discarded = {Card.TWO_SPADES};
            Assert.AreEqual(1, this.calculator.Combinations(held, discarded));
        }
        
        [Test]
        public void OneAwayButLastIsDiscardedHasNoChance() {
            Card[] held = {Card.KING_CLUBS, Card.JACK_CLUBS, Card.QUEEN_CLUBS, Card.TEN_CLUBS};
            Card[] discarded = {Card.ACE_CLUBS};
            Assert.AreEqual(0, this.calculator.Combinations(held, discarded));
        }

        [Test]
        public void EvaluationDoesNotAllocate() {
            Card[] held = {Card.KING_CLUBS, Card.JACK_CLUBS, Card.QUEEN_CLUBS, Card.TEN_CLUBS};
            Card[] discarded = {Card.ACE_CLUBS};
            
            long initialAllocation = GC.GetTotalMemory(false);

            for (int i = 0; i < 100; i++) {
                this.calculator.Combinations(held, discarded);
            }
            
            long finalAllocation = GC.GetTotalMemory(false);
            Assert.AreEqual(initialAllocation, finalAllocation);
        }
    }
}