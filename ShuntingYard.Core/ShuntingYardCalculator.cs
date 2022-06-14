using ShuntingYard.Core.Internal;

namespace ShuntingYard.Core;

public class ShuntingYardShuntingYardCalculator : IShuntingYardCalculator
{
    public decimal Solve(string calculation)
    {
        var infixTokens = Tokeniser.Tokenise(calculation);
        var postfixTokens = Parser.Parse(infixTokens);
        return PostfixCalculator.Solve(postfixTokens);
    }
}

public interface IShuntingYardCalculator
{
    decimal Solve(string calculation);
}