namespace Interview.Algorithms
{
    using System.Collections.Generic;

    public class Backtracking
    {
        // Given n pairs of parentheses, write a function to generate all combinations of well-formed parentheses.
        // For example, given n = 3, a solution set is:
        //        [
        //          "((()))",
        //          "(()())",
        //          "(())()",
        //          "()(())",
        //          "()()()"
        //]
        public IList<string> GenerateParenthesis(int n)
        {
            var parenthesisSet = new List<string>();
            GenerateParenthesisCore(n, 0, 0, string.Empty, parenthesisSet);
            return parenthesisSet;
        }

        private void GenerateParenthesisCore(int n, int left, int right, string s, IList<string> parenthesisSet)
        {
            if (left < right)
            {
                return;
            }

            if (left == n && right == n)
            {
                parenthesisSet.Add(s);
                return;
            }

            if (left < n)
            {
                GenerateParenthesisCore(n, left + 1, right, s + "(", parenthesisSet);
            }

            if (right < n)
            {
                GenerateParenthesisCore(n, left, right + 1, s + ")", parenthesisSet);
            }
        }
    }
}
