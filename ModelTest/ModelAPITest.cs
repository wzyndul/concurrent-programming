using Model;
namespace ModelTest
{
    [TestClass]
    public class ModelAPITest
    {
        private ModelAbstractAPI _modelApi = ModelAbstractAPI.CreateAPI();
        [TestMethod]
        public void TestMethod1()
        {
            _modelApi.Start(20);
            Thread.Sleep(1000);
            IModelBall modelBall = _modelApi.GetBalls().ElementAt(0);
            int x1 = modelBall.XPosition;
            int y1 = modelBall.YPosition;
            Thread.Sleep(2000);
            IModelBall modelBall1 = _modelApi.GetBalls().ElementAt(0);
            int x2 = modelBall1.XPosition;
            int y2 = modelBall1.YPosition;
            Assert.AreNotEqual(x1, x2);
            Assert.AreNotEqual(y1, y2);
        }
    }
}