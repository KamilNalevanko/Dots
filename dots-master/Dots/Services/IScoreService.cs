using System;
using System.Collections.Generic;
using System.Text;

namespace MojeZadanie.Services
{
    public interface IScoreService
    {
        void AddScore(Score score);

        IList<Score> GetTopScores();

        void ClearScores();
    }
}
