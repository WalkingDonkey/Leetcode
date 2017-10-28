namespace Interview.DataStructures
{
    using Interview.Utilities;

    public class Array
    {
        // Given two sorted integer arrays nums1 and nums2, merge nums2 into nums1 as one sorted array.
        // You may assume that nums1 has enough space(size that is greater or equal to m + n) to hold additional elements from nums2.
        // The number of elements initialized in nums1 and nums2 are m and n respectively.
        public void MergeTwoSortedArrays(int[] nums1, int m, int[] nums2, int n)
        {
            int i = m - 1, j = n - 1, k = m + n - 1;
            while (i >= 0 && j >= 0)
            {
                if (nums1[i] >= nums2[j])
                {
                    nums1[k--] = nums1[i--];
                }
                else
                {
                    nums1[k--] = nums2[j--];
                }
            }

            while (j >= 0)
            {
                nums1[k--] = nums2[j--];
            }
        }

        //Given a sorted array, remove the duplicates in place such that each element appear only once and return the new length.
        //Do not allocate extra space for another array, you must do this in place with constant memory.
        //For example,
        //Given input array nums = [1, 1, 2],
        //Your function should return length = 2, with the first two elements of nums being 1 and 2 respectively.It doesn't matter what you leave beyond the new length.
        public int RemoveDuplicates(int[] nums)
        {
            Guard.ArgumentNotNull(nums, nameof(nums));

            var length = nums.Length;
            if (length < 2)
            {
                return length;
            }

            int pre = 0, cur = 1;
            while (cur < length)
            {
                if (nums[pre] != nums[cur])
                {
                    nums[++pre] = nums[cur];
                }
                cur++;
            }

            return pre + 1;
        }
    }
}
