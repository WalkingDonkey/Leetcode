namespace Interview.DataStructures
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class HashTable
    {
        public int[] TwoSum(int[] nums, int target)
        {
            var valueToIndexMap = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (valueToIndexMap.ContainsKey(nums[i]))
                {
                    return new int[] { valueToIndexMap[nums[i]], i };
                }
                else
                {
                    valueToIndexMap[target - nums[i]] = i;
                }
            }

            return new int[] { -1, -1 };
        }

        public IList<IList<int>> FourSum(int[] nums, int target)
        {
            var result = new List<IList<int>>();

            var sumToNumsPairMap = new Dictionary<int, List<Tuple<int, int>>>();
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    var sum = nums[i] + nums[j];
                    var numsPair = new Tuple<int, int>(nums[i], nums[j]);
                    if (sumToNumsPairMap.ContainsKey(sum))
                    {
                        var numsPairList = sumToNumsPairMap[sum];
                        if (!numsPairList.Contains(numsPair))
                        {
                            numsPairList.Add(numsPair);
                        }
                    }
                    else
                    {
                        var numsPairList = new List<Tuple<int, int>> { numsPair };
                        sumToNumsPairMap[sum] = numsPairList;
                    }
                }
            }

            var sb = StringBuilder();
            foreach (var keyPairValue in sumToNumsPairMap)
            {
                var partSum = keyPairValue.Key;
                var partSets = keyPairValue.Value;
                File.wr($"hash is {partSum}");
                foreach (var partSet in partSets)
                {
                    Console.WriteLine($"{partSet.Item1}, {partSet.Item2}");
                }
            }

            var valueToNumsMap = new Dictionary<int, List<Tuple<int, int>>>();
            foreach (var keyPairValue in sumToNumsPairMap)
            {
                var partSum = keyPairValue.Key;
                var partSets = keyPairValue.Value;
                var leftSum = target - partSum;
                if (valueToNumsMap.ContainsKey(leftSum))
                {
                    var leftSets = valueToNumsMap[leftSum];
                    foreach (var partSet in partSets)
                    {
                        foreach (var leftSet in leftSets)
                        {
                            var set = new List<int> { partSet.Item1, partSet.Item2, leftSet.Item1, leftSet.Item2 };
                            Console.WriteLine($"{partSet.Item1}, {partSet.Item2}, {leftSet.Item1}, {leftSet.Item2}");
                            result.Add(set);
                        }
                    }
                }
                else
                {
                    valueToNumsMap[partSum] = partSets;
                }
            }

            return result;
        }

        public int FourSumCount(int[] A, int[] B, int[] C, int[] D)
        {
            var sumToCountMap = new Dictionary<int, int>();
            for (var i = 0; i < A.Length; i++)
            {
                for (var j = 0; j < B.Length; j++)
                {
                    var sum = A[i] + B[j];
                    if (sumToCountMap.ContainsKey(sum))
                    {
                        sumToCountMap[sum]++;
                    }
                    else
                    {
                        sumToCountMap[sum] = 1;
                    }
                }
            }

            var count = 0;
            for (var i = 0; i < C.Length; i++)
            {
                for (var j = 0; j < D.Length; j++)
                {
                    var sum = C[i] + D[j];
                    if (sumToCountMap.ContainsKey(-sum))
                    {
                        count += sumToCountMap[-sum];
                    }
                }
            }

            return count;
        }
    }
}
