namespace UnitTests.Algorithms
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Linq;

    using Interview.Algorithms;

    [TestClass]
    public class TwoSumTests
    {
        TwoPointers twoPointers = new TwoPointers();

        [TestMethod]
        public void TwoSum_ExactlyOneSolution_ReturnListWithOneElement()
        {
            int[] nums = new int[] { -1, 2, 4, 8 };
            var result = twoPointers.TwoSum(nums, 6);

            Assert.AreEqual(1, result.Count);
            CollectionAssert.AreEqual(new int[] { 2, 4 }, result[0].ToList());
        }

        [TestMethod]
        public void TwoSum_NoSolution_ReturnEmptyList()
        {
            int[] nums = new int[] { -1, 2, 4, 8 };
            var result = twoPointers.TwoSum(nums, 8);

            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void TwoSum_MoreThanOneSolution_ReturnListWithMultipleElements()
        {
            int[] nums = new int[] { -1, 4, 2, 7 };
            var result = twoPointers.TwoSum(nums, 6);

            Assert.AreEqual(2, result.Count);
            CollectionAssert.AreEqual(result[0].ToArray(), new int[] { -1, 7 });
            CollectionAssert.AreEqual(result[1].ToArray(), new int[] { 2, 4 });
        }
    }
}
