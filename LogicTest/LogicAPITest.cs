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
        public void ConstructorTest()
        {
            Assert.AreEqual((20, 30), _board.GetBoardDimensions());
            Assert.AreEqual(0, _board.GetBalls().Count());
            Assert.AreEqual(5, _board.GetBallRadius());
;
        }
        [TestMethod]
        public void CreateBallTest()
        {
            _ball = _board.CreateBall(2, 3, 4, 5);
            Assert.AreEqual((2, 3), _board.GetBallCordinates(_ball));
            Assert.AreEqual((4, 5), _board.GetBallSpeed(_ball));
        }
        [TestMethod]
        public void AddClearBallsTest()
        {
            _ball = _board.CreateBall(2, 3, 4, 5);
            Assert.AreEqual(1, _board.GetBalls().Count());
            _board.ClearBoard();
            Assert.AreEqual(0, _board.GetBalls().Count());
        }

        [TestMethod]
        public void CreateBallInRandomPlace()
        {
            _board.CreateRandomBallLocation();
            Assert.AreEqual(1, _board.GetBalls().Count());
        }
        [DataTestMethod]
        [DataRow(0, 0, 16, 2)]
        [DataRow(0, 0, 5, 26)]
        [DataRow(16, 0, 5, 2)]
        [DataRow(26, 0, 5, 2)]
        public void CreateBallNegativeTest(int x, int y, int xSpeed, int ySpeed)
        {
            Assert.ThrowsException<Exception>(()=> _board.CreateBall(x, y, xSpeed, ySpeed));
            Assert.AreEqual(0, _board.GetBalls().Count());
        }

    }
}
