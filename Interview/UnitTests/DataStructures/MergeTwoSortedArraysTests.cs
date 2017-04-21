namespace UnitTests.DataStructures
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Interview.DataStructures;

    [TestClass]
    public class MergeTwoSortedArraysTests
    {
        public class MergeTestInfo
        {
            public int[] FirstArray { get; set; }
            public int[] SecondArray { get; set; }
            public int[] MergedArray { get; set; }
            public int InitializedElementsOfFirstArray { get; set; }
            public int InitializedElementsOfSecondArray { get; set; }
        }

        Array array = new Array();

        private MergeTestInfo[] Initialize()
        {
            return new MergeTestInfo[]
            {
                new MergeTestInfo
                {
                    FirstArray = new int[] { 1, 3, 6, 0, 0 },
                    SecondArray = new int[] { 3, 4 },
                    MergedArray = new int[] { 1, 3, 3, 4, 6 },
                    InitializedElementsOfFirstArray = 3,
                    InitializedElementsOfSecondArray = 2
                },
                new MergeTestInfo
                {
                    FirstArray = new int[] { 3, 6, 0, 0, 0},
                    SecondArray = new int[] { 1, 3, 4 },
                    MergedArray = new int[] { 1, 3, 3, 4, 6 },
                    InitializedElementsOfFirstArray = 2,
                    InitializedElementsOfSecondArray = 3
                },
                new MergeTestInfo
                {
                    FirstArray = new int[] { 3, 6, 0, 0, 0},
                    SecondArray = new int[] { 1, 2, 7 },
                    MergedArray = new int[] { 1, 2, 3, 6, 7 },
                    InitializedElementsOfFirstArray = 2,
                    InitializedElementsOfSecondArray = 3
                },
                new MergeTestInfo
                {
                    FirstArray = new int[] { 3, 6, 0, 0, },
                    SecondArray = new int[] { 3, 6 },
                    MergedArray = new int[] { 3, 3, 6, 6 },
                    InitializedElementsOfFirstArray = 2,
                    InitializedElementsOfSecondArray = 2
                },
                new MergeTestInfo
                {
                    FirstArray = new int[] { 3, 6},
                    SecondArray = new int[] {},
                    MergedArray = new int[] { 3, 6 },
                    InitializedElementsOfFirstArray = 2,
                    InitializedElementsOfSecondArray = 0
                },
                new MergeTestInfo
                {
                    FirstArray = new int[] { 0, 0 },
                    SecondArray = new int[] { 3, 6 },
                    MergedArray = new int[] { 3, 6 },
                    InitializedElementsOfFirstArray = 0,
                    InitializedElementsOfSecondArray = 2
                }
            };
        }

        [TestMethod]
        public void MergeTwoSortedArrays_WithTwo_Success()
        {
            var mergeTestInfos = Initialize();
            foreach (var mergeTestInfo in mergeTestInfos)
            {
                array.MergeTwoSortedArrays(mergeTestInfo.FirstArray, mergeTestInfo.InitializedElementsOfFirstArray, mergeTestInfo.SecondArray, mergeTestInfo.InitializedElementsOfSecondArray);
                CollectionAssert.AreEqual(mergeTestInfo.MergedArray, mergeTestInfo.FirstArray);
            }
        }
    }
}
