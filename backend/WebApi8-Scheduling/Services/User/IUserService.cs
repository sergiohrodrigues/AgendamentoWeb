using WebApi8_Scheduling.Dto.Client;
using WebApi8_Scheduling.Dto.User;
using WebApi8_Scheduling.Models;

namespace WebApi8_Scheduling.Services.User;

public interface IUserService
{
    Task<ResponseModel<UserModel>> CreateUser(UserCreateDto pUser);
    Task<ResponseModel<UserModel>> Login(LoginDto pUser);
}