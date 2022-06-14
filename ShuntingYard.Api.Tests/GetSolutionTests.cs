namespace ShuntingYard.Api.Tests;

public class GetSolutionTests
{
    private readonly HttpClient _client;

    public GetSolutionTests()
    {
        var application = new WebApplicationFactory<Program>();

        _client = application.CreateClient();
    }

    [Fact]
    public async Task Get_ReturnsOkResponseWithSolution()
    {
        var response = await _client.GetAsync("solutions/(1+2)*(3+4)");
        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var solution = await response.Content.ReadAsStringAsync();
        decimal.Parse(solution).Should().Be(21);
    }
}
