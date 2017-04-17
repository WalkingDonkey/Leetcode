namespace Interview.Algorithms
{
    using System.Collections;

    public class StackUtilities
    {
        public int Calculate(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return 0;
            }

            Stack stack = new Stack();
            int num = 0;
            char sign = '+';
            for (int i = 0; i < s.Length; i++)
            {
                if (char.IsDigit(s[i]))
                {
                    num = num * 10 + s[i] - '0';
                }
                if ((!char.IsDigit(s[i]) && ' ' != s[i]) || i == s.Length - 1)
                {
                    if (sign == '-')
                    {
                        stack.Push(-num);
                    }
                    if (sign == '+')
                    {
                        stack.Push(num);
                    }
                    if (sign == '*')
                    {
                        stack.Push((int)stack.Pop() * num);
                    }
                    if (sign == '/')
                    {
                        stack.Push((int)stack.Pop() / num);
                    }
                    sign = s[i];
                    num = 0;
                }
            }

            int re = 0;
            while (stack.Count > 0)
            {
                re += (int)stack.Pop();
            }

            return re;
        }
    }
}
