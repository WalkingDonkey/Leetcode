namespace UnitTests.DataStructures
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Interview.DataStructures;

    [TestClass]
    public class TwoSumTests
    {
        HashTable hashTable = new HashTable();

        [TestMethod]
        public void TwoSum_ExactlyOneSolution_ReturnValidIndices()
        {
            int[] nums = new int[] { -1, 2, 4, 8 };
            var indices = hashTable.TwoSum(nums, 6);

            CollectionAssert.AreEqual(new int[] { 1, 2 }, indices);
        }

        [TestMethod]
        public void TwoSum_MoreThanOneSolution_ReturnFirstValidIndices()
        {
            int[] nums = new int[] { -1, 2, 4, 8 -2};
            var indices = hashTable.TwoSum(nums, 6);

            CollectionAssert.AreEqual(new int[] { 1, 2 }, indices);
        }

        [TestMethod]
        public void TwoSum_NoSolution_ReturnNegativeIndices()
        {
            int[] nums = new int[] { -1, 2, 4, 8 };
            var indices = hashTable.TwoSum(nums, 8);

            CollectionAssert.AreEqual(new int[] { -1, -1 }, indices);
        }

        [TestMethod]
        public void TwoSum_NoSolutionWithOneNumberInput_ReturnNegativeIndices()
        {
            int[] nums = new int[] { -1 };
            var indices = hashTable.TwoSum(nums, 8);

            CollectionAssert.AreEqual(new int[] { -1, -1 }, indices);
        }

        [TestMethod]
        public void TwoSum_NoSolutionWithNoNumberInput_ReturnNegativeIndices()
        {
            int[] nums = new int[] {};
            var indices = hashTable.TwoSum(nums, 8);

            CollectionAssert.AreEqual(new int[] { -1, -1 }, indices);
        }
    }
}
