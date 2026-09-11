using CaseFlow.Api.Contracts; // import API contract types
using Microsoft.AspNetCore.Mvc; // import ASP.NET Core MVC/Controller types and attributes

namespace CaseFlow.Api.Controllers; // declare namespace

[ApiController] // mark this class as an API controller and enable API-specific behaviors
[Route("api/health")] // define controller's base route
public sealed class HealthController : ControllerBase // define the controller class
{
    [HttpGet] // map this action to HTTP GET requests
    [ProducesResponseType<HealthResponse>(StatusCodes.Status200OK)] // document a 200 response with HealthResponse body
    public ActionResult<HealthResponse> Get() // define the GET actions and its return type
    {
        return Ok(new HealthResponse("Healthy")); // return HTTP 200 with a HealthResponse Body
    }
}
