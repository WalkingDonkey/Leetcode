namespace Interview.DataStructures
{
    using System.Collections.Generic;
    using System.Text;

    public class Stack
    {
        public int InfixCalculate(string s)
        {
            var result = 0;
            if (string.IsNullOrEmpty(s))
            {
                return result;
            }

            var num = 0;
            var sign = '+';
            var len = s.Length;
            var stack = new Stack<int>();
            for (var i = 0; i < len; i++)
            {
                var ch = s[i];
                if (char.IsDigit(ch))
                {
                    num = num * 10 + ch - '0';
                }
                if ((!char.IsDigit(ch) && ch != ' ') || i == len - 1)
                {
                    if (sign == '+')
                    {
                        stack.Push(num);
                    }
                    else if (sign == '-')
                    {
                        stack.Push(-num);
                    }
                    else if (sign == '*')
                    {
                        stack.Push(stack.Pop() * num);
                    }
                    else if (sign == '/')
                    {
                        stack.Push(stack.Pop() / num);
                    }

                    sign = ch;
                    num = 0;
                }
            }

            while (stack.Count > 0)
            {
                result += stack.Pop();
            }

            return result;
        }

        public int PostfixCalculate(string s)
        {
            var result = 0;
            if (string.IsNullOrEmpty(s))
            {
                return result;
            }

            var stack = new Stack<int>();
            var len = s.Length;
            int x, y;
            for (var i = 0; i < len; i++)
            {
                var ch = s[i];
                if (char.IsWhiteSpace(ch))
                {
                    continue;
                }
                switch (ch)
                {
                    case '+':
                        y = stack.Pop();
                        x = stack.Pop();
                        stack.Push(x + y);
                        break;

                    case '-':
                        y = stack.Pop();
                        x = stack.Pop();
                        stack.Push(x - y);
                        break;

                    case '*':
                        y = stack.Pop();
                        x = stack.Pop();
                        stack.Push(x * y);
                        break;

                    case '/':
                        y = stack.Pop();
                        x = stack.Pop();
                        stack.Push(x / y);
                        break;

                    default:
                        var sb = new StringBuilder();
                        var num = 0;
                        while (char.IsDigit(ch))
                        {
                            num = num * 10 + ch - '0';
                            ch = s[++i];
                        }
                        i--;
                        stack.Push(num);
                        break;
                }
            }

            return stack.Peek();
        }
    }
}
