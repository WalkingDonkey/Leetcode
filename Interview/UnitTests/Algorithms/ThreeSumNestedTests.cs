namespace UnitTests.Algorithms
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Linq;

    using Interview.Algorithms;

    [TestClass]
    public class ThreeSumNestedTests
    {
        TwoPointers twoPointers = new TwoPointers();

        [TestMethod]
        public void ThreeSumNested_ExactlyOneSolution_ReturnListWithOneElement()
        {
            int[] nums = new int[] { -1, 2, 4, 0, 8 };
            var result = twoPointers.ThreeSumNested(nums, 6);

            Assert.AreEqual(1, result.Count);
            CollectionAssert.AreEqual(new int[] { 0, 2, 4 }, result[0].ToList());
        }

        [TestMethod]
        public void TwoSum_NoSolution_ReturnEmptyList()
        {
            int[] nums = new int[] { -1, 2, 4, 8 };
            var result = twoPointers.ThreeSumNested(nums, 8);

            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void TwoSum_MoreThanOneSolution_ReturnListWithMultipleElements()
        {
            int[] nums = new int[] { -1, 0, 1, 2, -1, -4};
            var result = twoPointers.ThreeSumNested(nums, 0);

            Assert.AreEqual(2, result.Count);
            CollectionAssert.AreEqual(result[0].ToArray(), new int[] { -1, -1, 2 });
            CollectionAssert.AreEqual(result[1].ToArray(), new int[] { -1, 0, 1 });
        }
    }
}
