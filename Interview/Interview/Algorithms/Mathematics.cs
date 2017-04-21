namespace Interview.Algorithms
{
    using System;
    using System.Text;

    using SysArray = System.Array;

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

        // Given two binary strings, return their sum(also a binary string).
        // For example,
        // a = "11"
        // b = "1"
        // Return "100".
        public string AddBinary(string a, string b)
        {
            if (string.IsNullOrEmpty(a) || string.IsNullOrEmpty(b))
            {
                return null;
            }

            var carry = 0;
            var sb = new StringBuilder();
            int ia = a.Length - 1, ib = b.Length - 1;
            while (ia >= 0 || ib >= 0)
            {
                if (ia >= 0)
                {
                    carry += a[ia] - '0';
                    ia--;
                }
                if (ib >= 0)
                {
                    carry += a[ib] - '0';
                    ib--;
                }
                sb.Append(carry % 2);
                carry /= 2;
            }

            if (carry == 1)
            {
                sb.Append(1);
            }

            var charArray = sb.ToString().ToCharArray();
            SysArray.Reverse(charArray);

            return new string(charArray);
        }

        // Given two non-negative integers num1 and num2 represented as string, return the sum of num1 and num2.
        // Note:
        // The length of both num1 and num2 is < 5100.
        // Both num1 and num2 contains only digits 0-9.
        // Both num1 and num2 does not contain any leading zero.
        public string AddDecimal(string num1, string num2)
        {
            if (string.IsNullOrEmpty(num1) || string.IsNullOrEmpty(num2))
            {
                return null;
            }

            var carry = 0;
            var sb = new StringBuilder();
            int i1 = num1.Length - 1, i2 = num2.Length - 1;
            while (i1 >= 0 || i2 >= 0)
            {
                if (i1 >= 0)
                {
                    carry += num1[i1] - '0';
                    i1--;
                }
                if (i2 >= 0)
                {
                    carry += num2[i2] - '0';
                    i2--;
                }

                sb.Append(carry % 10);
                carry /= 10;
            }

            if (carry == 1)
            {
                sb.Append(1);
            }

            var charArray = sb.ToString().ToCharArray();
            SysArray.Reverse(charArray);

            return new string(charArray);
        }

        public int[] PlusOne(int[] digits)
        {
            if (digits == null || digits.Length == 0)
            {
                return digits;
            }

            var carry = 1;
            for (var i = digits.Length - 1; i >= 0; i--)
            {
                carry += digits[i];
                digits[i] = carry % 10;
                carry /= 10;
                if (carry == 0)
                {
                    return digits;
                }
            }

            var result = new int[digits.Length + 1];
        }
    }
}
