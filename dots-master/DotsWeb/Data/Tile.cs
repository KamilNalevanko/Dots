using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotsWeb.Data
{
    [Serializable]
    public class Tile
    {
        public int X;
        public int Y;

        public Tile()
        {

        }

        public Tile(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
