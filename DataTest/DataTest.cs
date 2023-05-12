using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTest
{
    [TestClass]
    public class DataTest
    {
        private DataAbstractAPI _board = DataAbstractAPI.CreateAPI(800, 600, 10);

        [TestMethod]
        public void TestGetBalls()
        {
            _board.CreateBall(0, 0, 10);
            _board.CreateBall(0, 0, 10);
            Assert.AreEqual(2, _board.GetBalls().Count);
        }

        [TestMethod]
        public void TestClearBoard()
        {
            _board.CreateBall(0, 0, 10);
            _board.CreateBall(0, 0, 10);
            Assert.AreEqual(2, _board.GetBalls().Count);
            _board.ClearBoard();
            Assert.AreEqual(0, _board.GetBalls().Count);
        }

        [TestMethod]
        public void TestCreateRandomBallLocation()
        {
            _board.CreateRandomBallLocation();
            Assert.AreEqual(1, _board.GetBalls().Count());  
        }
    }
}
