using ShuntingYard.Core.Internal.Tokens;

namespace ShuntingYard.Core.Internal;

internal static class TokenFactory
{
    public static Token TokenFrom(string input) =>
        input switch
        {
            "*" => new MultiplicationOperator(),
            "/" => new DivisionOperator(),
            "+" => new AdditionOperator(),
            "-" => new SubtractionOperator(),
            ")" => new RightParen(),
            "(" => new LeftParen(),
            _ => new Operand(decimal.Parse(input))
        };
}