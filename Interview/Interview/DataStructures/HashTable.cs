namespace Interview.DataStructures
{
    using System.Collections.Generic;
    using System.Linq;

    using Interview.Utilities;

    public class HashTable
    {
        public int[] TwoSum(int[] nums, int target)
        {
            var valueToIndexMap = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                //if (valueToIndexMap.ContainsKey(nums[i]))
                //{
                //    return new int[] { valueToIndexMap[nums[i]], i };
                //}
                //else
                //{
                //    valueToIndexMap[target - nums[i]] = i;
                //}

                if (valueToIndexMap.ContainsKey(target - nums[i]))
                {
                    return new int[] { valueToIndexMap[target - nums[i]], i };
                }
                else
                {
                    valueToIndexMap[nums[i]] = i;
                }
            }

            return new int[] { -1, -1 };
        }

        public IList<IList<int>> FourSum(int[] nums, int target)
        {
            var result = new List<IList<int>>();

            if (nums.Sum() == target)
            {
                result.Add(nums);
                return result;
            }

            var sumToNumsPairMap = new Dictionary<int, List<IList<int>>>();
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    var sum = nums[i] + nums[j];
                    var numsPair = new List<int> { nums[i], nums[j] };
                    numsPair.Sort();
                    if (sumToNumsPairMap.ContainsKey(sum))
                    {
                        var numsPairList = sumToNumsPairMap[sum];
                        if (!numsPairList.Exists(element => element.SequenceEqual(numsPair)))
                        {
                            numsPairList.Add(numsPair);
                        }
                    }
                    else
                    {
                        var numsPairList = new List<IList<int>> { numsPair };
                        sumToNumsPairMap[sum] = numsPairList;
                    }
                }
            }

            var buffer = string.Empty;
            foreach (var keyPairValue in sumToNumsPairMap)
            {
                var partSum = keyPairValue.Key;
                var partSets = keyPairValue.Value;
                buffer += ($"hash is {partSum}\n");
                foreach (var partSet in partSets)
                {
                    buffer += ($"{partSet[0]}, {partSet[1]}\n");
                }
            }

            var buffer1 = string.Empty;
            var valueToNumsMap = new Dictionary<int, List<IList<int>>>();
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
                            var set = new List<int> { partSet[0], partSet[1], leftSet[0], leftSet[1] };
                            set.Sort();
                            buffer1 += ($"{partSet[0]}, {partSet[1]}, {leftSet[0]}, {leftSet[1]}\n");
                            if (set.IsSubsetOf(nums) && !result.Exists(element => element.SequenceEqual(set)))
                            {
                                result.Add(set);
                            }
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
