using Microsoft.VisualStudio.TestTools.UnitTesting;
using MojeZadanie;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestDots
{
    [TestClass]
    public class GameTest
    {
        [TestMethod]
        public void HraciaPlochaTest()
        {
            HraciaPlocha hraciaPlocha = new HraciaPlocha(5, 6);
            Assert.AreEqual<int>(5, hraciaPlocha.hraciaplocha.GetLength(0));
            Assert.AreEqual<int>(6, hraciaPlocha.hraciaplocha.GetLength(1));
        }

        [TestMethod]
        public void VytvorenieHracejPlochy()
        {
            HraciaPlocha hraciaPlocha = new HraciaPlocha(5, 5);

            ConsoleGame consoleGame = new ConsoleGame();
            consoleGame.GenerateGameBoard(hraciaPlocha);

            for (int i = 0; i < hraciaPlocha.hraciaplocha.GetLength(0); i++)
            {
                for (int j = 0; j < hraciaPlocha.hraciaplocha.GetLength(1); j++)
                {
                    Assert.AreNotEqual<int>(0, hraciaPlocha.hraciaplocha[i, j]);
                }
            }
            
        }

        [TestMethod]
        public void ZaplneniePrazdnychMiest()
        {
            HraciaPlocha hraciaPlocha = new HraciaPlocha(5, 5);

            ConsoleGame consoleGame = new ConsoleGame();
            consoleGame.GenerateGameBoard(hraciaPlocha);

            hraciaPlocha.hraciaplocha[0, 0] = 0;
            hraciaPlocha.hraciaplocha[1, 0] = 0;
            hraciaPlocha.hraciaplocha[0, 1] = 0;
            hraciaPlocha.hraciaplocha[2, 2] = 0;
            hraciaPlocha.hraciaplocha[3, 1] = 0;

            Assert.AreEqual<int>(0, hraciaPlocha.hraciaplocha[0, 0]);
            Assert.AreEqual<int>(0, hraciaPlocha.hraciaplocha[1, 0]);
            Assert.AreEqual<int>(0, hraciaPlocha.hraciaplocha[0, 1]);
            Assert.AreEqual<int>(0, hraciaPlocha.hraciaplocha[2, 2]);
            Assert.AreEqual<int>(0, hraciaPlocha.hraciaplocha[3, 1]);

            consoleGame.GenerateEmptyPositions(hraciaPlocha);

            Assert.AreNotEqual<int>(0, hraciaPlocha.hraciaplocha[0, 0]);
            Assert.AreNotEqual<int>(0, hraciaPlocha.hraciaplocha[1, 0]);
            Assert.AreNotEqual<int>(0, hraciaPlocha.hraciaplocha[0, 1]);
            Assert.AreNotEqual<int>(0, hraciaPlocha.hraciaplocha[2, 2]);
            Assert.AreNotEqual<int>(0, hraciaPlocha.hraciaplocha[3, 1]);

        }


        [TestMethod]
        public void ZnicBlokyDoprava()
        {
            HraciaPlocha hraciaPlocha = new HraciaPlocha(5, 5);

            ConsoleGame consoleGame = new ConsoleGame();

            for (int i = 0; i < hraciaPlocha.hraciaplocha.GetLength(0); i++)
            {
                for (int j = 0; j < hraciaPlocha.hraciaplocha.GetLength(1); j++)
                {
                    hraciaPlocha.hraciaplocha[i, j] = 1;
                }
            }

            //11111
            //11111
            //11111
            //11111
            //11111

            consoleGame.DestroyBlocks(hraciaPlocha, "666",1,1);

            //11111
            //10001
            //11111
            //11111
            //11111

            Assert.AreEqual<int>(0, hraciaPlocha.hraciaplocha[1, 1]);
            Assert.AreEqual<int>(0, hraciaPlocha.hraciaplocha[2, 1]);
            Assert.AreEqual<int>(0, hraciaPlocha.hraciaplocha[3, 1]);

        }


        [TestMethod]
        public void ZnicBlokyDole()
        {
            HraciaPlocha hraciaPlocha = new HraciaPlocha(5, 5);

            ConsoleGame consoleGame = new ConsoleGame();

            for (int i = 0; i < hraciaPlocha.hraciaplocha.GetLength(0); i++)
            {
                for (int j = 0; j < hraciaPlocha.hraciaplocha.GetLength(1); j++)
                {
                    hraciaPlocha.hraciaplocha[i, j] = 1;
                }
            }

            //01111
            //11111
            //11111
            //11111
            //11111

            consoleGame.DestroyBlocks(hraciaPlocha, "222", 1, 1);

            //01111
            //01111
            //01111
            //01111
            //11111

            Assert.AreEqual<int>(0, hraciaPlocha.hraciaplocha[1, 2]);
            Assert.AreEqual<int>(0, hraciaPlocha.hraciaplocha[1, 3]);
            Assert.AreEqual<int>(0, hraciaPlocha.hraciaplocha[1, 4]);

        }

        [TestMethod]
        public void ZnicBlokyHore()
        {
            HraciaPlocha hraciaPlocha = new HraciaPlocha(5, 5);

            ConsoleGame consoleGame = new ConsoleGame();

            for (int i = 0; i < hraciaPlocha.hraciaplocha.GetLength(0); i++)
            {
                for (int j = 0; j < hraciaPlocha.hraciaplocha.GetLength(1); j++)
                {
                    hraciaPlocha.hraciaplocha[i, j] = 1;
                }
            }

            //11111
            //11111
            //11111
            //11111
            //10111

            consoleGame.DestroyBlocks(hraciaPlocha, "888", 4, 2);

            //11111
            //10111
            //10111
            //10111
            //10111

            Assert.AreEqual<int>(0, hraciaPlocha.hraciaplocha[2, 2]);
            Assert.AreEqual<int>(0, hraciaPlocha.hraciaplocha[2, 3]);
            Assert.AreEqual<int>(0, hraciaPlocha.hraciaplocha[2, 4]);

        }


        [TestMethod]
        public void ZnicBlokyDolava()
        {
            HraciaPlocha hraciaPlocha = new HraciaPlocha(5, 5);

            ConsoleGame consoleGame = new ConsoleGame();

            for (int i = 0; i < hraciaPlocha.hraciaplocha.GetLength(0); i++)
            {
                for (int j = 0; j < hraciaPlocha.hraciaplocha.GetLength(1); j++)
                {
                    hraciaPlocha.hraciaplocha[i, j] = 1;
                }
            }

            //11111
            //11110
            //11111
            //11111
            //11111

            consoleGame.DestroyBlocks(hraciaPlocha, "444", 2, 4);

            //11111
            //10000
            //11111
            //11111
            //11111

            Assert.AreEqual<int>(0, hraciaPlocha.hraciaplocha[2, 2]);
             Assert.AreEqual<int>(0, hraciaPlocha.hraciaplocha[3, 2]);
              Assert.AreEqual<int>(0, hraciaPlocha.hraciaplocha[4, 2]);

        }

        [TestMethod]
        public void ZnicBlokyDoL()
        {
            HraciaPlocha hraciaPlocha = new HraciaPlocha(5, 5);

            ConsoleGame consoleGame = new ConsoleGame();

            for (int i = 0; i < hraciaPlocha.hraciaplocha.GetLength(0); i++)
            {
                for (int j = 0; j < hraciaPlocha.hraciaplocha.GetLength(1); j++)
                {
                    hraciaPlocha.hraciaplocha[i, j] = 1;
                }
            }

            //11111
            //11110
            //11111
            //11111
            //11111

            consoleGame.DestroyBlocks(hraciaPlocha, "4442", 2, 4);


            //11111
            //10000
            //10111
            //11111
            //11111


            Assert.AreEqual<int>(0, hraciaPlocha.hraciaplocha[2, 2]);
            Assert.AreEqual<int>(0, hraciaPlocha.hraciaplocha[3, 2]);
            Assert.AreEqual<int>(0, hraciaPlocha.hraciaplocha[4, 2]);
            Assert.AreEqual<int>(0, hraciaPlocha.hraciaplocha[1, 2]);
        }
    }
}