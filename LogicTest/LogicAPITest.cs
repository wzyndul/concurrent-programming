using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic;

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
            _ball = _board.CreateBall(2, 3, 4, 5);
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
        //[DataTestMethod]
        //[DataRow(0, 0, 16, 2)]
        //[DataRow(0, 0, 5, 26)]
        //[DataRow(16, 0, 5, 2)]
        //[DataRow(26, 0, 5, 2)]
        //public void CreateBallNegativeTest(int x, int y, int xSpeed, int ySpeed)
        //{
        //    Assert.ThrowsException<Exception>(()=> _board.CreateBall(x, y, xSpeed, ySpeed));
        //}
        [TestMethod]
        public void AddBallsMoveBallsTest()
        {
            _board.ClearBoard();
            _board.AddBalls(5); //5 taskow
            _board.MoveBalls();   //rusza je tutaj
            Thread.Sleep(1000);
            List<int> first = _board.GetAllBallsPosition()[0];
            Console.WriteLine(first[0] + " " + first[1]);
            Thread.Sleep(1000);
            List<int> second = _board.GetAllBallsPosition()[0];
            Assert.AreNotEqual(first, second);
            Console.WriteLine(second[0] + " " + second[1]);
            Assert.AreEqual(5, _board.GetBalls().Count());
        }

    }
}
