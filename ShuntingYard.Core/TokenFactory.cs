using ShuntingYard.Core.Tokens;

namespace ShuntingYard.Core;

public static class TokenFactory
{
    public static Token TokenFrom(string input) =>
        input switch
        {
            "*" => new MultiplicationOperator(input),
            "/" => new DivisionOperator(input),
            "+" => new AdditionOperator(input),
            "-" => new SubtractionOperator(input),
            ")" => new RightParen(input),
            "(" => new LeftParen(input),
            _ => new Operand(input)
        };
}