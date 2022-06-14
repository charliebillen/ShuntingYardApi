namespace ShuntingYard.Core.Tests;

public class TokeniserTests
{
    [Theory]
    [MemberData(nameof(TestData))]
    public void Tokenise_ReturnsTokensFromString(string input, string[] expected)
    {
        var actual = Tokeniser.Tokenise(input);
        
        actual.Should().ContainInOrder(expected.Select(TokenFactory.TokenFrom));
    }

    private static IEnumerable<object[]> TestData()
    {
        yield return new object[]
        {
            string.Empty,
            Array.Empty<string>()
        };

        yield return new object[]
        {
            "1",
            new[] { "1" }
        };

        yield return new object[]
        {
            "1+2",
            new[] { "1", "+", "2" }
        };
        
        yield return new object[]
        {
            "(12-3*19)/8+0",
            new[] { "(", "12", "-", "3", "*", "19", ")", "/", "8", "+", "0" }
        };
    }
}
