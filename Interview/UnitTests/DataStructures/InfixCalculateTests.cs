namespace UnitTests.DataStructures
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Interview.DataStructures;

    [TestClass]
    public class InfixCalculateTests
    {
        Stack su = new Stack();

        [TestMethod]
        public void InfixCalculate_ValidExpressions_ReturnExpectedValues()
        {
            var expressions = new string[] { null, string.Empty, "12 + 2 * 7/4-2", "12 + 2 * 7/4-2 " };
            var expected = new int[] { 0, 0, 13, 13 };
            for (var i = 0; i < expressions.Length; i++)
            {
                var actual = su.InfixCalculate(expressions[i]);
                Assert.AreEqual(expected[i], actual);
            }
        }
    }
}
