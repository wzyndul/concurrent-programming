﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic;
using Model;

namespace LogicTest
{
    [TestClass]
    public class LogicApiTest
    {
        private LogicAbstractAPI _board = LogicAbstractAPI.CreateAPI(20, 30, 5);
        private IBall _ball;

        [TestMethod]
        public void AddClearBallsTest()
        {
            _ball = _board.CreateBall(2, 3, 10, 4, 5);
            Assert.AreEqual(10, _ball.Radius);
            Assert.AreEqual(1, _board.GetBalls().Count());
            _board.ClearBoard();
            Assert.AreEqual(0, _board.GetBalls().Count());
        }

        [TestMethod]
        public void CreateBallInRandomPlaceTest()
        {
            _board.CreateRandomBallLocation();
            _board.CreateRandomBallLocation();
            _board.CreateRandomBallLocation();
            _board.CreateRandomBallLocation();
            _board.CreateRandomBallLocation();
            _board.CreateRandomBallLocation();
            _board.CreateRandomBallLocation();
            _board.CreateRandomBallLocation();
            _board.CreateRandomBallLocation();
            _board.CreateRandomBallLocation();
            Assert.AreEqual(10, _board.GetBalls().Count());
        }
        [TestMethod]
        public void AddBallsMoveBallsTest()
        {
            _board.ClearBoard();
            _board.AddBalls(5); 
            _board.MoveBalls();   
            Thread.Sleep(1000);
            int firstX = _board.GetBalls().ToArray()[0].XPosition;
            Thread.Sleep(1000);
            int secondX = _board.GetBalls().ToArray()[0].XPosition;
            Assert.AreNotEqual(firstX, secondX);
        }

    }


}
