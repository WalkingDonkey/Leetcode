namespace UnitTests.Algorithms
{
    using Interview.Algorithms;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;
    using System.Linq;

    [TestClass]
    public class FourSumCountTests
    {
        TwoPointers twoPointers = new TwoPointers();

        [TestMethod]
        public void FourSumCountTests_Normal()
        {
            int i = 2;
            int j = -i;
            var nums = new List<int[]> { new int[] { -1, -1 }, new int[] { -1, 1 }, new int[] { -1, 1 }, new int[] { 1, -1 } };

            //var nums = new List<int[]> { new int[] { 1, 2 }, new int[] { -2, -1 }, new int[] { -1, 2 }, new int[] { 0, 2 } };
            //var result = twoPointers.FourSumCount(nums[0], nums[1], nums[2], nums[3]);
        }
    }
}
