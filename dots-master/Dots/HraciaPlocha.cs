using System;
using System.Collections.Generic;
using System.Text;

namespace MojeZadanie
{
    public class HraciaPlocha
    {
        public int[,] hraciaplocha;
        public Graphic Graphic { get; private set; }

        public HraciaPlocha(int W, int H)
        {
            Graphic = new Graphic();
            hraciaplocha = new int[W, H];
        }
    }
}
