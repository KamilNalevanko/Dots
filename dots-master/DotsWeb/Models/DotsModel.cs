using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MojeZadanie.Services;
using MojeZadanie;
using DotsWeb.Data;

namespace DotsWeb.Models
{
    [Serializable]
    public class DotsModel
    {
        public List<Tile> tileList { get; set; }

        public int PocetTahov { get; set; }
        public int Skore { get; set; }
        public int[,] Pole { get; set; }
    }
}

