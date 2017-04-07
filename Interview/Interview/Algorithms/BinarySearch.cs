namespace Interview.Algorithms
{
    public class BinarySearch
    {
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
