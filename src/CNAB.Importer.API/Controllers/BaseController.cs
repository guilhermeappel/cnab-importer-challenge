using CNAB.Importer.API.Infrastructure.Application;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CNAB.Importer.API.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class BaseController : ControllerBase
{
    protected ActionResult CustomResponse(BaseResult baseResult)
    {
        if (baseResult.Errors.Any())
        {
            return new BadRequestObjectResult(new
            {
                Title = "Bad Request",
                Status = 400,
                Errors = baseResult.Errors
            });
        }

        return Ok(baseResult);
    }
}