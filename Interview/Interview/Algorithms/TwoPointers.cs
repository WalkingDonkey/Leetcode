namespace Interview.Algorithms
{
    using System;
    using System.Collections.Generic;

    public class TwoPointers
    {
        public IList<IList<int>> ThreeSum(int[] nums)
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
                    if (sum == 0)
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
                    else if (sum < 0)
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
    }
}
