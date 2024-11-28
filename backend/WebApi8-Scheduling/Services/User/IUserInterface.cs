using WebApi8_Scheduling.Dto.User;
using WebApi8_Scheduling.Models;

namespace WebApi8_Scheduling.Services.User
{
    public interface IUserInterface
    {
        Task<ResponseModel<UserModel>> CreateUser(UserCreateDto user);
    }
}
