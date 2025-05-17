using Microsoft.AspNetCore.Mvc;
using WebApi8_Scheduling.Dto.Client;
using WebApi8_Scheduling.Dto.User;
using WebApi8_Scheduling.Models;
using WebApi8_Scheduling.Services.User;

namespace WebApi8_Scheduling.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }
    
    [HttpPost]
    public async Task<ActionResult<ResponseModel<UserModel>>> CreateUser(UserCreateDto pUser)
    {
        var user = await _userService.CreateUser(pUser);
        return Ok(user);
    }
    
    [HttpPost("login")]
    public async Task<ActionResult<ResponseModel<UserModel>>> Login(LoginDto pUser)
    {
        var user = await _userService.Login(pUser);
        return Ok(user);
    }
}