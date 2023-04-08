using Data;

namespace DataTest
{
    [TestClass]
    public class BallTest
    {
        private IBall _ball = IBall.CreateBall(2, 3, 2, 2);
        [TestMethod]
        public void ConstructorTest() {
            Assert.AreEqual(_ball.GetBallPosition(), (2, 3));
            Assert.AreEqual(_ball.GetBallSpeed(), (2, 2));
            Assert.AreEqual(_ball.GetBallRadius(), 5);
        }
        [TestMethod]
        public void MoveBallTest()
        {
           _ball.MoveBall();
            Assert.AreEqual(_ball.GetBallPosition(), (4, 5));
        }

    }
}