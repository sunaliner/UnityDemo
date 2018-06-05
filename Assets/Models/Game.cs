using UnityDemo.Models.Scorers;

namespace UnityDemo.Models
{
    public class Game
    {
        public Game()
        {
            _players = new[] { new Player("George"), new Player("Ringo") };
        }

        private const int Prize = 100;

        private readonly Player[] _players;

        public int RoundCount { get; private set; }

        private Scorer _scorer;

        /// <summary>
        /// 새 라운드를 시작한다.
        /// </summary>
        public void StartNewRound()
        {
            RoundCount++;
        }

        /// <summary>
        /// 스코어를 선택한다.
        /// </summary>
        /// <param name="scorerType"></param>
        public void SelectScorer(ScorerType scorerType)
        {
            _scorer = Scorer.Create(scorerType);
        }

        /// <summary>
        /// 플레이어들에게 카드를 두 장씩 나눠준다.
        /// </summary>
        public void DistributeCards()
        {
            Deck.Instance.PrepareNewRound();

            foreach (var player in _players)
                player.PrepareNewRound();

            foreach (var player in _players)
                for (int i = 0; i < 2; i++)
                    player.AddCard(Deck.Instance.Draw());
        }

        /// <summary>
        /// 승자의 인덱스를 반환한다.
        /// </summary>
        /// <returns></returns>
        public int GetWinnerIndex()
        {
            Player winner = _scorer.GetWinner(_players[0], _players[1]);
            winner.IncreaseMoney(Prize);
            Player loser = winner == _players[0] ? _players[1] : _players[0];
            loser.DecreaseMoney(Prize);

            return winner == _players[0] ? 0 : 1;
        }

        /// <summary>
        /// 파산한 플레이어를 반환한다.
        /// </summary>
        /// <returns>파산한 플레이어. 아무도 파산하지 않았으면 null</returns>
        public Player CheckBankrupt()
        {
            foreach (var player in _players)
                if (player.Money == 0)
                    return player;

            return null;
        }

//        public Player this[int playerIndex] => _players[playerIndex];

        public Player this[int playerIndex]
        {
            get { return _players[playerIndex]; }
        }

        public Card this[int playerIndex, int cardIndex] => this[playerIndex][cardIndex];
    }

    public enum ScorerType
    {
        Basic,
        Simple
    }
}