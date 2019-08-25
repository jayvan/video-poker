using System;
using Model;
using NUnit.Framework;

namespace Tests {
    public class HandEvaluation {
        private HandEvaluator evaluator;

        [SetUp]
        public void SetUp() {
            this.evaluator = new HandEvaluator();
        }
        
        [TestCase(HandResult.Nothing,
            Rank.Two, Suit.Heart,
            Rank.Five, Suit.Spade,
            Rank.Seven, Suit.Diamond,
            Rank.Queen, Suit.Club,
            Rank.Ace, Suit.Heart,
            TestName = "DisparateCardsAreNothing")]
        [TestCase(HandResult.Nothing,
            Rank.Five, Suit.Club,
            Rank.Two, Suit.Heart,
            Rank.Five, Suit.Spade,
            Rank.Seven, Suit.Diamond,
            Rank.Five, Suit.Heart,
            TestName = "PairOfThreesIsNothing")]
        [TestCase(HandResult.Nothing,
            Rank.Five, Suit.Club,
            Rank.Two, Suit.Heart,
            Rank.Five, Suit.Spade,
            Rank.Seven, Suit.Diamond,
            Rank.Five, Suit.Heart,
            TestName = "PairOfFivesIsNothing")]
        [TestCase(HandResult.Nothing,
            Rank.Ten, Suit.Club,
            Rank.Two, Suit.Heart,
            Rank.Five, Suit.Spade,
            Rank.Seven, Suit.Diamond,
            Rank.Ten, Suit.Heart,
            TestName = "PairOfTensIsNothing")]
        [TestCase(HandResult.JackOrBetterPair,
            Rank.Jack, Suit.Club,
            Rank.Two, Suit.Heart,
            Rank.Five, Suit.Spade,
            Rank.Seven, Suit.Diamond,
            Rank.Jack, Suit.Heart,
            TestName = "PairOfJacksIsJacksOrBetterPair")]
        [TestCase(HandResult.JackOrBetterPair,
            Rank.Queen, Suit.Club,
            Rank.Two, Suit.Heart,
            Rank.Five, Suit.Spade,
            Rank.Seven, Suit.Diamond,
            Rank.Queen, Suit.Heart,
            TestName = "PairOfQueensIsJacksOrBetterPair")]
        [TestCase(HandResult.JackOrBetterPair,
            Rank.King, Suit.Club,
            Rank.Two, Suit.Heart,
            Rank.Five, Suit.Spade,
            Rank.Seven, Suit.Diamond,
            Rank.King, Suit.Heart,
            TestName = "PairOfKingsIsjacksOrBetterPair")]
        [TestCase(HandResult.JackOrBetterPair,
            Rank.Ace, Suit.Club,
            Rank.Two, Suit.Heart,
            Rank.Five, Suit.Spade,
            Rank.Seven, Suit.Diamond,
            Rank.Ace, Suit.Heart,
            TestName = "PairOfAcesIsJacksOrBetterPair")]
        [TestCase(HandResult.JackOrBetterPair,
            Rank.Ace, Suit.Club,
            Rank.Two, Suit.Heart,
            Rank.Five, Suit.Spade,
            Rank.Seven, Suit.Diamond,
            Rank.Ace, Suit.Heart,
            TestName = "PairOfAcesIsJacksOrBetterPair")]
        [TestCase(HandResult.TwoPair,
            Rank.Four, Suit.Club,
            Rank.Four, Suit.Heart,
            Rank.Queen, Suit.Spade,
            Rank.Seven, Suit.Diamond,
            Rank.Queen, Suit.Heart,
            TestName = "FourQueenPairIsTwoPair")]
        [TestCase(HandResult.TwoPair,
            Rank.Ten, Suit.Club,
            Rank.Seven, Suit.Heart,
            Rank.Five, Suit.Spade,
            Rank.Ten, Suit.Diamond,
            Rank.Five, Suit.Heart,
            TestName = "TenFivePairIsTwoPair")]
        [TestCase(HandResult.ThreeOfKind,
            Rank.Seven, Suit.Club,
            Rank.Four, Suit.Heart,
            Rank.Seven, Suit.Spade,
            Rank.Ten, Suit.Diamond,
            Rank.Seven, Suit.Heart,
            TestName = "ThreeSevensIsThreeOfKind")]
        [TestCase(HandResult.ThreeOfKind,
            Rank.Ace, Suit.Club,
            Rank.Ace, Suit.Heart,
            Rank.Four, Suit.Spade,
            Rank.Ace, Suit.Diamond,
            Rank.King, Suit.Heart,
            TestName = "ThreeAcesIsThreeOfKind")]
        [TestCase(HandResult.Straight,
            Rank.Two, Suit.Club,
            Rank.Three, Suit.Heart,
            Rank.Four, Suit.Spade,
            Rank.Five, Suit.Diamond,
            Rank.Six, Suit.Heart,
            TestName = "TwoThroughSixIsStraight")]
        [TestCase(HandResult.Straight,
            Rank.Ten, Suit.Spade,
            Rank.Jack, Suit.Heart,
            Rank.Nine, Suit.Diamond,
            Rank.Eight, Suit.Heart,
            Rank.Queen, Suit.Club,
            TestName = "EightThroughQueenIsStraight")]
        [TestCase(HandResult.Straight,
            Rank.Ace, Suit.Club,
            Rank.King, Suit.Heart,
            Rank.Queen, Suit.Spade,
            Rank.Jack, Suit.Diamond,
            Rank.Ten, Suit.Heart,
            TestName = "TenThroughAceIsStraight")]
        [TestCase(HandResult.Flush,
            Rank.Ace, Suit.Club,
            Rank.Two, Suit.Club,
            Rank.Five, Suit.Club,
            Rank.Seven, Suit.Club,
            Rank.Nine, Suit.Club,
            TestName = "AllClubsIsFlush")]
        [TestCase(HandResult.Flush,
            Rank.King, Suit.Heart,
            Rank.Two, Suit.Heart,
            Rank.Six, Suit.Heart,
            Rank.Eight, Suit.Heart,
            Rank.Three, Suit.Heart,
            TestName = "AllHeartsIsFlush")]
        [TestCase(HandResult.FullHouse,
            Rank.King, Suit.Heart,
            Rank.King, Suit.Diamond,
            Rank.Four, Suit.Club,
            Rank.Four, Suit.Heart,
            Rank.King, Suit.Spade,
            TestName = "ThreeKingsTwoFoursIsFullHouse")]
        [TestCase(HandResult.FullHouse,
            Rank.Two, Suit.Heart,
            Rank.Two, Suit.Diamond,
            Rank.Three, Suit.Club,
            Rank.Three, Suit.Heart,
            Rank.Two, Suit.Spade,
            TestName = "ThreeTwosTwoThreesIsFullHouse")]
        [TestCase(HandResult.FourOfKind,
            Rank.Two, Suit.Heart,
            Rank.Two, Suit.Diamond,
            Rank.Three, Suit.Diamond,
            Rank.Two, Suit.Club,
            Rank.Two, Suit.Spade,
            TestName = "FourTwosIsFourOfKind")]
        [TestCase(HandResult.FourOfKind,
            Rank.Ace, Suit.Heart,
            Rank.Ace, Suit.Diamond,
            Rank.Three, Suit.Heart,
            Rank.Ace, Suit.Clthubub,
            Rank.Ace, Suit.Spade,
            TestName = "FourAcesIsFourOfKind")]
        [TestCase(HandResult.StraightFlush,
            Rank.Two, Suit.Club,
            Rank.Three, Suit.Club,
            Rank.Four, Suit.Club,
            Rank.Five, Suit.Club,
            Rank.Six, Suit.Club,
            TestName = "TwoThroughSixSuitedIsStraightFlush")]
        [TestCase(HandResult.StraightFlush,
            Rank.Ten, Suit.Heart,
            Rank.Jack, Suit.Heart,
            Rank.Nine, Suit.Heart,
            Rank.Eight, Suit.Heart,
            Rank.Queen, Suit.Heart,
            TestName = "EightThroughQueenSuitedIsStraightFlush")]
        [TestCase(HandResult.RoyalFlush,
            Rank.Ten, Suit.Heart,
            Rank.Jack, Suit.Heart,
            Rank.King, Suit.Heart,
            Rank.Ace, Suit.Heart,
            Rank.Queen, Suit.Heart,
            TestName = "ThenThroughAceOfHeartsIsRoyalFlush")]
        [TestCase(HandResult.RoyalFlush,
            Rank.Ten, Suit.Spade,
            Rank.Ace, Suit.Spade,
            Rank.King, Suit.Spade,
            Rank.Jack, Suit.Spade,
            Rank.Queen, Suit.Spade,
            TestName = "ThenThroughAceOfSpadesIsRoyalFlush")]
        public void HandEvaluator(HandResult result, 
                                  Rank rankOne, Suit suitOne,
                                  Rank rankTwo, Suit suitTwo,
                                  Rank rankThree, Suit suitthree,
                                  Rank rankFour, Suit suitFour,
                                  Rank rankFive, Suit SuitFive) {
            Card[] hand = {
                new Card(rankOne, suitOne),
                new Card(rankTwo, suitTwo),
                new Card(rankThree, suitthree),
                new Card(rankFour, suitFour),
                new Card(rankFive, SuitFive)
            };
            
            Assert.AreEqual(result, this.evaluator.Evaluate(hand));
        }

        [Test]
        public void EvaluationDoesNotAllocate() {
            Card[] hand = {
                new Card(Rank.Two, Suit.Heart),
                new Card(Rank.Five, Suit.Spade),
                new Card(Rank.Seven, Suit.Diamond),
                new Card(Rank.Queen, Suit.Club),
                new Card(Rank.Ace, Suit.Heart)
            };

            long initialAllocation = GC.GetTotalMemory(false);

            for (int i = 0; i < 100; i++) {
                this.evaluator.Evaluate(hand);
            }
            
            long finalAllocation = GC.GetTotalMemory(false);
            Assert.AreEqual(initialAllocation, finalAllocation);
        }
    }
}