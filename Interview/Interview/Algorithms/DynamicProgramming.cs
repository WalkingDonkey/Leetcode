namespace Interview.Algorithms
{
    using System;

    public class DynamicProgramming
    {
        // Three types of coins: 1, 3 ,5
        public int CoinChange(int amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException("n should not be less than zero.");
            }

            var predefinedCount = new int[] { 0, 1, 2, 1, 2, 1 };
            if (amount <= 5)
            {
                return predefinedCount[amount];
            }

            return Math.Min(Math.Min(CoinChange(amount - 1) + 1, CoinChange(amount - 3) + 1), CoinChange(amount - 5) + 1);
        }

        public int CoinChange(int[] coins, int amount)
        {
            return 0;
        }
    }
}
