namespace Interview.Algorithms
{
    using System;
    using System.Linq;

    public class DynamicProgramming
    {
        // Three types of coins: 1, 3 ,5
        public int CoinChange(int amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException("n should not be less than zero.");
            }

            var count = new int[amount + 1];
            count[0] = 0;

            for (var i = 1; i <= amount; i++)
            {
                if(i < 3)
                {
                    count[i] = count[i - 1] + 1;
                }
                if (i >= 5)
                {
                    count[i] = Math.Min(Math.Min(count[i - 1], count[i - 3]), count[i - 5]) + 1;
                }
                else if (i >= 3)
                {
                    count[i] = Math.Min(count[i - 1], count[i - 3]) + 1;
                }
                else
                {
                    count[i] = count[i - 1] + 1;
                }
            }

            return count[amount];
        }

        public int CoinChange(int[] coins, int amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException("n should not be less than zero.");
            }

            var count = Enumerable.Repeat(amount + 1, amount + 1).ToArray();
            count[0] = 0;

            for (var i = 1; i <= amount; i++)
            {
                for (var j = 0; j < coins.Length; j++)
                {
                    if (i >= coins[j])
                    {
                        count[i] = Math.Min(count[i], count[i - coins[j]] + 1);
                    }
                }
            }

            return count[amount] > amount ? -1 : count[amount];
        }

        public int FibonacciBottomUp(int n)
        {
            int[] fib = new int[n + 1];
            fib[0] = 0;
            fib[1] = 1;
            for (int i = 2; i < n + 1; i++)
            {
                fib[i] = fib[i - 1] + fib[i - 2];
            }

            return fib[n];
        }

        public int FibonacciTopDown(int n)
        {
            int[] fib = new int[n + 1];
            if (n <= 1)
            {
                return n;
            }

            if (fib[n] != 0)
            {
                return fib[n];
            }
            else
            {
                fib[n] = FibonacciTopDown(n - 1) + FibonacciTopDown(n - 2);
                return fib[n];
            }
        }

        public int LongestIncreasingSubsequence(int[] array, int n)
        {
            int[] length = new int[n];
            int maxLength = 1;
            for (int i = 0; i < n; i++)
            {
                length[i] = 1;
                for (int j = 0; j < i; j++)
                {
                    if (array[i] >= array[j] && array[j] + 1 > array[i])
                    {
                        array[i] = array[j] + 1;
                    }
                }

                if (array[i] > maxLength)
                {
                    maxLength = array[i];
                }
            }

            return maxLength;
        }

        public int MaxApples(int[,] apples, int row, int column)
        {
            int[,] maxApples = new int[row, column];
            for (int i = 0; i < row; i++)
            {
                maxApples[i, 0] = apples[i, 0];
            }

            for (int j = 0; j < column; j++)
            {
                maxApples[0, j] = apples[0, j];
            }

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    maxApples[i, j] = apples[i, j] + Math.Max(maxApples[i - 1, j], maxApples[i, j - 1]);
                }
            }

            return maxApples[row - 1, column - 1];
        }
    }
}
