using Data;
using Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicTest
{
    [TestClass]
    public class LogicBallTest
    {
        private ILogicBall _logicBall = ILogicBall.CreateBall(0, 0, 10);
        private IDataBall _dataBall = IDataBall.CreateBall(20, 20, 10);

        [TestMethod]
        public void TestUpdateBall()
        {
            _logicBall.UpdateBall(_dataBall, new PropertyChangedEventArgs(nameof(_dataBall.XPosition)));
            _logicBall.UpdateBall(_dataBall, new PropertyChangedEventArgs(nameof(_dataBall.YPosition)));
            Assert.AreEqual(_dataBall.XPosition, _logicBall.XPosition);
            Assert.AreEqual(_dataBall.YPosition, _logicBall.YPosition);
        }
    }
}
