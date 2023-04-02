using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace DataTest
{
    [TestClass]
    public class BoardTest
    {
        Board board = new(40.0, 60.0);
        [TestMethod]
        public void ConstructorTest()
        {
            Assert.AreEqual(board.BoardWidth, 40.0);
            Assert.AreEqual(board.BoardHeight, 60.0);
        }
        [TestMethod]
        public void GettersSettersTest()
        {
            board.BoardWidth = 80.0;
            board.BoardHeight = 120.0;
            Assert.AreEqual(board.BoardWidth, 80.0);
            Assert.AreEqual(board.BoardHeight, 120.0);
        }
    }
}
