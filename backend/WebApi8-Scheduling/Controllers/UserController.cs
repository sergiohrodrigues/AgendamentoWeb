using Microsoft.AspNetCore.Mvc;
using WebApi8_Scheduling.Dto.User;
using WebApi8_Scheduling.Models;
using WebApi8_Scheduling.Services.User;

namespace WebApi8_Scheduling.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserInterface _userInterface;

        public UserController(IUserInterface userInterface)
        {
            _userInterface = userInterface;
        }

        [HttpPost("CreateUser")]
        public async Task<ActionResult<ResponseModel<UserModel>>> CreateUser(UserCreateDto user)
        {
            var newUser = await _userInterface.CreateUser(user);
            return Ok(newUser);
        }


    }
}
