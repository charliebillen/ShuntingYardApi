using Microsoft.AspNetCore.Mvc;
using ShuntingYard.Core;

namespace ShuntingYard.Api.GetSolution;

[ApiController]
public class GetSolutionController : ControllerBase
{
    private readonly IShuntingYardCalculator _calculator;
    private readonly ILogger<GetSolutionController> _logger;

    public GetSolutionController(
        IShuntingYardCalculator calculator,
        ILogger<GetSolutionController> logger)
    {
        _calculator = calculator;
        _logger = logger;
    }

    [HttpGet]
    [Route("solutions/{*calculation}")]
    public ActionResult<decimal> Get([FromRoute] string calculation)
    {
        _logger.LogInformation("Calculating solution for {Calculation}", calculation);

        var solution = _calculator.Solve(calculation);

        return new OkObjectResult(solution);
    }
}

