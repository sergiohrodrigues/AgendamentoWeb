using WebApi8_Scheduling.Dto.Scheduling;
using WebApi8_Scheduling.Models;

namespace WebApi8_Scheduling.Services.Scheduling
{
    public interface IServiceInterface
    {
        Task<ResponseModel<List<ServiceModel>>> GetAllServices();
        //Task<ResponseModel<ServiceModel>> CreateService(ServiceCreateDto service);
        //Task<ResponseModel<ServiceModel>> DeleteService(int idService);
    }
}
