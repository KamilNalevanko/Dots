using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MojeZadanie;

namespace DotsWeb.Functions
{
    public class GameFunctions
    {
        public void VygenerujMapu(HraciaPlocha hraciaPlocha)
        {
            int num = 0;

            for (int j = 0; j < hraciaPlocha.hraciaplocha.GetLength(1); j++)
            {
                for (int i = 0; i < hraciaPlocha.hraciaplocha.GetLength(0); i++)
                {

                    while (num == 0)
                    {
                        Random rnd = new Random();
                        num = rnd.Next(6);

                    }

                    (hraciaPlocha.hraciaplocha[i, j]) = num;
                    num = 0;
                }
                num = 0;
            }
        }


        public int[,] SpadniTile(int[,] pole)
        {
            for (int k = 0; k < pole.GetLength(1) - 1; k++)
            {
                for (int i = 0; i < pole.GetLength(1) - 1; i++)
                {
                    for (int j = 0; j < pole.GetLength(0); j++)
                    {
                        int bott = pole.GetLength(1) - 1 - i;
                        if (pole[j, bott] == 0)
                        {
                            pole[j, bott] = pole[j, bott - 1];
                            pole[j, bott - 1] = 0;
                        }
                    }
                }
            }

            return pole;
        }



        public int[,] VygenerujPrazdneMiesta(int[,] pole)
        {

            int num = 0;

            //generovanie novych cisel na prazdne pozicie
            for (int j = 0; j < pole.GetLength(1); j++)
            {
                for (int i = 0; i < pole.GetLength(0); i++)
                {
                    if (pole[i, j] == 0)
                    {

                        Random rnd = new Random();
                        num = rnd.Next(1, 5);


                        pole[i, j] = num;

                    }
                }
            }

            return pole;
        }




    }
}