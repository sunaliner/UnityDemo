namespace UnityDemo.Models.Scorers
{
    public class SimpleScorer : Scorer
    {
        public override Player GetWinner(Player p1, Player p2)
        {
            if (p1[0].No + p1[1].No > p2[0].No + p2[1].No)
                return p1;
            else
                return p2;
        }
    }
}