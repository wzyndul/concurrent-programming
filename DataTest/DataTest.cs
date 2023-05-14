using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DataTest
{
    [TestClass]
    public class DataTest
    {
        private DataAbstractAPI _board = DataAbstractAPI.CreateAPI(800, 600, 10);

        [TestMethod]
        public void GetBallsTest()
        {
            for (int i = 0; i < 10; i++)
            {
                _board.CreateBall(1, 1, 10, 1, 1);
            }
            Assert.AreEqual(10, _board.GetBalls().Count());
        }


        [TestMethod]
        public void ClearBoardTest()
        {
            _board.CreateBall(1, 1, 10, 1, 1);
            _board.CreateBall(5, 5, 10, 5, 5);
            Assert.AreEqual(2, _board.GetBalls().Count());
            _board.ClearBoard();
            Assert.AreEqual(0, _board.GetBalls().Count());
        }

        [TestMethod]
        public void BallParameterTest()
        {
            IDataBall ball = _board.CreateBall(1, 1, 20, 1, 1);
            Assert.IsNotNull(_board.GetBalls());
            Assert.IsNotNull(ball);
            Assert.AreEqual(20, ball.Weight);
            Assert.AreEqual(1, ball.Velocity.X);
            Assert.AreEqual(1, ball.Velocity.Y);
        }

        [TestMethod]
        public void CreateRandomBallLocationTest()
        {
            List<IDataBall> balls = new List<IDataBall>
            {
                _board.CreateBall(1, 1, 10, 1, 1),
                _board.CreateBall(5, 5, 10, 5, 5)
            };

            IDataBall newBall = _board.CreateRandomBallLocation(balls);
            Assert.IsNotNull(newBall);
            Assert.IsTrue(newBall.Position.X > 4 * _board.BallRadius && newBall.Position.X < _board.BoardWidth - _board.BallRadius);
            Assert.IsTrue(newBall.Position.Y > 4 * _board.BallRadius && newBall.Position.Y < _board.BoardHeight - _board.BallRadius);
            Assert.AreNotEqual(0f, newBall.Velocity.X);
            Assert.AreNotEqual(0f, newBall.Velocity.Y);
        }

    }
}