using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace DataTest
{
    /*[TestClass]
    public class BoardRepositoryTest
    {
        BallRepository ballRepository = new();
        [TestMethod]
        public void AddBallTest()
        {
            Assert.AreEqual(ballRepository.GetBalls.Count, 0);
            ballRepository.Add(new Ball(2.0, 3.0, 4.0, 5.0));
            Assert.AreEqual(ballRepository.GetBalls.Count, 1);
        }
    }*/

    [TestClass]
    public class BallRepositoryTest
    {
        [TestMethod]
        public void ConnectExceptionTest()
        {
            Assert.ThrowsException<System.NotImplementedException>(() => DataAbstractAPI.CreateAPI().Connect());
        }
    }
}
