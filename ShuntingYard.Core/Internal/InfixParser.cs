using ShuntingYard.Core.Internal.Tokens;

namespace ShuntingYard.Core.Internal;

internal static class InfixParser
{
    public static IEnumerable<Token> Parse(IEnumerable<Token> input)
    {
        var operandsAndParens = new Stack<Token>();

        foreach (var token in input)
        {
            switch (token)
            {
                case Operator:
                    while (operandsAndParens.Any() && token <= operandsAndParens.Peek())
                    {
                        yield return operandsAndParens.Pop();
                    }
                    operandsAndParens.Push(token);
                    break;

                case LeftParen:
                    operandsAndParens.Push(token);
                    break;

                case RightParen:
                    while (operandsAndParens.Peek() is not LeftParen)
                    {
                        yield return operandsAndParens.Pop();
                    }
                    operandsAndParens.Pop();
                    break;

                default:
                    yield return token;
                    break;
            }
        }

        foreach (var op in operandsAndParens)
        {
            yield return op;
        }
    }
}