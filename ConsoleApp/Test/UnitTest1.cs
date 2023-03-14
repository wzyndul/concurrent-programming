using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace SimpleProgram.Test
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void AddPositiveNumbers()
        {
            int a = 4;
            int b = 8;

            Assert.AreEqual(12, Program.add(a, b));
        }

        [TestMethod]
        public void AddNegativeNumbers()
        {
            int a = -4;
            int b = -8;

            Assert.AreEqual(-12, Program.add(a, b));
        }

        [TestMethod]
        public void AddPositiveAndNegativeNumbers()
        {
            int a = 4;
            int b = -8;

            Assert.AreEqual(-4, Program.add(a, b));
        }

        [TestMethod]
        public void MultiplyPositiveNumbers()
        {
        int a = 4;
        int b = 8;
        Assert.AreEqual(32, Program.multiply(a, b));
        }

        [TestMethod]
        public void MultiplyNegativeNumbers()
        {
            int a = -1;
            int b = -6;
            Assert.AreEqual(6, Program.multiply(a, b));
        }

        [TestMethod]
        public void MultiplyPositiveAndNegativeNumbers()
        {
            int a = 4;
            int b = -8;

            Assert.AreEqual(-32, Program.multiply(a, b));
        }

        [TestMethod]
        public void MultiplyByZero()
        {
            int a = 4;
            int b = 0;

            Assert.AreEqual(0, Program.multiply(a, b));
        }
    }
}