using System.Collections.Generic;
using NUnit.Framework;
using UnityDemo.Models;
using UnityDemo.Models.Scorers;

namespace Assets.Tests
{
    public class SimpleScorerTest
    {
        [SetUp]
        public void Init()
        {
//            Deck.Instance.PrepareNewRound();
        }

        [Test]
        public void 두_카드의_숫자의_합이_10보다_작은_경우()
        {
            Scorer scorer = new SimpleScorer();
            Player p1 = new Player("1");
            p1.AddCard(new Card(4, false));
            p1.AddCard(new Card(4, false));

            Player p2 = new Player("2");
            p2.AddCard(new Card(4, false));
            p2.AddCard(new Card(5, false));

            Player winner = scorer.GetWinner(p1, p2);

            Assert.AreEqual(p2, winner);
        }
    }
}