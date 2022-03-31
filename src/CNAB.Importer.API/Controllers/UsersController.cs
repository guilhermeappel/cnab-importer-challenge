using CNAB.Importer.API.Application.InputModels;
using CNAB.Importer.API.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CNAB.Importer.API.Controllers;

public class UsersController : BaseController
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    [AllowAnonymous]
    [Route("authenticate")]
    public async Task<IActionResult> AuthenticateAsync([FromBody] UserAuthInputModel user)
    {
        var result = await _userService.AuthenticateAsync(user);

        return result.IsValid() ? Ok(result.Response) : CustomResponse(result);
    }

    [HttpPost]
    [AllowAnonymous]
    [Route("register")]
    [ActionName("NewUser")]
    public async Task<IActionResult> RegisterAsync([FromBody] UserRegisterInputModel inputUser)
    {
        var result = await _userService.RegisterAsync(inputUser);

        return result.IsValid() ? CreatedAtAction("NewUser", new { id = result.Response }) : CustomResponse(result);
    }
}