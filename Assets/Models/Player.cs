using System.Collections.Generic;

namespace UnityDemo.Models
{
    public class Player
    {
        public Player(string name)
        {
            Name = name;

            _cards = new List<Card>(2);

            Money = 300;
        }

        public string Name { get; private set; }

        private readonly List<Card> _cards;

        public int Money { get; private set; }

        internal void IncreaseMoney(int prize)
        {
            Money += prize;
        }

        internal void DecreaseMoney(int prize)
        {
            Money -= prize;
        }

        internal void PrepareNewRound()
        {
            _cards.Clear();
        }

#if UnitTest
        public Card AddCard(Card card)
#else
        internal Card AddCard(Card card)
#endif
        {
            _cards.Add(card);
            return card;
        }

        /// <summary>
        /// n 번째 카드를 반환한다.
        /// </summary>
        /// <param name="cardIndex"></param>
        /// <returns></returns>
        public Card this[int cardIndex]
        {
            get { return _cards[cardIndex]; }
        }
    }
}