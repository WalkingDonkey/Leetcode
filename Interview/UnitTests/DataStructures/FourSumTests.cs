namespace UnitTests.DataStructures
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Interview.DataStructures;

    [TestClass]
    public class FourSumTests
    {
        HashTable hashTable = new HashTable();

        [TestMethod]
        public void FourSum_Normal()
        {
            //var nums = new int[] { 1, 1, 0, 0, -2, 2 };
            var nums = new int[] { 0, 0, 0, 0 };
            hashTable.FourSum(nums, 0);
        }
    }
}
