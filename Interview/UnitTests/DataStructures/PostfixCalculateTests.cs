namespace UnitTests.DataStructures
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;

    using Interview.DataStructures;

    [TestClass]
    public class PostfixCalculateTests
    {
        Stack su = new Stack();

        [TestMethod]
        public void PostfixCalculate_ValidExpressions_ReturnExpectedValues()
        {
            var expressions = new string[] { null, string.Empty, "5 1 2 + 4 * + 3 -", " 5 1 2 +4 * + 3 - " };
            var expected = new int[] { 0, 0, 14, 14 };
            for (var i = 0; i < expressions.Length; i++)
            {
                var actual = su.PostfixCalculate(expressions[i]);
                Assert.AreEqual(expected[i], actual);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void PostfixCalculate_InvalidExpression_ThrowException()
        {
            var expression = "2 + 4 * + 3 −";
            su.PostfixCalculate(expression);
        }
    }
}
