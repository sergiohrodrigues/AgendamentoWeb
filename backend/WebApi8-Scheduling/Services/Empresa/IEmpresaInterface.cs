using WebApi8_Scheduling.Dto.User;
using WebApi8_Scheduling.Models;

namespace WebApi8_Scheduling.Services.Empresa
{
    public interface IEmpresaInterface
    {
        Task<ResponseModel<EmpresaModel>> CreateEnterprise(EnterpriseCreateDto enterprise);
        Task<ResponseModel<EmpresaModel>> LoginEnterprise(EnterpriseLoginDto enterpriseLoginDto);
    }
}
