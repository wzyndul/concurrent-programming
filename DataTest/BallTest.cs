using Data;

namespace DataTest
{
    [TestClass]
    public class BallTest
    {
        Ball ball = new(1.0, 2.0, 5.0, 7.0);
        [TestMethod]
        public void ConstructorTest() {
            Assert.AreEqual(ball.XPosition, 1.0);
            Assert.AreEqual(ball.YPosition, 2.0);
            Assert.AreEqual(ball.XSpeed, 5.0);
            Assert.AreEqual(ball.YSpeed, 7.0);
            Assert.AreEqual(ball.Radius, 5.0);
        }
        [TestMethod]
        public void GettersSettersTest()
        {
            ball.XPosition = 2.5;
            ball.YPosition = 3.5;
            ball.XSpeed = 0.5;
            ball.YSpeed = 2.0;
            Assert.AreEqual(ball.XPosition, 2.5);
            Assert.AreEqual(ball.YPosition, 3.5);
            Assert.AreEqual(ball.XSpeed, 0.5);
            Assert.AreEqual(ball.YSpeed, 2.0);
            Assert.AreEqual(ball.Radius, 5.0);
        }

    }
}