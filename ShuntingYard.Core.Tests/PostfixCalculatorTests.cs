namespace ShuntingYard.Core.Tests;

public class PostfixCalculatorTests
{
    [Theory]
    [MemberData(nameof(TestData))]
    public void Solve_GivenPostfixCalculation_ReturnsTheResult(string[] calculation, decimal expected)
    {
        var actual = PostfixCalculator.Solve(calculation.Select(TokenFactory.TokenFrom));

        actual.Should().BeApproximately(expected, 3);
    }
    
    private static IEnumerable<object[]> TestData()
    {
        yield return new object[]
        {
            new[] { "1", "2", "+" },
            3
        };
        
        yield return new object[]
        {
            new[] { "1", "2", "3", "*", "+" },
            7
        };
        
        yield return new object[]
        {
            new[] { "1", "2", "*", "3", "/" },
            0.667
        };

        yield return new object[]
        {
            new[] { "1", "2", "+", "3", "*" },
            9
        };
        
        yield return new object[]
        {
            new[] { "1", "2", "+", "3", "4", "+", "*" },
            21
        };
    }
}
