namespace Interview.Algorithms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class TwoPointers
    {
        public IList<IList<int>> TwoSum(int[] nums, int target)
        {
            Array.Sort(nums);

            return TwoSumCore(nums, 0, nums.Length - 1, target);
        }

        private IList<IList<int>> TwoSumCore(int[] nums, int l, int r, int target, int[] prefixElements = null)
        {
            var result = new List<IList<int>>();

            while (l < r)
            {
                var sum = nums[l] + nums[r];
                if (sum == target)
                {
                    if (prefixElements != null)
                    {
                        result.Add(prefixElements.Concat(new int[] { nums[l], nums[r] }).ToList());
                    }
                    else
                    {
                        result.Add(new int[] { nums[l], nums[r] });
                    }

                    l++;
                    while (l < r && nums[l] == nums[l - 1])
                    {
                        l++;
                    }

                    r--;
                    while (l < r && nums[r] == nums[r + 1])
                    {
                        r--;
                    }
                }
                else if (sum < target)
                {
                    l++;
                }
                else
                {
                    r--;
                }
            }

            return result;
        }

        public IList<IList<int>> ThreeSum(int[] nums, int target)
        {
            var result = new List<IList<int>>();

            Array.Sort(nums);

            for (var i = 0; i < nums.Length - 2; i++)
            {
                var j = i + 1;
                var k = nums.Length - 1;
                while (j < k)
                {
                    var sum = nums[i] + nums[j] + nums[k];
                    if (sum == target)
                    {
                        result.Add(new List<int> { nums[i], nums[j], nums[k] });

                        j++;
                        while (j < k && nums[j] == nums[j - 1])
                        {
                            j++;
                        }

                        k--;
                        while (j < k && nums[k] == nums[k + 1])
                        {
                            k--;
                        }
                    }
                    else if (sum < target)
                    {
                        j++;
                    }
                    else
                    {
                        k--;
                    }
                }

                while (i < nums.Length - 1 && nums[i] == nums[i+1])
                {
                    i++;
                }
            }

            return result;
        }

        public IList<IList<int>> ThreeSumNested(int[] nums, int target)
        {
            Array.Sort(nums);

            return ThreeSumCore(nums, 0, nums.Length - 1, target, int.MinValue);
        }

        private IList<IList<int>> ThreeSumCore(int[] nums, int l, int r, int target, int prefixElement = int.MinValue)
        {
            var result = new List<IList<int>>();

            for (var i = l; i < r - 1; i++)
            {
                int[] prefixElements;
                if (prefixElement != int.MinValue)
                {
                    prefixElements = new int[] { prefixElement, nums[i] };
                }
                else
                {
                    prefixElements = new int[] { nums[i] };
                }
                var partOfResult = TwoSumCore(nums, i + 1, r, target - nums[i], prefixElements);
                result.AddRange(partOfResult);

                while (i < nums.Length - 1 && nums[i] == nums[i + 1])
                {
                    i++;
                }
            }

            return result;
        }

        public IList<IList<int>> FourSumNested(int[] nums, int target)
        {
            var result = new List<IList<int>>();

            Array.Sort(nums);

            for(var i = 0; i < nums.Length - 3; i++)
            {
                var partOfResult = ThreeSumCore(nums, i + 1, nums.Length - 1, target - nums[i], nums[i]);
                result.AddRange(partOfResult);

                while (i < nums.Length - 1 && nums[i] == nums[i + 1])
                {
                    i++;
                }
            }

            return result;
        }

        public int ThreeSumClosest(int[] nums, int target)
        {
            Array.Sort(nums);

            var closestSum = 0;
            var minDiff = int.MaxValue;
            for (var i = 0; i < nums.Length - 2; i++)
            {
                var j = i + 1;
                var k = nums.Length - 1;

                while (j < k)
                {
                    var sum = nums[i] + nums[j] + nums[k];
                    if (sum == target)
                    {
                        return sum;
                    }
                    else if (sum < target)
                    {
                        j++;
                    }
                    else
                    {
                        k--;
                    }

                    var diff = Math.Abs(sum - target);
                    if (diff < minDiff)
                    {
                        minDiff = diff;
                        closestSum = sum;
                    }
                }
            }

            return closestSum;
        }

        public int ThreeSumClosestNested(int[] nums, int target)
        {
            Array.Sort(nums);

            var minDiff = nums[0] + nums[1] + nums[2] - target;
            for (int i = 0; i < nums.Length - 2; i++)
            {
                var currentMinDiff = TwoSumClosest(nums, i + 1, nums.Length - 1, target - nums[i], minDiff);
                if (Math.Abs(currentMinDiff) < Math.Abs(minDiff))
                {
                    minDiff = currentMinDiff;
                }
            }

            return minDiff + target;
        }

        public int TwoSumClosest(int[] nums, int l, int r, int target, int minDiff)
        {
            while (l < r)
            {
                var sum = nums[l] + nums[r];
                if (sum == target)
                {
                    return 0;
                }
                else if (sum < target)
                {
                    l++;
                }
                else
                {
                    r--;
                }

                var diff = sum - target;
                if (Math.Abs(diff) < Math.Abs(minDiff))
                {
                    minDiff = diff;
                }
            }

            return minDiff;
        }

        public int FourSumCount_Bruce(int[] A, int[] B, int[] C, int[] D)
        {
            Array.Sort(A);
            Array.Sort(B);
            Array.Sort(C);
            Array.Sort(D);

            var count = 0;

            for (var i = 0; i < A.Length; i++)
            {
                var countB = 0;
                for (var j = 0; j < B.Length; j++)
                {
                    var countC = 0;
                    for (var k = 0; k < C.Length; k++)
                    {
                        var countD = 0;
                        for (var l = 0; l < D.Length; l++)
                        {
                            var sum = A[i] + B[j] + C[k] + D[l];
                            if (sum == 0)
                            {
                                countD++;

                                while (l < D.Length - 1 && D[l] == D[l + 1])
                                {
                                    l++;
                                    countD++;
                                }
                            }
                        }

                        countC += countD;
                        while (k < C.Length - 1 && C[k] == C[k + 1])
                        {
                            k++;
                            countC += countD;
                        }
                    }

                    countB += countC;
                    while (j < B.Length - 1 && B[j] == B[j + 1])
                    {
                        j++;
                        countB += countC;
                    }
                }

                count += countB;
                while (i < A.Length - 1 && A[i] == A[i + 1])
                {
                    i++;
                    count += countB;
                }
            }

            return count;
        }

        // Given a string, find the length of the longest substring without repeating characters.
        // Examples:
        // Given "abcabcbb", the answer is "abc", which the length is 3.
        // Given "bbbbb", the answer is "b", with the length of 1.
        // Given "pwwkew", the answer is "wke", with the length of 3. Note that the answer must be a substring, "pwke" is a subsequence and not a substring.
        public int LengthOfLongestSubstring(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return 0;
            }

            var maxLength = 0;
            int walker = 0, runner = 0;
            var existingChars = new HashSet<char>();
            while (runner < s.Length)
            {
                // Moves left/slow pointer to next position of the repeated character of s[runner].
                while (existingChars.Contains(s[runner]))
                {
                    existingChars.Remove(s[walker++]);
                }

                existingChars.Add(s[runner]);
                maxLength = Math.Max(maxLength, runner - walker + 1);
                runner++;
            }

            return maxLength;
        }
    }
}
