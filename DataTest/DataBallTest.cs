using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTest
{
    [TestClass]
    public class DataBallTest
    {
        private IDataBall _ball = IDataBall.CreateBall(0, 0, 10, 1, 1);

        [TestMethod]
        public void TestCreateBall()
        {
            Assert.AreEqual(0, _ball.XPosition);
            Assert.AreEqual(0, _ball.YPosition);
            Assert.AreEqual(10, _ball.Weight);
        }

        [TestMethod]
        public void TestMoveBall()
        {
            _ball.MoveBall();
            Assert.AreEqual(1, _ball.XPosition);
            Assert.AreEqual(1, _ball.YPosition);
        }

        [TestMethod]
        public void TestOppositeXYSpeed()
        {
            _ball.OppositeXSpeed();
            Assert.AreEqual(-1, _ball.XSpeed);
            _ball.OppositeYSpeed();
            Assert.AreEqual(-1, _ball.YSpeed);
        }
    }
}
