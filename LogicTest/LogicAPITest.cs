using System;
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
            _ball = _board.CreateBall(2, 3, 5, 4, 5);
            Assert.AreEqual(5, _ball.GetRadius());
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
            Thread.Sleep(1000);
            List<int> second = _board.GetAllBallsPosition()[0];
            Assert.AreNotEqual(first, second);
        }

        private ModelAbstractAPI _modelApi = ModelAbstractAPI.CreateAPI();
        
        [TestMethod]
        public void TestMethod1()
        {
            _modelApi.Start(5);
            Thread.Sleep(1000);
            IModelBall modelBall = _modelApi.GetBalls().ElementAt(0);
            int x1 = modelBall.XPosition;
            int y1 = modelBall.YPosition;
            Thread.Sleep(2000);
            IModelBall modelBall1 = _modelApi.GetBalls().ElementAt(0);
            int x2 = modelBall1.XPosition;
            int y2 = modelBall1.YPosition;
            //Assert.AreNotEqual(x1, x2);
            Assert.AreNotEqual(y1, y2);
            //_modelApi.ClearBoard();  to zle dziala
        }

    }


}
