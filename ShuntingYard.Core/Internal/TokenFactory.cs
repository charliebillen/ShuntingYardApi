using ShuntingYard.Core.Internal.Tokens;

namespace ShuntingYard.Core.Internal;

internal static class TokenFactory
{
    public static Token TokenFrom(string input)
        => new Operand(decimal.Parse(input));

    public static Token TokenFrom(char input)
        => input switch
        {
            '*' => new MultiplicationOperator(),
            '/' => new DivisionOperator(),
            '+' => new AdditionOperator(),
            '-' => new SubtractionOperator(),
            ')' => new RightParen(),
            _ => new LeftParen()
        };
}