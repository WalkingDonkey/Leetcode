using System;

namespace Interview.DataStructures
{
    public class String
    {
        // Given a string, find the length of the longest substring without repeating characters.
        // Examples:
        // Given "abcabcbb", the answer is "abc", which the length is 3.
        // Given "bbbbb", the answer is "b", with the length of 1.
        // Given "pwwkew", the answer is "wke", with the length of 3. Note that the answer must be a substring, "pwke" is a subsequence and not a substring.

        public int LengthOfLongestSubstring(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return 0;
            }

            int start = 0, maxLength = 0;
            for (var i = 0; i < s.Length; i++)
            {
                if (s.Substring(start, i - start).IndexOf(s[i]) == -1)
                {
                    maxLength = Math.Max(maxLength, i - start + 1);
                }
                else
                {
                    // Moves left pointer to next position of the repeated character of s[i].
                    start += s.Substring(start, i - start).IndexOf(s[i]) + 1;
                }
            }

            return maxLength;
        }

        // Given a string s, find the longest palindromic substring in s.You may assume that the maximum length of s is 1000.
        // Example:
        // Input: "babad"
        // Output: "bab"
        // Note: "aba" is also a valid answer.
        // Example:
        // Input: "cbbd"
        // Output: "bb"
        public string LongestPalindromeBruce(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return s;
            }

            string longest = string.Empty;
            for (var i = 0; i < s.Length; i++)
            {
                for (var j = i; j < s.Length; j++)
                {
                    var temp = s.Substring(i, j - i + 1);
                    if(IsPalindrome(temp) && temp.Length > longest.Length)
                    {
                        longest = temp;
                    }
                }
            }

            return longest;
        }

        private bool IsPalindrome(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return true;
            }

            int start = 0, end = s.Length - 1;
            while (start <= end)
            {
                if (s[start++] != s[end--])
                {
                    return false;
                }
            }

            return true;
        }

        public string LongestPalindrome(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return s;
            }

            var longest = string.Empty;
            for (var i = 0; i < s.Length; i++)
            {
                // Gets palindrome with odd number characters
                var p = Palindrome(s, i, i);
                if (p.Length > longest.Length)
                {
                    longest = p;
                }

                // Gets palindrome with even number characters
                p = Palindrome(s, i, i + 1);
                if (p.Length > longest.Length)
                {
                    longest = p;
                }
            }

            return longest;
        }

        // longest palindrome using s[l] and s[r] as center
        private string Palindrome(string s, int l, int r)
        {
            while (l >= 0 && r < s.Length && s[l] == s[r])
            {
                l--;
                r++;
            }

            return s.Substring(l + 1, r - l - 1);
        }
    }
}
