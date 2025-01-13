using WebApi8_Scheduling.Dto.Scheduling;
using WebApi8_Scheduling.Models;

namespace WebApi8_Scheduling.Services.Scheduling
{
    public interface ISchedulingInterface
    {
        Task<ResponseModel<List<SchedulingModel>>> GetAllSchedulings(int UserId);
        Task<ResponseModel<SchedulingModel>> CreateSheduling(SchedulingCreateDto scheduling);
        Task<ResponseModel<SchedulingModel>> DeleteScheduling(int idScheduling);
    }
}
