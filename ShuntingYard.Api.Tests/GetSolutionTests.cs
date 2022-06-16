namespace ShuntingYard.Api.Tests;

public class GetSolutionTests
{
    private readonly HttpClient _client;

    public GetSolutionTests()
    {
        var application = new WebApplicationFactory<Program>();

        _client = application.CreateClient();
    }

    [Theory]
    [InlineData("0", 0)]
    [InlineData("1+2", 3)]
    [InlineData("1-2", -1)]
    [InlineData("1+2*3", 7)]
    [InlineData("1*2/3", 0.667)]
    [InlineData("(1+2)*3", 9)]
    [InlineData("(1+2)*(3+4)", 21)]
    [InlineData("(10*(1+3)+4)/2", 22)]
    [InlineData("100+200", 300)]
    [InlineData("10*2.5", 25)]
    [InlineData("3/1.5", 2)]
    [InlineData("(1+2.5)*(3+4)", 24.5)]
    public async Task Get_ReturnsOkResponseWithSolution(string calculation, decimal expected)
    {
        var encodedCalculation = Uri.EscapeDataString(calculation);

        var response = await _client.GetAsync($"solutions/{encodedCalculation}");
        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var solution = await response.Content.ReadAsStringAsync();
        decimal.Parse(solution).Should().BeApproximately(expected, 3);
    }
}
