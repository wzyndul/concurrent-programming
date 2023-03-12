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
    }
}