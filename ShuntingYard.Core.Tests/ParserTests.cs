using ShuntingYard.Core.Tokens;

namespace ShuntingYard.Core.Tests;

public class ParserTests
{
    [Theory]
    [MemberData(nameof(TestData))]
    public void Parse_ConvertsInfixToPostfix(string[] input, string[] expected)
    {
        var actual = Parser.Parse(input.Select(Token.From));

        actual.Should().ContainInOrder(expected.Select(Token.From));
    }

    private static IEnumerable<object[]> TestData()
    {
        yield return new object[]
        {
            Array.Empty<string>(),
            Array.Empty<string>()
        };

        yield return new object[]
        {
            new[] { "1", "+", "2" },
            new[] { "1", "2", "+" }
        };
        
        yield return new object[]
        {
            new[] { "1", "+", "2", "*", "3" },
            new[] { "1", "2", "3", "*", "+" }
        };
        
        yield return new object[]
        {
            new[] { "1", "*", "2", "/", "3" },
            new[] { "1", "2", "*", "3", "/" }
        };

        yield return new object[]
        {
            new[] { "(", "1", "+", "2", ")", "*", "3" },
            new[] { "1", "2", "+", "3", "*" }
        };
        
        yield return new object[]
        {
            new[] { "(", "1", "+", "2", ")", "*", "(", "3", "+", "4", ")" },
            new[] { "1", "2", "+", "3", "*" }
        };
    }
}