using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using UnityDemo.Models;
using UnityDemo.Models.Scorers;

namespace Assets.Tests
{
    class BasicScorerTest_김대한
    {
        private List<Card> _cards;

        [SetUp]
        public void Init()
        {
            Deck.Instance.PrepareNewRound();

            _cards = new List<Card>();
            for (int i = 0; i < 20; i++)
            {
                Card card = Deck.Instance.Draw();
                _cards.Add(card);
            }
        }

        [Test]
        public void Simple끗_끼리_승부_중_더_높은_끗을_가진_플레이어가_승리하는가()
        {
            Player player1 = new Player("마하반야밀다심경");
            Player player2 = new Player("무구정광대다라니경");

            player1.AddCard(_cards.FirstOrDefault(x => x.No == 5));
            player1.AddCard(_cards.FirstOrDefault(x => x.No == 6));

            player2.AddCard(_cards.FirstOrDefault(x => x.No == 5));
            player2.AddCard(_cards.FirstOrDefault(x => x.No == 8));

            Player winer = Scorer.Create(ScorerType.Simple).GetWinner(player1, player2);

            Assert.AreEqual("무구정광대다라니경", winer.Name);
        }

        [Test]
        public void Basic끗_끼리_승부_중_더_높은_끗을_가진_플레이어가_승리하는가()
        {
            Player player1 = new Player("마하반야밀다심경");
            Player player2 = new Player("무구정광대다라니경");

            player1.AddCard(_cards.FirstOrDefault(x => x.No == 5));
            player1.AddCard(_cards.FirstOrDefault(x => x.No == 6));

            player2.AddCard(_cards.FirstOrDefault(x => x.No == 5));
            player2.AddCard(_cards.FirstOrDefault(x => x.No == 8));

            Player winer = Scorer.Create(ScorerType.Basic).GetWinner(player1, player2);

            Assert.AreEqual("무구정광대다라니경", winer.Name);
        }

        [Test]
        public void Basic끗과_땡의_승부_중_더_높은_스코어를_가진_플레이어가_승리하는가()
        {
            Player player1 = new Player("마하반야밀다심경");
            Player player2 = new Player("무구정광대다라니경");

            player1.AddCard(_cards.FirstOrDefault(x => x.No == 5));
            player1.AddCard(_cards.FirstOrDefault(x => x.No == 5));

            player2.AddCard(_cards.FirstOrDefault(x => x.No == 9));
            player2.AddCard(_cards.FirstOrDefault(x => x.No == 8));

            Player winer = Scorer.Create(ScorerType.Basic).GetWinner(player1, player2);

            Assert.AreEqual("마하반야밀다심경", winer.Name);
        }

        [Test]
        public void Basic끗과_광땡의_승부_중_더_높은_스코어를_가진_플레이어가_승리하는가()
        {
            Player player1 = new Player("마하반야밀다심경");
            Player player2 = new Player("무구정광대다라니경");

            player1.AddCard(_cards.FirstOrDefault(x => x.No == 1 && x.IsKwang));
            player1.AddCard(_cards.FirstOrDefault(x => x.No == 3 && x.IsKwang));

            player2.AddCard(_cards.FirstOrDefault(x => x.No == 9));
            player2.AddCard(_cards.FirstOrDefault(x => x.No == 8));

            Player winer = Scorer.Create(ScorerType.Basic).GetWinner(player1, player2);

            Assert.AreEqual("마하반야밀다심경", winer.Name);
        }

        [Test]
        public void Basic땡과_광땡의_승부_중_더_높은_스코어를_가진_플레이어가_승리하는가()
        {
            Player player1 = new Player("마하반야밀다심경");
            Player player2 = new Player("무구정광대다라니경");

            player1.AddCard(_cards.FirstOrDefault(x => x.No == 1 && x.IsKwang));
            player1.AddCard(_cards.FirstOrDefault(x => x.No == 3 && x.IsKwang));

            player2.AddCard(_cards.FirstOrDefault(x => x.No == 8 && x.IsKwang == false));
            player2.AddCard(_cards.FirstOrDefault(x => x.No == 8 && x.IsKwang == false));

            Player winer = Scorer.Create(ScorerType.Basic).GetWinner(player1, player2);

            Assert.AreEqual("마하반야밀다심경", winer.Name);
        }

        [Test]
        public void 승리한_플레이어는_패배한_플레이어에게_판돈_100원을_받는다()
        {
            Game game = new Game();
            
            game.StartNewRound();
            game.SelectScorer(ScorerType.Basic);
            game.DistributeCards();
            
            Player winer = game[game.GetWinnerIndex()];
            Player loser = (winer == game[0]) ? game[1] : game[0];
            
            Assert.AreEqual(400, winer.Money);
            Assert.AreEqual(200, loser.Money);
        }
    }
}