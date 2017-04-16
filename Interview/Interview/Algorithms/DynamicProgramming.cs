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
    }
}
