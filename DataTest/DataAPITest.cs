using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTest
{
    [TestClass]
    public class DataAPITest
    {
        private DataAbstractAPI _data = DataAbstractAPI.CreateAPI();
        [TestMethod]
        public void ConnectTest()
        {
            Assert.ThrowsException<NotImplementedException>(() => _data.Connect());
        }
    }
}
