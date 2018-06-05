using System;

namespace UnityDemo.Models.Scorers
{
    public class BasicScorer : Scorer
    {
        public override Player GetWinner(Player p1, Player p2)
        {
            int score1 = CalculateScore(p1);
            int score2 = CalculateScore(p2);

            
            if (score1 > score2)
                return p1;
            else
                return p2;
        }

        private int CalculateScore(Player player)
        {
            if (player[0].IsKwang && player[1].IsKwang)
                return 101;
            else if (player[0].No == player[1].No)
                return player[0].No * 10;
            else
                return (player[0].No + player[1].No) % 10;
        }
    }
}