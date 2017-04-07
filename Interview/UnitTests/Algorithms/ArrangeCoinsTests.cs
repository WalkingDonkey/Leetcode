namespace UnitTests.Algorithms
{
    using Interview.Algorithms;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

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
