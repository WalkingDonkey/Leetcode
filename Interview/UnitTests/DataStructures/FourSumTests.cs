namespace UnitTests.Algorithms
{
    using Interview.DataStructures;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;
    using System.Linq;

    [TestClass]
    public class FourSumTests
    {
        HashTable hashTable = new HashTable();

        [TestMethod]
        public void FourSum_Normal()
        {
            var nums = new int[] { 1, 0, -1, 0, -2, 2 };
            hashTable.FourSum(nums, 0);
        }
    }
}
