namespace Interview.Algorithms
{
    public class BinarySearch
    {
        // You have a total of n coins that you want to form in a staircase shape, where every k-th row must have exactly k coins.
        // Given n, find the total number of full staircase rows that can be formed.
        // n is a non-negative integer and fits within the range of a 32-bit signed integer.
        public int ArrangeCoins(int n)
        {
            var start = 0;
            var end = n;

            while (start <= end)
            {
                var mid = (start + end) >> 1;
                if (0.5 * mid * (mid + 1) <= n)
                {
                    start = mid + 1;
                }
                else
                {
                    end = mid - 1;
                }
            }

            return start - 1;
        }
    }
}
