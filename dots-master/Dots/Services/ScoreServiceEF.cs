using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace MojeZadanie.Services
{
    public class ScoreServiceEF : IScoreService
    {
        public void AddScore(Score score)
        {
            using (var context = new GameDbContext())
            {
                context.Scores.Add(score);
                context.SaveChanges();
            }
        }

        public IList<Score> GetTopScores()
        {
            using (var context = new GameDbContext())
            {
                return (from s in context.Scores
                        orderby s.Value
                            descending
                        select s).Take(5).ToList();
            }
        }

        public void ClearScores()
        {
            using (var context = new GameDbContext())
            {
                context.Database.ExecuteSqlCommand("DELETE FROM Scores");
            }
        }
    }

}
