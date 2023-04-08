using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace DataTest
{
    [TestClass]
    public class BoardTest
    {
        private DataAbstractAPI _board = new Board(20, 30);
        private IBall _ball;
        [TestMethod]
        public void ConstructorTest()
        {
            Assert.AreEqual(_board.GetBoardDimensions(), (20, 30));
            Assert.AreEqual(_board.GetBalls().Count(), 0);
            
        }
        [TestMethod]
        public void CreateBallTest()
        {
            _ball = _board.CreateBall(2, 3, 4, 5);
            Assert.AreEqual(_board.GetBallCordinates(_ball), (2, 3));
            Assert.AreEqual(_board.GetBallSpeed(_ball), (4, 5));
            Assert.AreEqual(_board.GetBallRadius(_ball), 5);
        }
        [TestMethod]
        public void AddClearBallsTest()
        {
            _ball = _board.CreateBall(2, 3, 4, 5);
            Assert.AreEqual(_board.GetBalls().Count(), 1);
            _board.ClearBoard();
            Assert.AreEqual(_board.GetBalls().Count(), 0);
        }

        [TestMethod]
        public void MoveBallTest()
        {
            _ball = _board.CreateBall(2, 3, 4, 5);
            _board.MoveBall(_ball);
            Assert.AreEqual(_board.GetBallCordinates(_ball), (6, 8));
        }

    }
}
