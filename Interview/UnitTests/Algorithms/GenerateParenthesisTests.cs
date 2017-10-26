namespace UnitTests.Algorithms
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Interview.Algorithms;

    [TestClass]
    public class GenerateParenthesisTests
    {
        Backtracking bt = new Backtracking();

        [TestMethod]
        public void GenerateParenthesis_ValidValue_Success()
        {
            var actual = bt.GenerateParenthesis(3);
        }
    }
}
