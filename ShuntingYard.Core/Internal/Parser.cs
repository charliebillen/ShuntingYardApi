using ShuntingYard.Core.Internal.Tokens;

namespace ShuntingYard.Core.Internal;

internal static class Parser
{
    public static IEnumerable<Token> Parse(IEnumerable<Token> input)
    {
        var stack = new Stack<Token>();

        foreach (var token in input)
        {
            switch (token)
            {
                case Operator:
                    while (stack.Any() && token <= stack.Peek())
                    {
                        yield return stack.Pop();
                    }
                    stack.Push(token);
                    break;

                case LeftParen:
                    stack.Push(token);
                    break;

                case RightParen:
                    while (stack.Peek() is not LeftParen)
                    {
                        yield return stack.Pop();
                    }
                    stack.Pop();
                    break;

                default:
                    yield return token;
                    break;
            }
        }

        foreach (var op in stack)
        {
            yield return op;
        }
    }
}