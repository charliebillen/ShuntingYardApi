using Microsoft.AspNetCore.Mvc;

namespace ShuntingYard.Api.GetSolution;

[ApiController]
[Route("solutions/{calculation}")]
public class GetSolutionController : ControllerBase
{
    [HttpGet]
    public ActionResult<decimal> Get([FromRoute] string calculation)
    {
        return new OkObjectResult(999m);
    }
}

