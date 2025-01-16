using WebApi8_Scheduling.Dto.User;
using WebApi8_Scheduling.Models;

namespace WebApi8_Scheduling.Services.User
{
    public interface IEnterpriseInterface
    {
        Task<ResponseModel<EnterpriseModel>> CreateEnterprise(EnterpriseCreateDto enterprise);
        Task<ResponseModel<EnterpriseModel>> LoginEnterprise(EnterpriseLoginDto enterpriseLoginDto);
    }
}
