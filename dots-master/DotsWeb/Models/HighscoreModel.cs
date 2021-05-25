using MojeZadanie.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotsWeb.Models
{
    public class HighscoreModel
    {
        public IList<Score> Score { get; set; }
    }
}
