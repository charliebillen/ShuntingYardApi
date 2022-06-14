using ShuntingYard.Core.Internal;

namespace ShuntingYard.Core;

public class ShuntingYardCalculator : IShuntingYardCalculator
{
    public decimal Solve(string calculation)
    {
        if (string.IsNullOrWhiteSpace(calculation))
        {
            throw new ArgumentException("Must have a value", nameof(calculation));
        }

        var infixTokens = Tokeniser.Tokenise(calculation);
        var postfixTokens = Parser.Parse(infixTokens);
        return PostfixCalculator.Solve(postfixTokens);
    }
}

public interface IShuntingYardCalculator
{
    decimal Solve(string calculation);
}