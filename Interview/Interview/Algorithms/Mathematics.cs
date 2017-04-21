namespace Interview.Algorithms
{
    using System;

    public class Mathematics
    {
        // You have a total of n coins that you want to form in a staircase shape, where every k-th row must have exactly k coins.
        // Given n, find the total number of full staircase rows that can be formed.
        // n is a non-negative integer and fits within the range of a 32-bit signed integer.
        // sum = (x + 1) * x / 2
        // x = (-1 + sqrt(8 * n + 1)) / 2
        public int ArrangeCoins(int n)
        {
            return (int)((Math.Sqrt(1 + 8.0 * n) - 1) / 2);
        }

        // Given an integer n, return the number of trailing zeroes in n!.
        public int TrailingZeroesNlog5N(int n) // Time Limit Exceeded // Nlog5N
        {
            var count = 0;
            for (var i = 1; i <= n; i++)
            {
                var j = i;
                while (j % 5 == 0)
                {
                    count++;
                    j /= 5;
                }
            }

            return count;
        }

        // 1、 每隔5个，会产生一个0，比如 5， 10 ，15，20…… 
        // 2 、每隔 5×5 个会多产生出一个0，比如 25，50，75，100 ……
        // 3 、每隔 5×5×5 会多出一个0，比如125.
        public int TrailingZeroes(int n) // log5N
        {
            var count = 0;
            while (n > 0)
            {
                count += n / 5;
                n /= 5;
            }

            return count;
        }
    }
}
