using MojeZadanie.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace MojeZadanie
{
    public class ConsoleGame
    {
        private readonly IScoreService scoreService = new ScoreServiceEF();
        public int Skore { get; set; }

        public void DrawGameBoard(HraciaPlocha hraciaPlocha)
        {
            for (int j = 0; j < hraciaPlocha.hraciaplocha.GetLength(1); j++)
            {
                for (int i = 0; i < hraciaPlocha.hraciaplocha.GetLength(0); i++)
                {
                    if (i == 0)
                    {
                        Console.Write("                   ");
                    }

                    hraciaPlocha.Graphic.SetColor(hraciaPlocha.hraciaplocha[i, j]);

                    Console.Write("  " + hraciaPlocha.hraciaplocha[i, j]);

                }
                Console.ResetColor();
                Console.WriteLine("");
            }
            Console.ResetColor();
        }

        public void DrawRemovedTilesGameBoard(HraciaPlocha hraciaPlocha)
        {
            for (int j = 0; j < hraciaPlocha.hraciaplocha.GetLength(1); j++)
            {
                for (int i = 0; i < hraciaPlocha.hraciaplocha.GetLength(0); i++)
                {
                    if (i == 0)
                    {
                        Console.Write("                   ");
                    }

                    hraciaPlocha.Graphic.SetColor(hraciaPlocha.hraciaplocha[i, j]);

                    if (hraciaPlocha.hraciaplocha[i, j] == 0)
                    {
                        Console.ResetColor();
                        Console.Write("   ");
                        Console.ResetColor();
                    }
                    else
                        Console.Write("  " + hraciaPlocha.hraciaplocha[i, j]);
                }

                Console.ResetColor();
                Console.WriteLine();
            }
        }


        public void DestroyBlocks(HraciaPlocha hraciaPlocha ,string hybemsa, int riadok, int stlpec)
        {
            int riadok2 = riadok;
            int stlpec2 = stlpec;

            for (int i = 0; i < hybemsa.Length; i++)
            {

                if (hybemsa[i] == '6' && stlpec2 + 1 <= 4)
                {
                    hraciaPlocha.hraciaplocha[stlpec2, riadok2] = 0;
                    hraciaPlocha.hraciaplocha[stlpec2 + 1, riadok2] = 0;
                    stlpec2 = stlpec2 + 1;
                    Skore++;

                }
                else if (hybemsa[i] == '4' && stlpec2 - 1 >= 0)
                {
                    hraciaPlocha.hraciaplocha[stlpec2, riadok2] = 0;
                    hraciaPlocha.hraciaplocha[stlpec2 - 1, riadok2] = 0;
                    stlpec2 = stlpec2 - 1;
                    Skore++;
                }
                else if (hybemsa[i] == '2' && riadok2 + 1 <= 4)
                {
                    hraciaPlocha.hraciaplocha[stlpec2, riadok2] = 0;
                    hraciaPlocha.hraciaplocha[stlpec2, riadok2 + 1] = 0;
                    riadok2 = riadok2 + 1;
                    Skore++;
                }
                else if (hybemsa[i] == '8' && riadok2 - 1 >= 0)
                {
                    hraciaPlocha.hraciaplocha[stlpec2, riadok2] = 0;
                    hraciaPlocha.hraciaplocha[stlpec2, riadok2 - 1] = 0;
                    riadok2 = riadok2 - 1;
                    Skore++;
                }

            }
        }


        public void DrawModifiedGameBoard(HraciaPlocha hraciaPlocha, int Skore)
        {

            Console.WriteLine();

            Console.WriteLine("   Tvoje aktuálne skóre je : " + Skore);

            Console.WriteLine();

            for (int j = 0; j < hraciaPlocha.hraciaplocha.GetLength(1); j++)
            {
                for (int i = 0; i < hraciaPlocha.hraciaplocha.GetLength(0); i++)
                {
                    if (i == 0)
                    {
                        Console.Write("                   ");
                    }

                    hraciaPlocha.Graphic.SetColor(hraciaPlocha.hraciaplocha[i, j]);

                    if (hraciaPlocha.hraciaplocha[i, j] == 0)
                    {
                        Console.Write(" ");
                    }
                    else
                        Console.Write("  " + hraciaPlocha.hraciaplocha[i, j]);
                }
                Console.ResetColor();
                Console.WriteLine();
                Console.ResetColor();
            }
        }


        public void GenerateGameBoard(HraciaPlocha hraciaPlocha)
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


        public void GenerateEmptyPositions(HraciaPlocha hraciaPlocha)
        {
            int num = 0;

            //generovanie novych cisel na prazdne pozicie
            for (int j = 0; j < hraciaPlocha.hraciaplocha.GetLength(1); j++)
            {
                for (int i = 0; i < hraciaPlocha.hraciaplocha.GetLength(0); i++)
                {
                    if (hraciaPlocha.hraciaplocha[i, j] == 0)
                    {
                        while (num == 0)
                        {
                            Random rnd = new Random();
                            num = rnd.Next(5);

                        }

                    (hraciaPlocha.hraciaplocha[i, j]) = num;
                        num = 0;
                    }
                    num = 0;
                }
            }
        }

        public void RunGame()
        {
            Console.WriteLine("   Ahoj toto je variácia hry DOTS na console.");

            Console.WriteLine();
            Console.WriteLine("   Tvoje aktuálne skóre je : " + Skore);
            Console.WriteLine();

            HraciaPlocha hraciaPlocha = new HraciaPlocha(5, 5);

            GenerateGameBoard(hraciaPlocha);


            DrawGameBoard(hraciaPlocha);

            int hra = 0;

            while (hra == 0)
            {
                Boolean hodnota = false;
                Console.WriteLine();
                Console.Write("\n Napíš 'exit' pre ukončenie hry.");
                Console.WriteLine();
                Console.Write("\n 1. Vyber si číslo ktorým chceš hýbať. Každé číslo má inú farbu.");
                Console.WriteLine();
                Console.Write("\n 2. Za každé spojenie farby získava hráč 1 bod.");
                Console.WriteLine();
                Console.Write("\n Číslo sa nachádza v riadku 1 do 5:  ");

                int riadok = 0;

                int riadiaca_hod = 1;
                string input = Console.ReadLine();

                if (input == "exit")
                {
                    break;
                }

                while (hodnota != true)
                {
                    if (riadiaca_hod == 0)
                    {
                        input = Console.ReadLine();
                    }
                    riadiaca_hod = 0;

                    riadok = Convert.ToInt32(input);
                    if (riadok == 1 || riadok == 2 || riadok == 3 || riadok == 4 || riadok == 5) { hodnota = true; }
                    else
                    {
                        Console.Write("\n Tvoje číslo je mimo rozsah ! Zadaj znovu : ");
                        riadok = 0;
                    }
                }

                hodnota = false;
                int stlpec = 0;

                Console.Write("\n Tvoje číslo sa nachádza v stlpci  1 do 5: ");
                while (hodnota != true)
                {

                    stlpec = Convert.ToInt32(Console.ReadLine());
                    if (stlpec == 1 || stlpec == 2 || stlpec == 3 || stlpec == 4 || stlpec == 5) { hodnota = true; }
                    else
                    {
                        Console.Write("\n Tvoje číslo je mimo rozsah ! Zadaj znovu : ");
                        stlpec = 0;
                    }
                }
                hodnota = false;

                riadok = riadok - 1;
                stlpec = stlpec - 1;
                Console.Write("\n 8 - HORE ");
                Console.Write("\n 2 - DOLE ");
                Console.Write("\n 6 - VPRAVO");
                Console.Write("\n 4 - VĽAVO \n ");
                Console.Write("\n Vyber si smer spájania farebných čísiel a potvrď ENTER : ");

                string hybemsa = null;


                hybemsa = Console.ReadLine();



                // vymazavanie spojenych
                Console.WriteLine();


                DestroyBlocks(hraciaPlocha, hybemsa, riadok, stlpec);


                Console.WriteLine();
                // j stlpec i riadok
                for (int z = 0; z < 5; z++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            if (i + 1 < 5)
                            {
                                if (hraciaPlocha.hraciaplocha[j, i + 1] == 0)
                                {
                                    hraciaPlocha.hraciaplocha[j, i + 1] = hraciaPlocha.hraciaplocha[j, i];
                                    hraciaPlocha.hraciaplocha[j, i] = 0;
                                }
                            }

                        }
                    }
                }

                //generovanie hracej plochy s vymazanymi
                DrawRemovedTilesGameBoard(hraciaPlocha);

                GenerateEmptyPositions(hraciaPlocha);

                // vypis finalu
                DrawModifiedGameBoard(hraciaPlocha, Skore);
                Console.WriteLine("Max skóre je 30!");
                Console.WriteLine();


                /*
                if (Skore >= 30)
                {



                    Console.Write("                   ");
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine("VYHRAL SI !!!!");
                    Console.ResetColor();
                    hra = 1;

                }
                */





            }


            Console.WriteLine("Zadaj meno:");
            string meno = Console.ReadLine();

            //vloz do databazy
            Score score = new Score();
            score.Name = meno;
            score.Value = Skore;
            scoreService.AddScore(score);

        }



    }
}
