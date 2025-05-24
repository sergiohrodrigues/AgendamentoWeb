using WebApi8_Scheduling.Dto.Service;
using WebApi8_Scheduling.Models;

namespace WebApi8_Scheduling.Services.Servico
{
    public interface IServicoInterface
    {
        Task<ResponseModel<ServicoModel>> CreateService(CriarServicoDto pService);
        //Task<ResponseModel<ServiceModel>> DeleteService(int idService);
    }
}
