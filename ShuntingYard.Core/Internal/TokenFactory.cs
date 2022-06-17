using ShuntingYard.Core.Internal.Tokens;

namespace ShuntingYard.Core.Internal;

internal static class TokenFactory
{
    private static readonly Token MultiplicationOperator = new MultiplicationOperator();
    private static readonly Token DivisionOperator = new DivisionOperator();
    private static readonly Token AdditionOperator = new AdditionOperator();
    private static readonly Token SubtractionOperator = new SubtractionOperator();
    private static readonly Token RightParen = new RightParen();
    private static readonly Token LeftParen = new LeftParen();
    
    public static Token TokenFrom(string input)
        => new Operand(decimal.Parse(input));

    public static Token TokenFrom(char input)
        => input switch
        {
            '*' => MultiplicationOperator,
            '/' => DivisionOperator,
            '+' => AdditionOperator,
            '-' => SubtractionOperator,
            ')' => RightParen,
            _ => LeftParen
        };
}
