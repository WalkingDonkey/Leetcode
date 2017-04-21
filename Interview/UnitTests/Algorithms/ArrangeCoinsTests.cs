namespace UnitTests.Algorithms
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Interview.Algorithms;

    [TestClass]
    public class ArrangeCoinsTests
    {
        BinarySearch bs = new BinarySearch();

        [TestMethod]
        public void ArrangeCoins_ValidValue_Success()
        {
            bs.ArrangeCoins(21);
        }
    }
}
