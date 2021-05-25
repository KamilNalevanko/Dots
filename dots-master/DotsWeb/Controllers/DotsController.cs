using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using DotsWeb.Models;
using MojeZadanie.Services;
using System.Diagnostics;
using DotsWeb.Functions;
using MojeZadanie;
using DotsWeb.Data;

namespace DotsWeb.Controllers
{
    public class DotsController : Controller
    {
        public IActionResult Index()
        {
            DotsModel dotsModel = new DotsModel();

            HraciaPlocha hraciaPlocha = new HraciaPlocha(5, 5);

            GameFunctions gameFunctions = new GameFunctions();


            gameFunctions.VygenerujMapu(hraciaPlocha);

            dotsModel.Pole = hraciaPlocha.hraciaplocha;

            dotsModel.tileList = new List<Tile>();

            HttpContext.Session.SetObject("gamemodel", dotsModel);

            return View(dotsModel);
        }


        public IActionResult SelectTile(int x, int y)
        {
            //load
            DotsModel dotsModel = GetModel();

            //do something

            if(dotsModel.tileList.Count>0)
            {
                Tile lasttile = dotsModel.tileList.Last();
                if((x == lasttile.X +1 || x == lasttile.X - 1) && y == lasttile.Y) //doprava alebo dolava
                {
                    dotsModel.tileList.Add(new Tile(x, y));
                }
                if ((y == lasttile.Y + 1 || y == lasttile.Y - 1) && x == lasttile.X) //hore alebo dole
                {
                    dotsModel.tileList.Add(new Tile(x, y));
                }
            }
            else //prazdny list
            {
                dotsModel.tileList.Add(new Tile(x, y));
            }

            Debug.WriteLine("--------------------------");

            foreach(Tile tile in dotsModel.tileList)
            {
                Debug.WriteLine("Tile x: "+tile.X+"  y: "+tile.Y);
            }
            
            //save to session
            HttpContext.Session.SetObject("gamemodel", dotsModel);

            return View("Index", dotsModel);
        }


        public IActionResult EndTurn()
        {
            //load
            DotsModel dotsModel = GetModel();

            GameFunctions gameFunctions = new GameFunctions();

            bool wrong = false;

            if(dotsModel.tileList.Count == 1)
            {
                dotsModel.tileList.Clear();
            }

            if (dotsModel.tileList.Count > 1)
            {

                Tile firstT = dotsModel.tileList.First();

                int firstV = dotsModel.Pole[firstT.X, firstT.Y];

                foreach (Tile tile in dotsModel.tileList)
                {
                    Debug.WriteLine("Tile x: " + tile.X + "  y: " + tile.Y);
                    if (dotsModel.Pole[tile.X, tile.Y] != firstV)
                    {
                        wrong = true;
                    }
                }

                if (wrong == false)
                {
                    dotsModel.PocetTahov++;

                    foreach (Tile tile in dotsModel.tileList)
                    {
                        dotsModel.Pole[tile.X, tile.Y] = 0;
                        dotsModel.Skore++;
                    }
                }

                dotsModel.Pole = gameFunctions.SpadniTile(dotsModel.Pole);
                dotsModel.Pole = gameFunctions.VygenerujPrazdneMiesta(dotsModel.Pole);

                dotsModel.tileList.Clear();
            }

            //save to session
            HttpContext.Session.SetObject("gamemodel", dotsModel);

            if(dotsModel.PocetTahov>=20)
            {
                return View("EndGame", dotsModel);
            }


            return View("Index", dotsModel);
        }
        

        public IActionResult UlozSkore(string name)
        {
            DotsModel dotsModel = GetModel();

            IScoreService scoreService = new ScoreServiceEF();
            Score score = new Score();
            score.Name = name;
            score.Value = dotsModel.Skore;

            scoreService.AddScore(score);

            HighscoreModel highscoreModel = new HighscoreModel();

            highscoreModel.Score = scoreService.GetTopScores();

            return View("Table", highscoreModel);
        }

        private DotsModel GetModel()
        {
            return (DotsModel)HttpContext.Session.GetObject("gamemodel");
        }
    }
}



