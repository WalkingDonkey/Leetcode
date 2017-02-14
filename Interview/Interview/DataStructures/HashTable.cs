namespace Interview.DataStructures
{
    using System.Collections.Generic;

    public class HashTable
    {
        public int[] TwoSum(int[] nums, int target)
        {
            Dictionary<int, int> dictionary = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (dictionary.ContainsKey(nums[i]))
                {
                    return new int[] { dictionary[nums[i]], i };
                }
                else
                {
                    dictionary[target - nums[i]] = i;
                }
            }

            return new int[] { -1, -1 };
        }
    }
}
