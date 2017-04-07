namespace UnitTests.Algorithms
{
    using Interview.Algorithms;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;

    [TestClass]
    public class CoinChangeTests
    {
        DynamicProgramming dp = new DynamicProgramming();

        [TestMethod]
        public void CoinChange_ValidValues_Success()
        {
            var expected = new int[] { 0, 1, 2, 1, 2, 1, 2, 3, 2, 3, 2, 3 };
            for (int i = 0; i < 12; i++)
            {
                var actual = dp.CoinChange(i);
                Assert.AreEqual(expected[i], actual);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "n should not be less than zero.")]
        public void CoinChange_NegativeValue_ThrowException()
        {
            var actual = dp.CoinChange(-1);
        }
    }
}
