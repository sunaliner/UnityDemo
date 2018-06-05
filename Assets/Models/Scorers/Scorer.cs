#region
using System;
#endregion

namespace UnityDemo.Models.Scorers
{
    public abstract class Scorer
    {
        public abstract Player GetWinner(Player p1, Player p2);

        public static Scorer Create(ScorerType scorerType)
        {
            switch (scorerType)
            {
                case ScorerType.Basic:
                    return new BasicScorer();
                case ScorerType.Simple:
                    return new SimpleScorer();
                default:
                    throw new NotImplementedException("Scorer.Create");
            }
        }
    }
}