namespace Interview.Algorithms
{
    using System;

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

        //Divide two integers without using multiplication, division and mod operator.
        //If it is overflow, return MAX_INT.
        public int Divide(int dividend, int divisor)
        {
            var isNegative = false;
            if ((dividend < 0 && divisor > 0) || (dividend > 0 && divisor < 0))
            {
                isNegative = true;
            }

            var lDividend = Math.Abs((long)dividend);
            var lDivisor = Math.Abs((long)divisor);
            if (lDivisor == 0)
            {
                return int.MaxValue;
            }

            if (lDividend < lDivisor)
            {
                return 0;
            }

            var lResult = LDivide(lDividend, lDivisor);
            int result;
            if (lResult > int.MaxValue)
            {
                result = isNegative ? int.MinValue : int.MaxValue;
            }
            else
            {
                result = isNegative ? (int)(-1 * lResult) : (int)lResult;
            }

            return result;
        }

        private long LDivide(long lDividend, long lDivisor)
        {
            if (lDividend < lDivisor)
            {
                return 0;
            }

            var sum = lDivisor;
            var multiple = 1;
            while (sum + sum < lDividend)
            {
                sum += sum;
                multiple += multiple;
            }

            return multiple + LDivide(lDividend - sum, lDivisor);
        }
    }
}
