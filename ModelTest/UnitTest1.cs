using Model;
namespace ModelTest
{
    [TestClass]
    public class UnitTest1
    {
        private ModelAbstractAPI _modelApi = ModelAbstractAPI.CreateAPI();
        [TestMethod]
        public void TestMethod1()
        {
            _modelApi.Start(5);
            ModelBall modelBall = _modelApi.GetBalls().ElementAt(0);
            int x1 = modelBall.XPosition;
            int y1 = modelBall.YPosition;
            Thread.Sleep(1000);
            ModelBall modelBall1 = _modelApi.GetBalls().ElementAt(0);
            int x2 = modelBall1.XPosition;
            int y2 = modelBall1.YPosition;
            Assert.AreNotEqual(x1, x2);
            Assert.AreNotEqual(y1, y2);
            _modelApi.ClearBoard();
        }
    }
}