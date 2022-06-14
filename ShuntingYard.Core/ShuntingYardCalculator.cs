namespace ShuntingYard.Core;

public class ShuntingYardCalculator : ICalculator
{
    public decimal Solve(string calculation)
    {
        var infixTokens = Tokeniser.Tokenise(calculation);
        var postfixTokens = Parser.Parse(infixTokens);
        return PostfixCalculator.Solve(postfixTokens);
    }
}

public interface ICalculator
{
    decimal Solve(string calculation);
}